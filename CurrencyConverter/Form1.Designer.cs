namespace CurrencyConverter
{
    partial class currencyConverterForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblPeriod = new Label();
            btnSwap = new Button();
            gbOriginAmount = new GroupBox();
            txtAmount = new TextBox();
            lblAmount = new Label();
            cbInitialCurrency = new ComboBox();
            lblConverted = new Label();
            txtConverted = new TextBox();
            cbTargetCurrency = new ComboBox();
            gbConvertedTo = new GroupBox();
            cbPeriod = new ComboBox();
            gbOriginAmount.SuspendLayout();
            gbConvertedTo.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(259, 65);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(284, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Currency Converter";
            // 
            // lblPeriod
            // 
            lblPeriod.AutoSize = true;
            lblPeriod.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPeriod.Location = new Point(75, 151);
            lblPeriod.Name = "lblPeriod";
            lblPeriod.Size = new Size(68, 28);
            lblPeriod.TabIndex = 1;
            lblPeriod.Text = "Period";
            // 
            // btnSwap
            // 
            btnSwap.Image = Properties.Resources.exchange_1;
            btnSwap.Location = new Point(340, 265);
            btnSwap.Name = "btnSwap";
            btnSwap.Size = new Size(94, 60);
            btnSwap.TabIndex = 5;
            btnSwap.UseVisualStyleBackColor = true;
            btnSwap.Click += btnSwap_Click;
            // 
            // gbOriginAmount
            // 
            gbOriginAmount.Controls.Add(txtAmount);
            gbOriginAmount.Controls.Add(lblAmount);
            gbOriginAmount.Location = new Point(75, 230);
            gbOriginAmount.Name = "gbOriginAmount";
            gbOriginAmount.Size = new Size(210, 125);
            gbOriginAmount.TabIndex = 6;
            gbOriginAmount.TabStop = false;
            gbOriginAmount.Text = "Origin Amount";
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(6, 68);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(125, 27);
            txtAmount.TabIndex = 1;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(6, 45);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(100, 20);
            lblAmount.TabIndex = 0;
            lblAmount.Text = "Select Region";
            // 
            // cbInitialCurrency
            // 
            cbInitialCurrency.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbInitialCurrency.FormattingEnabled = true;
            cbInitialCurrency.Location = new Point(212, 298);
            cbInitialCurrency.Name = "cbInitialCurrency";
            cbInitialCurrency.Size = new Size(67, 28);
            cbInitialCurrency.TabIndex = 8;
            cbInitialCurrency.SelectedIndexChanged += cbInitialCurrency_SelectedIndexChanged;
            // 
            // lblConverted
            // 
            lblConverted.AutoSize = true;
            lblConverted.Location = new Point(7, 45);
            lblConverted.Name = "lblConverted";
            lblConverted.Size = new Size(100, 20);
            lblConverted.TabIndex = 1;
            lblConverted.Text = "Select Region";
            // 
            // txtConverted
            // 
            txtConverted.BackColor = SystemColors.Control;
            txtConverted.BorderStyle = BorderStyle.FixedSingle;
            txtConverted.Enabled = false;
            txtConverted.ForeColor = SystemColors.ControlText;
            txtConverted.Location = new Point(7, 68);
            txtConverted.Name = "txtConverted";
            txtConverted.ReadOnly = true;
            txtConverted.Size = new Size(125, 27);
            txtConverted.TabIndex = 2;
            // 
            // cbTargetCurrency
            // 
            cbTargetCurrency.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbTargetCurrency.FormattingEnabled = true;
            cbTargetCurrency.Location = new Point(137, 68);
            cbTargetCurrency.Name = "cbTargetCurrency";
            cbTargetCurrency.Size = new Size(67, 28);
            cbTargetCurrency.TabIndex = 9;
            cbTargetCurrency.SelectedIndexChanged += cbTargetCurrency_SelectedIndexChanged;
            // 
            // gbConvertedTo
            // 
            gbConvertedTo.Controls.Add(cbTargetCurrency);
            gbConvertedTo.Controls.Add(txtConverted);
            gbConvertedTo.Controls.Add(lblConverted);
            gbConvertedTo.Location = new Point(486, 230);
            gbConvertedTo.Name = "gbConvertedTo";
            gbConvertedTo.Size = new Size(210, 125);
            gbConvertedTo.TabIndex = 7;
            gbConvertedTo.TabStop = false;
            gbConvertedTo.Text = "Converted to:";
            // 
            // cbPeriod
            // 
            cbPeriod.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbPeriod.FormattingEnabled = true;
            cbPeriod.Location = new Point(168, 152);
            cbPeriod.Name = "cbPeriod";
            cbPeriod.Size = new Size(528, 28);
            cbPeriod.TabIndex = 4;
            // 
            // currencyConverterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cbInitialCurrency);
            Controls.Add(gbConvertedTo);
            Controls.Add(gbOriginAmount);
            Controls.Add(btnSwap);
            Controls.Add(cbPeriod);
            Controls.Add(lblPeriod);
            Controls.Add(lblTitle);
            Name = "currencyConverterForm";
            Text = "Currency Converter";
            gbOriginAmount.ResumeLayout(false);
            gbOriginAmount.PerformLayout();
            gbConvertedTo.ResumeLayout(false);
            gbConvertedTo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Label lblTitle;
        private Label lblPeriod;
        private Button btnSwap;
        private GroupBox gbOriginAmount;
        private TextBox txtAmount;
        private Label lblAmount;
        private ComboBox cbInitialCurrency;
        private Label lblConverted;
        private TextBox txtConverted;
        private ComboBox cbTargetCurrency;
        private GroupBox gbConvertedTo;
        private ComboBox cbPeriod;
    }
}