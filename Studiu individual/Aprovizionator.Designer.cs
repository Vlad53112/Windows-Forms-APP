namespace Studiu_individual
{
    partial class Aprovizionator
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
            dataGridView1 = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            butMarfa = new Button();
            menuStrip1 = new MenuStrip();
            sortareaMarfeiToolStripMenuItem = new ToolStripMenuItem();
            alfabeticToolStripMenuItem = new ToolStripMenuItem();
            zAToolStripMenuItem = new ToolStripMenuItem();
            ceaMaiMultaToolStripMenuItem = new ToolStripMenuItem();
            ceaMaiPutinaToolStripMenuItem = new ToolStripMenuItem();
            ceaMaToolStripMenuItem = new ToolStripMenuItem();
            ceaMaiIeftinaToolStripMenuItem = new ToolStripMenuItem();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 43);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(858, 296);
            dataGridView1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // butMarfa
            // 
            butMarfa.Location = new Point(495, 9);
            butMarfa.Margin = new Padding(3, 2, 3, 2);
            butMarfa.Name = "butMarfa";
            butMarfa.Size = new Size(176, 30);
            butMarfa.TabIndex = 2;
            butMarfa.Text = "Adaugarea Marfa";
            butMarfa.UseVisualStyleBackColor = true;
            butMarfa.Click += button1_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { sortareaMarfeiToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(858, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // sortareaMarfeiToolStripMenuItem
            // 
            sortareaMarfeiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { alfabeticToolStripMenuItem, zAToolStripMenuItem, ceaMaiMultaToolStripMenuItem, ceaMaiPutinaToolStripMenuItem, ceaMaToolStripMenuItem, ceaMaiIeftinaToolStripMenuItem });
            sortareaMarfeiToolStripMenuItem.Name = "sortareaMarfeiToolStripMenuItem";
            sortareaMarfeiToolStripMenuItem.Size = new Size(96, 20);
            sortareaMarfeiToolStripMenuItem.Text = "Sortarea Marfa";
            // 
            // alfabeticToolStripMenuItem
            // 
            alfabeticToolStripMenuItem.Name = "alfabeticToolStripMenuItem";
            alfabeticToolStripMenuItem.Size = new Size(196, 22);
            alfabeticToolStripMenuItem.Text = "A-Z";
            alfabeticToolStripMenuItem.Click += alfabeticToolStripMenuItem_Click;
            // 
            // zAToolStripMenuItem
            // 
            zAToolStripMenuItem.Name = "zAToolStripMenuItem";
            zAToolStripMenuItem.Size = new Size(196, 22);
            zAToolStripMenuItem.Text = "Z-A";
            zAToolStripMenuItem.Click += zAToolStripMenuItem_Click;
            // 
            // ceaMaiMultaToolStripMenuItem
            // 
            ceaMaiMultaToolStripMenuItem.Name = "ceaMaiMultaToolStripMenuItem";
            ceaMaiMultaToolStripMenuItem.Size = new Size(196, 22);
            ceaMaiMultaToolStripMenuItem.Text = "Cea mai mare cantitate";
            ceaMaiMultaToolStripMenuItem.Click += ceaMaiMultaToolStripMenuItem_Click;
            // 
            // ceaMaiPutinaToolStripMenuItem
            // 
            ceaMaiPutinaToolStripMenuItem.Name = "ceaMaiPutinaToolStripMenuItem";
            ceaMaiPutinaToolStripMenuItem.Size = new Size(196, 22);
            ceaMaiPutinaToolStripMenuItem.Text = "Cea mai mare cantitate";
            ceaMaiPutinaToolStripMenuItem.Click += ceaMaiPutinaToolStripMenuItem_Click;
            // 
            // ceaMaToolStripMenuItem
            // 
            ceaMaToolStripMenuItem.Name = "ceaMaToolStripMenuItem";
            ceaMaToolStripMenuItem.Size = new Size(196, 22);
            ceaMaToolStripMenuItem.Text = "Cel mai mare pret";
            ceaMaToolStripMenuItem.Click += ceaMaToolStripMenuItem_Click;
            // 
            // ceaMaiIeftinaToolStripMenuItem
            // 
            ceaMaiIeftinaToolStripMenuItem.Name = "ceaMaiIeftinaToolStripMenuItem";
            ceaMaiIeftinaToolStripMenuItem.Size = new Size(196, 22);
            ceaMaiIeftinaToolStripMenuItem.Text = "Cel mai mic pret";
            ceaMaiIeftinaToolStripMenuItem.Click += ceaMaiIeftinaToolStripMenuItem_Click;
            // 
            // button1
            // 
            button1.Location = new Point(677, 9);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(176, 30);
            button1.TabIndex = 4;
            button1.Text = "Cabinetul Personal";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // Aprovizionator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 338);
            Controls.Add(button1);
            Controls.Add(butMarfa);
            Controls.Add(menuStrip1);
            Controls.Add(dataGridView1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(300, 150);
            Name = "Aprovizionator";
            Text = "Aprovizionator";
            Load += Aprovizionator_Load;
            Resize += Aprovizionator_Resize;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private ContextMenuStrip contextMenuStrip1;
        private Button butMarfa;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem sortareaMarfeiToolStripMenuItem;
        private ToolStripMenuItem alfabeticToolStripMenuItem;
        private ToolStripMenuItem zAToolStripMenuItem;
        private ToolStripMenuItem ceaMaiMultaToolStripMenuItem;
        private ToolStripMenuItem ceaMaiPutinaToolStripMenuItem;
        private ToolStripMenuItem ceaMaToolStripMenuItem;
        private ToolStripMenuItem ceaMaiIeftinaToolStripMenuItem;
        private Button button1;
    }
}