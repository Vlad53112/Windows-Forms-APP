using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Studiu_individual
{
    public partial class Aprovizionator : Form
    {
        Conecsiune c = new Conecsiune();
        public int ID;
        string select = "SELECT Contract.IDContract,Contract.DenumireProdus as 'Denumire Produs',Contract.Descriere,Categorie.Categorie,Furnizor.DenumireFurnizor as 'Denumire Furnizor',Filiala.Denumire as 'Denumire Filiala', Contract.CantitateFurnizor as 'Cantitate',Contract.Pret_Unitate as 'Pret Unitate', Contract.DataContract as 'Data Aprovizionzrii' FROM Contract JOIN Categorie ON Contract.IDCategorie = Categorie.IDCategorie JOIN Furnizor ON Contract.IDFurnizor = Furnizor.IDFurnizor JOIN Filiala ON Contract.IDFiliala = Filiala.IDFiliala";
        int id;
        public Aprovizionator(int i)
        {
            InitializeComponent();
            id = i;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdugareMarfa a = new AdugareMarfa();
            a.ShowDialog();
            c.c.Open();
            SqlCommand scad = new SqlCommand("SELECT IDContract, Cantitate FROM Vinzari", c.c);
            SqlDataAdapter adaptSC = new SqlDataAdapter(scad);
            DataSet setSC = new DataSet();
            adaptSC.Fill(setSC);
            c.c.Close();
            c.c.Open();
            SqlCommand Produs = new SqlCommand(select + " ORDER BY 'Denumire Produs';", c.c);
            SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
            DataSet setPr = new DataSet();
            adaptPr.Fill(setPr);
            dataGridView1.DataSource = setPr.Tables[0];
            foreach (DataGridViewRow rindProdus in dataGridView1.Rows)
                foreach (DataRow rindVind in setSC.Tables[0].Rows)
                    if (Convert.ToInt32(rindProdus.Cells[0].Value) == Convert.ToInt32(rindVind["IDContract"]))
                        rindProdus.Cells[6].Value = Convert.ToInt32(rindProdus.Cells[6].Value) - Convert.ToInt32(rindVind["Cantitate"]);
            c.c.Close();
        }

        private void Aprovizionator_Load(object sender, EventArgs e)
        {
            dataGridView1.Top = 43;
            dataGridView1.Left = 0;
            dataGridView1.Height = this.Height - 83;
            dataGridView1.Width = this.Width - 20;
            c.c.Open();
            SqlCommand scad = new SqlCommand("SELECT IDContract, Cantitate FROM Vinzari", c.c);
            SqlDataAdapter adaptSC = new SqlDataAdapter(scad);
            DataSet setSC = new DataSet();
            adaptSC.Fill(setSC);
            c.c.Close();
            c.c.Open();
            SqlCommand Produs = new SqlCommand(select + " ORDER BY 'Denumire Produs';", c.c);
            SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
            DataSet setPr = new DataSet();
            adaptPr.Fill(setPr);
            dataGridView1.DataSource = setPr.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[2].Width = 350;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 170;
            dataGridView1.Columns[5].Width = 170;
            dataGridView1.Columns[6].Width = 100;
            foreach (DataGridViewRow rindProdus in dataGridView1.Rows)
                foreach (DataRow rindVind in setSC.Tables[0].Rows)
                    if (Convert.ToInt32(rindProdus.Cells[0].Value) == Convert.ToInt32(rindVind["IDContract"]))
                        rindProdus.Cells[6].Value = Convert.ToInt32(rindProdus.Cells[6].Value) - Convert.ToInt32(rindVind["Cantitate"]);
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[8].Width = 150;
            c.c.Close();
        }
        private void ceaMaiPutinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            c.c.Open();
            SqlCommand Produs = new SqlCommand(select + " ORDER BY 'Cantitate';", c.c);
            SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
            DataSet setPr = new DataSet();
            adaptPr.Fill(setPr);
            dataGridView1.DataSource = setPr.Tables[0];
            c.c.Close();
        }

        private void Aprovizionator_Resize(object sender, EventArgs e)
        {
            dataGridView1.Height = this.Height - 83;
            dataGridView1.Width = this.Width - 20;
            button1.Left = this.Width - 204;
            butMarfa.Left = this.Width - 386;
            if (this.Width - 20 > 1413)
                dataGridView1.Columns[2].Width = this.Width - 1083;
        }

        private void alfabeticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            c.c.Open();
            SqlCommand Produs = new SqlCommand(select + " ORDER BY 'Denumire Produs';", c.c);
            SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
            DataSet setPr = new DataSet();
            adaptPr.Fill(setPr);
            dataGridView1.DataSource = setPr.Tables[0];
            c.c.Close();
        }

        private void zAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            c.c.Open();
            SqlCommand Produs = new SqlCommand(select + " ORDER BY 'Denumire Produs' DESC;", c.c);
            SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
            DataSet setPr = new DataSet();
            adaptPr.Fill(setPr);
            dataGridView1.DataSource = setPr.Tables[0];
            c.c.Close();
        }

        private void ceaMaiMultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            c.c.Open();
            SqlCommand Produs = new SqlCommand(select + " ORDER BY 'Cantitate' DESC;", c.c);
            SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
            DataSet setPr = new DataSet();
            adaptPr.Fill(setPr);
            dataGridView1.DataSource = setPr.Tables[0];
            c.c.Close();
        }

        private void ceaMaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            c.c.Open();
            SqlCommand Produs = new SqlCommand(select + " ORDER BY 'Pret Unitate' DESC;", c.c);
            SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
            DataSet setPr = new DataSet();
            adaptPr.Fill(setPr);
            dataGridView1.DataSource = setPr.Tables[0];
            c.c.Close();
        }

        private void ceaMaiIeftinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            c.c.Open();
            SqlCommand Produs = new SqlCommand(select + " ORDER BY 'Pret Unitate' ;", c.c);
            SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
            DataSet setPr = new DataSet();
            adaptPr.Fill(setPr);
            dataGridView1.DataSource = setPr.Tables[0];
            c.c.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Cabinet_Personal ca = new Cabinet_Personal(id);
            this.Visible = false;
            ca.ShowDialog();
            this.Visible = true;
        }
    }
}
