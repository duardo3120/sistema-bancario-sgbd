//Propriedade Base
// Metodo depositar concreto
// Metodo Sacar abstrato
//Exibirextrato

using System.Diagnostics.Contracts;

namespace SGBD.Models
{
    public abstract class Conta
    {
        //Numero da conta
        public int NroConta { get; private set; }

        // Nome do usuário
        public string Nome { get; private set; }

        //Saldo da conta
        public decimal Saldo { get; protected set; } // 
        // Alterado proteced para SALDO e Historico para as filhas poderem acessar

        public List<Transacao> Historico { get; protected set; } // Necessário implementar para movimentar histórico de ações para a classe Transacao que recebe os valores

        public Conta(int nroConta, string nome)
        {
            NroConta = nroConta;
            Nome = nome;
            Saldo = 0; // Apagado no construtor pois a conta precisa inicializar sem dinheiro.
            Historico = new List<Transacao>();
        }

        public void Depositar(decimal dinheiro) //Metodo que deposita valor ao saldo do usuário
        {

            if (dinheiro <= 0) // Verifica se o valor é valido para a somatória
            {
                throw new ArgumentException("Valor incorreto para continuar a operação"); // Lança uma excessão de erro: Valor incorreto
            }
            // Não é necessário else, pois o argument interrompe o código
            Saldo += dinheiro;
            var transacao = new Transacao("Deposito", dinheiro, DateTime.Now); // Instancia a classe Transacao
            Historico.Add(transacao); //Adiciona o objeto instaciado acima em uma lista

        }
        //Metodo TED, com parametro do dinheiro e destino
        public void Ted(decimal dinheiro, Conta destino) // Parametrizado numero com a classe Conta para referenciar de onde vem o TED
        {
            if (dinheiro + 5.00m > Saldo) // Verifica se o dinheiro que saíra é maior que saldo
            {
                throw new ArgumentException("Valor abaixo para transferência, operação cancelada");
            }
            Saldo -= (dinheiro + 5.00m); // Saldo subtrai dinheiro + a taxa
            destino.Depositar(dinheiro);
            var transacao = new Transacao("TED", dinheiro, DateTime.Now);
            Historico.Add(transacao);
            Console.WriteLine("Operação concluída.");
        }

        public void Pix(decimal dinheiro, Conta destino)
        {
            //Validar o horário
            if (DateTime.Now.Hour >= 22 || DateTime.Now.Hour <= 6)
            {
                throw new ArgumentException("Operação não pode ser realizada neste horário");
            }
            //Validar o saldo
            if (dinheiro > Saldo)
            {
                throw new ArgumentException("Valor acima para transferência, operação cancelada");
            }
            Saldo -= dinheiro;
            destino.Depositar(dinheiro);
            var transacao = new Transacao("Pix", dinheiro, DateTime.Now);
            Historico.Add(transacao);
            Console.WriteLine("Operação concluída.");
        }

        public abstract void Sacar(decimal dinheiro); //Metodo abstrato que será herdado pelas filhas

        public void ExibirExtrato()
        {
            Console.WriteLine($"Olá, {Nome}, seu saldo atual é {Saldo}");

            Console.WriteLine("Abaixo, você poderá verificar todo seu histórico");

            foreach (var historicos in Historico)
            {
                Console.WriteLine($"Dados das transação {historicos.Tipo}, {historicos.Valor}, {historicos.Data}"); //Foreach que roda toda a lista iterando todas transações
            }
        }



    }
}