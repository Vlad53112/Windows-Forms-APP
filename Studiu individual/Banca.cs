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
using System.Data.SqlClient;

namespace Studiu_individual
{
    public partial class Banca : Form
    {
        Conecsiune c = new Conecsiune();
        Furnizor f;
        Filiala fl;
        int x;
        public Banca(Furnizor fu, Filiala fi, int a)
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
                for (int i = 0; i < f.comboBox1.Items.Count; i++)
                    if (f.comboBox1.Items[i].ToString() == textBox1.Text)
                        a = false;
            }
            else
            {
                for (int i = 0; i < fl.comboBox1.Items.Count; i++)
                    if (fl.comboBox1.Items[i].ToString() == textBox1.Text)
                        a = false;
            }
            if (a)
            {
                if (textBox1.Text != "")
                {
                    if (textBox1.Text.Length > 30) { MessageBox.Show("Ati depasit numarul de caractere pentru cinpul Denumire Banca!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBox1.Text = ""; }
                    else
                    {
                        c.c.Open();
                        SqlCommand insert = new SqlCommand($"INSERT INTO DenumireBanca (DenumireBanca) VALUES (@DenumireBanca); ", c.c);
                        insert.Parameters.AddWithValue("@DenumireBanca", textBox1.Text);
                        insert.ExecuteNonQuery();
                        c.c.Close();
                        c.c.Open();
                        SqlCommand banca = new SqlCommand("Select * From DenumireBanca ORDER BY DenumireBanca", c.c);
                        SqlDataAdapter adaptBac = new SqlDataAdapter(banca);
                        DataSet setBac = new DataSet();
                        adaptBac.Fill(setBac);
                        if (x == 1)
                        {
                            f.comboBox1.DataSource = null;
                            f.comboBox1.DataSource = setBac.Tables[0];
                            f.comboBox1.ValueMember = "IDDenumireBanca";
                            f.comboBox1.DisplayMember = "DenumireBanca";
                        }
                        else
                        {
                            fl.comboBox1.DataSource = null;
                            fl.comboBox1.DataSource = setBac.Tables[0];
                            fl.comboBox1.ValueMember = "IDDenumireBanca";
                            fl.comboBox1.DisplayMember = "DenumireBanca";
                        }
                        c.c.Close();
                        if (x == 1) f.comboBox1.SelectedItem = textBox1.Text;
                        else fl.comboBox1.SelectedItem = textBox1.Text;
                        this.Close();
                    }
                }
                else MessageBox.Show("Nu ati completat cinpul Denumire Banca!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Asa Banca in lista de Bbanci deja exista!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (x == 1) f.comboBox1.SelectedItem = textBox1.Text;
                else fl.comboBox1.SelectedItem = textBox1.Text;
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

        private void Banca_Load(object sender, EventArgs e)
        {

        }
    }
}
