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
        }

        private void LoadCurrencies()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id, abbreviation, name FROM Currency";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                bool firstItem = true;
                while (reader.Read())
                {
                    var currencyItem = new CurrencyItem
                    {
                        Id = reader.GetInt32(0),
                        Abbreviation = reader.GetString(1),
                        Name = reader.GetString(2)
                    };

                    cbInitialCurrency.Items.Add(currencyItem);
                    cbTargetCurrency.Items.Add(currencyItem);

                    if (firstItem)
                    {
                        cbInitialCurrency.SelectedItem = currencyItem;
                        cbTargetCurrency.SelectedIndex = cbTargetCurrency.Items.Count > 1 ? 1 : 0;
                        firstItem = false;
                    }
                }
                reader.Close();
            }

            // Update labels after initial load
            UpdateLabels();
        }

        private void LoadPeriods()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id, name FROM Period";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                bool firstItem = true;
                while (reader.Read())
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

        private void cbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            if (cbInitialCurrency.SelectedItem != null && cbTargetCurrency.SelectedItem != null)
            {
                var initialCurrency = cbInitialCurrency.SelectedItem as CurrencyItem;
                var targetCurrency = cbTargetCurrency.SelectedItem as CurrencyItem;

                if (initialCurrency != null && targetCurrency != null)
                {
                    lblAmount.Text = initialCurrency.Name;
                    lblConverted.Text = targetCurrency.Name;
                }
            }
        }

        private string ConvertCurrency(CurrencyItem originCurrency, CurrencyItem targetCurrency)
        {
            if (originCurrency == null || targetCurrency == null ||
                cbPeriod.SelectedItem == null || string.IsNullOrEmpty(txtAmount.Text))
            {
                return string.Empty; // Reset field hasil jika input tidak lengkap
            }

            var period = cbPeriod.SelectedItem as PeriodItem;

            if (period == null)
            {
                return string.Empty; // Reset field hasil jika input tidak valid
            }

            if (originCurrency.Id == targetCurrency.Id)
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


        private decimal GetCrossRate(int originCurrencyId, int targetCurrencyId, int periodId)
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
            string query = "SELECT rate FROM USDExchangeRate WHERE currency_id = @currencyId AND period_id = @periodId";
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

        public class CurrencyItem
        {
            public int Id { get; set; }
            public string Abbreviation { get; set; }
            public string Name { get; internal set; }

            public override string ToString()
            {
                return Abbreviation;
            }
        }

        public class PeriodItem
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        private void cbInitialCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void cbTargetCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLabels();

        }
    }
}