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
    public partial class CadExterno : Form
    {
        string cnsql = "";//constructor - Permissão de acesso ao Banco    
        public CadExterno(string cn)//cn= permissão de acesso ao form CadExterno
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
                    ﻿byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(Senha);
                     byte[] hash = md5.ComputeHash(inputBytes);
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
                MessageBox.Show("O e-mail: " + textBox2.Text + " já existe", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            comando.Parameters.Add("@senha", MySqlDbType.VarChar).Value = Criptografia.md5(textBox3.Text);

            conexao.Open();//abrindo a minha conexão

            int result = comando.ExecuteNonQuery();

            if (result > 0)
            {
                MessageBox.Show("Novo usuário cadastrado com sucesso!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                this.Visible = false;

                Login login = new Login();
                login.ShowDialog();
            }

            else
            {
                MessageBox.Show("Usuário não cadastrado!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
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
                    {
                        inserir();//chamando função
                    }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            verificaIgual();
        }

        private void CadExterno_MouseMove(object sender, MouseEventArgs e)
        {
            verificaIgual();
        }
    }
}
