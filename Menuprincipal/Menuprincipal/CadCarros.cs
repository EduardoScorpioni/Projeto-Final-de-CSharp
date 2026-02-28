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
    public partial class CadCarros : Form
    {
        string cnsql = "";//constructor - Permissão de acesso ao Banco 
        public CadCarros(string cn)//cn= permissão de acesso ao form CadExterno
        {
            cnsql = cn;
            InitializeComponent();
        }

        string placa;
        private void verificaIgual()
        {
            string sql = "select * from carros where placa=@placa";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco
            comando.Parameters.Add("@placa", MySqlDbType.VarChar).Value = placa;
            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//se achou??
            {
                MessageBox.Show("A placa: " + placa + " já existe", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox2.Clear();
                maskedTextBox1.Clear();
            }
            conexao.Close();//fechando a conexão com o banco
        }


        private void inserir()
        {
            // Atribui o valor da placa com base no TextBox visível
            if (maskedTextBox1.Visible==true)
            {
                placa = maskedTextBox1.Text;
            }
            else if (maskedTextBox2.Visible==true)
            {
                placa = maskedTextBox2.Text;
            }

            string sql = "insert into carros (modelo, marca, ano, placa, cor, status, preco_diaria, categoria) values (@modelo, @marca, @ano, @placa, @cor, @status, @preco_diaria, @categoria)";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            comando.Parameters.Add("@modelo", MySqlDbType.VarChar).Value = comboBox1.Text;
            comando.Parameters.Add("@marca", MySqlDbType.VarChar).Value = comboBox2.Text;
            comando.Parameters.Add("@ano", MySqlDbType.VarChar).Value = comboBox3.Text;
            comando.Parameters.Add("@placa", MySqlDbType.VarChar).Value = placa;
            comando.Parameters.Add("@cor", MySqlDbType.VarChar).Value = textBox7.Text;
            comando.Parameters.Add("@status", MySqlDbType.VarChar).Value = textBox8.Text;
            comando.Parameters.Add("@preco_diaria", MySqlDbType.VarChar).Value = comboBox6.Text;
            comando.Parameters.Add("@categoria", MySqlDbType.VarChar).Value = comboBox4.Text;

            conexao.Open();//abrindo a minha conexão

            int result = comando.ExecuteNonQuery();

            if (result > 0)
            {
                MessageBox.Show("Novo veículo cadastrado com sucesso!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                pictureBox5_Click(null, null);//chamando a ação de limpar do botão
                consultar();//chamando a função consultar
                ConsultarMarca();
            }

            else
            {
                MessageBox.Show("Veículo não cadastrado!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexao.Close();
        }


        private void editar()
        {

            string sql = "update carros set modelo=@modelo, marca=@marca, ano=@ano, placa=@placa, cor=@cor, status=@status, preco_diaria=@preco_diaria, categoria=@categoria where carro_id='" + textBox4.Text + "'";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            comando.Parameters.Add("@modelo", MySqlDbType.VarChar).Value = comboBox1.Text;
            comando.Parameters.Add("@marca", MySqlDbType.VarChar).Value = comboBox2.Text;
            comando.Parameters.Add("@ano", MySqlDbType.VarChar).Value = comboBox3.Text;
            comando.Parameters.Add("@placa", MySqlDbType.VarChar).Value = placa;
            comando.Parameters.Add("@cor", MySqlDbType.VarChar).Value = textBox7.Text;
            comando.Parameters.Add("@status", MySqlDbType.VarChar).Value = textBox8.Text;
            comando.Parameters.Add("@preco_diaria", MySqlDbType.VarChar).Value = comboBox6.Text;
            comando.Parameters.Add("@categoria", MySqlDbType.VarChar).Value = comboBox4.Text;

            conexao.Open();//abrindo a minha conexão

            int result = comando.ExecuteNonQuery();

            if (result > 0)
            {
                MessageBox.Show(result + " registro atualizado com sucesso!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                pictureBox5_Click(null, null);//chamando a ação de limpar do botão
                consultar();//chamando a função consultar
                ConsultarMarca();
            }

            else
            {
                MessageBox.Show("Registro não atualizado!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexao.Close();
        }





        private void excluir()
        {
            string sql = "delete from carros where carro_id='" + textBox4.Text + "'";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();//abrindo a minha conexão

            int result = comando.ExecuteNonQuery();

            if (result > 0)
            {
                MessageBox.Show(result + " registro(s) excluído(s) com sucesso!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                pictureBox5_Click(null, null);//chamando botão limpar

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
            string sql = "select * from carros where modelo LIKE '%" + textBox5.Text + "%'";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                {
                    dataGridView1.Rows.Add(Convert.ToString(leia["carro_id"]), Convert.ToString(leia["modelo"]), Convert.ToString(leia["marca"]), Convert.ToString(leia["ano"]), Convert.ToString(leia["placa"]), Convert.ToString(leia["cor"]), Convert.ToString(leia["status"]), Convert.ToString(leia["preco_diaria"]), Convert.ToString(leia["categoria"]));
                }
            }

            conexao.Close();//fechando a conexão
        }



        private void consultar()
        {
            dataGridView1.Rows.Clear();//limpando o grid de visualização
            string sql = "select * from carros";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando caminho do banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//comparação do que foi digitado no form com a informação do banco

            conexao.Open();
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto ele esiver encontrando dados ele vai exibir as informações no grid
                {
                    dataGridView1.Rows.Add(Convert.ToString(leia["carro_id"]), Convert.ToString(leia["modelo"]), Convert.ToString(leia["marca"]), Convert.ToString(leia["ano"]), Convert.ToString(leia["placa"]), Convert.ToString(leia["cor"]), Convert.ToString(leia["status"]), Convert.ToString(leia["preco_diaria"]), Convert.ToString(leia["categoria"]));
                }
            }

            else
            {
                MessageBox.Show("Nenhum registro encontrado!");
            }

            conexao.Close();//fechando a conexão
        }

        private void ConsultarMarca()
        {
            comboBox2.Items.Clear();//limpando o combobox de visualização
            string sql = "select distinct marca from catalogo order by marca";
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
            string sql = "select distinct modelo from catalogo where marca='" + comboBox2.Text + "' order by modelo";
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


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Deseja realmente voltar ao menu?", "Voltar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.Yes)
            {
                this.Close();
            } 
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Informe o modelo!");
                comboBox1.Focus();
            }

            else
                if (comboBox2.Text == "")
                {
                    MessageBox.Show("Informe o marca!");
                    comboBox2.Focus();
                }

                else
                    if (comboBox3.Text == "")
                    {
                        MessageBox.Show("Informe a ano!");
                        comboBox3.Focus();
                    }

                    else
                        if (comboBox5.Text == "")
                        {
                            MessageBox.Show("Informe a placa!");
                            comboBox5.Focus();
                        }
                        else
                            if (maskedTextBox1.Text == "" || maskedTextBox2.Text=="")
                            {
                                MessageBox.Show("Informe a placa!");
                                comboBox5.Focus();
                            }

                        else
                            if (textBox7.Text == "")
                            {
                                MessageBox.Show("Informe a cor!");
                                textBox7.Focus();
                            }

                            else
                                if (textBox8.Text == "")
                                {
                                    MessageBox.Show("Informe a status!");
                                    textBox8.Focus();
                                }

                                else
                                    if (comboBox6.Text == "")
                                    {
                                        MessageBox.Show("Informe a diária!");
                                        comboBox6.Focus();
                                    }

                                    else
                                        if (comboBox4.Text == "")
                                        {
                                            MessageBox.Show("Informe a categoria!");
                                            comboBox4.Focus();
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            comboBox3.Text="";
            comboBox4.Text = "";
            textBox7.Clear();
            textBox5.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            textBox8.Clear();
            comboBox6.Text = "";
            comboBox4.Items.Clear();
            textBox4.Clear();
            dataGridView1.Rows.Clear();
            placa = "";
            label12.Visible = false;
            maskedTextBox1.Visible = false;
            maskedTextBox2.Visible = false;
            comboBox5.SelectedIndex = -1; // Limpa a seleção e o texto exibido
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            consultar();//função de consultar
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

        private void CadCarros_MouseMove(object sender, MouseEventArgs e)
        {
            if (textBox4.Text == "")
            {
                verificaIgual();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //modelo
            comboBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);

            //marca
            comboBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);

            //ano
            comboBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);

            //placa
            maskedTextBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);

            //placa mercosul
            maskedTextBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);

            //cor
            textBox7.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);

            //status
            textBox8.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value);

            //diaria
            comboBox6.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[7].Value);

            //categoria
            comboBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[8].Value);

            //código
            textBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
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

        private void CadCarros_Load(object sender, EventArgs e)
        {
            ConsultarMarca();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConsultarModelo();
            textBox8.Text = "Disponível";
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text == "Placa Cinza")
            {
                label12.Visible = true;
                maskedTextBox1.Visible = true;                
                maskedTextBox2.Visible = false;
                placa = maskedTextBox1.Text;
            }
            else
                if(comboBox5.Text == "Placa Mercosul")
                {
                    label12.Visible = true;
                    maskedTextBox1.Visible = false;
                    maskedTextBox2.Visible = true;
                    placa = maskedTextBox2.Text;
                }
        }

        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {
            placa = maskedTextBox2.Text;
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            placa = maskedTextBox1.Text;
        }

        private void maskedTextBox2_Leave(object sender, EventArgs e)
        {
            placa = maskedTextBox2.Text;
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            placa = maskedTextBox1.Text;
        }

        
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Color selectedColor = colorDialog.Color;

                // Verifica se a cor é conhecida e possui um nome
                string selectedColorName;
                if (selectedColor.IsKnownColor)
                {
                    selectedColorName = selectedColor.Name; // Nome da cor, como "Red", "Blue", etc.
                }
                else
                {
                    // Caso a cor não seja conhecida, salva o código hexadecimal
                    selectedColorName = ColorTranslator.ToHtml(selectedColor);
                }

                // Exibe a cor no TextBox
                textBox7.Text = selectedColorName; // Aqui o nome da cor ou o código hexadecimal será exibido
            }
        }

        private void maskedTextBox2_MouseLeave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                verificaIgual();
            }
        }

        private void maskedTextBox1_MouseLeave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                verificaIgual();
            }
        }

        private void maskedTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox4.Text == "")
            {
                verificaIgual();
            }
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox4.Text == "")
            {
                verificaIgual();
            }
        }

   
    }
}
