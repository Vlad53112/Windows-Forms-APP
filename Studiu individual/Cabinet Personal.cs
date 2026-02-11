using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Studiu_individual
{
    public partial class Cabinet_Personal : Form
    {
        private int cod;
        public Cabinet_Personal(int a)
        {
            InitializeComponent();
            cod = a;
        }
        Conecsiune c = new Conecsiune();
        private void Cabinet_Personal_Load(object sender, EventArgs e)
        {
            c.c.Open();
            SqlCommand Produs = new SqlCommand($"SELECT Angajati.Nume,Angajati.Prenume,Angajati.PostaElectronica,Angajati.NrTelefon,Angajati.Parola,Salariu.Salariu,Functie.Functie From Angajati JOIN ContractAngajare ON ContractAngajare.IDAngajat = Angajati.IDAngajati Join Salariu on Salariu.IDContractAngajare = ContractAngajare.IDContractAngajare Join Functie on ContractAngajare.IDFunctie = Functie.IDFunctie Where Angajati.IDAngajati = {cod}", c.c);
            SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
            DataSet setPr = new DataSet();
            adaptPr.Fill(setPr);
            DataGridView a = new DataGridView();
            a.DataSource = setPr.Tables[0];
            this.Controls.Add(a);
            label1.Text += a.Rows[0].Cells[0].Value.ToString() + " " + a.Rows[0].Cells[1].Value.ToString();
            label6.Text += a.Rows[0].Cells[2].Value.ToString();
            label5.Text += a.Rows[0].Cells[3].Value.ToString();
            label4.Text += a.Rows[0].Cells[4].Value.ToString();
            label2.Text += a.Rows[0].Cells[5].Value.ToString();
            label3.Text += a.Rows[0].Cells[6].Value.ToString();
            a.Visible = false;
            c.c.Close();
        }
        public string update;
        private void modificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Parola p = new Parola(this, 1);
            p.ShowDialog();
            c.c.Open();
            SqlCommand updat = new SqlCommand($"UPDATE Angajati SET NrTelefon = '{update}' WHERE IDAngajati ={cod};", c.c);
            updat.ExecuteNonQuery();
            c.c.Close();
            c.c.Open();
            SqlCommand Produs = new SqlCommand($"SELECT Angajati.Nume,Angajati.Prenume,Angajati.PostaElectronica,Angajati.NrTelefon,Angajati.Parola,Salariu.Salariu,Functie.Functie From Angajati JOIN ContractAngajare ON ContractAngajare.IDAngajat = Angajati.IDAngajati Join Salariu on Salariu.IDContractAngajare = ContractAngajare.IDContractAngajare Join Functie on ContractAngajare.IDFunctie = Functie.IDFunctie Where Angajati.IDAngajati = {cod}", c.c);
            SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
            DataSet setPr = new DataSet();
            adaptPr.Fill(setPr);
            DataGridView a = new DataGridView();
            a.DataSource = setPr.Tables[0];
            this.Controls.Add(a);
            label5.Text = "Numar telefon: " + a.Rows[0].Cells[3].Value.ToString();
            a.Visible = false;
            c.c.Close();
        }

        private void modificaParolaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Parola p = new Parola(this, 2);
            p.ShowDialog();
            c.c.Open();
            SqlCommand updat = new SqlCommand($"UPDATE Angajati SET NrTelefon = '{update}' WHERE IDAngajati ={cod};", c.c);
            updat.ExecuteNonQuery();
            c.c.Close();
            c.c.Open();
            SqlCommand Produs = new SqlCommand($"SELECT Angajati.Nume,Angajati.Prenume,Angajati.PostaElectronica,Angajati.NrTelefon,Angajati.Parola,Salariu.Salariu,Functie.Functie From Angajati JOIN ContractAngajare ON ContractAngajare.IDAngajat = Angajati.IDAngajati Join Salariu on Salariu.IDContractAngajare = ContractAngajare.IDContractAngajare Join Functie on ContractAngajare.IDFunctie = Functie.IDFunctie Where Angajati.IDAngajati = {cod}", c.c);
            SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
            DataSet setPr = new DataSet();
            adaptPr.Fill(setPr);
            DataGridView a = new DataGridView();
            a.DataSource = setPr.Tables[0];
            this.Controls.Add(a);
            label5.Text = "Numar telefon: " + a.Rows[0].Cells[3].Value.ToString();
            a.Visible = false;
            c.c.Close();
        }

        private void modificaPostaElectronicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Parola p = new Parola(this, 3);
            p.ShowDialog();
            c.c.Open();
            SqlCommand updat = new SqlCommand($"UPDATE Angajati SET NrTelefon = '{update}' WHERE IDAngajati ={cod};", c.c);
            updat.ExecuteNonQuery();
            c.c.Close();
            c.c.Open();
            SqlCommand Produs = new SqlCommand($"SELECT Angajati.Nume,Angajati.Prenume,Angajati.PostaElectronica,Angajati.NrTelefon,Angajati.Parola,Salariu.Salariu,Functie.Functie From Angajati JOIN ContractAngajare ON ContractAngajare.IDAngajat = Angajati.IDAngajati Join Salariu on Salariu.IDContractAngajare = ContractAngajare.IDContractAngajare Join Functie on ContractAngajare.IDFunctie = Functie.IDFunctie Where Angajati.IDAngajati = {cod}", c.c);
            SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
            DataSet setPr = new DataSet();
            adaptPr.Fill(setPr);
            DataGridView a = new DataGridView();
            a.DataSource = setPr.Tables[0];
            this.Controls.Add(a);
            label5.Text = "Numar telefon: " + a.Rows[0].Cells[3].Value.ToString();
            a.Visible = false;
            c.c.Close();
        }
    }
}
