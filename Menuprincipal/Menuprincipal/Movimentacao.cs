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
    public partial class Movimentacao : Form
    {
        string cnsql = "";//constructor - Permissão de acesso ao Banco 
        public Movimentacao(string cn)//cn= permissão de acesso ao form CadExterno
        {
            cnsql = cn;
            InitializeComponent();
        }

        int opcao = 0;
        double total;
        public string cliente, modelo, marca, cpf, placa, valor_diaria, diaria, data_inicio, data_fim, locacao_id, cliente_id;
        public double valor_final;

        private void inserirTabelaLocacoes()
        {
            string sql = "insert into locacoes (carro_id, cliente_id, data_inicio, data_fim, valor_total, status) values (@carro_id, @cliente_id, @data_inicio, @data_fim, @valor_total, @status)";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            comando.Parameters.Add("@carro_id", MySqlDbType.VarChar).Value = label47.Text;
            comando.Parameters.Add("@cliente_id", MySqlDbType.VarChar).Value = label49.Text;
            comando.Parameters.Add("@data_inicio", MySqlDbType.Date).Value = Convert.ToDateTime(textBox1.Text).Date;
            comando.Parameters.Add("@data_fim", MySqlDbType.Date).Value = Convert.ToDateTime(textBox2.Text).Date;
            comando.Parameters.Add("@valor_total", MySqlDbType.Decimal).Value = total;
            comando.Parameters.Add("@status", MySqlDbType.VarChar).Value = "Ativa";

            conexao.Open();//abrindo a minha conexão

            int result = comando.ExecuteNonQuery();

            if (result > 0)
            {
                consultarTabelalocacoes();

                comando.CommandText = "update carros set status = 'Alugado' where carro_id = @carro_id";

                int updateresult = comando.ExecuteNonQuery();

                if (updateresult <= 0)
                {
                    MessageBox.Show("Erro ao cadastrar!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            else
            {
                MessageBox.Show("Erro de cadastro!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexao.Close();
        }

        private void ConsultarMarca()
        {
            comboBox2.Items.Clear();//limpando o combobox de visualização
            string sql = "select distinct marca from carros order by marca";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                {
                    comboBox2.Items.Add(Convert.ToString(leia["marca"]));
                }
            }

            conexao.Close();//fechando a conexão
        }

        private void ConsultarModelo()
        {
            comboBox1.Items.Clear();//limpando o combobox de visualização
            string sql = "select distinct modelo from carros where marca='" + comboBox2.Text + "'order by modelo";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                {
                    comboBox1.Items.Add(Convert.ToString(leia["modelo"]));
                }
            }

            conexao.Close();//fechando a conexão
        }

        private void ConsultarPlaca()
        {
            comboBox3.Items.Clear();//limpando o combobox de visualização
            string sql = "select placa from carros where marca='" + comboBox2.Text + "' and modelo= '" + comboBox1.Text + "' and status='Disponível'";
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

        private void consultarTabelaCarros()
        {
            
            string sql = "select * from carros where placa='"+comboBox3.Text+"'";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                {
                    label9.Text = Convert.ToString(leia["ano"]);
                    label10.Text = Convert.ToString(leia["cor"]);
                    label11.Text = Convert.ToString(leia["preco_diaria"]);
                    label12.Text = Convert.ToString(leia["categoria"]);
                    label47.Text = Convert.ToString(leia["carro_id"]);
                }
            }

            conexao.Close();//fechando a conexão
        }

        private void consultarTabelalocacoes()
        {

            string sql = "select locacao_id from locacoes";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                {
                    label51.Text = Convert.ToString(leia["locacao_id"]);
                }
            }

            conexao.Close();//fechando a conexão
        }

        private void consultarTabelaClientes()
        {
            if (opcao == 1)
            {
                
                string sql = "select * from clientes where nome='" + comboBox4.Text + "'";
                MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
                MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

                conexao.Open();
                MySqlDataReader leia = comando.ExecuteReader();
                if (leia.HasRows)//encontrou alguma coisa?
                {
                    while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                    {
                       
                        label22.Text = Convert.ToString(leia["nome"]);
                        label20.Text = Convert.ToString(leia["cpf"]);
                        label13.Text = Convert.ToString(leia["email"]);
                        label16.Text = Convert.ToString(leia["telefone"]);
                        label15.Text = Convert.ToString(leia["endereco"]);
                        label14.Text = Convert.ToString(leia["data_nascimento"]);
                        label49.Text = Convert.ToString(leia["cliente_id"]);

                    }
                }

                conexao.Close();//fechando a conexão
            }

            else
                if (opcao == 2)
                {
                    
                    string sql = "select * from clientes where email='" + comboBox4.Text + "'";
                    MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
                    MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

                    conexao.Open();
                    MySqlDataReader leia = comando.ExecuteReader();
                    if (leia.HasRows)//encontrou alguma coisa?
                    {
                        while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                        {

                            label22.Text = Convert.ToString(leia["nome"]);
                            label20.Text = Convert.ToString(leia["cpf"]);
                            label13.Text = Convert.ToString(leia["email"]);
                            label16.Text = Convert.ToString(leia["telefone"]);
                            label15.Text = Convert.ToString(leia["endereco"]);
                            label14.Text = Convert.ToString(leia["data_nascimento"]);
                            label49.Text = Convert.ToString(leia["cliente_id"]);
                        }
                    }

                    conexao.Close();//fechando a conexão
                }
                else
                    if (opcao == 3)
                    {
                        
                        string sql = "select * from clientes where cpf='" + comboBox4.Text + "'";
                        MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
                        MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

                        conexao.Open();
                        MySqlDataReader leia = comando.ExecuteReader();
                        if (leia.HasRows)//encontrou alguma coisa?
                        {
                            while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                            {

                                label22.Text = Convert.ToString(leia["nome"]);
                                label20.Text = Convert.ToString(leia["cpf"]);
                                label13.Text = Convert.ToString(leia["email"]);
                                label16.Text = Convert.ToString(leia["telefone"]);
                                label15.Text = Convert.ToString(leia["endereco"]);
                                label14.Text = Convert.ToString(leia["data_nascimento"]);
                                label49.Text = Convert.ToString(leia["cliente_id"]);
                            }
                        }

                        conexao.Close();//fechando a conexão
                    }
            
        }

        private void consultarCPF()
        {
            comboBox4.Items.Clear();//limpando o combobox de visualização
            string sql = "select cpf from clientes";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                {
                    comboBox4.Items.Add(Convert.ToString(leia["cpf"]));
                }
            }

            conexao.Close();//fechando a conexão
        }

        private void consultarNome()
        {
            comboBox4.Items.Clear();//limpando o combobox de visualização
            string sql = "select nome from clientes";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                {
                    comboBox4.Items.Add(Convert.ToString(leia["nome"]));
                }
            }

            conexao.Close();//fechando a conexão
        }

        private void consultarEmail()
        {
            comboBox4.Items.Clear();//limpando o combobox de visualização
            string sql = "select email from clientes";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                {
                    comboBox4.Items.Add(Convert.ToString(leia["email"]));
                }
            }

            conexao.Close();//fechando a conexão
        }



        //----------------------------------------------------------------------------------------------

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
                //initialDate = initialDate.AddDays(1);
                //conta apenas dias da semana
                //if (initialDate.DayOfWeek != DayOfWeek.Sunday && initialDate.DayOfWeek != DayOfWeek.Saturday)
                //{
                    daysCount++;
                //}

            }
            return daysCount;
        }

        
        private void Movimentacao_Load(object sender, EventArgs e)
        {
            ConsultarMarca();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConsultarModelo();
            label9.Text = "";//limpando a label
            label10.Text = "";//limpando a label
            label11.Text = "";//limpando a label
            label12.Text = "";//limpando a label
            comboBox3.SelectedIndex = -1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConsultarPlaca();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            consultarTabelaCarros();
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            
        }
       
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            consultarNome();
            opcao = 1;
            label22.Text = "";//limpando a label
            label20.Text = "";//limpando a label
            label13.Text = "";//limpando a label
            label16.Text = "";//limpando a label
            label15.Text = "";//limpando a label
            label14.Text = "";//limpando a label
            comboBox4.SelectedIndex = -1;
        }

        
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            consultarEmail();
            opcao = 2;
            label22.Text = "";//limpando a label
            label20.Text = "";//limpando a label
            label13.Text = "";//limpando a label
            label16.Text = "";//limpando a label
            label15.Text = "";//limpando a label
            label14.Text = "";//limpando a label
            comboBox4.SelectedIndex = -1;
        }
        

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            consultarCPF();
            opcao = 3;
            label22.Text = "";//limpando a label
            label20.Text = "";//limpando a label
            label13.Text = "";//limpando a label
            label16.Text = "";//limpando a label
            label15.Text = "";//limpando a label
            label14.Text = "";//limpando a label
            comboBox4.SelectedIndex = -1;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            consultarTabelaClientes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Insira o modelo!");
                comboBox1.Focus();
            }
            else
                if (comboBox2.Text == "")
                {
                    MessageBox.Show("Insira o marca!");
                    comboBox2.Focus();
                }
                else
                    if (comboBox3.Text == "")
                    {
                        MessageBox.Show("Insira o placa!");
                        comboBox3.Focus();
                    }
                    else
                        if (comboBox4.Text == "")
                        {
                            MessageBox.Show("Insira a informação do cliente!");
                            comboBox4.Focus();
                        }
                        else
                            if (opcao == 0)
                            {
                                MessageBox.Show("Insira o modelo!");
                                radioButton1.Focus();
                            }
                            else
                            {
                               panel3.Visible = true;
                               textBox2.Clear();
                               label39.Text = label22.Text;
                               label35.Text = label20.Text;

                                   //placa
                               label37.Text = comboBox3.Text;

                                   //modelo
                               label42.Text = comboBox1.Text;

                                   //marca
                               label44.Text = comboBox2.Text;

                                   //valor diária
                               double valordiaria = double.Parse(label11.Text);
                               label27.Text = String.Format("{0:R$ ###,###.00}", valordiaria);

                               monthCalendar2.Enabled = false;
                            }
            
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox1.Text = monthCalendar1.SelectionStart.ToShortDateString();
            monthCalendar2.Enabled = true;
        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (monthCalendar2.SelectionStart < monthCalendar1.SelectionStart)
            {
                MessageBox.Show("Data inválida!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Clear();
                label30.Text = "";
                label33.Text="";
            }
           
            else
            {
                textBox2.Text = monthCalendar2.SelectionStart.ToShortDateString();
                DateTime a, b;
                a = Convert.ToDateTime(textBox1.Text);
                b = Convert.ToDateTime(textBox2.Text);
                label30.Text = Convert.ToString(contadias(a, b));
                label31.Visible = true;
                label32.Visible = true;
                label34.Visible = true;

                int dias = int.Parse(label30.Text);
                if (dias == 0)
                {
                    label30.Text = "1";
                }
                int diarias = int.Parse(label30.Text);
                double valordiaria = double.Parse(label11.Text);
                total = diarias * valordiaria;
                label33.Text = String.Format("{0:R$ ###,###.00}", total);

                }
            if (textBox2.Text == "")
            {
                button2.Visible = false;
            }
            else 
            {
                button2.Visible = true;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Deseja realmente voltar a aba anterior?", "Voltar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.Yes)
            {
                panel3.Visible = false;
                textBox1.Text = "";

            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            inserirTabelaLocacoes();
            DialogResult msg = MessageBox.Show("Deseja prosseguir para area de pagamentos?", "Voltar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.Yes)
            {
                
                Pagamento Pag = new Pagamento(cnsql);
                Pag.cliente = label39.Text;
                Pag.cpf = label35.Text;
                Pag.placa = label37.Text;
                Pag.modelo = label42.Text;
                Pag.marca = label44.Text;
                Pag.valor_diaria = label27.Text;
                Pag.diaria = label30.Text;
                Pag.valor_final = total;
                Pag.data_inicio = textBox1.Text;
                Pag.data_fim = textBox2.Text;
                Pag.locacao_id = label51.Text;
                Pag.cliente_id = label49.Text;
                this.Visible = false;
                Pag.ShowDialog();

                
            } 
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Deseja realmente voltar ao menu?", "Voltar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.Yes)
            {
                Form1 form = new Form1(cnsql);
                this.Close();
                form.ShowDialog();
            } 
        }

       
    }
}
