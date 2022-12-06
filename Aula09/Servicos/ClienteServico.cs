using Aula09.Models;

namespace Aula09.Servicos
{
    class ClienteServico
    {
        private ClienteServico() { }

        private static ClienteServico instancia = default!;

        public static ClienteServico Get()
        {
            if (instancia == null)
            {
                instancia = new ClienteServico();
            }

            return instancia;
        }

        public List<Cliente> Lista = new List<Cliente>();

        public Cliente ObtemClientePorEmail(string email)
        {
            return Get().Lista.Where(c => c.Email == email).FirstOrDefault();
        }

        public bool Salvar(Cliente cliente)
        {
            Get().Lista.Add(cliente);
            return true;
        }
    }
}
