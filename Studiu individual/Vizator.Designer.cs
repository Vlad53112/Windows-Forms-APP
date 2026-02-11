namespace Studiu_individual
{
    partial class Vizator
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
            dataGridView1 = new DataGridView();
            textCaut = new TextBox();
            butCaut = new Button();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            button1 = new Button();
            comboBox3 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(1, 64);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(865, 391);
            dataGridView1.TabIndex = 0;
            // 
            // textCaut
            // 
            textCaut.Location = new Point(10, 39);
            textCaut.Margin = new Padding(3, 2, 3, 2);
            textCaut.Name = "textCaut";
            textCaut.PlaceholderText = "Produs Denumire";
            textCaut.Size = new Size(758, 23);
            textCaut.TabIndex = 1;
            // 
            // butCaut
            // 
            butCaut.Location = new Point(774, 38);
            butCaut.Margin = new Padding(3, 2, 3, 2);
            butCaut.Name = "butCaut";
            butCaut.Size = new Size(82, 22);
            butCaut.TabIndex = 2;
            butCaut.Text = "Cautare";
            butCaut.UseVisualStyleBackColor = true;
            butCaut.Click += butCaut_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(10, 9);
            comboBox1.Margin = new Padding(3, 2, 3, 2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(198, 23);
            comboBox1.TabIndex = 3;
            comboBox1.Text = "Categorie";
            comboBox1.SelectionChangeCommitted += comboBox1_SelectionChangeCommitted;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(225, 9);
            comboBox2.Margin = new Padding(3, 2, 3, 2);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(197, 23);
            comboBox2.TabIndex = 4;
            comboBox2.Text = "Filiala";
            comboBox2.SelectionChangeCommitted += comboBox2_SelectionChangeCommitted;
            // 
            // button1
            // 
            button1.Location = new Point(680, 4);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(176, 30);
            button1.TabIndex = 5;
            button1.Text = "Cabinetul Personal";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(428, 9);
            comboBox3.Margin = new Padding(3, 2, 3, 2);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(204, 23);
            comboBox3.TabIndex = 6;
            comboBox3.Text = "Furnizor";
            comboBox3.SelectionChangeCommitted += comboBox3_SelectionChangeCommitted;
            // 
            // Vizator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(866, 456);
            Controls.Add(comboBox3);
            Controls.Add(button1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(butCaut);
            Controls.Add(textCaut);
            Controls.Add(dataGridView1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Vizator";
            Text = "Vizator";
            Load += Vizator_Load;
            Resize += Vizator_Resize;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox textCaut;
        private Button butCaut;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Button button1;
        private ComboBox comboBox3;
    }
}