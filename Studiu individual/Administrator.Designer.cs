namespace Studiu_individual
{
    partial class Administrator
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
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            inserareToolStripMenuItem = new ToolStripMenuItem();
            angajatToolStripMenuItem1 = new ToolStripMenuItem();
            produsToolStripMenuItem1 = new ToolStripMenuItem();
            vinzareToolStripMenuItem = new ToolStripMenuItem();
            bonusPedeapsaToolStripMenuItem = new ToolStripMenuItem();
            afisareToolStripMenuItem = new ToolStripMenuItem();
            produseToolStripMenuItem = new ToolStripMenuItem();
            angajatiToolStripMenuItem = new ToolStripMenuItem();
            vinzariToolStripMenuItem = new ToolStripMenuItem();
            filiaToolStripMenuItem = new ToolStripMenuItem();
            furnizoriiToolStripMenuItem = new ToolStripMenuItem();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            stergereInterogareToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { inserareToolStripMenuItem, afisareToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // inserareToolStripMenuItem
            // 
            inserareToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { angajatToolStripMenuItem1, produsToolStripMenuItem1, vinzareToolStripMenuItem, bonusPedeapsaToolStripMenuItem });
            inserareToolStripMenuItem.Name = "inserareToolStripMenuItem";
            inserareToolStripMenuItem.Size = new Size(60, 20);
            inserareToolStripMenuItem.Text = "Inserare";
            // 
            // angajatToolStripMenuItem1
            // 
            angajatToolStripMenuItem1.Name = "angajatToolStripMenuItem1";
            angajatToolStripMenuItem1.Size = new Size(160, 22);
            angajatToolStripMenuItem1.Text = "Angajat";
            angajatToolStripMenuItem1.Click += angajatToolStripMenuItem1_Click;
            // 
            // produsToolStripMenuItem1
            // 
            produsToolStripMenuItem1.Name = "produsToolStripMenuItem1";
            produsToolStripMenuItem1.Size = new Size(160, 22);
            produsToolStripMenuItem1.Text = "Produs";
            produsToolStripMenuItem1.Click += produsToolStripMenuItem1_Click;
            // 
            // vinzareToolStripMenuItem
            // 
            vinzareToolStripMenuItem.Name = "vinzareToolStripMenuItem";
            vinzareToolStripMenuItem.Size = new Size(160, 22);
            vinzareToolStripMenuItem.Text = "Vinzare";
            vinzareToolStripMenuItem.Click += vinzareToolStripMenuItem_Click;
            // 
            // bonusPedeapsaToolStripMenuItem
            // 
            bonusPedeapsaToolStripMenuItem.Name = "bonusPedeapsaToolStripMenuItem";
            bonusPedeapsaToolStripMenuItem.Size = new Size(160, 22);
            bonusPedeapsaToolStripMenuItem.Text = "Bonus Pedeapsa";
            bonusPedeapsaToolStripMenuItem.Click += bonusPedeapsaToolStripMenuItem_Click;
            // 
            // afisareToolStripMenuItem
            // 
            afisareToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { produseToolStripMenuItem, angajatiToolStripMenuItem, vinzariToolStripMenuItem, filiaToolStripMenuItem, furnizoriiToolStripMenuItem });
            afisareToolStripMenuItem.Name = "afisareToolStripMenuItem";
            afisareToolStripMenuItem.Size = new Size(55, 20);
            afisareToolStripMenuItem.Text = "Afisare";
            // 
            // produseToolStripMenuItem
            // 
            produseToolStripMenuItem.Name = "produseToolStripMenuItem";
            produseToolStripMenuItem.Size = new Size(180, 22);
            produseToolStripMenuItem.Text = "Produse";
            produseToolStripMenuItem.Click += produseToolStripMenuItem_Click;
            // 
            // angajatiToolStripMenuItem
            // 
            angajatiToolStripMenuItem.Name = "angajatiToolStripMenuItem";
            angajatiToolStripMenuItem.Size = new Size(180, 22);
            angajatiToolStripMenuItem.Text = "Angajati";
            angajatiToolStripMenuItem.Click += angajatiToolStripMenuItem_Click;
            // 
            // vinzariToolStripMenuItem
            // 
            vinzariToolStripMenuItem.Name = "vinzariToolStripMenuItem";
            vinzariToolStripMenuItem.Size = new Size(180, 22);
            vinzariToolStripMenuItem.Text = "Vinzari";
            vinzariToolStripMenuItem.Click += vinzariToolStripMenuItem_Click;
            // 
            // filiaToolStripMenuItem
            // 
            filiaToolStripMenuItem.Name = "filiaToolStripMenuItem";
            filiaToolStripMenuItem.Size = new Size(180, 22);
            filiaToolStripMenuItem.Text = "Filiale";
            filiaToolStripMenuItem.Click += filiaToolStripMenuItem_Click;
            // 
            // furnizoriiToolStripMenuItem
            // 
            furnizoriiToolStripMenuItem.Name = "furnizoriiToolStripMenuItem";
            furnizoriiToolStripMenuItem.Size = new Size(180, 22);
            furnizoriiToolStripMenuItem.Text = "Furnizorii";
            furnizoriiToolStripMenuItem.Click += furnizoriiToolStripMenuItem_Click;
            // 
            // button1
            // 
            button1.Location = new Point(629, 26);
            button1.Name = "button1";
            button1.Size = new Size(159, 33);
            button1.TabIndex = 1;
            button1.Text = "Cabinet Personal";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            dataGridView1.Location = new Point(0, 65);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(800, 386);
            dataGridView1.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { stergereInterogareToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(181, 48);
            // 
            // stergereInterogareToolStripMenuItem
            // 
            stergereInterogareToolStripMenuItem.Name = "stergereInterogareToolStripMenuItem";
            stergereInterogareToolStripMenuItem.Size = new Size(180, 22);
            stergereInterogareToolStripMenuItem.Text = "Stergere interogare";
            stergereInterogareToolStripMenuItem.Click += stergereInterogareToolStripMenuItem_Click;
            // 
            // Administrator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Administrator";
            Text = "Administrator";
            Load += Administrator_Load;
            Resize += Administrator_Resize;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem inserareToolStripMenuItem;
        private ToolStripMenuItem angajatToolStripMenuItem1;
        private ToolStripMenuItem produsToolStripMenuItem1;
        private ToolStripMenuItem vinzareToolStripMenuItem;
        private ToolStripMenuItem afisareToolStripMenuItem;
        private Button button1;
        private DataGridView dataGridView1;
        private ToolStripMenuItem produseToolStripMenuItem;
        private ToolStripMenuItem angajatiToolStripMenuItem;
        private ToolStripMenuItem vinzariToolStripMenuItem;
        private ToolStripMenuItem bonusPedeapsaToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem stergereInterogareToolStripMenuItem;
        private ToolStripMenuItem filiaToolStripMenuItem;
        private ToolStripMenuItem furnizoriiToolStripMenuItem;
    }
}