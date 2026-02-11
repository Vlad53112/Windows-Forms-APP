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
    public partial class Functie : Form
    {
        Angajati f;
        Conecsiune c = new Conecsiune();
        public Functie(Angajati a)
        {
            InitializeComponent();
            f = a;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zA-Z\s\b]$"))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool a = true;
            for (int i = 0; i < f.comboBox2.Items.Count; i++)
                if (f.comboBox2.Items[i].ToString() == textBox1.Text)
                    a = false;
            if (a)
            {
                if (textBox1.Text != "")
                {
                    if (textBox1.Text.Length > 20) { MessageBox.Show("Ati depasit numarul de caractere pentru cinpul Functie!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBox1.Text = ""; }
                    else
                    {
                        c.c.Open();
                        SqlCommand insert = new SqlCommand($"INSERT INTO Functie (Functie) VALUES (@Functie); ", c.c);
                        insert.Parameters.AddWithValue("@Functie", textBox1.Text);
                        insert.ExecuteNonQuery();
                        c.c.Close();
                        c.c.Open();
                        SqlCommand functie = new SqlCommand("Select * From Functie ORDER BY Functie", c.c);
                        SqlDataAdapter adaptFu = new SqlDataAdapter(functie);
                        DataSet setFu = new DataSet();
                        adaptFu.Fill(setFu);
                        f.comboBox2.DataSource = null;
                        f.comboBox2.DataSource = setFu.Tables[0];
                        f.comboBox2.ValueMember = "IDFunctie";
                        f.comboBox2.DisplayMember = "Functie";
                        c.c.Close();
                        f.comboBox2.SelectedItem = textBox1.Text;
                        this.Close();
                    }
                }
                else MessageBox.Show("Nu ati completat cinpul Functie!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Asa functie in lista de Functii deja exista!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                f.comboBox2.SelectedItem = textBox1.Text;
                this.Close();
            }
        }

        private void Functie_Load(object sender, EventArgs e)
        {

        }
    }
}
