using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Menuprincipal
{
    public partial class Form1 : Form
    {
        string cnsql = "";//constructor - Permissão de acesso ao Banco
        public Form1(string cn)
        {
            cnsql = cn;//permissao
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Deseja realmente sair do sistema?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.Yes)
            {
                Application.Exit();
            } 
        }

        private void comboBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComboBox combobox = new ComboBox(); //Permissão(estanciar)
            combobox.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mensagemDialogadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mensagem mensagem = new Mensagem(); //Permissão(estanciar)
            mensagem.ShowDialog();      
        }

        private void depositoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Deposito dep= new Deposito(); //Permissão(estanciar)
            dep.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void rádioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Radio radio = new Radio(); //Permissão(estanciar)
            radio.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadUsuario cadastro = new CadUsuario(cnsql);
            cadastro.ShowDialog();
        }

        private void contagemDeDiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContagemDias contagem = new ContagemDias();
            contagem.ShowDialog();
        }

        private void letrasNúmerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LetrasNumeros ln = new LetrasNumeros();
            ln.ShowDialog();
        }

        private void alunosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadAlunos alunoscad = new CadAlunos(cnsql);
            alunoscad.ShowDialog();
        }

        private void calculadoraCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalculadoraCase carqui = new CalculadoraCase();
            carqui.ShowDialog();
        }

        private void carrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadCarros carros = new CadCarros(cnsql);
            carros.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadClientes clientes = new CadClientes(cnsql);
            clientes.ShowDialog();
        }

        private void funcionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadFuncionarios funcionario = new CadFuncionarios(cnsql);
            funcionario.ShowDialog();
        }

        private void movimentaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void locaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Movimentacao mov = new Movimentacao(cnsql);
            mov.ShowDialog();
        }

        private void devoluçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Devolucao devolucao = new Devolucao(cnsql);
            devolucao.ShowDialog();
        }

        private void veiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelatorioLocacoes rel = new RelatorioLocacoes(cnsql);
            rel.ShowDialog();
        }
    }
}
