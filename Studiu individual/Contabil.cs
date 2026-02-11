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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace Studiu_individual
{
    public partial class Contabil : Form
    {
        Conecsiune c = new Conecsiune();
        string selectVinzari = "SELECT Vinzari.IDVinzari,Contract.DenumireProdus as 'Denumire Produs',Furnizor.DenumireFurnizor as 'Denumire Furnizor',Filiala.Denumire as 'Denumire Filiala', Angajati.Nume as 'Angajat Nume', Angajati.Prenume as 'Angajat Prenume',Vinzari.Cantitate, Vinzari.Pret_Unitate + Vinzari.Cantitate as 'Pret', Vinzari.DataVinzarii as 'Data Vinzarii' FROM Contract JOIN Furnizor ON Contract.IDFurnizor = Furnizor.IDFurnizor JOIN Filiala ON Contract.IDFiliala = Filiala.IDFiliala JOIN Vinzari ON Vinzari.IDContract = Contract.IDContract JOIN Angajati ON Vinzari.IDAngajat = Angajati.IDAngajati";
        string selectAngajati = "SELECT Angajati.IDAngajati,(Angajati.Nume + ' ' + Angajati.Prenume) as 'Nume Prenume',Filiala.Denumire as 'Denumire Filiala',Functie.Functie,Salariu.Salariu,SUM(BonusuriPedepse.Valoare) as 'Total Bonusuri si Pedepse' FROM Angajati JOIN ContractAngajare ON Angajati.IDAngajati = ContractAngajare.IDAngajat JOIN Functie ON Functie.IDFunctie = ContractAngajare.IDFunctie JOIN Salariu ON Salariu.IDContractAngajare = ContractAngajare.IDContractAngajare LEFT JOIN BonusuriPedepse ON BonusuriPedepse.IDContractAngajare = ContractAngajare.IDContractAngajare JOIN Filiala ON Filiala.IDFiliala = Angajati.IDFiliala ";
        string selectAngajatiGrup = "GROUP BY Angajati.IDAngajati, Angajati.Nume, Angajati.Prenume, Filiala.Denumire, Functie.Functie, Salariu.Salariu";
        string selectAprovizionare = "SELECT Contract.IDContract, Contract.DenumireProdus as 'Denumire Produs', Contract.Descriere, Categorie.Categorie, Furnizor.DenumireFurnizor as 'Denumire Furnizor', Filiala.Denumire as 'Denumire Filiala', Contract.CantitateFurnizor as 'Cantitate', Contract.Pret_Unitate as 'Pret Unitate', Contract.DataContract as 'Data Aprovizionzrii' FROM Contract JOIN Categorie ON Contract.IDCategorie = Categorie.IDCategorie JOIN Furnizor ON Contract.IDFurnizor = Furnizor.IDFurnizor JOIN Filiala ON Contract.IDFiliala = Filiala.IDFiliala";
        int id;
        public Contabil(int i)
        {
            InitializeComponent();
            id = i;
        }
        int afisare = 1;
        private void Contabil_Load(object sender, EventArgs e)
        {
            comboBox3.Visible = true;
            dataGridView1.Top = 85;
            dataGridView1.Left = 0;
            dataGridView1.Height = this.Height - 125;
            dataGridView1.Width = this.Width - 20;
            c.c.Open();
            SqlCommand Produs = new SqlCommand(selectVinzari + " ORDER BY 'Denumire Produs';", c.c);
            SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
            DataSet setPr = new DataSet();
            adaptPr.Fill(setPr);
            dataGridView1.DataSource = setPr.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            for (int i = 1; i <= 5; i++) dataGridView1.Columns[i].Width = 170;
            for (int i = 5; i <= 8; i++) dataGridView1.Columns[i].Width = 100;
            c.c.Close();
            c.c.Open();
            SqlCommand Furnizori = new SqlCommand("Select IDFurnizor,DenumireFurnizor From Furnizor ORDER BY DenumireFurnizor", c.c);
            SqlDataAdapter adaptFu = new SqlDataAdapter(Furnizori);
            DataSet setFU = new DataSet();
            adaptFu.Fill(setFU);
            comboBox3.DataSource = null;
            comboBox3.DataSource = setFU.Tables[0];
            comboBox3.ValueMember = "IDFurnizor";
            comboBox3.DisplayMember = "DenumireFurnizor";
            comboBox3.Text = "Furnizorii";
            c.c.Close();
            c.c.Open();
            SqlCommand Filiala = new SqlCommand("Select IDFiliala,Denumire From Filiala ORDER BY Denumire", c.c);
            SqlDataAdapter adaptFi = new SqlDataAdapter(Filiala);
            DataSet setFi = new DataSet();
            adaptFi.Fill(setFi);
            comboBox2.DataSource = null;
            comboBox2.DataSource = setFi.Tables[0];
            comboBox2.ValueMember = "IDFiliala";
            comboBox2.DisplayMember = "Denumire";
            comboBox2.Text = "Filiale";
            c.c.Close();
            c.c.Open();
            SqlCommand angajati = new SqlCommand("Select IDAngajati,(Nume + ' ' + Prenume) as Numee From Angajati ORDER BY Numee", c.c);
            SqlDataAdapter adaptAg = new SqlDataAdapter(angajati);
            DataSet setAg = new DataSet();
            adaptAg.Fill(setAg);
            comboBox1.DataSource = null;
            comboBox1.DataSource = setAg.Tables[0];
            comboBox1.ValueMember = "IDAngajati";
            comboBox1.DisplayMember = "Numee";
            comboBox1.Text = "Angajatii";
            c.c.Close();
        }

        private void Contabil_Resize(object sender, EventArgs e)
        {
            if (afisare == 1)
                if (this.Width - 20 > 1223)
                    for (int i = 1; i <= 5; i++) dataGridView1.Columns[i].Width = 170 + (this.Width - 1243) / 5;
            if (afisare == 3)
                if (this.Width - 20 > 1413)
                    dataGridView1.Columns[2].Width = this.Width - 1063;
            dataGridView1.Height = this.Height - 125;
            dataGridView1.Width = this.Width - 20;
            textCaut.Width = this.Width - 128;
            butCaut.Left = this.Width - 110;
            button1.Left = this.Width - 204;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (afisare == 1)
            {
                c.c.Open();
                SqlCommand Produs = new SqlCommand(selectVinzari + $" WHERE Angajati.IDAngajati = {Convert.ToInt32(comboBox1.SelectedValue.ToString())};", c.c);
                SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
                DataSet setPr = new DataSet();
                adaptPr.Fill(setPr);
                dataGridView1.DataSource = setPr.Tables[0];
                c.c.Close();
            }
            if (afisare == 2)
            {
                c.c.Open();
                SqlCommand Produs = new SqlCommand(selectAngajati + $" WHERE Functie.IDFunctie = {Convert.ToInt32(comboBox1.SelectedValue.ToString())} " + selectAngajatiGrup, c.c);
                SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
                DataSet setPr = new DataSet();
                adaptPr.Fill(setPr);
                dataGridView1.DataSource = setPr.Tables[0];
                c.c.Close();
            }
            if (afisare == 3)
            {
                c.c.Open();
                SqlCommand Produs = new SqlCommand(selectAprovizionare + $" WHERE Contract.IDFurnizor = {Convert.ToInt32(comboBox1.SelectedValue.ToString())};", c.c);
                SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
                DataSet setPr = new DataSet();
                adaptPr.Fill(setPr);
                dataGridView1.DataSource = setPr.Tables[0];
                c.c.Close();
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (afisare == 1)
            {
                c.c.Open();
                SqlCommand Produs = new SqlCommand(selectVinzari + $" WHERE Filiala.IDFiliala = {Convert.ToInt32(comboBox2.SelectedValue.ToString())};", c.c);
                SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
                DataSet setPr = new DataSet();
                adaptPr.Fill(setPr);
                dataGridView1.DataSource = setPr.Tables[0];
                c.c.Close();
            }
            if (afisare == 2)
            {
                c.c.Open();
                SqlCommand Produs = new SqlCommand(selectAngajati + $" WHERE Filiala.IDFiliala = {Convert.ToInt32(comboBox2.SelectedValue.ToString())} " + selectAngajatiGrup, c.c);
                SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
                DataSet setPr = new DataSet();
                adaptPr.Fill(setPr);
                dataGridView1.DataSource = setPr.Tables[0];
                c.c.Close();
            }
            if (afisare == 3)
            {
                c.c.Open();
                SqlCommand Produs = new SqlCommand(selectAprovizionare + $" WHERE Contract.IDFiliala = {Convert.ToInt32(comboBox2.SelectedValue.ToString())};", c.c);
                SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
                DataSet setPr = new DataSet();
                adaptPr.Fill(setPr);
                dataGridView1.DataSource = setPr.Tables[0];
                c.c.Close();
            }
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (afisare == 1)
            {
                c.c.Open();
                SqlCommand Produs = new SqlCommand(selectVinzari + $" WHERE Furnizor.IDFurnizor = {Convert.ToInt32(comboBox3.SelectedValue.ToString())};", c.c);
                SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
                DataSet setPr = new DataSet();
                adaptPr.Fill(setPr);
                dataGridView1.DataSource = setPr.Tables[0];
                c.c.Close();
            }
            if (afisare == 3)
            {
                c.c.Open();
                SqlCommand Produs = new SqlCommand(selectAprovizionare + $" WHERE Contract.IDCategorie = {Convert.ToInt32(comboBox3.SelectedValue.ToString())};", c.c);
                SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
                DataSet setPr = new DataSet();
                adaptPr.Fill(setPr);
                dataGridView1.DataSource = setPr.Tables[0];
                c.c.Close();
            }
        }

        private void vinzariiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textCaut.Text = "";
            comboBox3.Visible = true;
            c.c.Open();
            SqlCommand Produs = new SqlCommand(selectVinzari + " ORDER BY 'Denumire Produs';", c.c);
            SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
            DataSet setPr = new DataSet();
            adaptPr.Fill(setPr);
            dataGridView1.DataSource = setPr.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            if (this.Width - 20 > 1223)
                for (int i = 1; i <= 5; i++) dataGridView1.Columns[i].Width = 170 + (this.Width - 1243) / 5;
            else for (int i = 1; i <= 5; i++) dataGridView1.Columns[i].Width = 170;
            for (int i = 5; i <= 7; i++) dataGridView1.Columns[i].Width = 100;
            dataGridView1.Columns[8].Width = 150;
            c.c.Close();
            c.c.Open();
            SqlCommand Furnizori = new SqlCommand("Select IDFurnizor,DenumireFurnizor From Furnizor ORDER BY DenumireFurnizor", c.c);
            SqlDataAdapter adaptFu = new SqlDataAdapter(Furnizori);
            DataSet setFU = new DataSet();
            adaptFu.Fill(setFU);
            comboBox3.DataSource = null;
            comboBox3.DataSource = setFU.Tables[0];
            comboBox3.ValueMember = "IDFurnizor";
            comboBox3.DisplayMember = "DenumireFurnizor";
            comboBox3.Text = "Furnizorii";
            c.c.Close();
            c.c.Open();
            SqlCommand Filiala = new SqlCommand("Select IDFiliala,Denumire From Filiala ORDER BY Denumire", c.c);
            SqlDataAdapter adaptFi = new SqlDataAdapter(Filiala);
            DataSet setFi = new DataSet();
            adaptFi.Fill(setFi);
            comboBox2.DataSource = null;
            comboBox2.DataSource = setFi.Tables[0];
            comboBox2.ValueMember = "IDFiliala";
            comboBox2.DisplayMember = "Denumire";
            comboBox2.Text = "Filiale";
            c.c.Close();
            c.c.Open();
            SqlCommand angajati = new SqlCommand("Select IDAngajati,(Nume + ' ' + Prenume) as Numee From Angajati ORDER BY Numee", c.c);
            SqlDataAdapter adaptAg = new SqlDataAdapter(angajati);
            DataSet setAg = new DataSet();
            adaptAg.Fill(setAg);
            comboBox1.DataSource = null;
            comboBox1.DataSource = setAg.Tables[0];
            comboBox1.ValueMember = "IDAngajati";
            comboBox1.DisplayMember = "Numee";
            comboBox1.Text = "Angajatii";
            c.c.Close();
            textCaut.PlaceholderText = "Produs Denumire";
            afisare = 1;
        }

        private void angajatiiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textCaut.Text = "";
            c.c.Open();
            SqlCommand Produs = new SqlCommand(selectAngajati + selectAngajatiGrup + " ORDER BY 'Nume Prenume';", c.c);
            SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
            DataSet setPr = new DataSet();
            adaptPr.Fill(setPr);
            dataGridView1.DataSource = setPr.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[2].Width = 170;
            dataGridView1.Columns[3].Width = 170;
            dataGridView1.Columns[4].Width = 70;
            dataGridView1.Columns[5].Width = 70;
            c.c.Close();
            comboBox3.Visible = false;
            c.c.Open();
            SqlCommand Filiala = new SqlCommand("Select IDFiliala,Denumire From Filiala ORDER BY Denumire", c.c);
            SqlDataAdapter adaptFi = new SqlDataAdapter(Filiala);
            DataSet setFi = new DataSet();
            adaptFi.Fill(setFi);
            comboBox2.DataSource = null;
            comboBox2.DataSource = setFi.Tables[0];
            comboBox2.ValueMember = "IDFiliala";
            comboBox2.DisplayMember = "Denumire";
            comboBox2.Text = "Filiale";
            c.c.Close();
            c.c.Open();
            SqlCommand Functii = new SqlCommand("Select IDFunctie,Functie From Functie ORDER BY Functie", c.c);
            SqlDataAdapter adaptFu = new SqlDataAdapter(Functii);
            DataSet setFu = new DataSet();
            adaptFu.Fill(setFu);
            comboBox1.DataSource = null;
            comboBox1.DataSource = setFu.Tables[0];
            comboBox1.ValueMember = "IDFunctie";
            comboBox1.DisplayMember = "Functie";
            comboBox1.Text = "Functii";
            c.c.Close();
            textCaut.PlaceholderText = "Nume Prenume Angajat";
            afisare = 2;
        }

        private void butCaut_Click(object sender, EventArgs e)
        {
            if (afisare == 1)
            {
                c.c.Open();
                SqlCommand Produs = new SqlCommand(selectVinzari + $" WHERE Contract.DenumireProdus LIKE '%{textCaut.Text}%';", c.c);
                SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
                DataSet setPr = new DataSet();
                adaptPr.Fill(setPr);
                dataGridView1.DataSource = setPr.Tables[0];
                c.c.Close();
            }
            if (afisare == 2)
            {
                c.c.Open();
                SqlCommand Produs = new SqlCommand(selectAngajati + $" WHERE Angajati.Nume LIKE '%{textCaut.Text}%' OR Angajati.Prenume LIKE '%{textCaut.Text}%'" + selectAngajatiGrup, c.c);
                SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
                DataSet setPr = new DataSet();
                adaptPr.Fill(setPr);
                dataGridView1.DataSource = setPr.Tables[0];
                c.c.Close();
            }
            if (afisare == 3)
            {
                c.c.Open();
                SqlCommand Produs = new SqlCommand(selectAprovizionare + $" WHERE Contract.DenumireProdus LIKE '%{textCaut.Text}%';", c.c);
                SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
                DataSet setPr = new DataSet();
                adaptPr.Fill(setPr);
                dataGridView1.DataSource = setPr.Tables[0];
                c.c.Close();
            }
        }

        private void aprovizionareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textCaut.Text = "";
            comboBox3.Visible = true;
            c.c.Open();
            SqlCommand scad = new SqlCommand("SELECT IDContract, Cantitate FROM Vinzari", c.c);
            SqlDataAdapter adaptSC = new SqlDataAdapter(scad);
            DataSet setSC = new DataSet();
            adaptSC.Fill(setSC);
            c.c.Close();
            c.c.Open();
            SqlCommand Produs = new SqlCommand(selectAprovizionare + " ORDER BY 'Denumire Produs';", c.c);
            SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
            DataSet setPr = new DataSet();
            adaptPr.Fill(setPr);
            dataGridView1.DataSource = setPr.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 170;
            if (this.Width - 20 > 1413)
                dataGridView1.Columns[2].Width = this.Width - 1063;
            else dataGridView1.Columns[2].Width = 350;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 170;
            dataGridView1.Columns[5].Width = 170;
            dataGridView1.Columns[6].Width = 100;
            foreach (DataGridViewRow rindProdus in dataGridView1.Rows)
                foreach (DataRow rindVind in setSC.Tables[0].Rows)
                    if (Convert.ToInt32(rindProdus.Cells[0].Value) == Convert.ToInt32(rindVind["IDContract"]))
                        rindProdus.Cells[6].Value = Convert.ToInt32(rindProdus.Cells[6].Value) - Convert.ToInt32(rindVind["Cantitate"]);
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[8].Width = 150;
            c.c.Close();
            c.c.Open();
            SqlCommand categorie = new SqlCommand("Select * From Categorie ORDER BY Categorie", c.c);
            SqlDataAdapter adaptCa = new SqlDataAdapter(categorie);
            DataSet setCa = new DataSet();
            adaptCa.Fill(setCa);
            comboBox3.DataSource = null;
            comboBox3.DataSource = setCa.Tables[0];
            comboBox3.ValueMember = "IDCategorie";
            comboBox3.DisplayMember = "Categorie";
            comboBox3.Text = "Categori";
            c.c.Close();
            c.c.Open();
            SqlCommand Filiala = new SqlCommand("Select IDFiliala,Denumire From Filiala ORDER BY Denumire", c.c);
            SqlDataAdapter adaptFi = new SqlDataAdapter(Filiala);
            DataSet setFi = new DataSet();
            adaptFi.Fill(setFi);
            comboBox2.DataSource = null;
            comboBox2.DataSource = setFi.Tables[0];
            comboBox2.ValueMember = "IDFiliala";
            comboBox2.DisplayMember = "Denumire";
            comboBox2.Text = "Filiale";
            c.c.Close();
            c.c.Open();
            SqlCommand Furnizori = new SqlCommand("Select IDFurnizor,DenumireFurnizor From Furnizor ORDER BY DenumireFurnizor", c.c);
            SqlDataAdapter adaptFu = new SqlDataAdapter(Furnizori);
            DataSet setFU = new DataSet();
            adaptFu.Fill(setFU);
            comboBox1.DataSource = null;
            comboBox1.DataSource = setFU.Tables[0];
            comboBox1.ValueMember = "IDFurnizor";
            comboBox1.DisplayMember = "DenumireFurnizor";
            comboBox1.Text = "Furnizori";
            c.c.Close();
            textCaut.PlaceholderText = "Denumire Produs";
            afisare = 3;
        }

        private void textCaut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zA-Z\b]$"))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cabinet_Personal ca = new Cabinet_Personal(id);
            this.Visible = false;
            ca.ShowDialog();
            this.Visible = true;
        }
    }
}
