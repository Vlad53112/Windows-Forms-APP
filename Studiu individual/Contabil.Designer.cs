namespace Studiu_individual
{
    partial class Contabil
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
            comboBox3 = new ComboBox();
            button1 = new Button();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            butCaut = new Button();
            textCaut = new TextBox();
            menuStrip1 = new MenuStrip();
            afisariDateToolStripMenuItem = new ToolStripMenuItem();
            vinzariiToolStripMenuItem = new ToolStripMenuItem();
            angajatiiToolStripMenuItem = new ToolStripMenuItem();
            aprovizionareToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(1, 86);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(852, 373);
            dataGridView1.TabIndex = 0;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(408, 24);
            comboBox3.Margin = new Padding(3, 2, 3, 2);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(204, 23);
            comboBox3.TabIndex = 12;
            comboBox3.Text = "Furnizor";
            comboBox3.SelectionChangeCommitted += comboBox3_SelectionChangeCommitted;
            // 
            // button1
            // 
            button1.Location = new Point(671, 21);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(176, 30);
            button1.TabIndex = 11;
            button1.Text = "Cabinetul Personal";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(205, 24);
            comboBox2.Margin = new Padding(3, 2, 3, 2);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(197, 23);
            comboBox2.TabIndex = 10;
            comboBox2.Text = "Filiala";
            comboBox2.SelectionChangeCommitted += comboBox2_SelectionChangeCommitted;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(1, 24);
            comboBox1.Margin = new Padding(3, 2, 3, 2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(198, 23);
            comboBox1.TabIndex = 9;
            comboBox1.Text = "Angajat";
            comboBox1.SelectionChangeCommitted += comboBox1_SelectionChangeCommitted;
            // 
            // butCaut
            // 
            butCaut.Location = new Point(765, 55);
            butCaut.Margin = new Padding(3, 2, 3, 2);
            butCaut.Name = "butCaut";
            butCaut.Size = new Size(82, 22);
            butCaut.TabIndex = 8;
            butCaut.Text = "Cautare";
            butCaut.UseVisualStyleBackColor = true;
            butCaut.Click += butCaut_Click;
            // 
            // textCaut
            // 
            textCaut.Location = new Point(1, 54);
            textCaut.Margin = new Padding(3, 2, 3, 2);
            textCaut.Name = "textCaut";
            textCaut.PlaceholderText = "Produs Denumire";
            textCaut.Size = new Size(758, 23);
            textCaut.TabIndex = 7;
            textCaut.KeyPress += textCaut_KeyPress;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { afisariDateToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(853, 24);
            menuStrip1.TabIndex = 13;
            menuStrip1.Text = "menuStrip1";
            // 
            // afisariDateToolStripMenuItem
            // 
            afisariDateToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { vinzariiToolStripMenuItem, angajatiiToolStripMenuItem, aprovizionareToolStripMenuItem });
            afisariDateToolStripMenuItem.Name = "afisariDateToolStripMenuItem";
            afisariDateToolStripMenuItem.Size = new Size(78, 20);
            afisariDateToolStripMenuItem.Text = "Afisari date";
            // 
            // vinzariiToolStripMenuItem
            // 
            vinzariiToolStripMenuItem.Name = "vinzariiToolStripMenuItem";
            vinzariiToolStripMenuItem.Size = new Size(147, 22);
            vinzariiToolStripMenuItem.Text = "Vinzarii";
            vinzariiToolStripMenuItem.Click += vinzariiToolStripMenuItem_Click;
            // 
            // angajatiiToolStripMenuItem
            // 
            angajatiiToolStripMenuItem.Name = "angajatiiToolStripMenuItem";
            angajatiiToolStripMenuItem.Size = new Size(147, 22);
            angajatiiToolStripMenuItem.Text = "Angajatii";
            angajatiiToolStripMenuItem.Click += angajatiiToolStripMenuItem_Click;
            // 
            // aprovizionareToolStripMenuItem
            // 
            aprovizionareToolStripMenuItem.Name = "aprovizionareToolStripMenuItem";
            aprovizionareToolStripMenuItem.Size = new Size(147, 22);
            aprovizionareToolStripMenuItem.Text = "Aprovizionare";
            aprovizionareToolStripMenuItem.Click += aprovizionareToolStripMenuItem_Click;
            // 
            // Contabil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 460);
            Controls.Add(comboBox3);
            Controls.Add(button1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(butCaut);
            Controls.Add(textCaut);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Contabil";
            Text = "Contabil";
            Load += Contabil_Load;
            Resize += Contabil_Resize;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox comboBox3;
        private Button button1;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Button butCaut;
        private TextBox textCaut;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem afisariDateToolStripMenuItem;
        private ToolStripMenuItem vinzariiToolStripMenuItem;
        private ToolStripMenuItem angajatiiToolStripMenuItem;
        private ToolStripMenuItem aprovizionareToolStripMenuItem;
    }
}