using Aula09.Models;
using Aula09.Servicos;

namespace Aula09Test.Servicos
{
    [TestClass]
    public class ClienteServicoTest
    {
        [TestMethod]
        public void TestandoUnicaInstanciaDoServico()
        {
            Assert.IsNotNull(ClienteServico.Get());
            Assert.IsNotNull(ClienteServico.Get().Lista);

            ClienteServico.Get().Lista.Add(new Cliente()
            {
                Nome = "teste"
            });

            Assert.AreEqual(1, ClienteServico.Get().Lista.Count);
        }
    }
}
