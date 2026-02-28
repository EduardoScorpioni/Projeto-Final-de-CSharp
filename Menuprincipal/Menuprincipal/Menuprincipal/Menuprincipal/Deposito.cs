using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Menuprincipal
{
    public partial class Deposito : Form
    {
        public Deposito()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");
            }

            else
            {
                Dados dados = new Dados();
                dados.nome = textBox1.Text;
                dados.celular = textBox2.Text;
                dados.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
