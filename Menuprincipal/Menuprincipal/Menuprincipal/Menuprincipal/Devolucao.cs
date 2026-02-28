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
    public partial class Devolucao : Form
    {
        string cnsql = "";
        public Devolucao(string cn)
        {
            cnsql = cn;
            InitializeComponent();
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //nome do cliente
            opcao = 1;
            dataGridView1.Rows.Clear();
            consultanomecliente();
            groupBox2.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            textBox6.Clear();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //placa do carro
            opcao = 2;
            dataGridView1.Rows.Clear();
            consultaplaca();
            groupBox2.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            textBox6.Clear();
        }

        private void consultanomecliente()
        {
            comboBox1.Items.Clear();//limpando o combobox de visualização
            string sql = "SELECT Clientes.nome AS nome FROM Locacoes JOIN Clientes ON Locacoes.cliente_id = Clientes.cliente_id WHERE Locacoes.status = 'Ativa'";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                {
                    comboBox1.Items.Add(Convert.ToString(leia["nome"]));
                }
            }

            conexao.Close();//fechando a conexão 
        }

        private void consultaplaca()
        {
            comboBox1.Items.Clear();//limpando o combobox de visualização
            //string sql = "SELECT Carros.placa, Locacoes.carro_id, Locacoes.locacao_id, Locacoes.data_inicio, Locacoes.data_fim, Locacoes.status FROM Locacoes JOIN Carros ON Locacoes.carro_id = Carros.carro_id WHERE Locacoes.status = 'Ativa'";
            string sql = "SELECT Carros.placa FROM Locacoes JOIN Carros ON Locacoes.carro_id = Carros.carro_id WHERE Locacoes.status = 'Ativa'";

            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                {
                    comboBox1.Items.Add(Convert.ToString(leia["placa"]));
                }
            }

            conexao.Close();//fechando a conexão
        }
        int opcao = 0;
        private void consultar()
        {
            if (opcao == 1) //por nome
            {
                dataGridView1.Rows.Clear();
                string sql = "SELECT Locacoes.locacao_id, Locacoes.data_inicio, Locacoes.data_fim, Locacoes.valor_total, Locacoes.status, Clientes.nome AS nome_cliente, Carros.modelo, Carros.marca, Carros.ano, Carros.placa, Carros.cor FROM Locacoes JOIN Clientes ON Locacoes.cliente_id = Clientes.cliente_id JOIN Carros ON Locacoes.carro_id = Carros.carro_id WHERE Locacoes.status = 'Ativa' and Clientes.nome='" + comboBox1.Text + "'";

                MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
                MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

                conexao.Open();
                MySqlDataReader leia = comando.ExecuteReader();
                if (leia.HasRows)//encontrou alguma coisa?
                {
                    int x = 0;
                    while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                    {
                        dataGridView1.Rows.Add(Convert.ToString(leia["locacao_id"]),
                            Convert.ToString(leia["nome_cliente"]),
                            Convert.ToString(leia["placa"]),
                            Convert.ToString(leia["marca"]),
                            Convert.ToString(leia["modelo"]),
                            Convert.ToString(leia["ano"]),
                            Convert.ToString(leia["cor"]),
                            Convert.ToString(leia["data_inicio"]),
                            Convert.ToString(leia["data_fim"]),
                            Convert.ToString(leia["valor_total"]),
                            Convert.ToString(leia["status"]));
                        x++;
                    }
                    textBox6.Text = Convert.ToString(x);
                }
                else
                {
                    MessageBox.Show("Nenhum registro encontrado!");
                }

                conexao.Close();//fechando a conexão
            }
            else
                if (opcao == 2) //por placa
                {
                    //por placa
                    dataGridView1.Rows.Clear();
                    string sql = "SELECT Locacoes.locacao_id, Locacoes.data_inicio, Locacoes.data_fim, Locacoes.valor_total, Locacoes.status, Clientes.nome AS nome_cliente, Carros.modelo, Carros.marca, Carros.ano, Carros.placa, Carros.cor FROM Locacoes JOIN Clientes ON Locacoes.cliente_id = Clientes.cliente_id JOIN Carros ON Locacoes.carro_id = Carros.carro_id WHERE Locacoes.status = 'Ativa' and Carros.placa='" + comboBox1.Text + "'";

                    MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
                    MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

                    conexao.Open();
                    MySqlDataReader leia = comando.ExecuteReader();
                    if (leia.HasRows)//encontrou alguma coisa?
                    {
                        int x = 0;
                        while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                        {
                            dataGridView1.Rows.Add(Convert.ToString(leia["locacao_id"]),
                                Convert.ToString(leia["nome_cliente"]),
                                Convert.ToString(leia["placa"]),
                                Convert.ToString(leia["marca"]),
                                Convert.ToString(leia["modelo"]),
                                Convert.ToString(leia["ano"]),
                                Convert.ToString(leia["cor"]),
                                Convert.ToString(leia["data_inicio"]),
                                Convert.ToString(leia["data_fim"]),
                                Convert.ToString(leia["valor_total"]),
                                Convert.ToString(leia["status"]));
                            x++;
                        }
                        textBox6.Text = Convert.ToString(x);
                    }
                    else
                    {
                        MessageBox.Show("Nenhum registro encontrado!");
                    }

                    conexao.Close();//fechando a conexão 
                }
        }

        //função Devolução
        private void devolucaoCarros()
        {
            string sql = "update locacoes  set status= 'Finalizada' where locacao_id=@locacao_id";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco
            comando.Parameters.Add("@locacao_id", MySqlDbType.VarChar).Value = label11.Text;

            conexao.Open();//abrindo a minha conexão

            int result = comando.ExecuteNonQuery();

            if (result > 0)
            {
                MessageBox.Show("Devolução Realizada com Sucesso!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //criando um gatilho para atualizar a tabela de carros
                comando.CommandText = "update carros set status = 'Disponivel' where placa = '" + label13.Text + "'";
                int GatilhoCarros = comando.ExecuteNonQuery();
                if (GatilhoCarros > 0)
                {
                    MessageBox.Show("Tabela de Carros Atualizada!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupBox2.Visible = false;
                    dataGridView1.Rows.Clear();
                    comboBox1.Items.Clear();
                }
            }
            else
            {
                MessageBox.Show("Locação Não Realizada!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexao.Close();
        }



        private void Devolucao_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            consultar();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            groupBox2.Visible = true;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            label11.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            label12.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            label13.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
            label14.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
            label15.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
            label16.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);
            label17.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value);
            label18.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[7].Value);
            label19.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[8].Value);
            double valor = double.Parse(Convert.ToString(dataGridView1.CurrentRow.Cells[9].Value));
            label20.Text = String.Format("{0:R$ ###,###.00}", valor);
            label21.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[10].Value);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (label11.Text == "")
            {
                MessageBox.Show("Duplo Clique no Registro para Efetuar a Devolução!");
            }
            else
            {
                DialogResult msg = MessageBox.Show("Deseja Realmente Realizar a Devolução?", "Devolução do Carro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes)
                {
                    devolucaoCarros();
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Deseja realmente Cancelar a Locação?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.Yes)
            {
                Movimentacao mov = new Movimentacao(cnsql);
                mov.ShowDialog();
                this.Visible = false;
            }
        }
    }
}