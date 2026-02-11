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
    public partial class Categorie : Form
    {
        Produs f;
        Conecsiune c = new Conecsiune();
        public Categorie(Produs p)
        {
            InitializeComponent();
            f = p;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool a = true;
            for (int i = 0; i < f.comboBoxCategorie.Items.Count; i++)
                if (f.comboBoxCategorie.Items[i].ToString() == textBox1.Text)
                    a = false;
            if (a)
            {
                if (textBox1.Text != "")
                {
                    if (textBox1.Text.Length > 30) { MessageBox.Show("Ati depasit numarul de caractere pentru cinpul Categorie!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBox1.Text = ""; }
                    else
                    {
                        c.c.Open();
                        SqlCommand insert = new SqlCommand($"INSERT INTO Categorie (categorie) VALUES (@categorie); ", c.c);
                        insert.Parameters.AddWithValue("@categorie", textBox1.Text);
                        insert.ExecuteNonQuery();
                        insert.ExecuteNonQuery();
                        c.c.Close();
                        c.c.Open();
                        SqlCommand categorie = new SqlCommand("Select * From Categorie ORDER BY Categorie", c.c);
                        SqlDataAdapter adaptCa = new SqlDataAdapter(categorie);
                        DataSet setCa = new DataSet();
                        adaptCa.Fill(setCa);
                        f.comboBoxCategorie.DataSource = null;
                        f.comboBoxCategorie.DataSource = setCa.Tables[0];
                        f.comboBoxCategorie.ValueMember = "IDCategorie";
                        f.comboBoxCategorie.DisplayMember = "Categorie";
                        c.c.Close();
                        f.comboBoxCategorie.SelectedItem = textBox1.Text;
                        this.Close();
                    }
                }
                else MessageBox.Show("Nu ati completat cinpul Categorie!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Asa categorie in lista de Categorii deja exista!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                f.comboBoxCategorie.SelectedItem = textBox1.Text;
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

        private void Categorie_Load(object sender, EventArgs e)
        {

        }
    }
}
