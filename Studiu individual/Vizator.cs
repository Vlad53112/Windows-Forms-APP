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

namespace Studiu_individual
{
    public partial class Vizator : Form
    {
        Conecsiune c = new Conecsiune();
        string select = "SELECT Contract.IDContract,Contract.DenumireProdus as 'Denumire Produs',Contract.Descriere,Categorie.Categorie,Furnizor.DenumireFurnizor as 'Denumire Furnizor',Filiala.Denumire as 'Denumire Filiala', Contract.CantitateFurnizor as 'Cantitate',Contract.Pret_Unitate as 'Pret Unitate', Contract.DataContract as 'Data Aprovizionzrii' FROM Contract LEFT JOIN Categorie ON Contract.IDCategorie = Categorie.IDCategorie JOIN Furnizor ON Contract.IDFurnizor = Furnizor.IDFurnizor JOIN Filiala ON Contract.IDFiliala = Filiala.IDFiliala";
        int id;
        public Vizator(int i)
        {
            InitializeComponent();
            id = i;
        }
        private void Vizator_Load(object sender, EventArgs e)
        {
            dataGridView1.Top = 85;
            dataGridView1.Left = 0;
            dataGridView1.Height = this.Height - 125;
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
            c.c.Open();
            SqlCommand Furnizori = new SqlCommand("Select IDFurnizor,DenumireFurnizor From Furnizor ORDER BY DenumireFurnizor", c.c);
            SqlDataAdapter adaptFu = new SqlDataAdapter(Furnizori);
            DataSet setFU = new DataSet();
            adaptFu.Fill(setFU);
            comboBox3.DataSource = null;
            comboBox3.DataSource = setFU.Tables[0];
            comboBox3.ValueMember = "IDFurnizor";
            comboBox3.DisplayMember = "DenumireFurnizor";
            comboBox3.Text = "Furnizorii";
            c.c.Close();
            c.c.Open();
            SqlCommand Filiala = new SqlCommand("Select IDFiliala,Denumire From Filiala ORDER BY Denumire", c.c);
            SqlDataAdapter adaptFi = new SqlDataAdapter(Filiala);
            DataSet setFi = new DataSet();
            adaptFi.Fill(setFi);
            comboBox2.DataSource = null;
            comboBox2.DataSource = setFi.Tables[0];
            comboBox2.ValueMember = "IDFiliala";
            comboBox2.DisplayMember = "Denumire";
            comboBox2.Text = "Filiale";
            c.c.Close();
            c.c.Open();
            SqlCommand categorie = new SqlCommand("Select * From Categorie ORDER BY Categorie", c.c);
            SqlDataAdapter adaptCa = new SqlDataAdapter(categorie);
            DataSet setCa = new DataSet();
            adaptCa.Fill(setCa);
            comboBox1.DataSource = null;
            comboBox1.DataSource = setCa.Tables[0];
            comboBox1.ValueMember = "IDCategorie";
            comboBox1.DisplayMember = "Categorie";
            comboBox1.Text = "Categorii";
            c.c.Close();
        }

        private void Vizator_Resize(object sender, EventArgs e)
        {
            dataGridView1.Height = this.Height - 125;
            dataGridView1.Width = this.Width - 20;
            textCaut.Width = this.Width - 128;
            butCaut.Left = this.Width - 110;
            button1.Left = this.Width - 204;
            if (this.Width - 20 > 1413)
                dataGridView1.Columns[2].Width = this.Width - 1083;
        }

        private void butCaut_Click(object sender, EventArgs e)
        {
            c.c.Open();
            SqlCommand Produs = new SqlCommand(select + $" WHERE 'Denumire Produs' LIKE '%{textCaut.Text}%';", c.c);
            SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
            DataSet setPr = new DataSet();
            adaptPr.Fill(setPr);
            dataGridView1.DataSource = setPr.Tables[0];
            c.c.Close();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            c.c.Open();
            SqlCommand Produs = new SqlCommand(select + $" WHERE Categorie.IDCategorie = {Convert.ToInt32(comboBox1.SelectedValue.ToString())};", c.c);
            SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
            DataSet setPr = new DataSet();
            adaptPr.Fill(setPr);
            dataGridView1.DataSource = setPr.Tables[0];
            c.c.Close();
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            c.c.Open();
            SqlCommand Produs = new SqlCommand(select + $" WHERE Filiala.IDFiliala = {Convert.ToInt32(comboBox2.SelectedValue.ToString())};", c.c);
            SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
            DataSet setPr = new DataSet();
            adaptPr.Fill(setPr);
            dataGridView1.DataSource = setPr.Tables[0];
            c.c.Close();
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            c.c.Open();
            SqlCommand Produs = new SqlCommand(select + $" WHERE Furnizor.IDFurnizor = {Convert.ToInt32(comboBox3.SelectedValue.ToString())};", c.c);
            SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
            DataSet setPr = new DataSet();
            adaptPr.Fill(setPr);
            dataGridView1.DataSource = setPr.Tables[0];
            c.c.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cabinet_Personal ca = new Cabinet_Personal(id);
            this.Visible = false;
            ca.ShowDialog();
            this.Visible = true;
        }
    }
}
