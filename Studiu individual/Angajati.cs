using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Studiu_individual
{
    public partial class Angajati : Form
    {
        Conecsiune c = new Conecsiune();
        public Angajati()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zA-Z\s\b]$"))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zA-Z\s\b]$"))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[0-9\b]$"))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[0-9.\b]$"))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[0-9\b]$"))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Functie a = new Functie(this);
            a.ShowDialog();
        }

        private void Angajati_Load(object sender, EventArgs e)
        {
            c.c.Open();
            SqlCommand functie = new SqlCommand("Select * From Functie ORDER BY Functie", c.c);
            SqlDataAdapter adaptFu = new SqlDataAdapter(functie);
            DataSet setFu = new DataSet();
            adaptFu.Fill(setFu);
            comboBox2.DataSource = null;
            comboBox2.DataSource = setFu.Tables[0];
            comboBox2.ValueMember = "IDFunctie";
            comboBox2.DisplayMember = "Functie";
            comboBox2.Text = "Selectati Functia";
            c.c.Close();
            c.c.Open();
            SqlCommand Filiala = new SqlCommand("Select IDFiliala,Denumire From Filiala ORDER BY Denumire", c.c);
            SqlDataAdapter adaptFi = new SqlDataAdapter(Filiala);
            DataSet setFi = new DataSet();
            adaptFi.Fill(setFi);
            comboBox1.DataSource = null;
            comboBox1.DataSource = setFi.Tables[0];
            comboBox1.ValueMember = "IDFiliala";
            comboBox1.DisplayMember = "Denumire";
            comboBox1.Text = "Selectati Filiala";
            c.c.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdugareMarfa f = new AdugareMarfa();
            Filiala a = new Filiala(f, this, 2);
            a.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                if(textBox1.Text.Length > 20) MessageBox.Show("Cimpul Nume nu trebuie sa depaseasca 20 de caractere!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if(textBox2.Text.Length > 20) MessageBox.Show("Cimpul Prenume nu trebuie sa depaseasca 20 de caractere!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (textBox3.Text.Length > 20 || !Regex.IsMatch(textBox3.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) MessageBox.Show("Ati depasit numarul de caractere pentru cinpul Posta Electronica sau ati introduso gresit!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (textBox4.Text.Length != 9) MessageBox.Show("Ati introdus gresit cinpul Telefon!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    c.c.Open();
                    SqlCommand insertAngajat = new SqlCommand($"INSERT INTO Angajati (Nume, Prenume, PostaElectronica, NrTelefon,IDFiliala,Parola,MuncesteSauNu) VALUES (@Nume, @Prenume,@PostaElectronica,@NrTelefon,@IDFiliala,'12345aA_','True'); ", c.c);
                    insertAngajat.Parameters.AddWithValue("@Nume", textBox1.Text);
                    insertAngajat.Parameters.AddWithValue("@Prenume", textBox2.Text);
                    insertAngajat.Parameters.AddWithValue("@PostaElectronica", textBox3.Text);
                    insertAngajat.Parameters.AddWithValue("@NrTelefon", textBox4.Text);
                    insertAngajat.Parameters.AddWithValue("@IDFiliala", Convert.ToInt32(comboBox1.SelectedValue.ToString()));
                    insertAngajat.ExecuteNonQuery();
                    c.c.Close();
                    c.c.Open();
                    SqlCommand ang = new SqlCommand($"Select IDAngajati From Angajati where PostaElectronica ='{textBox3.Text}'", c.c);
                    SqlDataAdapter adapta = new SqlDataAdapter(ang);
                    DataSet seta = new DataSet();
                    adapta.Fill(seta);
                    DataGridView l = new DataGridView();
                    l.DataSource = seta.Tables[0];
                    this.Controls.Add(l);
                    c.c.Close();
                    c.c.Open();
                    SqlCommand insertContract = new SqlCommand($"INSERT INTO ContractAngajare (IDAngajat, IDFunctie, DataSemnariiContract, DurataContract) VALUES (@IDAngajat, @IDFunctie,@DataSemnariiContract,@DurataContract); ", c.c);
                    insertContract.Parameters.AddWithValue("@IDAngajat", Convert.ToInt32(l.Rows[0].Cells[0].Value.ToString()));
                    insertContract.Parameters.AddWithValue("@IDFunctie", Convert.ToInt32(comboBox1.SelectedValue.ToString()));
                    insertContract.Parameters.AddWithValue("@DataSemnariiContract", DateTime.Today.ToString("yyyy-MM-dd"));
                    insertContract.Parameters.AddWithValue("@DurataContract", textBox6.Text);
                    insertContract.ExecuteNonQuery();
                    c.c.Close();
                    c.c.Open();
                    SqlCommand con = new SqlCommand($"Select IDAngajati From Angajati where PostaElectronica ='{textBox3.Text}'", c.c);
                    SqlDataAdapter adaptc = new SqlDataAdapter(con);
                    DataSet setc = new DataSet();
                    adaptc.Fill(setc);
                    l.DataSource = seta.Tables[0];
                    this.Controls.Add(l);
                    c.c.Close();
                    c.c.Open();
                    SqlCommand insertSalariu = new SqlCommand($"INSERT INTO Salariu (IDContractAngajare, Salariu, DataModificarii) VALUES (@IDContractAngajare, @Salariu,@DataModificarii); ", c.c);
                    insertSalariu.Parameters.AddWithValue("@IDContractAngajare", Convert.ToInt32(l.Rows[0].Cells[0].Value.ToString()));
                    insertSalariu.Parameters.AddWithValue("@Salariu", textBox5.Text);
                    insertSalariu.Parameters.AddWithValue("@DataModificarii", DateTime.Today.ToString("yyyy-MM-dd"));
                    insertSalariu.ExecuteNonQuery();
                    c.c.Close();
                    this.Close();
                }
            }
            else MessageBox.Show("Nu ati completat unul din cinpurile Cantitate , Pret Unitate, sau nu ati selectat Denumire Urnizor, Denumire Filiala sau Denumire Marfa!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
