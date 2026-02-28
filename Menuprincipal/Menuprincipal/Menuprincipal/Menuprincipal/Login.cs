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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        //area de variaveis globais

        //variavel de conexão co a base de dados
        string cnsql = @"SERVER=localhost;DATABASE=escola;UID=root;PASSWORD=''";

        private void consultar()
        {
            comboBox1.Items.Clear();
            string sql = "select email from usuarios where email LIKE '%" + comboBox1.Text +"'";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                {
                    comboBox1.Items.Add (Convert.ToString(leia["email"]));
                }
            }

            conexao.Close();//fechando a conexão
        }

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

        //funções
        private void acesso()
        {
            string sql = "select * from usuarios where email=@email";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            comando.Parameters.Add("@email", MySqlDbType.VarChar).Value = comboBox1.Text;//definindo o parametro de comparação
            conexao.Open();//abrindo a minha conexão
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.Read())//se achou o email la na tabela entra aqui
            {
                if (Convert.ToString(leia["senha"]) == Criptografia.md5(textBox2.Text))
                {
                    Form1 principal = new Form1(cnsql);//Permissão(estanciar)
                    MessageBox.Show("Seja bem vindo ao Sistema! " + leia["nome"]);
                    principal.ShowDialog();
                    this.Visible = false;
                    
                }

                else
                {
                    MessageBox.Show("E-mail ou senha não encontrados!");
                    //textBox1.Clear();
                    textBox2.Clear();
                }
            }

            else
            {
                MessageBox.Show("E-mail ou senha incorretos!");
               // textBox1.Clear();
                textBox2.Clear();
            }
        }

        //Botão de acesso ao sistema

        private void button1_Click(object sender, EventArgs e)
        {
            //if (textBox1.Text == "")
            //{
            //    MessageBox.Show("Insira o E-mail!");
                //textBox1.Focus();
            //}
           
            //else
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Insira a senha!");
                    textBox2.Focus();
                }
                else
                {
                    acesso();//chamando função
                }
                

        }

        private void label3_Click(object sender, EventArgs e)
        {
            CadExterno cad = new CadExterno(cnsql);
            cad.ShowDialog();

            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            consultar();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            consultar();
        }

    }
}
