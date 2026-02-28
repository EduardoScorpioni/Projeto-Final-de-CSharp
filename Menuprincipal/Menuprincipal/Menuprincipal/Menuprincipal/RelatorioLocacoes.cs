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
    public partial class RelatorioLocacoes : Form
    {
        string cnsql = "";
        public RelatorioLocacoes(string cn)
        {
            cnsql = cn;
            InitializeComponent();
        }

        private void RelatorioLocacoes_Load(object sender, EventArgs e)
        {

        }
        
        int opcao = 0;
        
      /*  private void consultanomecliente()
        {
            comboBox1.Items.Clear();//limpando o combobox de visualização
            //string sql = "SELECT Clientes.nome AS nome FROM Locacoes JOIN Clientes ON Locacoes.cliente_id = Clientes.cliente_id WHERE Locacoes.status = 'Ativa'";
            string sql = "select nome from clientes order by nome";
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
            // string sql = "SELECT Carros.placa FROM Locacoes JOIN Carros ON Locacoes.carro_id = Carros.carro_id WHERE Locacoes.status = 'Ativa'";
            string sql = "select placa from carros order by placa";
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
        */
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //nome do cliente
            opcao = 1;
            dataGridView2.Rows.Clear();           
          //  consultanomecliente();            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //placa do carro
            opcao = 2;
            dataGridView2.Rows.Clear();
            //consultaplaca();
        }
        int tipo = 0;
        private void consultatodos()
        {
            dataGridView2.Rows.Clear();
            string sql = "SELECT Locacoes.locacao_id, Locacoes.data_inicio, Locacoes.data_fim, Locacoes.valor_total, Locacoes.status, Clientes.nome AS nome_cliente, Carros.modelo, Carros.marca, Carros.ano, Carros.placa, Carros.cor FROM Locacoes JOIN Clientes ON Locacoes.cliente_id = Clientes.cliente_id JOIN Carros ON Locacoes.carro_id = Carros.carro_id and (Locacoes.data_inicio BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'AND'" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "')";

            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                int x = 0;
                while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                {
                    dataGridView2.Rows.Add(Convert.ToString(leia["locacao_id"]),
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
                pictureBox1.Visible = true;//imprimir
            }
            else
            {
                MessageBox.Show("Nenhum registro encontrado!");
            }

            conexao.Close();//fechando a conexão  
        
        }
        private void devolvidos()
        {
            dataGridView2.Rows.Clear();
            string sql = "SELECT Locacoes.locacao_id, Locacoes.data_inicio, Locacoes.data_fim, Locacoes.valor_total, Locacoes.status, Clientes.nome AS nome_cliente, Carros.modelo, Carros.marca, Carros.ano, Carros.placa, Carros.cor FROM Locacoes JOIN Clientes ON Locacoes.cliente_id = Clientes.cliente_id JOIN Carros ON Locacoes.carro_id = Carros.carro_id WHERE Locacoes.status = 'Finalizada' and (Locacoes.data_inicio BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'AND'" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "')";

            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                int x = 0;
                while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                {
                    dataGridView2.Rows.Add(Convert.ToString(leia["locacao_id"]),
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
                pictureBox1.Visible = true;//imprimir
            }
            else
            {
                MessageBox.Show("Nenhum registro encontrado!");
            }

            conexao.Close();//fechando a conexão  
        }
        private void alugados()
        {
            dataGridView2.Rows.Clear();
            string sql = "SELECT Locacoes.locacao_id, Locacoes.data_inicio, Locacoes.data_fim, Locacoes.valor_total, Locacoes.status, Clientes.nome AS nome_cliente, Carros.modelo, Carros.marca, Carros.ano, Carros.placa, Carros.cor FROM Locacoes JOIN Clientes ON Locacoes.cliente_id = Clientes.cliente_id JOIN Carros ON Locacoes.carro_id = Carros.carro_id WHERE Locacoes.status = 'Ativa' and (Locacoes.data_inicio BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'AND'" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "')";

            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                int x = 0;
                while (leia.Read())//enquanto ele estiver encontrando dados ele vai exibir as informações no grid
                {
                    dataGridView2.Rows.Add(Convert.ToString(leia["locacao_id"]),
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
                pictureBox1.Visible = true;//imprimir
            }
            else
            {
                MessageBox.Show("Nenhum registro encontrado!");
            }

            conexao.Close();//fechando a conexão 

        }

        private void imprimir()
        {
            if (tipo == 0)
            {
                MessageBox.Show("Selecione o tipo de consulta");
            }
            else
            if (tipo == 1)
            {
                //TEMOS QUE APONTAR PARA A LISTA
                Menuprincipal.listaclassrelatorio cadastro = new listaclassrelatorio();
                string sql = "SELECT Locacoes.locacao_id, Locacoes.data_inicio, Locacoes.data_fim, Locacoes.valor_total, Locacoes.status, Clientes.nome AS nome_cliente, Carros.modelo, Carros.marca, Carros.ano, Carros.placa, Carros.cor FROM Locacoes JOIN Clientes ON Locacoes.cliente_id = Clientes.cliente_id JOIN Carros ON Locacoes.carro_id = Carros.carro_id WHERE Locacoes.status = 'Ativa' and (Locacoes.data_inicio BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'AND'" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "')";
                MySqlConnection conexao = new MySqlConnection(cnsql);//enviando o caminho onde está alocado o banco
                MySqlCommand comando = new MySqlCommand(sql, conexao);//enviando o caminho e a instrução em sql para o  banco
                conexao.Open();//abrindo conexão

                MySqlDataReader leia = comando.ExecuteReader();//enviando uma variavel que irá realizar uma leitura dos dados

                if (leia.HasRows)//encontrou alguma coisa?
                {
                    while (leia.Read())//enquanto o leia estiver encontrando dados ele vai exibir as informações no grid, registro por registro
                    {
                        Menuprincipal.Classrelatorio linha = new Classrelatorio(); //TEMOS QUE APONTAR PARA O OBJETO
                        linha.Locacao_id = Convert.ToInt32(leia["Locacao_id"]);
                        linha.Nome_cliente = Convert.ToString (leia["nome_cliente"]);
                        linha.Placa = Convert.ToString(leia["Placa"]);
                        linha.Marca = Convert.ToString(leia["Marca"]);
                        linha.Modelo = Convert.ToString(leia["Modelo"]);
                        linha.Ano = Convert.ToInt32(leia["Ano"]);
                        linha.Cor = Convert.ToString(leia["Cor"]);
                        linha.Data_inicio = Convert.ToDateTime(leia["Data_inicio"]);
                        linha.Data_inicio = Convert.ToDateTime(leia["Data_fim"]);
                        linha.Valor_total = Convert.ToInt32(leia["Valor_total"]);
                        linha.Status = Convert.ToString(leia["Status"]);
                        cadastro.Add(linha);

                    }
                }

                conexao.Close();
                Tabela tab = new Tabela();
                tab.imprimir(cadastro);
                tab.Show();
            }
            else
                if (tipo == 2)
                {
                    //TEMOS QUE APONTAR PARA A LISTA
                    Menuprincipal.listaclassrelatorio cadastro = new listaclassrelatorio();
                    string sql = "SELECT Locacoes.locacao_id, Locacoes.data_inicio, Locacoes.data_fim, Locacoes.valor_total, Locacoes.status, Clientes.nome AS nome_cliente, Carros.modelo, Carros.marca, Carros.ano, Carros.placa, Carros.cor FROM Locacoes JOIN Clientes ON Locacoes.cliente_id = Clientes.cliente_id JOIN Carros ON Locacoes.carro_id = Carros.carro_id WHERE Locacoes.status = 'Finalizada' and (Locacoes.data_inicio BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'AND'" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "')";
                    MySqlConnection conexao = new MySqlConnection(cnsql);//enviando o caminho onde está alocado o banco
                    MySqlCommand comando = new MySqlCommand(sql, conexao);//enviando o caminho e a instrução em sql para o  banco
                    conexao.Open();//abrindo conexão

                    MySqlDataReader leia = comando.ExecuteReader();//enviando uma variavel que irá realizar uma leitura dos dados

                    if (leia.HasRows)//encontrou alguma coisa?
                    {
                        while (leia.Read())//enquanto o leia estiver encontrando dados ele vai exibir as informações no grid, registro por registro
                        {
                            Menuprincipal.Classrelatorio linha = new Classrelatorio(); //TEMOS QUE APONTAR PARA O OBJETO
                            linha.Locacao_id = Convert.ToInt32(leia["Locacao_id"]);
                            linha.Nome_cliente = Convert.ToString(leia["nome_cliente"]);
                            linha.Placa = Convert.ToString(leia["Placa"]);
                            linha.Marca = Convert.ToString(leia["Marca"]);
                            linha.Modelo = Convert.ToString(leia["Modelo"]);
                            linha.Ano = Convert.ToInt32(leia["Ano"]);
                            linha.Cor = Convert.ToString(leia["Cor"]);
                            linha.Data_inicio = Convert.ToDateTime(leia["Data_inicio"]);
                            linha.Data_inicio = Convert.ToDateTime(leia["Data_fim"]);
                            linha.Valor_total = Convert.ToInt32(leia["Valor_total"]);
                            linha.Status = Convert.ToString(leia["Status"]);
                            cadastro.Add(linha);

                        }
                    }

                    conexao.Close();
                    Tabela tab = new Tabela();
                    tab.imprimir(cadastro);
                    tab.Show();
                }
                else
                    if (tipo == 3)
                    {
                        //TEMOS QUE APONTAR PARA A LISTA
                        Menuprincipal.listaclassrelatorio cadastro = new listaclassrelatorio();
                        string sql = "SELECT Locacoes.locacao_id, Locacoes.data_inicio, Locacoes.data_fim, Locacoes.valor_total, Locacoes.status, Clientes.nome AS nome_cliente, Carros.modelo, Carros.marca, Carros.ano, Carros.placa, Carros.cor FROM Locacoes JOIN Clientes ON Locacoes.cliente_id = Clientes.cliente_id JOIN Carros ON Locacoes.carro_id = Carros.carro_id and (Locacoes.data_inicio BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'AND'" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "')";
                        MySqlConnection conexao = new MySqlConnection(cnsql);//enviando o caminho onde está alocado o banco
                        MySqlCommand comando = new MySqlCommand(sql, conexao);//enviando o caminho e a instrução em sql para o  banco
                        conexao.Open();//abrindo conexão

                        MySqlDataReader leia = comando.ExecuteReader();//enviando uma variavel que irá realizar uma leitura dos dados

                        if (leia.HasRows)//encontrou alguma coisa?
                        {
                            while (leia.Read())//enquanto o leia estiver encontrando dados ele vai exibir as informações no grid, registro por registro
                            {
                                Menuprincipal.Classrelatorio linha = new Classrelatorio(); //TEMOS QUE APONTAR PARA O OBJETO
                                linha.Locacao_id = Convert.ToInt32(leia["Locacao_id"]);
                                linha.Nome_cliente = Convert.ToString(leia["nome_cliente"]);
                                linha.Placa = Convert.ToString(leia["Placa"]);
                                linha.Marca = Convert.ToString(leia["Marca"]);
                                linha.Modelo = Convert.ToString(leia["Modelo"]);
                                linha.Ano = Convert.ToInt32(leia["Ano"]);
                                linha.Cor = Convert.ToString(leia["Cor"]);
                                linha.Data_inicio = Convert.ToDateTime(leia["Data_inicio"]);
                                linha.Data_inicio = Convert.ToDateTime(leia["Data_fim"]);
                                linha.Valor_total = Convert.ToInt32(leia["Valor_total"]);
                                linha.Status = Convert.ToString(leia["Status"]);
                                cadastro.Add(linha);

                            }
                        }

                        conexao.Close();
                        Tabela tab = new Tabela();
                        tab.imprimir(cadastro);
                        tab.Show();
                    }

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            tipo = 1; //alugados  
            dataGridView2.Rows.Clear();
            textBox6.Clear();
            pictureBox1.Visible = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            tipo = 2;//devolvidos
            dataGridView2.Rows.Clear();
            textBox6.Clear();
            pictureBox1.Visible = false;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            tipo = 3;//todos
            dataGridView2.Rows.Clear();
            textBox6.Clear();
            pictureBox1.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (tipo == 0)
            {
                MessageBox.Show("Selecione o Tipo da Consulta Desejada!");
            }
            else
            if (tipo == 1)
            {
                //alugados
                alugados();
            }
            else
                if (tipo == 2)
                {
                    //devolvidos
                    devolvidos();
                }
                else
                {
                    //todos
                    consultatodos();
                }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            imprimir();
        }
    }
}
