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
    public partial class ComboBox : Form
    {
        public ComboBox()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Selecione alguma opção");
            }
            else
                if (comboBox1.Text == "1-Alunos")
                {
                    MessageBox.Show("Você selecionou ALUNOS");
                }
                    else
                       if (comboBox1.Text == "2-Professores")
                       {
                           MessageBox.Show("Você selecionou PROFESSORES");
                       }

                        else
                           if (comboBox1.Text == "3-Pais")
                           {
                               MessageBox.Show("Você selecionou PAIS");
                           }

                           else
                               if (comboBox1.Text == "4-Diretores")
                               {
                                   MessageBox.Show("Você selecionou DIRETORES");
                               }
        }
    }
}
