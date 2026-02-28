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
    public partial class CadUsuario : Form
    {
        string cnsql = "";//constructor - Permissão de acesso ao Banco  
        public CadUsuario(string cn)//cn= permissão de acesso ao form CadExterno 
        {
            cnsql = cn;
            InitializeComponent();
        }

        //global

        //criptografia MD5
        public static class Criptografia
        {
            //calcula md5 de uma determinada string passada como parâmetro
            //<parametro name="Senha">String contendo a senha que dev ser criptografada para md5 hash</param>
            //retorna string com 32 caracteres com a senha criptografada 

            public static string md5(string Senha)
            {
                try
                {
                    System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                    ﻿byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes (Senha); 
                    byte[] hash= md5.ComputeHash (inputBytes); 
                    //calcula a saída! 
                    System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
                      for (int i = 0; i < hash.Length; i++)
                      {
                          sb.Append(hash[i].ToString("x2"));
                      }
                      return sb.ToString(); // Retorna senha criptografada
                }
                      catch (Exception)
                      {
                          return null; // Caso encontre erro retorna nulo
                      }

            }
        }
        

        private void verificaIgual()
        {
            string sql = "select * from usuarios where email=@email";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco
            comando.Parameters.Add("@email", MySqlDbType.VarChar).Value = textBox2.Text;
            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//se achou??
            { 
               MessageBox.Show("O e-mail: " + textBox2.Text+ " já existe","Ajuda do sistema",MessageBoxButtons.OK, MessageBoxIcon.Error);
               textBox2.Clear();
            }
            conexao.Close();//fechando a conexão com o banco
        }


        private void inserir()
        {
            string sql = "insert into usuarios (nome, email, senha) values (@nome, @email, @senha)";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            comando.Parameters.Add("@nome", MySqlDbType.VarChar).Value = textBox1.Text;
            comando.Parameters.Add("@email", MySqlDbType.VarChar).Value = textBox2.Text;
            comando.Parameters.Add("@senha", MySqlDbType.VarChar).Value = Criptografia.md5 (textBox3.Text);

            conexao.Open();//abrindo a minha conexão

            int result = comando.ExecuteNonQuery();

            if (result > 0)
            {
                MessageBox.Show("Novo usuário cadastrado com sucesso!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                pictureBox5_Click(null,null);//chamando a ação de limpar do botão
                consultar();//chamando a função consultar
            }

            else
            {
                MessageBox.Show("Usuário não cadastrado!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexao.Close();
        }


        private void editar()
        {

            string sql = "update usuarios set nome=@nome, email=@email, senha=@senha where codigo='" + textBox4.Text + "'";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            comando.Parameters.Add("@nome", MySqlDbType.VarChar).Value = textBox1.Text;
            comando.Parameters.Add("@email", MySqlDbType.VarChar).Value = textBox2.Text;
            comando.Parameters.Add("@senha", MySqlDbType.VarChar).Value = textBox3.Text;

            conexao.Open();//abrindo a minha conexão

            int result = comando.ExecuteNonQuery();

            if (result > 0)
            {
                MessageBox.Show(result+ " registro atualizado com sucesso!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            string sql = "delete from usuarios where codigo='" + textBox4.Text + "'";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();//abrindo a minha conexão

            int result = comando.ExecuteNonQuery();

            if (result > 0)
            {
                MessageBox.Show(result + " registro(s) excluído(s) com sucesso!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                pictureBox5_Click(null,null);//chamando botão limpar

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
            string sql = "select * from usuarios where nome LIKE '%" + textBox5.Text + "%'";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                {
                    dataGridView1.Rows.Add(Convert.ToString(leia["codigo"]), Convert.ToString(leia["nome"]), Convert.ToString(leia["email"]), Convert.ToString(leia["senha"]));
                }
            }

            conexao.Close();//fechando a conexão
        }


        private void consultar()
        {
            dataGridView1.Rows.Clear();//limpando o grid de visualização
            string sql = "select * from usuarios";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                {
                    dataGridView1.Rows.Add(Convert.ToString(leia["codigo"]), Convert.ToString(leia["nome"]), Convert.ToString(leia["email"]),Convert.ToString(leia["senha"]) );
                }
            }

            else 
            {
                MessageBox.Show("Nenhum registro encontrado!");
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

        //botão ok
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
                    if (textBox3.Text == "")
                    {
                        MessageBox.Show("Informe a senha!");
                        textBox3.Focus();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            consultar();//função de consultar


            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //nome
            textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            
            //email
            textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
            
            //senha
            textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
            
            //código
            textBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
        }

        //botão limpar
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
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

        private void textBox2_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                verificaIgual();
            }
        }

        private void CadUsuario_MouseMove(object sender, MouseEventArgs e)
        {
            if (textBox4.Text == "")
            {
                verificaIgual();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

       
    }
}
