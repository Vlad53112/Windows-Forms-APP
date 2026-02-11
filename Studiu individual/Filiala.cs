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
    public partial class Filiala : Form
    {
        Conecsiune c = new Conecsiune();
        AdugareMarfa f;
        Angajati ag;
        int x;
        public Filiala(AdugareMarfa m, Angajati a, int i)
        {
            InitializeComponent();
            f = m;
            ag = a;
            x = i;
        }

        private void Filiala_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            Furnizor fur = new Furnizor(f);
            Adresa a = new Adresa(fur, this, 2);
            a.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Furnizor fur = new Furnizor(f);
            Banca a = new Banca(fur, this, 2);
            a.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool a = true;
            if (x == 1)
            for (int i = 0; i < f.comboBox3.Items.Count; i++)
                if (f.comboBox3.Items[i].ToString() == textBox1.Text)
                    a = false;
            if (x == 2)
                for (int i = 0; i < ag.comboBox1.Items.Count; i++)
                    if (ag.comboBox1.Items[i].ToString() == textBox1.Text)
                        a = false;
            if (a)
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "" && comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
                {
                    if (textBox1.Text.Length > 30) { MessageBox.Show("Ati depasit numarul de caractere pentru cinpul Nume Filiala!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBox1.Text = ""; }
                    else if (textBox2.Text.Length != 24 || textBox2.Text[0] < 'A' || textBox2.Text[0] > 'Z' || textBox2.Text[1] < 'A' || textBox2.Text[1] > 'Z') { MessageBox.Show("Ati introdus gresit cinpul IBAN!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBox1.Text = ""; }
                    else if (textBox4.Text.Length != 9) { MessageBox.Show("Ati introdus gresit cinpul Telefon!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBox1.Text = ""; }
                    else
                    {
                        c.c.Open();
                        SqlCommand insert = new SqlCommand($"INSERT INTO Filiala (Denumire, IDAdresa, NrTelefon, IBAN ,IDDenumireBanca) VALUES (@Denumire, @IDAdresa,@NrTelefon,@IBAN,@IDDenumireBanca); ", c.c);
                        insert.Parameters.AddWithValue("@Denumire", textBox1.Text);
                        insert.Parameters.AddWithValue("@IDAdresa", Convert.ToInt32(comboBox2.SelectedValue.ToString()));
                        insert.Parameters.AddWithValue("@NrTelefon", textBox4.Text);
                        insert.Parameters.AddWithValue("@IBAN", textBox2.Text);
                        insert.Parameters.AddWithValue("@IDDenumireBanca", Convert.ToInt32(comboBox1.SelectedValue.ToString()));
                        insert.ExecuteNonQuery();
                        c.c.Close();
                        c.c.Open();
                        SqlCommand Filiala = new SqlCommand("Select IDFiliala,Denumire From Filiala ORDER BY Denumire", c.c);
                        SqlDataAdapter adaptFi = new SqlDataAdapter(Filiala);
                        DataSet setFi = new DataSet();
                        adaptFi.Fill(setFi);
                        if(x == 1)
                        {
                            f.comboBox3.DataSource = null;
                            f.comboBox3.DataSource = setFi.Tables[0];
                            f.comboBox3.ValueMember = "IDFiliala";
                            f.comboBox3.DisplayMember = "Denumire";
                            f.comboBox3.Text = "Selectati Filiala";
                        }
                        if(x == 2)
                        {
                            ag.comboBox1.DataSource = null;
                            ag.comboBox1.DataSource = setFi.Tables[0];
                            ag.comboBox1.ValueMember = "IDFiliala";
                            ag.comboBox1.DisplayMember = "Denumire";
                            ag.comboBox1.Text = "Selectati Filiala";
                        }
                        c.c.Close();
                        if (x == 1) f.comboBox3.SelectedItem = textBox1.Text;
                        if (x == 2) ag.comboBox1.SelectedItem = textBox1.Text;
                        this.Close();
                    }
                }
                else MessageBox.Show("Nu ati completat unul din cinpurile Nume FFiliala , IBAN, telefon sau nu ati selectat Banca sau Adresa!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Asa Filiala in lista de filiale deja exista!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if(x == 1)f.comboBox3.SelectedItem = textBox1.Text;
                if (x == 2) ag.comboBox1.SelectedItem = textBox1.Text;
                this.Close();
            }
        }
    }
}
