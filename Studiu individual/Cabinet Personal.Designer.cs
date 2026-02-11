namespace Studiu_individual
{
    partial class Cabinet_Personal
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            contextMenuStrip3 = new ContextMenuStrip(components);
            modificaParolaToolStripMenuItem = new ToolStripMenuItem();
            label5 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            modificaToolStripMenuItem = new ToolStripMenuItem();
            label6 = new Label();
            contextMenuStrip2 = new ContextMenuStrip(components);
            modificaPostaElectronicaToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip3.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(35, 21);
            label1.Name = "label1";
            label1.Size = new Size(179, 30);
            label1.TabIndex = 0;
            label1.Text = "Nume Prenume: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            label2.Location = new Point(35, 62);
            label2.Name = "label2";
            label2.Size = new Size(92, 30);
            label2.TabIndex = 1;
            label2.Text = "Salariu: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            label3.Location = new Point(35, 104);
            label3.Name = "label3";
            label3.Size = new Size(97, 30);
            label3.TabIndex = 2;
            label3.Text = "Functie: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ContextMenuStrip = contextMenuStrip3;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            label4.Location = new Point(35, 245);
            label4.Name = "label4";
            label4.Size = new Size(86, 30);
            label4.TabIndex = 3;
            label4.Text = "Parola: ";
            // 
            // contextMenuStrip3
            // 
            contextMenuStrip3.Items.AddRange(new ToolStripItem[] { modificaParolaToolStripMenuItem });
            contextMenuStrip3.Name = "contextMenuStrip3";
            contextMenuStrip3.Size = new Size(158, 26);
            // 
            // modificaParolaToolStripMenuItem
            // 
            modificaParolaToolStripMenuItem.Name = "modificaParolaToolStripMenuItem";
            modificaParolaToolStripMenuItem.Size = new Size(157, 22);
            modificaParolaToolStripMenuItem.Text = "Modifica Parola";
            modificaParolaToolStripMenuItem.Click += modificaParolaToolStripMenuItem_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ContextMenuStrip = contextMenuStrip1;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            label5.Location = new Point(35, 151);
            label5.Name = "label5";
            label5.Size = new Size(169, 30);
            label5.TabIndex = 4;
            label5.Text = "Numar telefon: ";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { modificaToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(180, 26);
            // 
            // modificaToolStripMenuItem
            // 
            modificaToolStripMenuItem.Name = "modificaToolStripMenuItem";
            modificaToolStripMenuItem.Size = new Size(179, 22);
            modificaToolStripMenuItem.Text = "Modifica Nr Telefon";
            modificaToolStripMenuItem.Click += modificaToolStripMenuItem_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ContextMenuStrip = contextMenuStrip2;
            label6.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            label6.Location = new Point(35, 201);
            label6.Name = "label6";
            label6.Size = new Size(191, 30);
            label6.TabIndex = 5;
            label6.Text = "Posta electronica: ";
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange(new ToolStripItem[] { modificaPostaElectronicaToolStripMenuItem });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(215, 26);
            // 
            // modificaPostaElectronicaToolStripMenuItem
            // 
            modificaPostaElectronicaToolStripMenuItem.Name = "modificaPostaElectronicaToolStripMenuItem";
            modificaPostaElectronicaToolStripMenuItem.Size = new Size(214, 22);
            modificaPostaElectronicaToolStripMenuItem.Text = "Modifica Posta electronica";
            modificaPostaElectronicaToolStripMenuItem.Click += modificaPostaElectronicaToolStripMenuItem_Click;
            // 
            // Cabinet_Personal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(758, 301);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximumSize = new Size(774, 340);
            MinimumSize = new Size(774, 340);
            Name = "Cabinet_Personal";
            Text = "Cabinet_Personal";
            Load += Cabinet_Personal_Load;
            contextMenuStrip3.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            contextMenuStrip2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem modificaToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip3;
        private ToolStripMenuItem modificaParolaToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem modificaPostaElectronicaToolStripMenuItem;
    }
}