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
    public partial class Radio : Form
    {
        
        public Radio()
        {
            InitializeComponent();
        }

        //variaveis globais ou públicas

        int opcao = 0; //essa variavel controla o cargo do funcionario
        double salario;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Deseja voltar ao menu?", "Voltar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.Yes)
            {
                this.Close();
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;

            if (opcao == 1)
            {
                textBox4.Text = radioButton1.Text;

                if (comboBox1.Text == "50")
                {
                    textBox3.Text = comboBox1.Text;
                    salario = 50 * 100;
                    textBox5.Text = String.Format("R$ {0:###,###.00}", salario);
                }

                else
                    if (comboBox1.Text == "100")
                    {
                        textBox3.Text = comboBox1.Text;
                        salario = 100 * 100;
                        textBox5.Text = String.Format("R$ {0:###,###.00}", salario);
                    }

                    else
                        if (comboBox1.Text == "150")
                        {
                            textBox3.Text = comboBox1.Text;
                            salario = 150 * 100;
                            textBox5.Text = String.Format("R$ {0:###,###.00}", salario);
                        }

                        else
                            if (comboBox1.Text == "200")
                            {
                                textBox3.Text = comboBox1.Text;
                                salario = 200 * 100;
                                textBox5.Text = String.Format("R$ {0:###,###.00}", salario);
                            }
                 }


            else
            if (opcao == 2)
            {
                textBox4.Text = radioButton2.Text;

                if (comboBox1.Text == "50")
                {
                    textBox3.Text = comboBox1.Text;
                    salario = 50 * 80;
                    textBox5.Text = String.Format("R$ {0:###,###.00}", salario);
                }

                else
                    if (comboBox1.Text == "100")
                    {
                        textBox3.Text = comboBox1.Text;
                        salario = 100 * 80;
                        textBox5.Text = String.Format("R$ {0:###,###.00}", salario);
                    }

                    else
                        if (comboBox1.Text == "150")
                        {
                            textBox3.Text = comboBox1.Text;
                            salario = 150 * 80;
                            textBox5.Text = String.Format("R$ {0:###,###.00}", salario);
                        }

                        else
                            if (comboBox1.Text == "200")
                            {
                                textBox3.Text = comboBox1.Text;
                                salario = 200 * 80;
                                textBox5.Text = String.Format("R$ {0:###,###.00}", salario);
                            }

            }

            else
            if (opcao == 3)
            {
                textBox4.Text = radioButton3.Text;

                if (comboBox1.Text == "50")
                {
                    textBox3.Text = comboBox1.Text;
                    salario = 50 * 65;
                    textBox5.Text = String.Format("R$ {0:###,###.00}", salario);
                }

                else
                    if (comboBox1.Text == "100")
                    {
                        textBox3.Text = comboBox1.Text;
                        salario = 100 * 65;
                        textBox5.Text = String.Format("R$ {0:###,###.00}", salario);
                    }

                    else
                        if (comboBox1.Text == "150")
                        {
                            textBox3.Text = comboBox1.Text;
                            salario = 150 * 65;
                            textBox5.Text = String.Format("R$ {0:###,###.00}", salario);
                        }

                        else
                            if (comboBox1.Text == "200")
                            {
                                textBox3.Text = comboBox1.Text;
                                salario = 200 * 65;
                                textBox5.Text = String.Format("R$ {0:###,###.00}", salario);
                            }
            }

            else
                if (opcao == 4)
                {
                    textBox4.Text=radioButton4.Text;

                    if (comboBox1.Text == "50")
                    {
                        textBox3.Text = comboBox1.Text;
                        salario = 50 * 50;
                        textBox5.Text = String.Format("R$ {0:###,###.00}", salario);
                    }

                    else
                        if (comboBox1.Text == "100")
                        {
                            textBox3.Text = comboBox1.Text;
                            salario = 100 * 50;
                            textBox5.Text = String.Format("R$ {0:###,###.00}", salario);
                        }

                        else
                            if (comboBox1.Text == "150")
                            {
                                textBox3.Text = comboBox1.Text;
                                salario = 150 * 50;
                                textBox5.Text = String.Format("R$ {0:###,###.00}", salario);
                            }

                            else
                                if (comboBox1.Text == "200")
                                {
                                    textBox3.Text = comboBox1.Text;
                                    salario = 200 * 50;
                                    textBox5.Text = String.Format("R$ {0:###,###.00}", salario);
                                }
                }

           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //diretor
            opcao= 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //coordenador
            opcao = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //professor
            opcao = 3;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            //funcionário
            opcao = 4;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Radio_MouseMove(object sender, MouseEventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Text != "" && opcao != 0)
            {
                button1.Enabled = true;
            }

            else
            {
                button1.Enabled = false;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
