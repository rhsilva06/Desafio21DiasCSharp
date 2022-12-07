using Aula09.Models;

namespace Aula09Test.Models
{
    [TestClass]
    public class ContaCorrenteTest
    {
        [TestMethod]
        public void TestandoPropriedadesDaClasse()
        {
            var contaCorrenteTest = new ContaCorrente();
            contaCorrenteTest.ClienteId = "234321";
            contaCorrenteTest.Valor = 1;
            contaCorrenteTest.Data = DateTime.Now;

            Assert.AreEqual("234321", contaCorrenteTest.ClienteId);
            Assert.AreEqual(1, contaCorrenteTest.Valor);
            Assert.IsNotNull(contaCorrenteTest.Data);
        }
    }
}
