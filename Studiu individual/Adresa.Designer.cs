namespace Studiu_individual
{
    partial class Adresa
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
            button1 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Tara";
            textBox1.Size = new Size(161, 23);
            textBox1.TabIndex = 0;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 53);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Oras";
            textBox2.Size = new Size(161, 23);
            textBox2.TabIndex = 1;
            textBox2.KeyPress += textBox2_KeyPress;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 99);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Strada";
            textBox3.Size = new Size(161, 23);
            textBox3.TabIndex = 2;
            textBox3.KeyPress += textBox3_KeyPress;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(12, 140);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Numar Bloc";
            textBox4.Size = new Size(161, 23);
            textBox4.TabIndex = 3;
            textBox4.KeyPress += textBox4_KeyPress;
            // 
            // button1
            // 
            button1.Location = new Point(256, 130);
            button1.Name = "button1";
            button1.Size = new Size(128, 33);
            button1.TabIndex = 4;
            button1.Text = "Adaugare";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Adresa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 195);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            MaximumSize = new Size(483, 234);
            MinimumSize = new Size(483, 234);
            Name = "Adresa";
            Text = "Adresa";
            Load += Adresa_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
    }
}