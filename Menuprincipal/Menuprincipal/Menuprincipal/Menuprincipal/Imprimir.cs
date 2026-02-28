using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Menuprincipal
{
    public class relatorioimprimir : List<Imprimir> { }//lista
    public class Imprimir//objeto
    {
        int locacao_id = 0;

        public int Locacao_id
        {
            get { return locacao_id; }
            set { locacao_id = value; }
        }
        int carro_id = 0;

        public int Carro_id
        {
            get { return carro_id; }
            set { carro_id = value; }
        }
        int cliente_id = 0;

        public int Cliente_id
        {
            get { return cliente_id; }
            set { cliente_id = value; }
        }
        DateTime data_inicio;

        public DateTime Data_inicio
        {
            get { return data_inicio; }
            set { data_inicio = value; }
        }

        DateTime data_fim;

        public DateTime Data_fim
        {
            get { return data_fim; }
            set { data_fim = value; }
        }
      
        int valor_total = 0;

        public int Valor_total
        {
            get { return valor_total; }
            set { valor_total = value; }
        }
        string status = "";

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
