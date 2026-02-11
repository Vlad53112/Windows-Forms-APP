using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Studiu_individual
{
    public partial class Vinzare : Form
    {
        Conecsiune c = new Conecsiune();
        public Vinzare()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                c.c.Open();
                SqlCommand scad = new SqlCommand($"SELECT Cantitate FROM Vinzari where IDContract ={Convert.ToInt32(comboBox1.SelectedValue.ToString())}", c.c);
                SqlDataAdapter adaptSC = new SqlDataAdapter(scad);
                DataSet setSC = new DataSet();
                adaptSC.Fill(setSC);
                c.c.Close();
                c.c.Open();
                SqlCommand baza = new SqlCommand($"SELECT CantitateFurnizor,Pret_Unitate FROM Contract where IDContract ={Convert.ToInt32(comboBox1.SelectedValue.ToString())}", c.c);
                SqlDataAdapter adaptBa = new SqlDataAdapter(baza);
                DataSet setBa = new DataSet();
                adaptBa.Fill(setBa);
                DataGridView a = new DataGridView();
                a.DataSource = setBa.Tables[0];
                this.Controls.Add(a);
                a.Visible = false;
                c.c.Close();
                    foreach (DataRow rindVind in setSC.Tables[0].Rows)
                        a.Rows[0].Cells[0].Value = Convert.ToInt32(a.Rows[0].Cells[0].Value) - Convert.ToInt32(rindVind["Cantitate"]);
                if (Convert.ToInt32(textBox1.Text) > Convert.ToInt32(a.Rows[0].Cells[0].Value)) MessageBox.Show("Cantitatea de produs nu poate depasi cantitatea disponibila in depozit!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (Convert.ToDouble(textBox2.Text) < Convert.ToDouble(a.Rows[0].Cells[1].Value) || Convert.ToDouble(textBox2.Text) > Convert.ToDouble(a.Rows[0].Cells[1].Value)+ Convert.ToDouble(a.Rows[0].Cells[1].Value)*2.0) MessageBox.Show("Pretul produsului nu trebuie sa fie mai mic decit la aprovizionare su mai mare dd 20 de procent de la aprovizionare!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else 
                {
                    c.c.Open();
                    SqlCommand insert = new SqlCommand("INSERT INTO Vinzari (IDContract, IDAngajat, Cantitate, Pret_Unitate, DataVinzarii) VALUES (@IDContract, @IDAngajat, @Cantitate, @Pret, @Data)", c.c);
                    insert.Parameters.AddWithValue("@IDContract", Convert.ToInt32(comboBox1.SelectedValue));
                    insert.Parameters.AddWithValue("@IDAngajat", Convert.ToInt32(comboBox2.SelectedValue));
                    insert.Parameters.AddWithValue("@Cantitate", Convert.ToInt32(textBox1.Text));
                    insert.Parameters.AddWithValue("@Pret", Convert.ToDouble(textBox2.Text));
                    insert.Parameters.AddWithValue("@Data", DateTime.Today);
                    insert.ExecuteNonQuery();
                    c.c.Close();
                    this.Close();
                }
            }
            else MessageBox.Show("Nu ati completat unul din cinpurile Pret Unitate , Cantitate sau nu ati selectat Angajatul sau Produsul!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Vinzare_Load(object sender, EventArgs e)
        {
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
            SqlCommand angajati = new SqlCommand("Select IDAngajati,(Nume + ' ' + Prenume) as Numee From Angajati ORDER BY Numee", c.c);
            SqlDataAdapter adaptAg = new SqlDataAdapter(angajati);
            DataSet setAg = new DataSet();
            adaptAg.Fill(setAg);
            comboBox2.DataSource = null;
            comboBox2.DataSource = setAg.Tables[0];
            comboBox2.ValueMember = "IDAngajati";
            comboBox2.DisplayMember = "Numee";
            comboBox2.Text = "Selectati Angajatul";
            c.c.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[0-9\b]$"))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[0-9.\b]$"))
            {
                e.Handled = true;
            }
        }
    }
}
