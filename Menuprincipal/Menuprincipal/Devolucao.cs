using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//Usar essas bibiliotecas para o MySql
using MySql.Data;
using MySql.Data.MySqlClient;


namespace Menuprincipal
{
    public partial class Devolucao : Form
    {
        int opcao = 0;
        string cnsql = "";//constructor - Permissão de acesso ao Banco 
        public Devolucao(string cn)//cn= permissão de acesso ao form CadExterno
        {
            cnsql = cn;
            InitializeComponent();
        }

        
        private void consultarDataGridVeiculo()
        {
            dataGridView1.Rows.Clear();//limpando o grid de visualização
            string sql = "select locacoes.locacao_id as locacao_id, clientes.nome as nome, carros.modelo as modelo, carros.marca as marca, carros.ano as ano, carros.placa as placa, carros.cor as cor, carros.categoria as categoria, locacoes.data_inicio as data_inicio, locacoes.data_fim as data_fim, locacoes.valor_total as valor_total, locacoes.status as status FROM locacoes JOIN clientes ON locacoes.cliente_id = clientes.cliente_id JOIN carros ON locacoes.carro_id = carros.carro_id WHERE carros.placa = '" + comboBox3.Text + "' AND locacoes.status = 'Ativa'";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                {
                    dataGridView1.Rows.Add(Convert.ToString(leia["locacao_id"]), Convert.ToString(leia["nome"]), Convert.ToString(leia["modelo"]), Convert.ToString(leia["marca"]), Convert.ToString(leia["ano"]), Convert.ToString(leia["placa"]), Convert.ToString(leia["cor"]), Convert.ToString(leia["categoria"]), Convert.ToString(leia["data_inicio"]), Convert.ToString(leia["data_fim"]), Convert.ToString(leia["valor_total"]), Convert.ToString(leia["status"]));
                }
            }

            else
            {
                MessageBox.Show("Nenhum registro encontrado!");
            }

            conexao.Close();//fechando a conexão
        }

        private void consultarDataGridCliente()
        {
            if (opcao == 1)
            {
                dataGridView1.Rows.Clear();//limpando o grid de visualização
                string sql = "select locacoes.locacao_id as locacao_id, clientes.nome as nome, carros.modelo as modelo, carros.marca as marca, carros.ano as ano, carros.placa as placa, carros.cor as cor, carros.categoria as categoria, locacoes.data_inicio as data_inicio, locacoes.data_fim as data_fim, locacoes.valor_total as valor_total, locacoes.status as status FROM locacoes JOIN clientes ON locacoes.cliente_id = clientes.cliente_id JOIN carros ON locacoes.carro_id = carros.carro_id WHERE clientes.nome = '" + comboBox1.Text + "' AND locacoes.status = 'Ativa'";
                MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
                MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

                conexao.Open();
                MySqlDataReader leia = comando.ExecuteReader();
                if (leia.HasRows)//encontrou alguma coisa?
                {
                    while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                    {
                        dataGridView1.Rows.Add(Convert.ToString(leia["locacao_id"]), Convert.ToString(leia["nome"]), Convert.ToString(leia["modelo"]), Convert.ToString(leia["marca"]), Convert.ToString(leia["ano"]), Convert.ToString(leia["placa"]), Convert.ToString(leia["cor"]), Convert.ToString(leia["categoria"]), Convert.ToString(leia["data_inicio"]), Convert.ToString(leia["data_fim"]), Convert.ToString(leia["valor_total"]), Convert.ToString(leia["status"]));
                    }
                }

                else
                {
                    MessageBox.Show("Nenhum registro encontrado!");
                }

                conexao.Close();//fechando a conexão
            }

            else
                if (opcao == 2)
                {
                    dataGridView1.Rows.Clear();//limpando o grid de visualização
                    string sql = "select locacoes.locacao_id as locacao_id, clientes.nome as nome, carros.modelo as modelo, carros.marca as marca, carros.ano as ano, carros.placa as placa, carros.cor as cor, carros.categoria as categoria, locacoes.data_inicio as data_inicio, locacoes.data_fim as data_fim, locacoes.valor_total as valor_total, locacoes.status as status FROM locacoes JOIN clientes ON locacoes.cliente_id = clientes.cliente_id JOIN carros ON locacoes.carro_id = carros.carro_id WHERE clientes.cpf = '" + comboBox1.Text + "' AND locacoes.status = 'Ativa'";
                    MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
                    MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

                    conexao.Open();
                    MySqlDataReader leia = comando.ExecuteReader();
                    if (leia.HasRows)//encontrou alguma coisa?
                    {
                        while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                        {
                            dataGridView1.Rows.Add(Convert.ToString(leia["locacao_id"]), Convert.ToString(leia["nome"]), Convert.ToString(leia["modelo"]), Convert.ToString(leia["marca"]), Convert.ToString(leia["ano"]), Convert.ToString(leia["placa"]), Convert.ToString(leia["cor"]), Convert.ToString(leia["categoria"]), Convert.ToString(leia["data_inicio"]), Convert.ToString(leia["data_fim"]), Convert.ToString(leia["valor_total"]), Convert.ToString(leia["status"]));
                        }
                    }

                    else
                    {
                        MessageBox.Show("Nenhum registro encontrado!");
                    }

                    conexao.Close();//fechando a conexão
                }
        }
        private void consultarCPF()
        {
            comboBox1.Items.Clear();//limpando o combobox de visualização
            string sql = "select cpf from clientes";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                {
                    comboBox1.Items.Add(Convert.ToString(leia["cpf"]));
                }
            }

            conexao.Close();//fechando a conexão
        }

        private void consultarNome()
        {
            comboBox1.Items.Clear();//limpando o combobox de visualização
            string sql = "select nome from clientes";
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

         

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Deseja realmente voltar ao menu?", "Voltar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Devolucao_Load(object sender, EventArgs e)
        {
            // Adiciona itens ao ComboBox
            comboBox2.Items.Add("Cliente");
            comboBox2.Items.Add("Carro");

            comboBox2.DrawMode = DrawMode.OwnerDrawFixed;
        }

        private void comboBox2_DrawItem_1(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return; // Verifica se o índice é válido

            e.DrawBackground(); // Desenha o fundo do item

            // Obtém o texto e a imagem correspondente ao item
            string texto = comboBox2.Items[e.Index].ToString();
            Image icone = imageList1.Images[e.Index]; // Usa o índice para obter a imagem

            // Configura a qualidade de interpolação para suavizar a imagem
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            // Aumenta o tamanho do ícone e do texto
            e.Graphics.DrawImage(icone, e.Bounds.Left, e.Bounds.Top, 27, 27); // Aumenta o tamanho do ícone

            Font textoFonte = new Font(e.Font.FontFamily, 16, FontStyle.Regular); // Aumenta o tamanho da fonte
            e.Graphics.DrawString(texto, textoFonte, Brushes.Black, e.Bounds.Left + 40, e.Bounds.Top); // Desenha o texto

            e.DrawFocusRectangle(); // Desenha o foco se o item estiver selecionado
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Cliente")
            {
                panel1.Visible = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            opcao = 1;
            consultarNome();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            opcao = 2;
            consultarCPF();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            consultarDataGridVeiculo();
            consultarDataGridCliente();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
