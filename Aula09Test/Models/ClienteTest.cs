using Aula09.Models;


namespace Aula09Test.Models
{
    [TestClass]
    public class ClienteTest
    {
        [TestMethod]
        public void TestandoPropriedadesDaClasse()
        {
            var cliente = new Cliente();
            cliente.Id = "1111111";
            cliente.Nome = "rafael";
            cliente.Email = "rafaelteste.com";
            cliente.Telefone = "99999999999";

            Assert.AreEqual("1111111", cliente.Id);
            Assert.AreEqual("rafael", cliente.Nome);
            Assert.AreEqual("rafaelteste.com", cliente.Email);
            Assert.AreEqual("99999999999", cliente.Telefone);
        }
    }
}
