using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Studiu_individual
{
    public partial class Parola : Form
    {
        Cabinet_Personal c;
        int cod;
        public Parola(Cabinet_Personal ca, int a)
        {
            InitializeComponent();
            c = ca;
            cod = a;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cod == 1)
                if (textBox2.Text.Length != 9) { MessageBox.Show("Ati Introdus gresit numarul de telefon!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBox2.Text = ""; }
                else
                {
                    c.update = textBox2.Text;
                    this.Close();
                }
            if (cod == 2)
                if (textBox1.Text.Length < 8) MessageBox.Show("Parola trebuie sa contina minim 8 caractere!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (textBox1.Text.Length > 15) MessageBox.Show("Parola nu trebuie sa depaseasca 15 caractere!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (!Regex.IsMatch(textBox1.Text, "[a-z]")) MessageBox.Show("Parola trebuie sa contina cel putin o litera mica!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (!Regex.IsMatch(textBox1.Text, "[A-Z]")) MessageBox.Show("Parola trebuie sa contina cel putin o litera Mare!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (!Regex.IsMatch(textBox1.Text, "[0-9]")) MessageBox.Show("Parola trebuie sa contina cel putin o cifra!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (!Regex.IsMatch(textBox1.Text, "[!-/:-@[-`{-~]")) MessageBox.Show("Parola trebuie sa contina cel putin un caracter special!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (textBox1.Text != textBox2.Text) MessageBox.Show("Cinpul parola se deosebeste de confirmare!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    c.update = textBox2.Text;
                    this.Close();
                }
            if (cod == 3)
                if (textBox2.Text.Length > 20 || !Regex.IsMatch(textBox2.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) MessageBox.Show("Ati depasit numarul de caractere pentru cinpul Posta Electronica sau ati introduso gresit!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    c.update = textBox2.Text;
                    this.Close();
                }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cod == 1)
                if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[0-9\b]$"))
                    e.Handled = true;
        }

        private void Parola_Load(object sender, EventArgs e)
        {
            if (cod == 1)
            {
                textBox1.Visible = false;
                textBox2.PlaceholderText = "Itroduceti Numarul de telefon";
            }
            if (cod == 2) 
            {
                textBox1.PlaceholderText = "Introducetii Parola";
                textBox2.PlaceholderText = "Confirmare Parola";
            }
            if (cod == 3) 
            {
                textBox1.Visible = false;
                textBox2.PlaceholderText = "Posta electronica";
            }
        }
    }
}
