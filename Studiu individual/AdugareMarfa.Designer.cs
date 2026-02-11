namespace Studiu_individual
{
    partial class AdugareMarfa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBox1 = new ComboBox();
            butMarfa = new Button();
            comboBox2 = new ComboBox();
            butFurnizor = new Button();
            textBox1 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            textBox2 = new TextBox();
            butAdauga = new Button();
            butFactura = new Button();
            comboBox3 = new ComboBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(10, 104);
            comboBox1.Margin = new Padding(3, 2, 3, 2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(134, 23);
            comboBox1.TabIndex = 0;
            comboBox1.Text = "Denumire Marfa";
            // 
            // butMarfa
            // 
            butMarfa.Location = new Point(170, 105);
            butMarfa.Margin = new Padding(3, 2, 3, 2);
            butMarfa.Name = "butMarfa";
            butMarfa.Size = new Size(164, 22);
            butMarfa.TabIndex = 1;
            butMarfa.Text = "Adugare Marfa Noua";
            butMarfa.UseVisualStyleBackColor = true;
            butMarfa.Click += button1_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(10, 66);
            comboBox2.Margin = new Padding(3, 2, 3, 2);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(133, 23);
            comboBox2.TabIndex = 2;
            comboBox2.Text = "Denumire Furnizor";
            // 
            // butFurnizor
            // 
            butFurnizor.Location = new Point(170, 65);
            butFurnizor.Margin = new Padding(3, 2, 3, 2);
            butFurnizor.Name = "butFurnizor";
            butFurnizor.Size = new Size(164, 22);
            butFurnizor.TabIndex = 3;
            butFurnizor.Text = "Adugare Furnizor Nou";
            butFurnizor.UseVisualStyleBackColor = true;
            butFurnizor.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(170, 22);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Cantitate de produs";
            textBox1.Size = new Size(134, 23);
            textBox1.TabIndex = 4;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(350, 22);
            dateTimePicker1.Margin = new Padding(3, 2, 3, 2);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(219, 23);
            dateTimePicker1.TabIndex = 5;
            dateTimePicker1.Value = new DateTime(2025, 6, 12, 14, 1, 0, 0);
            // 
            // textBox2
            // 
            textBox2.Location = new Point(10, 22);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Pret Unitate";
            textBox2.Size = new Size(134, 23);
            textBox2.TabIndex = 6;
            textBox2.KeyPress += textBox2_KeyPress;
            // 
            // butAdauga
            // 
            butAdauga.Location = new Point(408, 138);
            butAdauga.Margin = new Padding(3, 2, 3, 2);
            butAdauga.Name = "butAdauga";
            butAdauga.Size = new Size(144, 38);
            butAdauga.TabIndex = 7;
            butAdauga.Text = "Adaugare";
            butAdauga.UseVisualStyleBackColor = true;
            butAdauga.Click += butAdauga_Click_1;
            // 
            // butFactura
            // 
            butFactura.Location = new Point(80, 153);
            butFactura.Name = "butFactura";
            butFactura.Size = new Size(169, 23);
            butFactura.TabIndex = 8;
            butFactura.Text = "Adaugare Factura";
            butFactura.UseVisualStyleBackColor = true;
            butFactura.Click += butFactura_Click;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(12, 138);
            comboBox3.Margin = new Padding(3, 2, 3, 2);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(134, 23);
            comboBox3.TabIndex = 9;
            comboBox3.Text = "Denumire Marfa";
            // 
            // button1
            // 
            button1.Location = new Point(170, 139);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(164, 22);
            button1.TabIndex = 10;
            button1.Text = "Adugare Filiala Noua";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // AdugareMarfa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(599, 198);
            Controls.Add(button1);
            Controls.Add(comboBox3);
            Controls.Add(butFactura);
            Controls.Add(butAdauga);
            Controls.Add(textBox2);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox1);
            Controls.Add(butFurnizor);
            Controls.Add(comboBox2);
            Controls.Add(butMarfa);
            Controls.Add(comboBox1);
            Margin = new Padding(3, 2, 3, 2);
            MaximumSize = new Size(615, 237);
            MinimumSize = new Size(615, 237);
            Name = "AdugareMarfa";
            Text = "AdugareMarfa";
            Load += AdugareMarfa_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button butMarfa;
        private Button butFurnizor;
        private TextBox textBox1;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox2;
        private Button butAdauga;
        private Button butFactura;
        public ComboBox comboBox1;
        public ComboBox comboBox2;
        public ComboBox comboBox3;
        private Button button1;
    }
}