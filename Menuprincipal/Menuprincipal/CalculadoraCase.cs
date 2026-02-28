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
    public partial class CalculadoraCase : Form
    {
        public CalculadoraCase()
        {
            InitializeComponent();
        }
        // variaveis globais
        int opcao = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Informe o primeiro valor.");
                textBox1.Focus();
            }
            else
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Informe o segundo valor.");
                    textBox2.Focus();
                }
                else
                    if (opcao == 0)
                    {
                        MessageBox.Show("Selecione uma operação.");
                    }
                    else
                    {
                        double n1, n2, result = 0;

                        n1 = double.Parse(textBox1.Text);
                        n2 = double.Parse(textBox2.Text);

                        switch (opcao)
                        { 
                           
                            case 1:
                                result = n1 + n2;
                                textBox3.Text = Convert.ToString(result);
                            break;

                            case 2:
                            
                            if (n1 >= n2)
                            {
                                result = n1 - n2;
                                textBox3.Text = Convert.ToString(result);
                            }
                            else
                                if (n1 < n2)
                                {
                                    result = n2 - n1;
                                    textBox3.Text = Convert.ToString(result);
                                }

                            break;

                            case 3:
                            result = n1 * n2;
                            textBox3.Text = Convert.ToString(result);
                            break;

                            case 4:
                            if (n1 == 0)
                            {
                                MessageBox.Show("O primeiro valor informado é inválido, digite um número diferente de 0.");
                                textBox1.Clear();
                                textBox1.Focus();
                            }
                            else
                            if (n2 == 0)
                            {
                                MessageBox.Show("O segundo valor informado é inválido, digite um número diferente de 0.");
                                textBox2.Clear();
                                textBox2.Focus();
                            }
                            else
                            {
                                result = n1 / n2;
                                textBox3.Text = Convert.ToString(result);
                            }
                            break;

                        }
                    }
            
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            //Divisão
            opcao = 4;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //Multiplicação
            opcao = 3;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //Subtração
            opcao = 2;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //Adição
            opcao = 1;
        }

        
    }
}
