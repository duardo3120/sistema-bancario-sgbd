using SGBD.Models;
using SGBD.Services;

// Instanciamos banco
Banco banco = new Banco();

while (true)
{
    Console.WriteLine("=== SISTEMA BANCÁRIO ===");
    Console.WriteLine("1 - Criar Conta");
    Console.WriteLine("2 - Fazer Transferência (Pix/TED)");
    Console.WriteLine("3 - Depositar");
    Console.WriteLine("4 - Sacar");
    Console.WriteLine("5 - Relatórios");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");

    string opcao = Console.ReadLine() ?? "0";


    switch (opcao)
    {
        case "1":
            Console.WriteLine("Qual seu nome?");
            string nome = Console.ReadLine() ?? ""; // Adicionado ?? para aceitar nulo

            Console.WriteLine("Qual tipo de conta deseja? Corrente / Poupanca");
            string tipo = Console.ReadLine() ?? "";

            int numeroGerado = new Random().Next(1, 9999);

            Conta novaConta; // Criando apenas a conta não fica redundante o código

            if (tipo == "Corrente")
            {
                novaConta = new ContaCorrente(numeroGerado, nome);
            }
            else
            {
                novaConta = new ContaCorrente(numeroGerado, nome);
            }

            banco.AdicionarConta(novaConta);
            Console.WriteLine($"Conta criada com sucesso! Anote seu número: {numeroGerado}\n");
            break;

        case "2":
            Console.WriteLine("Qual transferência deseja realizar? Pix/ TED");
            string trans = Console.ReadLine() ?? "";

            Console.WriteLine("Por favor informar número da conta de origem");
            int contaOrigem = int.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Digite o valor: ");
            decimal valor = decimal.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Por favor informar número da conta destino");
            int contaDestino = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine($"Operação concluída com sucesso para {contaDestino}");
            try
            {
                banco.Transferir(contaOrigem, valor, contaDestino, trans);

                Console.WriteLine("Transferência realizada!\n");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro na operação:  {ex.Message}");
            }
            break;

        case "3":
            Console.WriteLine("Por favor informe o valor que deseja depositar");
            decimal dinheiro = decimal.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Por favor informar número da conta destino");
            int destinoConta = int.Parse(Console.ReadLine() ?? "0");

            try
            {
                banco.RealizarDeposito(dinheiro, destinoConta);

                Console.WriteLine("Operação realizada com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            break;

        case "4":
            Console.WriteLine("Por favor informe sua conta");
            int destino = int.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Digite o valor para saque ");
            decimal valorSaque = decimal.Parse(Console.ReadLine() ?? "0");

            try
            {
                banco.RealizarSaque(destino, valorSaque);

                Console.WriteLine("Operação realizada com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            break;

        case "5":
            var todasAsContas = banco.ObterTodasAsContas();

            var clientesVip = todasAsContas
                                .Where(n => n.Saldo > 50000)
                                .OrderByDescending(n => n.Saldo)
                                .ToList();


            foreach (var conta in clientesVip)
            {
                Console.WriteLine($"Titular: {conta.Nome} | Saldo: R$ {conta.Saldo}");
            }

            break;

        case "0":
            Console.WriteLine("Saindo do sistema...");
            return; // O return mata o console inteiro, encerrando o while(true)
        default:
            Console.WriteLine("Opção inválida! Tente novamente.\n");
            break;
    }
}