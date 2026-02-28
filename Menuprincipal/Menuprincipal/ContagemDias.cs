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
    public partial class ContagemDias : Form
    {
        public ContagemDias()
        {
            InitializeComponent();
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
            if (initialDate.DayOfWeek != DayOfWeek.Sunday && initialDate.DayOfWeek != DayOfWeek.Saturday)
            {
                daysCount++;
            }
            
        }
        return daysCount;
    }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox1.Text=monthCalendar1.SelectionStart.ToShortDateString();
        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox2.Text = monthCalendar2.SelectionStart.ToShortDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Selecione a Data Inicial e a Data Final!", "Ajuda do sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
               DateTime a, b;
               a = Convert.ToDateTime(textBox1.Text);
               b = Convert.ToDateTime(textBox2.Text);
               textBox3.Text = Convert.ToString(contadias(a, b));
            }
        }

        private void ContagemDias_Load(object sender, EventArgs e)
        {

        }


        
    }
}
