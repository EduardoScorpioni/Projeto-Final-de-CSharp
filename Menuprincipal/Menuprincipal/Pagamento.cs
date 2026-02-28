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
    public partial class Pagamento : Form
    {
        string cnsql = "";//constructor - Permissão de acesso ao Banco 
        public Pagamento(string cn)//cn= permissão de acesso ao form CadExterno
        {
            cnsql = cn;
            InitializeComponent();
        }

        public string cliente, modelo, marca, placa, cpf, valor_diaria, diaria, data_inicio, data_fim, locacao_id, cliente_id;
        public double valor_final;

        private void inserirTabelaPagamento()
        {
            string sql = "insert into pagamentos (locacao_id, cliente_id, data_pagamento, valor_pago, metodo_pagamento) values (@locacao_id, @cliente_id, @data_pagamento, @valor_pago, @metodo_pagamento)";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            comando.Parameters.Add("@locacao_id", MySqlDbType.VarChar).Value =label16.Text;
            comando.Parameters.Add("@cliente_id", MySqlDbType.VarChar).Value =label19.Text;
            comando.Parameters.Add("@data_pagamento", MySqlDbType.Date).Value = Convert.ToDateTime(dateTimePicker1.Text).Date;
            comando.Parameters.Add("@valor_pago", MySqlDbType.Decimal).Value = valor_final;
            comando.Parameters.Add("@metodo_pagamento", MySqlDbType.VarChar).Value = comboBox1.Text;

            conexao.Open();//abrindo a minha conexão

            int result = comando.ExecuteNonQuery();

            if (result > 0)
            {
                MessageBox.Show("Aluguel efetuado com sucesso!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                MessageBox.Show("Erro de cadastro!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexao.Close();
        }

        private void AtualizarLocacoes()
        {
            string sql = "update locacoes set status='Cancelada' where locacao_id='" + label16.Text + "'";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            comando.Parameters.Add("@status", MySqlDbType.VarChar).Value = "Ativa";

            conexao.Open();//abrindo a minha conexão

            int result = comando.ExecuteNonQuery();

            if (result > 0)
            {
                MessageBox.Show("Locação cancelada.", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Locação não pode ser cancelada!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexao.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Deseja realmente cancelar esta locação? Esta ação será irreversível.", "Voltar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.Yes)
            {
                AtualizarLocacoes();
                Movimentacao Moviment = new Movimentacao(cnsql);
                this.Close();
                Moviment.ShowDialog();
            } 
        }

        private void Pagamento_Load(object sender, EventArgs e)
        {
            label60.Text = cliente;
            label58.Text = cpf;
            label56.Text = placa;
            label53.Text = modelo;
            label51.Text = marca;
            label64.Text = valor_diaria;
            label66.Text = diaria;
            label62.Text = Convert.ToString(valor_final);
            label2.Text = data_inicio;
            label16.Text = locacao_id;
            label19.Text = cliente_id;
            label4.Text = data_fim;

            // Adiciona itens ao ComboBox
            comboBox1.Items.Add("Pix (à vista)");
            comboBox1.Items.Add("Cartão de crédito");
            comboBox1.Items.Add("Cartão de débito");
            comboBox1.Items.Add("Carteira digital");
            comboBox1.Items.Add("Dinheiro");

            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
        }

        private void comboBox1_DrawItem_1(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return; // Verifica se o índice é válido

            e.DrawBackground(); // Desenha o fundo do item

            // Obtém o texto e a imagem correspondente ao item
            string texto = comboBox1.Items[e.Index].ToString();
            Image icone = imageList1.Images[e.Index]; // Usa o índice para obter a imagem

            // Configura a qualidade de interpolação para suavizar a imagem
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            // Aumenta o tamanho do ícone e do texto
            e.Graphics.DrawImage(icone, e.Bounds.Left, e.Bounds.Top, 30, 30); // Aumenta o tamanho do ícone

            Font textoFonte = new Font(e.Font.FontFamily, 16, FontStyle.Regular); // Aumenta o tamanho da fonte
            e.Graphics.DrawString(texto, textoFonte, Brushes.Black, e.Bounds.Left + 40, e.Bounds.Top); // Desenha o texto

            e.DrawFocusRectangle(); // Desenha o foco se o item estiver selecionado
        }



        private void button3_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Selecione o método de pagamento!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                if (dateTimePicker1.Text == "")
                {
                    MessageBox.Show("Selecione a data para pagamento!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    inserirTabelaPagamento();
                    Form1 form = new Form1(cnsql);
                    this.Visible = false;
                    form.ShowDialog();
                }
        }
    }
}
