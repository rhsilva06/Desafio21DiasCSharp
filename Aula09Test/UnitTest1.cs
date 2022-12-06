using Aula09.Models;

namespace Aula09Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var cliente = new Cliente
            {
                Id = "1",
                Nome = "Rafael",
                Telefone = "11999999999",
                Email = "rafael@teste.com"

            };

            Assert.AreEqual(30, cliente.Id);
        }
    }
}