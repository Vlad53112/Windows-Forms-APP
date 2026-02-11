namespace Studiu_individual
{
    partial class Filiala
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
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            textBox4 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Location = new Point(445, 79);
            button3.Name = "button3";
            button3.Size = new Size(145, 35);
            button3.TabIndex = 17;
            button3.Text = "Adaugare";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(260, 110);
            button2.Name = "button2";
            button2.Size = new Size(159, 23);
            button2.TabIndex = 16;
            button2.Text = "Adaugare Adresa Noua";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(260, 60);
            button1.Name = "button1";
            button1.Size = new Size(159, 23);
            button1.TabIndex = 15;
            button1.Text = "Adaugare Banca Noua";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(12, 110);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(229, 23);
            comboBox2.TabIndex = 14;
            comboBox2.Text = "Adresa";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 60);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(229, 23);
            comboBox1.TabIndex = 13;
            comboBox1.Text = "Denumire Banca";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(210, 13);
            textBox4.Margin = new Padding(3, 2, 3, 2);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Telefon";
            textBox4.Size = new Size(176, 23);
            textBox4.TabIndex = 12;
            textBox4.KeyPress += textBox4_KeyPress;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(403, 13);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "IBAN";
            textBox2.Size = new Size(229, 23);
            textBox2.TabIndex = 10;
            textBox2.KeyPress += textBox2_KeyPress;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 13);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Numele Furnizor";
            textBox1.Size = new Size(176, 23);
            textBox1.TabIndex = 9;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // Filiala
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 167);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(textBox4);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            MaximumSize = new Size(660, 206);
            MinimumSize = new Size(660, 206);
            Name = "Filiala";
            Text = "Filiala";
            Load += Filiala_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button3;
        private Button button2;
        private Button button1;
        public ComboBox comboBox2;
        public ComboBox comboBox1;
        private TextBox textBox4;
        private TextBox textBox2;
        private TextBox textBox1;
    }
}