using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Studiu_individual
{
    public partial class Administrator : Form
    {
        Conecsiune c = new Conecsiune();
        int id;
        string selectProdus = "SELECT Contract.IDContract,Contract.DenumireProdus as 'Denumire Produs',Contract.Descriere,Categorie.Categorie,Furnizor.DenumireFurnizor as 'Denumire Furnizor',Filiala.Denumire as 'Denumire Filiala', Contract.CantitateFurnizor as 'Cantitate',Contract.Pret_Unitate as 'Pret Unitate', Contract.DataContract as 'Data Aprovizionzrii' FROM Contract JOIN Categorie ON Contract.IDCategorie = Categorie.IDCategorie JOIN Furnizor ON Contract.IDFurnizor = Furnizor.IDFurnizor JOIN Filiala ON Contract.IDFiliala = Filiala.IDFiliala";
        string selectVinzari = "SELECT Vinzari.IDVinzari,Contract.DenumireProdus as 'Denumire Produs',Furnizor.DenumireFurnizor as 'Denumire Furnizor',Filiala.Denumire as 'Denumire Filiala', Angajati.Nume as 'Angajat Nume', Angajati.Prenume as 'Angajat Prenume',Vinzari.Cantitate, Vinzari.Pret_Unitate + Vinzari.Cantitate as 'Pret', Vinzari.DataVinzarii as 'Data Vinzarii' FROM Contract JOIN Furnizor ON Contract.IDFurnizor = Furnizor.IDFurnizor JOIN Filiala ON Contract.IDFiliala = Filiala.IDFiliala JOIN Vinzari ON Vinzari.IDContract = Contract.IDContract JOIN Angajati ON Vinzari.IDAngajat = Angajati.IDAngajati";
        string selectAngajati = "SELECT Angajati.IDAngajati,(Angajati.Nume + ' ' + Angajati.Prenume) as 'Nume Prenume',Angajati.PostaElectronica as 'Posta Electronica',Angajati.NrTelefon as 'Numar Telefon',Filiala.Denumire as 'Denumire Filiala',Functie.Functie,Salariu.Salariu,SUM(BonusuriPedepse.Valoare) as 'Total Bonusuri si Pedepse',ContractAngajare.DataSemnariiContract as 'Data Semnarii Contract',ContractAngajare.DurataContract as 'Durata Contract' FROM Angajati JOIN ContractAngajare ON Angajati.IDAngajati = ContractAngajare.IDAngajat JOIN Functie ON Functie.IDFunctie = ContractAngajare.IDFunctie JOIN Salariu ON Salariu.IDContractAngajare = ContractAngajare.IDContractAngajare LEFT JOIN BonusuriPedepse ON BonusuriPedepse.IDContractAngajare = ContractAngajare.IDContractAngajare JOIN Filiala ON Filiala.IDFiliala = Angajati.IDFiliala GROUP BY Angajati.IDAngajati, Angajati.Nume, Angajati.Prenume, Filiala.Denumire, Functie.Functie, Salariu.Salariu, Angajati.PostaElectronica,Angajati.NrTelefon,ContractAngajare.DurataContract,ContractAngajare.DataSemnariiContract ";
        string selectFiliale = "SELECT Filiala.IDFiliala, Filiala.Denumire, (Adresa.Tara + ', ' + Adresa.Oras + ', ' + Adresa.Strada + ' ' + Adresa.NrBloc) as 'Adresa',Filiala.NrTelefon as 'Numar Telefon',Filiala.IBAN,DenumireBanca.DenumireBanca as 'Denumire Banca' FROM Filiala JOIN Adresa ON Filiala.IDAdresa = Adresa.IDAdresa JOIN DenumireBanca ON DenumireBanca.IDDenumireBanca = Filiala.IDDenumireBanca ";
        string selectFurnizori = "SELECT Furnizor.IDFurnizor, Furnizor.DenumireFurnizor, (Adresa.Tara + ', ' + Adresa.Oras + ', ' + Adresa.Strada + ' ' + Adresa.NrBloc) as 'Adresa',Furnizor.Telefon as 'Numar Telefon',Furnizor.PostaElecronica as 'Posta Elecronica',Furnizor.IBAN,DenumireBanca.DenumireBanca as 'Denumire Banca' FROM Furnizor JOIN Adresa ON Furnizor.IDAdresa = Adresa.IDAdresa JOIN DenumireBanca ON DenumireBanca.IDDenumireBanca = Furnizor.IDDenumireBanca ";
        int afisare = 1;
        public Administrator(int i)
        {
            InitializeComponent();
            id = i;
        }

        private void Administrator_Load(object sender, EventArgs e)
        {
            c.c.Open();
            SqlCommand scad = new SqlCommand("SELECT IDContract, Cantitate FROM Vinzari", c.c);
            SqlDataAdapter adaptSC = new SqlDataAdapter(scad);
            DataSet setSC = new DataSet();
            adaptSC.Fill(setSC);
            c.c.Close();
            c.c.Open();
            SqlCommand Produs = new SqlCommand(selectProdus + " ORDER BY 'Denumire Produs';", c.c);
            SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
            DataSet setPr = new DataSet();
            adaptPr.Fill(setPr);
            dataGridView1.DataSource = setPr.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[2].Width = 350;
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
        }

        private void produsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AdugareMarfa a = new AdugareMarfa();
            a.ShowDialog();
            afisare = 1;
            c.c.Open();
            SqlCommand scad = new SqlCommand("SELECT IDContract, Cantitate FROM Vinzari", c.c);
            SqlDataAdapter adaptSC = new SqlDataAdapter(scad);
            DataSet setSC = new DataSet();
            adaptSC.Fill(setSC);
            c.c.Close();
            c.c.Open();
            SqlCommand Produs = new SqlCommand(selectProdus + " ORDER BY 'Denumire Produs';", c.c);
            SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
            DataSet setPr = new DataSet();
            adaptPr.Fill(setPr);
            dataGridView1.DataSource = setPr.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[2].Width = 350;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cabinet_Personal ca = new Cabinet_Personal(id);
            this.Visible = false;
            ca.ShowDialog();
            this.Visible = true;
        }

        private void produseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            afisare = 1;
            c.c.Open();
            SqlCommand scad = new SqlCommand("SELECT IDContract, Cantitate FROM Vinzari", c.c);
            SqlDataAdapter adaptSC = new SqlDataAdapter(scad);
            DataSet setSC = new DataSet();
            adaptSC.Fill(setSC);
            c.c.Close();
            c.c.Open();
            SqlCommand Produs = new SqlCommand(selectProdus + " ORDER BY 'Denumire Produs';", c.c);
            SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
            DataSet setPr = new DataSet();
            adaptPr.Fill(setPr);
            dataGridView1.DataSource = setPr.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[2].Width = 350;
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
        }

        private void Administrator_Resize(object sender, EventArgs e)
        {
            if (afisare == 1)
                if (this.Width - 20 > 1403)
                    dataGridView1.Columns[2].Width = this.Width - 1073;
            if (afisare == 2)
                if (this.Width - 20 > 1238)
                    for (int i = 1; i <= 5; i++) dataGridView1.Columns[i].Width = 170 + (this.Width - 1258) / 5;
            if (afisare == 3)
                if (this.Width - 20 > 1133)
                {
                    for (int i = 1; i <= 2; i++) dataGridView1.Columns[i].Width = 170 + (this.Width - 1153) / 4;
                    for (int i = 4; i <= 5; i++) dataGridView1.Columns[i].Width = 170 + (this.Width - 1153) / 4;
                }
            if (afisare == 4)
                if (this.Width - 20 > 890)
                    for (int i = 1; i <= 5; i++) dataGridView1.Columns[i].Width = 170 + (this.Width - 910) / 5;
            if (afisare == 5)
                if (this.Width - 20 > 1060)
                    for (int i = 1; i <= 6; i++) dataGridView1.Columns[i].Width = 170 + (this.Width - 1080) / 6;
            dataGridView1.Height = this.Height - 105;
            dataGridView1.Width = this.Width - 20;
            button1.Left = this.Width - 187;
        }

        private void vinzareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vinzare a = new Vinzare();
            a.ShowDialog();
            afisare = 2;
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
        }

        private void angajatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            afisare = 3;
            c.c.Open();
            SqlCommand Produs = new SqlCommand(selectAngajati + " ORDER BY 'Nume Prenume';", c.c);
            SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
            DataSet setPr = new DataSet();
            adaptPr.Fill(setPr);
            dataGridView1.DataSource = setPr.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[2].Width = 170;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 170;
            dataGridView1.Columns[5].Width = 170;
            dataGridView1.Columns[6].Width = 70;
            dataGridView1.Columns[7].Width = 70;
            dataGridView1.Columns[8].Width = 100;
            dataGridView1.Columns[9].Width = 70;
            c.c.Close();
        }

        private void vinzariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            afisare = 2;
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
        }

        private void angajatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Angajati a = new Angajati();
            a.ShowDialog();
            afisare = 3;
            c.c.Open();
            SqlCommand Produs = new SqlCommand(selectAngajati + " ORDER BY 'Nume Prenume';", c.c);
            SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
            DataSet setPr = new DataSet();
            adaptPr.Fill(setPr);
            dataGridView1.DataSource = setPr.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[2].Width = 170;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 170;
            dataGridView1.Columns[5].Width = 170;
            dataGridView1.Columns[6].Width = 70;
            dataGridView1.Columns[7].Width = 70;
            dataGridView1.Columns[8].Width = 100;
            dataGridView1.Columns[9].Width = 70;
            c.c.Close();
        }

        private void bonusPedeapsaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BonusurPedepse a = new BonusurPedepse();
            a.ShowDialog();
            afisare = 3;
            c.c.Open();
            SqlCommand Produs = new SqlCommand(selectAngajati + " ORDER BY 'Nume Prenume';", c.c);
            SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
            DataSet setPr = new DataSet();
            adaptPr.Fill(setPr);
            dataGridView1.DataSource = setPr.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[2].Width = 170;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 170;
            dataGridView1.Columns[5].Width = 170;
            dataGridView1.Columns[6].Width = 70;
            dataGridView1.Columns[7].Width = 70;
            dataGridView1.Columns[8].Width = 100;
            dataGridView1.Columns[9].Width = 70;
            c.c.Close();
        }

        private void filiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            afisare = 4;
            c.c.Open();
            SqlCommand filiala = new SqlCommand(selectFiliale + " ORDER BY Filiala.Denumire;", c.c);
            SqlDataAdapter adaptFi = new SqlDataAdapter(filiala);
            DataSet setFi = new DataSet();
            adaptFi.Fill(setFi);
            dataGridView1.DataSource = setFi.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            for (int i = 1; i <= 5; i++)
                dataGridView1.Columns[i].Width = 170;
            c.c.Close();
        }

        private void furnizoriiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            afisare = 5;
            c.c.Open();
            SqlCommand furnizor = new SqlCommand(selectFurnizori + " ORDER BY Furnizor.DenumireFurnizor;", c.c);
            SqlDataAdapter adaptFu = new SqlDataAdapter(furnizor);
            DataSet setFu = new DataSet();
            adaptFu.Fill(setFu);
            dataGridView1.DataSource = setFu.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            for (int i = 1; i <= 6; i++)
                dataGridView1.Columns[i].Width = 170;
            c.c.Close();
        }

        private void stergereInterogareToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (afisare == 1)
                {
                    c.c.Open(); 
                    SqlCommand stergere = new SqlCommand($"DELETE FROM Contract WHERE IDContract = '{Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())}';", c.c);
                    stergere.ExecuteNonQuery();
                    c.c.Close();
                    c.c.Open();
                    SqlCommand scad = new SqlCommand("SELECT IDContract, Cantitate FROM Vinzari", c.c);
                    SqlDataAdapter adaptSC = new SqlDataAdapter(scad);
                    DataSet setSC = new DataSet();
                    adaptSC.Fill(setSC);
                    c.c.Close();
                    c.c.Open();
                    SqlCommand Produs = new SqlCommand(selectProdus + " ORDER BY 'Denumire Produs';", c.c);
                    SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
                    DataSet setPr = new DataSet();
                    adaptPr.Fill(setPr);
                    dataGridView1.DataSource = setPr.Tables[0];
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Width = 170;
                    dataGridView1.Columns[2].Width = 350;
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
                }
                if (afisare == 2)
                {
                    c.c.Open();
                    SqlCommand stergere = new SqlCommand($"DELETE FROM Vinzari WHERE IDVinzari = '{Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())}';", c.c);
                    stergere.ExecuteNonQuery();
                    c.c.Close();
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
                }
                if (afisare == 3)
                {
                    c.c.Open();
                    SqlCommand stergere = new SqlCommand($"DELETE FROM Angajati WHERE IDAngajati = '{Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())}';", c.c);
                    stergere.ExecuteNonQuery();
                    c.c.Close();
                    c.c.Open();
                    SqlCommand Produs = new SqlCommand(selectAngajati + " ORDER BY 'Nume Prenume';", c.c);
                    SqlDataAdapter adaptPr = new SqlDataAdapter(Produs);
                    DataSet setPr = new DataSet();
                    adaptPr.Fill(setPr);
                    dataGridView1.DataSource = setPr.Tables[0];
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Width = 170;
                    dataGridView1.Columns[2].Width = 170;
                    dataGridView1.Columns[3].Width = 100;
                    dataGridView1.Columns[4].Width = 170;
                    dataGridView1.Columns[5].Width = 170;
                    dataGridView1.Columns[6].Width = 70;
                    dataGridView1.Columns[7].Width = 70;
                    dataGridView1.Columns[8].Width = 100;
                    dataGridView1.Columns[9].Width = 70;
                    c.c.Close();
                }
                if (afisare == 4)
                {
                    c.c.Open();
                    SqlCommand stergere = new SqlCommand($"DELETE FROM Filiala WHERE IDFiliala = '{Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())}';", c.c);
                    stergere.ExecuteNonQuery();
                    c.c.Close();
                    c.c.Open();
                    SqlCommand filiala = new SqlCommand(selectFiliale + " ORDER BY Filiala.Denumire;", c.c);
                    SqlDataAdapter adaptFi = new SqlDataAdapter(filiala);
                    DataSet setFi = new DataSet();
                    adaptFi.Fill(setFi);
                    dataGridView1.DataSource = setFi.Tables[0];
                    dataGridView1.Columns[0].Visible = false;
                    for (int i = 1; i <= 5; i++)
                        dataGridView1.Columns[i].Width = 170;
                    c.c.Close();
                }
                if (afisare == 5)
                {
                    c.c.Open();
                    SqlCommand stergere = new SqlCommand($"DELETE FROM Furnizor WHERE IDFurnizor = '{Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())}';", c.c);
                    stergere.ExecuteNonQuery();
                    c.c.Close();
                    c.c.Open();
                    SqlCommand furnizor = new SqlCommand(selectFurnizori + " ORDER BY Furnizor.DenumireFurnizor;", c.c);
                    SqlDataAdapter adaptFu = new SqlDataAdapter(furnizor);
                    DataSet setFu = new DataSet();
                    adaptFu.Fill(setFu);
                    dataGridView1.DataSource = setFu.Tables[0];
                    dataGridView1.Columns[0].Visible = false;
                    for (int i = 1; i <= 6; i++)
                        dataGridView1.Columns[i].Width = 170;
                    c.c.Close();
                }
            }
            else
            {
                MessageBox.Show("Nu ati selectat nici un rind!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
