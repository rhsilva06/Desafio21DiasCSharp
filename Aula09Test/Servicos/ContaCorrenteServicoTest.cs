using Aula09.Models;
using Aula09.Servicos;

namespace Aula09Test.Servicos
{
    [TestClass]
    public class ContaCorrenteServicoTest
    {
        #region Metodos de setup test
        [TestInitialize()]
        public void Startup()
        {
            // Console.WriteLine("=========[Antes do teste]==========");
            ContaCorrenteServico.Get().Lista = new List<ContaCorrente>();
        }

        [TestCleanup()]
        public void Cleanup()
        {
            // ContaCorrenteServico.Get().Lista = new List<ContaCorrente>();
            Console.WriteLine("=========[Depois do teste]==========");
        }
        #endregion

        #region Metodos helpers
        private void criaDadosContaFake(string clienteId, double[] valores)
        {
            foreach (var valor in valores)
            {
                ContaCorrenteServico.Get().Lista.Add(new ContaCorrente()
                {
                    ClienteId = clienteId,
                    Valor = valor,
                    Data = DateTime.Now
                });
            }
        }
        #endregion

        [TestMethod]
        public void TestandoUnicaInstanciaDoServico()
        {
            Assert.IsNotNull(ContaCorrenteServico.Get());
            Assert.IsNotNull(ContaCorrenteServico.Get().Lista);

            ContaCorrenteServico.Get().Lista.Add(new ContaCorrente()
            {
                ClienteId = "2122222"
            });

            Assert.AreEqual(1, ContaCorrenteServico.Get().Lista.Count);
        }

        [TestMethod]
        public void TestandoRetornoDoExtrato()
        {
            // Preparação (Arrange)
            var clienteId = Guid.NewGuid().ToString();
            criaDadosContaFake(clienteId, new double[] { 100.5, 10 });

            // Processamento dados (Act)
            var extrato = ContaCorrenteServico.Get().ObtemClienteConta(clienteId); 

            // Validação (Assert)
            Assert.AreEqual(2, extrato.Count);
        }

        [TestMethod]
        public void TestandoRetornoDoExtratoComQuantidadeAMais()
        {
            // Preparação (Arrange)
            var clienteId = Guid.NewGuid().ToString();
            criaDadosContaFake(clienteId, new double[] { 100.01, 50 });

            var clienteId2 = Guid.NewGuid().ToString();
            criaDadosContaFake(clienteId2, new double[] { 40 });

            // Processamento dados (Act)
            var extrato = ContaCorrenteServico.Get().ObtemClienteConta(clienteId2);

            // Validação (Assert)
            Assert.AreEqual(1, extrato.Count);
            Assert.AreEqual(3, ContaCorrenteServico.Get().Lista.Count);
        }

        [TestMethod]
        public void TestandoSaldoDeUmCliente()
        {
            // Preparação (Arrange)
            var clienteId = Guid.NewGuid().ToString();
            criaDadosContaFake(clienteId, new double[] { 5, 5, 5, -10 });
            criaDadosContaFake(Guid.NewGuid().ToString(), new double[] { 300, 45 });

            // Processamento dados (Act)
            var saldo = ContaCorrenteServico.Get().ObtemSaldoCliente(clienteId);

            // Validação (Assert)
            Assert.AreEqual(5, saldo);
            Assert.AreEqual(6, ContaCorrenteServico.Get().Lista.Count);
        }
    }
}
