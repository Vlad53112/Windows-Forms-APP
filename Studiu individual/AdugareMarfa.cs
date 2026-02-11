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
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Studiu_individual
{
    public partial class AdugareMarfa : Form
    {
        Conecsiune c = new Conecsiune();
        public AdugareMarfa()
        {
            InitializeComponent();
        }

        private void AdugareMarfa_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today;
            butFactura.Visible = false;
            c.c.Open();
            SqlCommand Furnizori = new SqlCommand("Select IDFurnizor,DenumireFurnizor From Furnizor ORDER BY DenumireFurnizor", c.c);
            SqlDataAdapter adaptFu = new SqlDataAdapter(Furnizori);
            DataSet setFU = new DataSet();
            adaptFu.Fill(setFU);
            comboBox2.DataSource = null;
            comboBox2.DataSource = setFU.Tables[0];
            comboBox2.ValueMember = "IDFurnizor";
            comboBox2.DisplayMember = "DenumireFurnizor";
            comboBox2.Text = "Selectati Furnizorul";
            c.c.Close();
            c.c.Open();
            SqlCommand Produs = new SqlCommand("Select IDContract,DenumireProdus From Contract ORDER BY DenumireProdus", c.c);
            SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
            DataSet setPr = new DataSet();
            adaptPr.Fill(setPr);
            comboBox1.DataSource = null;
            comboBox1.DataSource = setPr.Tables[0];
            comboBox1.ValueMember = "IDContract";
            comboBox1.DisplayMember = "DenumireProdus";
            comboBox1.Text = "Selectati Produsul";
            c.c.Close();
            c.c.Open();
            SqlCommand Filiala = new SqlCommand("Select IDFiliala,Denumire From Filiala ORDER BY Denumire", c.c);
            SqlDataAdapter adaptFi = new SqlDataAdapter(Filiala);
            DataSet setFi = new DataSet();
            adaptFi.Fill(setFi);
            comboBox3.DataSource = null;
            comboBox3.DataSource = setFi.Tables[0];
            comboBox3.ValueMember = "IDFiliala";
            comboBox3.DisplayMember = "Denumire";
            comboBox3.Text = "Selectati Filiala";
            c.c.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Furnizor a = new Furnizor(this);
            a.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Produs a = new Produs(this);
            a.ShowDialog();
        }

        public int categorieNew;
        public string denumireNew = "";
        public string descriereNew;


        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[0-9.\b]$"))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[0-9\b]$"))
            {
                e.Handled = true;
            }
        }

        private void butAdauga_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1 && comboBox3.SelectedIndex != -1)
            {
                if (comboBox1.SelectedItem == denumireNew)
                {
                    c.c.Open();
                    SqlCommand insert = new SqlCommand($"INSERT INTO Contract (DenumireProdus, Descriere, IDCategorie, IDFurnizor,IDFiliala,CantitateFurnizor,DataContract,Pret_Unitate) VALUES (@DenumireProdus, @Descriere,@IDCategorie,@IDFurnizor,@IDFiliala,@CantitateFurnizor,@DataContract,@Pret_Unitate); ", c.c);
                    insert.Parameters.AddWithValue("@DenumireProdus", denumireNew);
                    insert.Parameters.AddWithValue("@Descriere", descriereNew);
                    insert.Parameters.AddWithValue("@IDCategorie", categorieNew);
                    insert.Parameters.AddWithValue("@IDFurnizor", Convert.ToInt32(comboBox2.SelectedValue.ToString()));
                    insert.Parameters.AddWithValue("@IDFiliala", Convert.ToInt32(comboBox3.SelectedValue.ToString()));
                    insert.Parameters.AddWithValue("@CantitateFurnizor", textBox1.Text);
                    insert.Parameters.AddWithValue("@DataContract", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    insert.Parameters.AddWithValue("@Pret_Unitate", textBox2.Text);
                    insert.ExecuteNonQuery();
                    c.c.Close();
                    this.Close();
                }
                else
                {
                    c.c.Open();
                    SqlCommand Produs = new SqlCommand($"Select DenumireProdus,Descriere,IDCategorie From Contract WHERE IDContract = '{Convert.ToInt32(comboBox2.SelectedValue.ToString())}';", c.c);
                    SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
                    DataSet setPr = new DataSet();
                    adaptPr.Fill(setPr);
                    DataGridView a = new DataGridView();
                    a.DataSource = setPr.Tables[0];
                    this.Controls.Add(a);
                    c.c.Close();
                    c.c.Open();
                    SqlCommand insert = new SqlCommand($"INSERT INTO Contract (DenumireProdus, Descriere, IDCategorie, IDFurnizor,IDFiliala,CantitateFurnizor,DataContract,Pret_Unitate) VALUES (@DenumireProdus, @Descriere,@IDCategorie,@IDFurnizor,@IDFiliala,@CantitateFurnizor,@DataContract,@Pret_Unitate); ", c.c);
                    insert.Parameters.AddWithValue("@DenumireProdus", a.Rows[0].Cells[0].Value.ToString());
                    insert.Parameters.AddWithValue("@Descriere", a.Rows[0].Cells[1].Value.ToString());
                    insert.Parameters.AddWithValue("@IDCategorie", a.Rows[0].Cells[2].Value.ToString());
                    insert.Parameters.AddWithValue("@IDFurnizor", Convert.ToInt32(comboBox2.SelectedValue.ToString()));
                    insert.Parameters.AddWithValue("@IDFiliala", Convert.ToInt32(comboBox3.SelectedValue.ToString()));
                    insert.Parameters.AddWithValue("@CantitateFurnizor", textBox1.Text);
                    insert.Parameters.AddWithValue("@DataContract", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    insert.Parameters.AddWithValue("@Pret_Unitate", textBox2.Text);
                    insert.ExecuteNonQuery();
                    c.c.Close();
                    this.Close();
                }
            }
            else MessageBox.Show("Nu ati completat unul din cinpurile Cantitate , Pret Unitate, sau nu ati selectat Denumire Urnizor, Denumire Filiala sau Denumire Marfa!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void butFactura_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Angajati q = new Angajati();
            Filiala a = new Filiala(this,q,1);
            a.ShowDialog();
        }
    }
}
