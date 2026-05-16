

namespace SGBD.Models
{
    public class Transacao //Classe que exibirá todo tipo e valor de transação
    {   // Propriedades da classe
        public string Tipo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime Data { get; private set; }

        public Transacao(string tipo, decimal valor, DateTime data) //Construtor
        {
            Tipo = tipo;
            Valor = valor;
            Data = data;
        }

    }
}