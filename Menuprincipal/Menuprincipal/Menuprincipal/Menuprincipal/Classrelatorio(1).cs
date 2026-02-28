using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Menuprincipal
{
    public class listaclassrelatorio : List<Classrelatorio> { }//lista
    public class Classrelatorio//objeto
    {
        int locacao_id = 0;

        public int Locacao_id
        {
            get { return locacao_id; }
            set { locacao_id = value; }
        }
        string nome_cliente;

        public string Nome_cliente
        {
            get { return nome_cliente; }
            set { nome_cliente = value; }
        }
        string placa;

        public string Placa
        {
            get { return placa; }
            set { placa = value; }
        }
        string marca;

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }
        string modelo;

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }
        int ano = 0;

        public int Ano
        {
            get { return ano; }
            set { ano = value; }
        }
        string cor;

        public string Cor
        {
            get { return cor; }
            set { cor = value; }
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
