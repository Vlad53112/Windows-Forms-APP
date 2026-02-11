using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Studiu_individual
{
    public partial class Furnizor : Form
    {
        Conecsiune c = new Conecsiune();
        AdugareMarfa f;
        public Furnizor(AdugareMarfa m)
        {
            InitializeComponent();
            f = m;
        }
        private void Furnizor_Load(object sender, EventArgs e)
        {
            c.c.Open();
            SqlCommand banca = new SqlCommand("Select * From DenumireBanca ORDER BY DenumireBanca", c.c);
            SqlDataAdapter adaptBanc = new SqlDataAdapter(banca);
            DataSet setBanc = new DataSet();
            adaptBanc.Fill(setBanc);
            comboBox1.DataSource = null;
            comboBox1.DataSource = setBanc.Tables[0];
            comboBox1.ValueMember = "IDDenumirebanca";
            comboBox1.DisplayMember = "DenumireBanca";
            comboBox1.Text = "Selectati Denumire Bancii";
            c.c.Close();
            c.c.Open();
            SqlCommand adresa = new SqlCommand("Select IDAdresa, (Tara + ', ' + Oras + ', ' + Strada + ' ' + NrBloc) AS AdresaCompleta From Adresa ORDER BY AdresaCompleta", c.c);
            SqlDataAdapter adaptAdr = new SqlDataAdapter(adresa);
            DataSet setAdr = new DataSet();
            adaptAdr.Fill(setAdr);
            comboBox2.DataSource = null;
            comboBox2.DataSource = setAdr.Tables[0];
            comboBox2.ValueMember = "IDAdresa";
            comboBox2.DisplayMember = "AdresaCompleta";
            comboBox2.Text = "Selectati Adresa";
            c.c.Close();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[A-Z0-9\b]$"))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Angajati ag = new Angajati();
            Filiala fur = new Filiala(f, ag, 0);
            Adresa a = new Adresa(this, fur, 1);
            a.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool a = true;
            for (int i = 0; i < f.comboBox2.Items.Count; i++)
                if (f.comboBox2.Items[i].ToString() == textBox1.Text)
                    a = false;
            if (a)
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
                {
                    if (textBox1.Text.Length > 30) { MessageBox.Show("Ati depasit numarul de caractere pentru cinpul Nume Furnizor!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBox1.Text = ""; }
                    else if (textBox2.Text.Length != 24 || textBox2.Text[0] < 'A' || textBox2.Text[0] > 'Z' || textBox2.Text[1] < 'A' || textBox2.Text[1] > 'Z') { MessageBox.Show("Ati introdus gresit cinpul IBAN!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBox1.Text = ""; }
                    else if (textBox3.Text.Length > 20 || !Regex.IsMatch(textBox3.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) { MessageBox.Show("Ati depasit numarul de caractere pentru cinpul Posta Electronica sau ati introduso gresit!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBox1.Text = ""; }
                    else if (textBox4.Text.Length != 9) { MessageBox.Show("Ati introdus gresit cinpul Telefon!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBox1.Text = ""; }
                    else
                    {
                        c.c.Open();
                        SqlCommand insert = new SqlCommand($"INSERT INTO Furnizor (DenumireFurnizor, IBAN, IDDenumireBanca, IDAdresa,PostaElectronica,Telefon) VALUES (@DenumireFurnizor,@IBAN,@IDDenumireBanca,@IDAdresa,@PostaElectronica,@Telefon); ", c.c);
                        insert.Parameters.AddWithValue("@DenumireFurnizor", textBox1.Text);
                        insert.Parameters.AddWithValue("@IBAN", textBox2.Text);
                        insert.Parameters.AddWithValue("@IDDenumireBanca", Convert.ToInt32(comboBox1.SelectedValue.ToString()));
                        insert.Parameters.AddWithValue("@IDAdresa", Convert.ToInt32(comboBox2.SelectedValue.ToString()));
                        insert.Parameters.AddWithValue("@PostaElectronica", textBox3.Text);
                        insert.Parameters.AddWithValue("@Telefon", textBox4.Text);
                        insert.ExecuteNonQuery();
                        c.c.Close();
                        c.c.Open();
                        SqlCommand furnizor = new SqlCommand("Select IDFurnizor,DenumireFurnizor From Furnizor ORDER BY DenumireFurnizor", c.c);
                        SqlDataAdapter adaptFur = new SqlDataAdapter(furnizor);
                        DataSet setFur = new DataSet();
                        adaptFur.Fill(setFur);
                        f.comboBox2.DataSource = null;
                        f.comboBox2.DataSource = setFur.Tables[0];
                        f.comboBox2.ValueMember = "IDFurnizor";
                        f.comboBox2.DisplayMember = "DenumireFurnizor";
                        c.c.Close();
                        f.comboBox2.SelectedItem = textBox1.Text;
                        this.Close();
                    }
                }
                else MessageBox.Show("Nu ati completat unul din cinpurile Nume Furnizor , IBAN, telefon, Posta Electronica sau nu ati selectat Banca sau Adresa!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Asa Furnizor in lista de furnizorii deja exista!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                f.comboBox2.SelectedItem = textBox1.Text;
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Angajati ag = new Angajati();
            Filiala fur = new Filiala(f,ag,0);
            Banca a = new Banca(this, fur, 1);
            a.ShowDialog();
        }
    }
}
