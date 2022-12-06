using Aula09.Models;
using System.Runtime.CompilerServices;

namespace Aula09.Servicos
{
    class ContaCorrenteServico
    {
        private  ContaCorrenteServico() { }

        private static ContaCorrenteServico instancia = default!;

        public static ContaCorrenteServico Get()
        {
            if(instancia == null)
            {
                instancia= new ContaCorrenteServico();
            }

            return instancia;
        }

        public List<ContaCorrente> Lista = new List<ContaCorrente>();

        public double ObtemSaldoCliente(string id)
        {
            double saldo = 0;

            saldo = Get().Lista.Where(c => c.ClienteId == id).Sum(c => c.Valor);
            //saldo = listaClienteConta.FindAll(delegate (dynamic p) { return p.ClienteId == id; }).Sum(x => x.Valor);

            return saldo;
        }

        /// <summary>
        /// Método para obter dados da conta do cliente.
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <returns>Array conta do cliente</returns>
        public List<ContaCorrente> ObtemClienteConta(string id)
        {
            var busca = Get().Lista.FindAll(delegate (ContaCorrente p) { return p.ClienteId == id; });

            return busca;
        }

        public bool Salvar(ContaCorrente conta)
        {
            Get().Lista.Add(conta);
            return true;
        }
    }
}
