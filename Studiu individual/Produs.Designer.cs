namespace Studiu_individual
{
    partial class Produs
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
            richTextBox1 = new RichTextBox();
            label1 = new Label();
            comboBoxCategorie = new ComboBox();
            butCategorie = new Button();
            butAdauga = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(10, 16);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Denumire Produsului";
            textBox1.Size = new Size(239, 23);
            textBox1.TabIndex = 0;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(10, 70);
            richTextBox1.Margin = new Padding(3, 2, 3, 2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(512, 144);
            richTextBox1.TabIndex = 1;
            richTextBox1.Tag = "Descrierea Produsului";
            richTextBox1.Text = "";
            richTextBox1.KeyPress += richTextBox1_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 53);
            label1.Name = "label1";
            label1.Size = new Size(121, 15);
            label1.TabIndex = 2;
            label1.Text = "Descrierea produsului";
            // 
            // comboBoxCategorie
            // 
            comboBoxCategorie.FormattingEnabled = true;
            comboBoxCategorie.Location = new Point(270, 16);
            comboBoxCategorie.Margin = new Padding(3, 2, 3, 2);
            comboBoxCategorie.Name = "comboBoxCategorie";
            comboBoxCategorie.Size = new Size(174, 23);
            comboBoxCategorie.TabIndex = 3;
            comboBoxCategorie.Text = "Categorie";
            // 
            // butCategorie
            // 
            butCategorie.Location = new Point(473, 16);
            butCategorie.Margin = new Padding(3, 2, 3, 2);
            butCategorie.Name = "butCategorie";
            butCategorie.Size = new Size(172, 23);
            butCategorie.TabIndex = 4;
            butCategorie.Text = "Adauga Categorie Noua";
            butCategorie.UseVisualStyleBackColor = true;
            butCategorie.Click += butCategorie_Click;
            // 
            // butAdauga
            // 
            butAdauga.Location = new Point(544, 151);
            butAdauga.Margin = new Padding(3, 2, 3, 2);
            butAdauga.Name = "butAdauga";
            butAdauga.Size = new Size(130, 39);
            butAdauga.TabIndex = 5;
            butAdauga.Text = "Adaugare";
            butAdauga.UseVisualStyleBackColor = true;
            butAdauga.Click += butAdauga_Click;
            // 
            // Produs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 242);
            Controls.Add(butAdauga);
            Controls.Add(butCategorie);
            Controls.Add(comboBoxCategorie);
            Controls.Add(label1);
            Controls.Add(richTextBox1);
            Controls.Add(textBox1);
            Margin = new Padding(3, 2, 3, 2);
            MaximumSize = new Size(716, 281);
            MinimumSize = new Size(716, 281);
            Name = "Produs";
            Text = "Produs";
            Load += Produs_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private RichTextBox richTextBox1;
        private Label label1;
        private Button butCategorie;
        private Button butAdauga;
        public ComboBox comboBoxCategorie;
    }
}