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
    public partial class CadClientes : Form
    {
        string cnsql = "";//constructor - Permissão de acesso ao Banco 
        public CadClientes(string cn)//cn= permissão de acesso ao form Cadclientes
        {
            cnsql = cn;
            InitializeComponent();
        }

        
        private void verificaIgual()
        {
            string sql = "select * from clientes where cpf=@cpf";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco
            comando.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = maskedTextBox2.Text;
            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//se achou??
            {
                MessageBox.Show("O cpf: " + maskedTextBox2.Text + " já está cadastrado", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox2.Clear();
            }
            conexao.Close();//fechando a conexão com o banco
        }


        private void inserir()
        {
            string sql = "insert into clientes (nome, cpf, telefone, email, endereco, data_nascimento) values (@nome, @cpf, @telefone, @email, @endereco, @data_nascimento)";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            comando.Parameters.Add("@nome", MySqlDbType.VarChar).Value = textBox1.Text;
            comando.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = maskedTextBox2.Text;
            comando.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = maskedTextBox1.Text;
            comando.Parameters.Add("@email", MySqlDbType.VarChar).Value = textBox2.Text;
            comando.Parameters.Add("@endereco", MySqlDbType.VarChar).Value = textBox6.Text;
            comando.Parameters.Add("@data_nascimento", MySqlDbType.Date).Value = dateTimePicker1.Value.Date;

            conexao.Open();//abrindo a minha conexão

            int result = comando.ExecuteNonQuery();

            if (result > 0)
            {
                MessageBox.Show("Novo cliente cadastrado com sucesso!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                pictureBox5_Click(null, null);//chamando a ação de limpar do botão
                consultar();//chamando a função consultar
            }

            else
            {
                MessageBox.Show("Cliente não cadastrado!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexao.Close();
        }


        private void editar()
        {

            string sql = "update clientes set nome=@nome, cpf=@cpf, telefone=@telefone, email=@email, endereco=@endereco, data_nascimento=@data_nascimento where cliente_id='" + textBox4.Text + "'";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            comando.Parameters.Add("@nome", MySqlDbType.VarChar).Value = textBox1.Text;
            comando.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = maskedTextBox2.Text;
            comando.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = maskedTextBox1.Text;
            comando.Parameters.Add("@email", MySqlDbType.VarChar).Value = textBox2.Text;
            comando.Parameters.Add("@endereco", MySqlDbType.VarChar).Value = textBox6.Text;
            comando.Parameters.Add("@data_nascimento", MySqlDbType.Date).Value = dateTimePicker1.Value.Date;

            conexao.Open();//abrindo a minha conexão

            int result = comando.ExecuteNonQuery();

            if (result > 0)
            {
                MessageBox.Show(result + " registro atualizado com sucesso!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                pictureBox5_Click(null, null);//chamando a ação de limpar do botão
                consultar();//chamando a função consultar
            }

            else
            {
                MessageBox.Show("Registro não atualizado!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexao.Close();
        }





        private void excluir()
        {
            string sql = "delete from clientes where cliente_id='" + textBox4.Text + "'";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();//abrindo a minha conexão

            int result = comando.ExecuteNonQuery();

            if (result > 0)
            {
                MessageBox.Show(result + " registro(s) excluído(s) com sucesso!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //pictureBox5_Click(null, null);//chamando botão limpar

                consultar();//chamando a função consultar
            }

            else
            {
                MessageBox.Show("Dado(s) não excluído(s)!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexao.Close();
        }


        private void consultarLIKE()
        {
            dataGridView1.Rows.Clear();//limpando o grid de visualização
            string sql = "select * from clientes where nome LIKE '%" + textBox5.Text + "%'";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                {
                    dataGridView1.Rows.Add(Convert.ToString(leia["cliente_id"]), Convert.ToString(leia["nome"]), Convert.ToString(leia["cpf"]), Convert.ToString(leia["telefone"]), Convert.ToString(leia["email"]), Convert.ToString(leia["endereco"]), Convert.ToString(leia["data_nascimento"]));
                }
            }

            conexao.Close();//fechando a conexão
        }


        private void consultar()
        {
            dataGridView1.Rows.Clear();//limpando o grid de visualização
            string sql = "select * from clientes";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                {
                    dataGridView1.Rows.Add(Convert.ToString(leia["cliente_id"]), Convert.ToString(leia["nome"]), Convert.ToString(leia["cpf"]), Convert.ToString(leia["telefone"]), Convert.ToString(leia["email"]), Convert.ToString(leia["endereco"]), Convert.ToString(leia["data_nascimento"]));
                }
            }

            else
            {
                MessageBox.Show("Nenhum registro encontrado!");
            }

            conexao.Close();//fechando a conexão
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Informe o nome!");
                textBox1.Focus();
            }

            else
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Informe o e-mail!");
                    textBox2.Focus();
                }
                else
                    if (textBox6.Text == "")
                    {
                        MessageBox.Show("Informe o endereço!");
                        textBox6.Focus();
                    }

                else
                    if (maskedTextBox2.Text == "")
                    {
                        MessageBox.Show("Informe o cpf!");
                        maskedTextBox2.Focus();
                    }
                    else
                        if (maskedTextBox1.Text == "")
                        {
                            MessageBox.Show("Informe o telefone!");
                            maskedTextBox1.Focus();
                        }

                        else
                            if (dateTimePicker1.Text == "")
                            {
                                MessageBox.Show("Informe a data de nascimento!");
                                dateTimePicker1.Focus();
                            }

                    else
                        if (textBox4.Text == "")//codigo
                        {
                            inserir();//chamando função
                        }

                        else
                        {
                            editar();//chamandoa função editar
                        }
                    
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Deseja realmente voltar ao menu?", "Voltar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.Yes)
            {
                this.Close();
            } 
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            consultar();//função de consultar
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //código
            textBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);

            //nome
            textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);

            //cpf
            maskedTextBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);

            //telefone
            maskedTextBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);

            //email
            textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);

            //endereço
            textBox6.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);

            //nascimento
            dateTimePicker1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            maskedTextBox2.Clear();
            textBox4.Clear();
            maskedTextBox1.Clear();
            textBox5.Clear();
            textBox6.Clear();
            dateTimePicker1.Text="";
            dataGridView1.Rows.Clear();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Necessário selecionar o registro com um Duplo Clique!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                DialogResult msg = MessageBox.Show("Deseja realmente excluir o registro? Essa ação será irreversível", "Ajuda do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msg == DialogResult.Yes)
                {
                    excluir();//chamando função excluir
                }
            }
        }

        private void maskedTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                consultarLIKE();
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void maskedTextBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (textBox4.Text == "")
            {
                verificaIgual();
            }
        }

        private void maskedTextBox2_MouseLeave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                verificaIgual();
            }
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Necessário selecionar o registro com um Duplo Clique!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                DialogResult msg = MessageBox.Show("Deseja realmente excluir o registro? Essa ação será irreversível", "Ajuda do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msg == DialogResult.Yes)
                {
                    excluir();//chamando função excluir
                }
            }
        }
    
    }
}
