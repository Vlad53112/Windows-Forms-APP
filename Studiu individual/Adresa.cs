using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Studiu_individual
{
    public partial class Adresa : Form
    {
        Furnizor f;
        Filiala fl;
        int x;
        Conecsiune c = new Conecsiune();
        public Adresa(Furnizor fu, Filiala fi, int a)
        {
            InitializeComponent();
            f = fu;
            fl = fi;
            x = a;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            bool a = true;
            if (x == 1)
            {
                for (int i = 0; i < f.comboBox2.Items.Count; i++)
                    if (f.comboBox2.Items[i].ToString() == textBox1.Text + ", " + textBox2.Text + ", " + textBox3.Text + " " + textBox4.Text)
                        a = false;
            }
            else
            {
                for (int i = 0; i < fl.comboBox2.Items.Count; i++)
                    if (fl.comboBox2.Items[i].ToString() == textBox1.Text + ", " + textBox2.Text + ", " + textBox3.Text + " " + textBox4.Text)
                        a = false;
            }
            if (a)
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    if (textBox1.Text.Length > 30) MessageBox.Show("Ati depasit numarul de caractere pentru cinpul Tara!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (textBox2.Text.Length > 30) MessageBox.Show("Ati depasit numarul de caractere pentru cinpul Oras!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (textBox3.Text.Length > 30) MessageBox.Show("Ati depasit numarul de caractere pentru cinpul Strada!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (textBox4.Text.Length > 30) MessageBox.Show("Ati depasit numarul de caractere pentru cinpul Numar Bloc!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        c.c.Open();
                        SqlCommand insert = new SqlCommand($"INSERT INTO Adresa (tara, Oras, Strada, NrBloc) VALUES (@tara, @Oras,@Strada,@NrBloc); ", c.c);
                        insert.Parameters.AddWithValue("@tara", textBox1.Text);
                        insert.Parameters.AddWithValue("@Oras", textBox2.Text);
                        insert.Parameters.AddWithValue("@Strada", textBox3.Text);
                        insert.Parameters.AddWithValue("@NrBloc", textBox4.Text);
                        insert.ExecuteNonQuery();
                        c.c.Close();
                        c.c.Open();
                        SqlCommand adresa = new SqlCommand("Select IDAdresa, (Tara + ', ' + Oras + ', ' + Strada + ' ' + NrBloc) AS AdresaCompleta From Adresa ORDER BY AdresaCompleta", c.c);
                        SqlDataAdapter adaptAdr = new SqlDataAdapter(adresa);
                        DataSet setAdr = new DataSet();
                        adaptAdr.Fill(setAdr);
                        if (x == 1)
                        {
                            f.comboBox2.DataSource = null;
                            f.comboBox2.DataSource = setAdr.Tables[0];
                            f.comboBox2.ValueMember = "IDAdresa";
                            f.comboBox2.DisplayMember = "AdresaCompleta";
                        }
                        else
                        {
                            fl.comboBox2.DataSource = null;
                            fl.comboBox2.DataSource = setAdr.Tables[0];
                            fl.comboBox2.ValueMember = "IDAdresa";
                            fl.comboBox2.DisplayMember = "AdresaCompleta";
                        }
                        c.c.Close();
                        if (x == 1) f.comboBox2.SelectedItem = textBox1.Text + ", " + textBox2.Text + ", " + textBox3.Text + " " + textBox4.Text;
                        else fl.comboBox2.SelectedItem = textBox1.Text + ", " + textBox2.Text + ", " + textBox3.Text + " " + textBox4.Text;
                        this.Close();
                    }
                }
                else MessageBox.Show("Nu ati completat unul din cinpurile Tara , Oras, Strada sau Numar Bloc!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Asa adresa in lista de adrese deja exista!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (x == 1) f.comboBox2.SelectedItem = textBox1.Text + ", " + textBox2.Text + ", " + textBox3.Text + " " + textBox4.Text;
                else fl.comboBox2.SelectedItem = textBox1.Text + ", " + textBox2.Text + ", " + textBox3.Text + " " + textBox4.Text;
                this.Close();
            }
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zA-Z\s\b]$"))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[0-9/\s\b]$"))
            {
                e.Handled = true;
            }
        }

        private void Adresa_Load(object sender, EventArgs e)
        {

        }
    }
}
