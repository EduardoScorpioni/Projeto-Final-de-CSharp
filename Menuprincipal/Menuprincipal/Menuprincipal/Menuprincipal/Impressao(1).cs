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
    public partial class Impressao : Form
    {
        
        public Impressao()
        {
           
            InitializeComponent();
        }


        //apontar para a lista
        public void imprimir(Menuprincipal.Imprimir cadastro)
        {
            relatorioimprimirBindingSource.DataSource = cadastro;
        }


        private void Impressao_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
