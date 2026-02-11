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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Studiu_individual
{
    public partial class Produs : Form
    {

        Conecsiune c = new Conecsiune();
        AdugareMarfa m;
        public Produs(AdugareMarfa f)
        {
            InitializeComponent();
            m = f;
        }

        private void butCategorie_Click(object sender, EventArgs e)
        {
            Categorie c = new Categorie(this);
            c.ShowDialog();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zA-Z\s\b]$"))
            {
                e.Handled = true;
            }
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zA-Z\s\b]$"))
            {
                e.Handled = true;
            }
        }

        private void butAdauga_Click(object sender, EventArgs e)
        {
            bool a = true;
            for (int i = 0; i < m.comboBox1.Items.Count; i++)
                if (m.comboBox1.Items[i].ToString() == textBox1.Text)
                    a = false;
            if (a)
            {
                if (comboBoxCategorie.SelectedItem != null && textBox1.Text != "" && richTextBox1.Text != "")
                {
                    if (textBox1.Text.Length > 20) { MessageBox.Show("Ati depasit numarul de caractere pentru cinpul Denumire Produs!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBox1.Text = ""; }
                    else
                    {
                        m.categorieNew = Convert.ToInt32(comboBoxCategorie.SelectedValue.ToString());
                        m.denumireNew = textBox1.Text;
                        m.descriereNew = richTextBox1.Text;
                        m.comboBox1.Items.Add(textBox1.Text);
                        m.comboBox1.SelectedItem = textBox1.Text;
                        this.Close();
                    }
                }
                else MessageBox.Show("Nu ati completat Denumirea Produsului sau Descrierea sau nu ati selectat categoria", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Asa Produs in lista de Produse deja exista", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                m.comboBox1.SelectedItem = textBox1.Text;
                this.Close();
            }
        }

        private void Produs_Load(object sender, EventArgs e)
        {
            c.c.Open();
            SqlCommand categorie = new SqlCommand("Select * From Categorie ORDER BY Categorie", c.c);
            SqlDataAdapter adaptCa = new SqlDataAdapter(categorie);
            DataSet setCa = new DataSet();
            adaptCa.Fill(setCa);
            comboBoxCategorie.DataSource = null;
            comboBoxCategorie.DataSource = setCa.Tables[0];
            comboBoxCategorie.ValueMember = "IDCategorie";
            comboBoxCategorie.DisplayMember = "Categorie";
            comboBoxCategorie.Text = "Selectati Categoria";
            c.c.Close();
        }
    }
}
