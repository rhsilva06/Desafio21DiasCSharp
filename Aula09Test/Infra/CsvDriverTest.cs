using Aula09.Infra;
using Aula09.Models;

namespace Aula09Test.Infra
{
    [TestClass]
    public class CsvDriverTest
    {
        public CsvDriverTest()
        {
            var caminho = Environment.GetEnvironmentVariable("TEMP") ?? "/tmp";
            this.caminhoArquivoTest = caminho;
            this.csvDriver = new CsvDriver(this.caminhoArquivoTest);
        }

        private string caminhoArquivoTest;
        private CsvDriver csvDriver;

        [TestMethod]
        public async Task TestandoDriverCsvParaClientes()
        {

            var cliente = new Cliente()
            {
                Id = Guid.NewGuid().ToString(),
                Nome = "Danilo",
                Email = "danilo@teste.com",
                Telefone = "(11)9999-9999"
            };

            await this.csvDriver.Salvar(cliente);

            var existe = File.Exists(this.caminhoArquivoTest + "/clientes.csv");
        }

        [TestMethod]
        public async Task TestandoDriverCsvParaContaCorrente()
        {
            var contaCorrente = new ContaCorrente()
            {
                ClienteId = Guid.NewGuid().ToString(),
                Valor = 200,
                Data = DateTime.Now
            };

            await csvDriver.Salvar(contaCorrente);

            var existe = File.Exists(this.caminhoArquivoTest + "/contacorrentes.csv");
        }
    }
}
