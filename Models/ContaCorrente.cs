namespace SGBD.Models
{
    public class ContaCorrente : Conta
    {
        public ContaCorrente(int nroConta, string nome) : base(nroConta, nome) { }

        public override void Sacar(decimal dinheiro)
        {
            if ((dinheiro + 2.5m) > Saldo)
            {
                throw new ArgumentException("Saldo insuficiente");
            }
            Saldo -= (dinheiro + 2.5m);
            var transacao = new Transacao("Sacar", dinheiro, DateTime.Now);
            Historico.Add(transacao);
        }
    }
}