using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CurrencyConverter
{
    public partial class currencyConverterForm : Form
    {
        /** Connection Database **/
        private string connectionString = "Data Source=MIFDAL\\SQLEXPRESS;Initial Catalog=CurrencyConverter;Integrated Security=True";

        public currencyConverterForm()
        {
            InitializeComponent();
            LoadCurrencies();
            LoadPeriods();
            txtAmount.TextChanged += txtAmount_TextChanged;
        }

        public class CurrencyItem // Class untuk menyimpan data mata uang yang dipilih oleh pengguna
        {
            public int Id { get; set; }
            public string Abbreviation { get; set; }
            public string Name { get; internal set; }

            public override string ToString()
            {
                return Abbreviation;
            }
        }

        public class PeriodItem // Class untuk menyimpan data periode yang dipilih oleh pengguna
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        private void LoadPeriods()
        {
            using (SqlConnection conn = new SqlConnection(connectionString)) // Menggunakan blok using untuk memastikan koneksi ditutup setelah selesai
            {
                conn.Open();
                string query = "SELECT id, name FROM Period"; // Query untuk mendapatkan data periode
                SqlCommand cmd = new SqlCommand(query, conn); // Membuat objek SqlCommand untuk menjalankan query
                SqlDataReader reader = cmd.ExecuteReader(); // Membaca hasil query
                bool firstItem = true; // Flag untuk menandai item pertama
                while (reader.Read()) // Loop untuk membaca setiap baris hasil query
                {
                    var periodItem = new PeriodItem
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    };

                    cbPeriod.Items.Add(periodItem);

                    if (firstItem)
                    {
                        cbPeriod.SelectedItem = periodItem;
                        firstItem = false;
                    }
                }
                reader.Close();
            }
        }

        private void UpdateLabels() // Method untuk mengupdate label mata uang asal dan tujuan
        {
            if (cbInitialCurrency.SelectedItem != null && cbTargetCurrency.SelectedItem != null) // Cek apakah item mata uang asal dan tujuan sudah dipilih
            {
                var initialCurrency = cbInitialCurrency.SelectedItem as CurrencyItem; // Buat variabel untuk menyimpan item mata uang asal
                var targetCurrency = cbTargetCurrency.SelectedItem as CurrencyItem; // Buat variabel untuk menyimpan item mata uang tujuan

                if (initialCurrency != null && targetCurrency != null) // Cek apakah item mata uang asal dan tujuan tidak null
                {
                    lblAmount.Text = initialCurrency.Name; // Set label mata uang asal (Name adalah nama mata uang)
                    lblConverted.Text = targetCurrency.Name; // Set label mata uang tujuan
                }
            }
        }

        private void LoadCurrencies()
        {
            using (SqlConnection conn = new SqlConnection(connectionString)) // Menggunakan blok using untuk memastikan koneksi ditutup setelah selesai
            {
                conn.Open();
                string query = "SELECT id, abbreviation, name FROM Currency"; // Query untuk mendapatkan data mata uang
                SqlCommand cmd = new SqlCommand(query, conn); // Membuat objek SqlCommand untuk menjalankan query
                SqlDataReader reader = cmd.ExecuteReader(); // Membaca hasil query
                bool firstItem = true; // Flag untuk menandai item pertama (Flag digunakan untuk menentukan item mana yang dipilih pertama kali)
                while (reader.Read()) // Loop untuk membaca setiap baris hasil query
                {
                    var currencyItem = new CurrencyItem // Membuat objek CurrencyItem untuk menyimpan data mata uang
                    {
                        Id = reader.GetInt32(0), // Mengambil data id mata uang 
                        Abbreviation = reader.GetString(1), // Mengambil data singkatan mata uang
                        Name = reader.GetString(2) // Mengambil data nama mata uang
                    };

                    cbInitialCurrency.Items.Add(currencyItem); // Menambahkan item mata uang ke combobox origin
                    cbTargetCurrency.Items.Add(currencyItem); // Menambahkan item mata uang ke combobox target, tujuan convert

                    if (firstItem) // Jika item pertama, maka pilih item tersebut
                    {
                        cbInitialCurrency.SelectedItem = currencyItem; // Pilih item mata uang asal
                        cbTargetCurrency.SelectedIndex = cbTargetCurrency.Items.Count > 1 ? 1 : 0; // Pilih item mata uang tujuan
                        firstItem = false; // Set flag item pertama menjadi false
                    }
                }
                reader.Close();
            }

            // Update labels after initial load
            UpdateLabels();
        }


        private void cbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void cbInitialCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            // Simpan mata uang yang dipilih saat ini
            var initialCurrency = cbInitialCurrency.SelectedItem as CurrencyItem;
            var targetCurrency = cbTargetCurrency.SelectedItem as CurrencyItem;

            // Menukar nilai mata uang asal dan tujuan dalam 
            var tempCurrency = initialCurrency;
            initialCurrency = targetCurrency;
            targetCurrency = tempCurrency;

            // Hitung ulang hasil konversi dengan pasangan mata uang yang baru
            txtConverted.Text = ConvertCurrency(initialCurrency, targetCurrency);
        }


        private string ConvertCurrency(CurrencyItem originCurrency, CurrencyItem targetCurrency)
        {
            if (originCurrency == null || targetCurrency == null ||
                cbPeriod.SelectedItem == null || string.IsNullOrEmpty(txtAmount.Text)) // Cek apakah input sudah lengkap
            {
                return string.Empty; // Reset field hasil jika input tidak lengkap
            }

            var period = cbPeriod.SelectedItem as PeriodItem; // Ambil item periode yang dipilih

            if (period == null) // Cek apakah item periode tidak null
            {
                return string.Empty; // Reset field hasil jika input tidak valid
            }

            if (originCurrency.Id == targetCurrency.Id) // Cek apakah mata uang asal sama dengan tujuan
            {
                return txtAmount.Text; // Jika mata uang asal sama dengan tujuan, hasil sama dengan input
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal originAmount))
            {
                return string.Empty; // Reset field hasil jika jumlah tidak valid
            }

            decimal crossRate = GetCrossRate(originCurrency.Id, targetCurrency.Id, period.Id);
            decimal result = originAmount * crossRate;

            return result.ToString("F3"); // Menggunakan format string untuk hasil dengan tiga desimal
        }


        private decimal GetCrossRate(int originCurrencyId, int targetCurrencyId, int periodId) // Method untuk mendapatkan nilai tukar mata uang  (Private Decimal adalah tipe data yang digunakan untuk menyimpan nilai tukar)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Dapatkan nilai tukar mata uang asal terhadap USD
                decimal originToUSD = GetExchangeRate(originCurrencyId, periodId, conn);

                // Dapatkan nilai tukar mata uang target terhadap USD
                decimal targetToUSD = GetExchangeRate(targetCurrencyId, periodId, conn);

                // Hitung cross-exchange rate
                if (targetToUSD != 0)
                {
                    decimal crossRate = originToUSD / targetToUSD;

                    // Bulatkan hasil ke tiga desimal
                    //crossRate = Math.Round(crossRate, 3);

                    // Jika hasil adalah 1.000, kembalikan 1
                    //if (crossRate == 1.000m)
                    //{
                    //  return 1m;
                    //}

                    return crossRate;
                }
                else
                {
                    // Handle division by zero or invalid rates
                    return 0;
                }
            }
        }

        private decimal GetExchangeRate(int currencyId, int periodId, SqlConnection conn)
        {
            string query = "SELECT rate FROM USDExchangeRate WHERE currency_id = @currencyId AND period_id = @periodId"; // Query untuk mendapatkan nilai tukar mata uang terhadap USD
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@currencyId", currencyId);
            cmd.Parameters.AddWithValue("@periodId", periodId);

            object result = cmd.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                return Convert.ToDecimal(result);
            }
            else
            {
                // Return 0 or handle null value appropriately
                return 0;
            }
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            if (cbInitialCurrency.SelectedItem != null && cbTargetCurrency.SelectedItem != null)
            {
                // Simpan item terpilih sementara
                var initialSelectedItem = cbInitialCurrency.SelectedItem;
                var targetSelectedItem = cbTargetCurrency.SelectedItem;

                var initialCurrency = cbInitialCurrency.SelectedItem as CurrencyItem;
                var targetCurrency = cbTargetCurrency.SelectedItem as CurrencyItem;

                // Simpan indeks terpilih sementara
                int initialSelectedIndex = cbInitialCurrency.SelectedIndex;
                int targetSelectedIndex = cbTargetCurrency.SelectedIndex;

                // Menukar indeks terpilih antara ComboBox
                cbInitialCurrency.SelectedIndex = targetSelectedIndex;
                cbTargetCurrency.SelectedIndex = initialSelectedIndex;

                txtAmount.Text = txtConverted.Text;

                // Recalculate the conversion
                ConvertCurrency(initialCurrency, targetCurrency);
            }
        }

        private void cbTargetCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLabels();

        }
    }
}