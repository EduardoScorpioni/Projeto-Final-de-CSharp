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
    public partial class Movimentacao : Form
    {
        string cnsql = "";
        public Movimentacao(string cn)
        {
            cnsql = cn;
            InitializeComponent();
        }

        private void ConsultarMarca()
        {
            comboBox1.Items.Clear();//limpando o combobox de visualização
            string sql = "select distinct marca from carros order by marca";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                {
                    comboBox1.Items.Add(Convert.ToString(leia["marca"]));
                }
            }

            conexao.Close();//fechando a conexão
        }

        private void consultaPlaca()
        {
            comboBox3.Items.Clear();
            string sql = "select placa, carro_id from carros where marca='" + comboBox1.Text + "' and modelo='" + comboBox2.Text + "' and status='Disponivel'";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco
            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                {
                    comboBox3.Items.Add(Convert.ToString(leia["placa"]));
                }
            }
            conexao.Close();//fechando a conexão
        }
        private void ConsultarModelo()
        {
            comboBox2.Items.Clear();//limpando o combobox de visualização
            string sql = "select distinct modelo from carros where marca='" + comboBox1.Text + "' order by modelo";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                {
                    comboBox2.Items.Add(Convert.ToString(leia["modelo"]));
                }
            }

            conexao.Close();//fechando a conexão
        }


        private void Movimentacao_Load(object sender, EventArgs e)
        {
            ConsultarMarca();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConsultarModelo();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            consultaPlaca();
        }
        private void DadosCarro()
        {
            //comboBox2.Items.Clear();//limpando o combobox de visualização
            string sql = "select * from carros where placa='" + comboBox3.Text + "'";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                {
                    label5.Text = Convert.ToString(leia["ano"]);
                    label6.Text = Convert.ToString(leia["cor"]);
                    label8.Text = Convert.ToString(leia["preco_diaria"]);
                    label10.Text = Convert.ToString(leia["categoria"]);
                    textBox1.Text = Convert.ToString(leia["carro_id"]);
                }
            }

            conexao.Close();//fechando a conexão 
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DadosCarro();
        }
        private void consultaNome()
        {
            textBox2.Clear();
            label12.Text = "";
            label14.Text = "";
            label16.Text = "";
            label18.Text = "";
            label20.Text = "";
            label22.Text = "";
            comboBox6.Items.Clear();//limpando o combobox de visualização
            string sql = "select distinct nome from clientes order by nome";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                {
                    comboBox6.Items.Add(Convert.ToString(leia["nome"]));
                }
            }

            conexao.Close();//fechando a conexão 
        }
        int opcao = 0;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            consultaNome();
            opcao = 1;
        }

        private void consultaCPF()
        {
            textBox2.Clear();
            label12.Text = "";
            label14.Text = "";
            label16.Text = "";
            label18.Text = "";
            label20.Text = "";
            label22.Text = "";
            comboBox6.Items.Clear();//limpando o combobox de visualização
            string sql = "select cpf from clientes order by cpf";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                {
                    comboBox6.Items.Add(Convert.ToString(leia["cpf"]));
                }
            }
            conexao.Close();//fechando a conexão 
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            consultaCPF();
            opcao = 2;
        }
        private void DadosCliente()
        {
            if (opcao == 0)
            {
                MessageBox.Show("Selecione a Opção Desejada!");
            }
            else
                if (opcao == 1)//consuta preenche pelo nome
                {
                    // comboBox6.Items.Clear();//limpando o combobox de visualização
                    string sql = "select * from clientes where nome='" + comboBox6.Text + "'";
                    MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
                    MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

                    conexao.Open();
                    MySqlDataReader leia = comando.ExecuteReader();
                    if (leia.HasRows)//encontrou alguma coisa?
                    {
                        while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                        {
                            label18.Text = Convert.ToString(leia["nome"]);
                            label16.Text = Convert.ToString(leia["cpf"]);
                            label14.Text = Convert.ToString(leia["telefone"]);
                            label12.Text = Convert.ToString(leia["email"]);
                            label20.Text = Convert.ToString(leia["endereco"]);
                            label22.Text = Convert.ToString(leia["data_nascimento"]);
                            textBox2.Text = Convert.ToString(leia["cliente_id"]);
                        }
                    }
                    conexao.Close();//fechando a conexão  
                }
                else
                    if (opcao == 2)//consulta preenche pelo cpf
                    {
                        // comboBox6.Items.Clear();//limpando o combobox de visualização
                        string sql = "select * from clientes where cpf='" + comboBox6.Text + "'";
                        MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
                        MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco
                        conexao.Open();
                        MySqlDataReader leia = comando.ExecuteReader();
                        if (leia.HasRows)//encontrou alguma coisa?
                        {
                            while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                            {
                                label18.Text = Convert.ToString(leia["nome"]);
                                label16.Text = Convert.ToString(leia["cpf"]);
                                label14.Text = Convert.ToString(leia["telefone"]);
                                label12.Text = Convert.ToString(leia["email"]);
                                label20.Text = Convert.ToString(leia["endereco"]);
                                label22.Text = Convert.ToString(leia["data_nascimento"]);
                                textBox2.Text = Convert.ToString(leia["cliente_id"]);
                            }
                        }
                        conexao.Close();//fechando a conexão   
                    }
        }
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            DadosCliente();
        }

        //funcao
        public int contadias(DateTime initialDate, DateTime finalDate)
        {
            int days = 0;
            int daysCount = 0;
            days = initialDate.Subtract(finalDate).Days;

            //modulo
            if (days < 0)
            {
                days = days * -1; //para o resultado não ser negativo 
            }
            for (int i = 1; i <= days; i++)
            {
                initialDate = initialDate.AddDays(1);
                //conta apenas dias da semana
                // if (initialDate.DayOfWeek != DayOfWeek.Sunday && initialDate.DayOfWeek != DayOfWeek.Saturday)
                //{
                daysCount++;
                //}

            }
            return daysCount;
        }


        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox3.Text = monthCalendar1.SelectionStart.ToShortDateString();
            monthCalendar2.Enabled = true;
        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Necessário Selecinar a Data Inicial!");
            }
            else
                if (monthCalendar2.SelectionStart < monthCalendar1.SelectionStart)
                {
                    MessageBox.Show("Data Inválida!");
                    textBox4.Clear();
                }
                else
                {
                    textBox4.Text = monthCalendar2.SelectionStart.ToShortDateString();
                    DateTime a, b;
                    a = Convert.ToDateTime(textBox3.Text);
                    b = Convert.ToDateTime(textBox4.Text);
                    label29.Text = Convert.ToString(contadias(a, b));

                    //*******************************************
                    //garantindo que tenha pelo menos uma diaria
                    int dias = int.Parse(label29.Text);
                    if (dias == 0)
                    {
                        label29.Text = "1";
                    }
                    //*****************************************

                    //variaveis locais
                    int diarias = int.Parse(label29.Text);
                    double valordiaria = double.Parse(label8.Text);
                    double total = diarias * valordiaria;
                    //label30.Text = String.Format("{0:R$ ###,###.00}", valordiaria);
                    //label31.Text = String.Format("{0:R$ ###,###.00}", total);
                    label30.Text = Convert.ToString(valordiaria);
                    label31.Text = Convert.ToString(total);
                   
                    button1.Visible = true;//chamando o botão pagamento
                }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void inserir()
        {
            string sql = "insert into locacoes (carro_id,cliente_id,data_inicio,data_fim,valor_total,status) values (@carro_id,@cliente_id,@data_inicio,@data_fim,@valor_total,@status)";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            comando.Parameters.Add("@carro_id", MySqlDbType.VarChar).Value = textBox1.Text;
            comando.Parameters.Add("@cliente_id", MySqlDbType.VarChar).Value = textBox2.Text;
            comando.Parameters.Add("@data_inicio", MySqlDbType.Date).Value = Convert.ToDateTime(textBox3.Text);
            comando.Parameters.Add("@data_fim", MySqlDbType.Date).Value = Convert.ToDateTime(textBox4.Text);
            comando.Parameters.Add("@valor_total", MySqlDbType.Decimal).Value = label31.Text;
            comando.Parameters.Add("@status", MySqlDbType.VarChar).Value = "Ativa";

            conexao.Open();//abrindo a minha conexão

            int result = comando.ExecuteNonQuery();

            if (result > 0)
            {
                MessageBox.Show("Locação Realizada com Sucesso!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //criando um gatilho para atualizar a tabela de carros
                comando.CommandText = "update carros set status = 'Alugado' where carro_id = @carro_id";
                int GatilhoCarros = comando.ExecuteNonQuery();
                if (GatilhoCarros > 0)
                {
                    MessageBox.Show("Tabela de Carros Atualizada!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Locação Não Realizada!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexao.Close();
        }
        private void consultaLocacao_id()
        {            
            string sql = "select locacao_id from locacoes where carro_id = @carro_id and cliente_id=@cliente_id and status='Ativa'";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco
            comando.Parameters.Add("@carro_id", MySqlDbType.VarChar).Value = textBox1.Text;
            comando.Parameters.Add("@cliente_id", MySqlDbType.VarChar).Value = textBox2.Text;
           
            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                {
                    textBox5.Text=Convert.ToString(leia["locacao_id"]);
                }
            }
            conexao.Close();//fechando a conexão 
        }



        //botão ir para pagamento
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Selecione os Dados Corretamente!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                inserir();//função inserir na tabela de Locação
                consultaLocacao_id();//chamando o consulta locacao_id e preenchendo o textbox5
                Pagamentos pag = new Pagamentos(cnsql);
                pag.diarias = label29.Text;
                pag.valor_diaria = label30.Text;
                pag.total = label31.Text;
                pag.data_inicio = textBox3.Text;
                pag.data_fim = textBox4.Text;
                pag.marca = comboBox1.Text;
                pag.modelo = comboBox2.Text;
                pag.placa = comboBox3.Text;
                pag.nome = label18.Text;
                pag.cpf = label16.Text;
                pag.carro_id = textBox1.Text;
                pag.cliente_id = textBox2.Text;
                pag.locacao_id = textBox5.Text;
                this.Visible = false;
                pag.ShowDialog();
            }
        }
    }
}
