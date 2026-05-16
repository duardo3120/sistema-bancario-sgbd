using System.Runtime.CompilerServices;
using SGBD.Models;

namespace SGBD.Services
{
    public class Banco
    {
        private Dictionary<int, Conta> contas = new Dictionary<int, Conta>(); //key, value, nome = new dict, key, value

        public List<Conta> ObterTodasAsContas()
        {
            return contas.Values.ToList();
        }
        public void AdicionarConta(Conta novaConta) // Parametro do objeto da conta
        {
            contas.Add(novaConta.NroConta, novaConta);
        }

        public void Transferir(int contaOrigem, decimal valor, int contaDestino, string trans)
        {
            if (contas.ContainsKey(contaOrigem) && contas.ContainsKey(contaDestino)) // Nessa trava de segurança, constains só busca valores chaves int correspondente ao "Banco"
            {
                Conta contaOrigemObj = contas[contaOrigem]; //Ambas variaveis instanciam da classe conta para acessar o Banco com os IDS INFORMADOS
                Conta contaDestinoObj = contas[contaDestino];

                if (trans.ToUpper() == "TED")
                {
                    //Chamar metodo TED
                    contaOrigemObj.Ted(valor, contaDestinoObj);
                }
                else if (trans.ToUpper() == "PIX")
                {
                    contaOrigemObj.Pix(valor, contaDestinoObj);
                }
                else
                {
                    throw new ArgumentException("Operação incorreta!");
                }
            }
            else
            {
                throw new ArgumentException("Contas não encontadas");
            }
        }

        public void RealizarDeposito(decimal valor, int numeroConta)
        {
            if (contas.ContainsKey(numeroConta))
            {
                Conta contaDestinoObj = contas[numeroConta];

                contaDestinoObj.Depositar(valor);
            }
            else
            {
                throw new ArgumentException("Conta não encontrada");
            }
        }

        public void RealizarSaque(int contaDestino, decimal valor)
        {
            if (contas.ContainsKey(contaDestino))
            {
                Conta contaDestinoObj = contas[contaDestino];

                contaDestinoObj.Sacar(valor);
            }
            else
            {
                throw new ArgumentException("Conta não encontrada");
            }
        }

    }

}