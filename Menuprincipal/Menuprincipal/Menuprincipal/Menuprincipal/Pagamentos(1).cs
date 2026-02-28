using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Menuprincipal
{
    public partial class Pagamentos : Form
    {
        string cnsql = "";
        public Pagamentos(string cn)
        {
            cnsql = cn;
            InitializeComponent();
        }

        //variáveis globais
        public string locacao_id, cliente_id, carro_id, nome, cpf, marca, modelo, placa, data_inicio, data_fim, valor_diaria, total, diarias = "";
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Selecione o Método de Pagamento!");
            }
            else
                if (label11.Text == "")
                {
                    MessageBox.Show("Selecione a Data de Pagamento!");
                }
                else
                {
                    inserir();
                }
        }

        private void inserir()
        {
            string sql = "insert into pagamentos (locacao_id,cliente_id,data_pagamento,valor_pago,metodo_pagamento) values (@locacao_id,@cliente_id,@data_pagamento,@valor_pago,@metodo_pagamento)";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            comando.Parameters.Add("@locacao_id", MySqlDbType.VarChar).Value = textBox3.Text;
            comando.Parameters.Add("@cliente_id", MySqlDbType.VarChar).Value = textBox1.Text;
            comando.Parameters.Add("@data_pagamento", MySqlDbType.Date).Value = Convert.ToDateTime(label11.Text);
            comando.Parameters.Add("@valor_pago", MySqlDbType.Decimal).Value = label24.Text;
            comando.Parameters.Add("@metodo_pagamento", MySqlDbType.VarChar).Value = comboBox1.Text;

            conexao.Open();//abrindo a minha conexão

            int result = comando.ExecuteNonQuery();

            if (result > 0)
            {
                MessageBox.Show("Locação/Pagamento - Realizado com Sucesso!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();//fechando o Form
            }
            else
            {
                MessageBox.Show("Locação/Pagamento -  Não Realizado!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexao.Close(); 
        }

        private void Pagamentos_Load(object sender, EventArgs e)
        {
            label15.Text = nome;
            label16.Text = cpf;
            textBox1.Text = cliente_id;
            textBox2.Text = carro_id;
            textBox3.Text = locacao_id;
            label17.Text = marca;
            label18.Text = modelo;
            label19.Text = placa;
            label20.Text = data_inicio;
            label21.Text = data_fim;
            label22.Text = diarias;
            label23.Text = valor_diaria;
            label24.Text = total;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            /*DialogResult msg = MessageBox.Show("Deseja realmente Cancelar a Locação?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.Yes)
            {
                Movimentacao mov = new Movimentacao(cnsql);
                mov.ShowDialog();
                this.Visible = false;
            } */
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            label11.Text = monthCalendar1.SelectionStart.ToShortDateString();
        }
    }
}
