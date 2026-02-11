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
    public partial class BonusurPedepse : Form
    {
        Conecsiune c = new Conecsiune();
        public BonusurPedepse()
        {
            InitializeComponent();
        }

        private void BonusurPedepse_Load(object sender, EventArgs e)
        {
            c.c.Open();
            SqlCommand angajati = new SqlCommand("Select ContractAngajare.IDContractAngajare,(Angajati.Nume + ' ' + Angajati.Prenume) as Numee From Angajati Join ContractAngajare on Angajati.IDAngajati = ContractAngajare.IDAngajat ORDER BY Numee", c.c);
            SqlDataAdapter adaptAg = new SqlDataAdapter(angajati);
            DataSet setAg = new DataSet();
            adaptAg.Fill(setAg);
            comboBox1.DataSource = null;
            comboBox1.DataSource = setAg.Tables[0];
            comboBox1.ValueMember = "IDContractAngajare";
            comboBox1.DisplayMember = "Numee";
            comboBox1.Text = "Selectati Angajatul";
            c.c.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[-0-9.\b]$"))
            {
                e.Handled = true;
            }
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zA-Z\b\s]$"))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.SelectedIndex != -1 && richTextBox1.Text != "")
            {
                c.c.Open();
                SqlCommand insert = new SqlCommand($"INSERT INTO BonusuriPedepse (IDContractAngajare, Valoare, Motiv, Data) VALUES (@IDContractAngajare,@Valoare,@Motiv,@Data); ", c.c);
                insert.Parameters.AddWithValue("@IDContractAngajare", Convert.ToInt32(comboBox1.SelectedValue.ToString()));
                insert.Parameters.AddWithValue("@Valoare", Convert.ToInt32(textBox1.Text));
                insert.Parameters.AddWithValue("@Motiv", richTextBox1.Text);
                insert.Parameters.AddWithValue("@Data", DateTime.Today.ToString("yyyy-MM-dd"));
                insert.ExecuteNonQuery();
                c.c.Close();
                this.Close();
            }
            else MessageBox.Show("Nu ati completat unul din cinpurile Valoare , Motiv sau nu ati selectat Angajatul!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
