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
    public partial class Dados : Form
    {
        public Dados()
        {
            InitializeComponent();
        }

        //área de declaração de variáveis GLOBAIS ou PÚBLICAS

        public string nome, celular;
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = nome;
            textBox2.Text = celular;
        }

        private void Dados_Load(object sender, EventArgs e)
        {
            textBox3.Text = nome;
            textBox4.Text = celular;
        }
    }
}
