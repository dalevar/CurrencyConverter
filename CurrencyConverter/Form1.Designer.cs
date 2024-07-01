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
            lblTitle.Location = new Point(227, 49);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(227, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Currency Converter";
            // 
            // lblPeriod
            // 
            lblPeriod.AutoSize = true;
            lblPeriod.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPeriod.Location = new Point(66, 113);
            lblPeriod.Name = "lblPeriod";
            lblPeriod.Size = new Size(54, 21);
            lblPeriod.TabIndex = 1;
            lblPeriod.Text = "Period";
            // 
            // btnSwap
            // 
            btnSwap.BackgroundImage = Properties.Resources.exchange_1;
            btnSwap.BackgroundImageLayout = ImageLayout.Zoom;
            btnSwap.Location = new Point(298, 199);
            btnSwap.Margin = new Padding(3, 2, 3, 2);
            btnSwap.Name = "btnSwap";
            btnSwap.Size = new Size(82, 45);
            btnSwap.TabIndex = 5;
            btnSwap.UseVisualStyleBackColor = true;
            btnSwap.Click += btnSwap_Click;
            // 
            // gbOriginAmount
            // 
            gbOriginAmount.Controls.Add(txtAmount);
            gbOriginAmount.Controls.Add(lblAmount);
            gbOriginAmount.Location = new Point(66, 172);
            gbOriginAmount.Margin = new Padding(3, 2, 3, 2);
            gbOriginAmount.Name = "gbOriginAmount";
            gbOriginAmount.Padding = new Padding(3, 2, 3, 2);
            gbOriginAmount.Size = new Size(184, 94);
            gbOriginAmount.TabIndex = 6;
            gbOriginAmount.TabStop = false;
            gbOriginAmount.Text = "Origin Amount";
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(5, 51);
            txtAmount.Margin = new Padding(3, 2, 3, 2);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(110, 23);
            txtAmount.TabIndex = 1;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(5, 34);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(78, 15);
            lblAmount.TabIndex = 0;
            lblAmount.Text = "Select Region";
            // 
            // cbInitialCurrency
            // 
            cbInitialCurrency.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbInitialCurrency.FormattingEnabled = true;
            cbInitialCurrency.Location = new Point(186, 224);
            cbInitialCurrency.Margin = new Padding(3, 2, 3, 2);
            cbInitialCurrency.Name = "cbInitialCurrency";
            cbInitialCurrency.Size = new Size(59, 23);
            cbInitialCurrency.TabIndex = 8;
            cbInitialCurrency.SelectedIndexChanged += cbInitialCurrency_SelectedIndexChanged;
            // 
            // lblConverted
            // 
            lblConverted.AutoSize = true;
            lblConverted.Location = new Point(6, 34);
            lblConverted.Name = "lblConverted";
            lblConverted.Size = new Size(78, 15);
            lblConverted.TabIndex = 1;
            lblConverted.Text = "Select Region";
            // 
            // txtConverted
            // 
            txtConverted.BackColor = SystemColors.Control;
            txtConverted.BorderStyle = BorderStyle.FixedSingle;
            txtConverted.Enabled = false;
            txtConverted.ForeColor = SystemColors.ControlText;
            txtConverted.Location = new Point(6, 51);
            txtConverted.Margin = new Padding(3, 2, 3, 2);
            txtConverted.Name = "txtConverted";
            txtConverted.ReadOnly = true;
            txtConverted.Size = new Size(110, 23);
            txtConverted.TabIndex = 2;
            // 
            // cbTargetCurrency
            // 
            cbTargetCurrency.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbTargetCurrency.FormattingEnabled = true;
            cbTargetCurrency.Location = new Point(120, 51);
            cbTargetCurrency.Margin = new Padding(3, 2, 3, 2);
            cbTargetCurrency.Name = "cbTargetCurrency";
            cbTargetCurrency.Size = new Size(59, 23);
            cbTargetCurrency.TabIndex = 9;
            cbTargetCurrency.SelectedIndexChanged += cbTargetCurrency_SelectedIndexChanged;
            // 
            // gbConvertedTo
            // 
            gbConvertedTo.Controls.Add(cbTargetCurrency);
            gbConvertedTo.Controls.Add(txtConverted);
            gbConvertedTo.Controls.Add(lblConverted);
            gbConvertedTo.Location = new Point(425, 172);
            gbConvertedTo.Margin = new Padding(3, 2, 3, 2);
            gbConvertedTo.Name = "gbConvertedTo";
            gbConvertedTo.Padding = new Padding(3, 2, 3, 2);
            gbConvertedTo.Size = new Size(184, 94);
            gbConvertedTo.TabIndex = 7;
            gbConvertedTo.TabStop = false;
            gbConvertedTo.Text = "Converted to:";
            // 
            // cbPeriod
            // 
            cbPeriod.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbPeriod.FormattingEnabled = true;
            cbPeriod.Location = new Point(147, 114);
            cbPeriod.Margin = new Padding(3, 2, 3, 2);
            cbPeriod.Name = "cbPeriod";
            cbPeriod.Size = new Size(462, 23);
            cbPeriod.TabIndex = 4;
            // 
            // currencyConverterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(cbInitialCurrency);
            Controls.Add(gbConvertedTo);
            Controls.Add(gbOriginAmount);
            Controls.Add(btnSwap);
            Controls.Add(cbPeriod);
            Controls.Add(lblPeriod);
            Controls.Add(lblTitle);
            Margin = new Padding(3, 2, 3, 2);
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