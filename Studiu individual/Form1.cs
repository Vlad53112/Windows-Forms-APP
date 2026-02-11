using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;

namespace Studiu_individual;

public partial class Form1 : Form
{
    Conecsiune c = new Conecsiune();
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Aprovizionator v = new Aprovizionator(1004);
        v.Show();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        Contabil v = new Contabil(1003);
        v.Show();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        Vizator v = new Vizator(1002);
        v.Show();
    }


    private void button4_Click(object sender, EventArgs e)
    {
        Administrator a = new Administrator(1013);
        a.Show();
    }

    private void button5_Click(object sender, EventArgs e)
    {
        c.c.Open();
        SqlCommand Verificare = new SqlCommand($"SELECT Angajati.IDAngajati,Functie.Functie From Angajati JOIN ContractAngajare ON ContractAngajare.IDAngajat = Angajati.IDAngajati Join Functie on ContractAngajare.IDFunctie = Functie.IDFunctie Where Angajati.PostaElectronica = '{textBox1.Text}' and Angajati.Parola = '{textBox2.Text}'", c.c);
        SqlDataAdapter adaptVe = new SqlDataAdapter(Verificare);
        DataSet setVe = new DataSet();
        adaptVe.Fill(setVe);
        DataGridView a = new DataGridView();
        a.DataSource = setVe.Tables[0];
        c.c.Close();
        this.Controls.Add(a);
        a.Visible = false;
        if (a.Rows.Count > 1)
        {
            if (a.Rows[0].Cells[1].Value.ToString() == "Vinzator")
            {
                Vizator v = new Vizator(Convert.ToInt32(a.Rows[0].Cells[0].Value.ToString()));
                this.Visible = false;
                v.ShowDialog();
                this.Close();
            }
            else if (a.Rows[0].Cells[1].Value.ToString() == "Administrator")
            {
                Administrator v = new Administrator(Convert.ToInt32(a.Rows[0].Cells[0].Value.ToString()));
                this.Visible = false;
                v.ShowDialog();
                this.Close();
            }
            else if (a.Rows[0].Cells[1].Value.ToString() == "Aprovizionator")
            {
                Aprovizionator v = new Aprovizionator(Convert.ToInt32(a.Rows[0].Cells[0].Value.ToString()));
                this.Visible = false;
                v.ShowDialog();
                this.Close();
            }
            else if (a.Rows[0].Cells[1].Value.ToString() == "Contabil")
            {
                Contabil v = new Contabil(Convert.ToInt32(a.Rows[0].Cells[0].Value.ToString()));
                this.Visible = false;
                v.ShowDialog();
                this.Close();
            }
        }
        else MessageBox.Show("Ati introdus gresit parola sau posta electronica!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }
}
