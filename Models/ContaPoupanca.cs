namespace SGBD.Models
{
    public class ContaPoupanca : Conta
    {
        public ContaPoupanca(int nroConta, string nome) : base(nroConta, nome) { }

        public override void Sacar(decimal dinheiro)
        {
            if (dinheiro > Saldo)
            {
                throw new ArgumentException("Saldo insuficiente");
            }
            Saldo -= dinheiro;
            var transacao = new Transacao("Sacar", dinheiro, DateTime.Now);
            Historico.Add(transacao);
        }
    }
}