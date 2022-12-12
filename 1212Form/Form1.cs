using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _1212Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nev.Text))
            {
                MessageBox.Show("Nem adott meg nevet!");
                return;
            }
            if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Nem adott meg szöveget!");
                return;
            }
            saveFileDialog1.Filter = "Szöveg fájl|*.txt| Vesszővel tagolt szövegfájl (*.csv) |*.csv|minden fájl|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string szoveg = string.Join(";", nev.Text, richTextBox1.Text, datum.Value);
                string kivFile = saveFileDialog1.FileName;
                File.WriteAllText(kivFile, szoveg);
                MessageBox.Show("A kiválasztott fájl:" + kivFile);
                nev.Text = "";
                richTextBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva!");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string kivFile = openFileDialog1.FileName;
                string beolvasottSzoveg = File.ReadAllText(kivFile);
                string[] adatok = beolvasottSzoveg.Split(';');
                nev.Text = adatok[0];
                richTextBox1.Text = adatok[1];
                datum.Text = adatok[2];
            }
        }
    }
}
