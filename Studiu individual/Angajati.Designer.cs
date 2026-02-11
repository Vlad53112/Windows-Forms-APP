namespace Studiu_individual
{
    partial class Angajati
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            textBox5 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            textBox6 = new TextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Nume";
            textBox1.Size = new Size(166, 23);
            textBox1.TabIndex = 0;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(198, 12);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Prenume";
            textBox2.Size = new Size(166, 23);
            textBox2.TabIndex = 1;
            textBox2.KeyPress += textBox2_KeyPress;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(383, 12);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Posta Elecronica";
            textBox3.Size = new Size(166, 23);
            textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(12, 52);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Numar Telefon";
            textBox4.Size = new Size(166, 23);
            textBox4.TabIndex = 3;
            textBox4.KeyPress += textBox4_KeyPress;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 98);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(166, 23);
            comboBox1.TabIndex = 4;
            comboBox1.Text = "Filiala";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(12, 149);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(166, 23);
            comboBox2.TabIndex = 5;
            comboBox2.Text = "Functie";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(198, 52);
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "Salariu";
            textBox5.Size = new Size(166, 23);
            textBox5.TabIndex = 6;
            textBox5.KeyPress += textBox5_KeyPress;
            // 
            // button1
            // 
            button1.Location = new Point(198, 97);
            button1.Name = "button1";
            button1.Size = new Size(166, 23);
            button1.TabIndex = 7;
            button1.Text = "Adauga Filiala";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(198, 148);
            button2.Name = "button2";
            button2.Size = new Size(166, 23);
            button2.TabIndex = 8;
            button2.Text = "Adauga Functie";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(398, 116);
            button3.Name = "button3";
            button3.Size = new Size(139, 31);
            button3.TabIndex = 9;
            button3.Text = "Adauga";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(383, 52);
            textBox6.Name = "textBox6";
            textBox6.PlaceholderText = "Durata Angajare";
            textBox6.Size = new Size(166, 23);
            textBox6.TabIndex = 10;
            textBox6.KeyPress += textBox6_KeyPress;
            // 
            // Angajati
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(585, 200);
            Controls.Add(textBox6);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox5);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            MaximumSize = new Size(601, 239);
            MinimumSize = new Size(601, 239);
            Name = "Angajati";
            Text = "Angajati";
            Load += Angajati_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox textBox6;
        public ComboBox comboBox1;
        public ComboBox comboBox2;
    }
}