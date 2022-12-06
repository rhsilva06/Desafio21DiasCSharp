using System.Text.RegularExpressions;

namespace Aula07
{
    internal class Program
    {
        /*
         * Visando criar uma startup do sistema financeiro, iremos trabalhar 
         * para um cliente da empresa lina.
         * A primeira ação que você irá fazer:
         *  - Montar o menu de usabilidade para o uso da aplicação console.
         *  Exemplo:
         *  ===============================[Seja bem vindo a empresa lina]===============================
         *  O que você deseja fazer ?
         *  1 - Cadastro o cliente
         *  2 - Ver conta corrente
         *  3 - Fazer crédito em conta
         *  4 - Fazer débito em conta
         *  5 - Sair do sistema.
         *  
         *  construido o menu , iremos contruir outra parte do sistema.
         *  Esta  parte será o cadastro ou exclusão do cliente.
         *  Fazer o cadastro do cliente, quando o usuário selecionar a opção 1, pedir os seguintes dados
         *      - Nome do cliente
         *      - Telefone
         *      - E-mail
         *      
         *  Agora fazendo com funções
         */

        /// <summary>
        /// Lista para armazenar os cadastro de clientes do sistema.
        /// Posição dos campos no array: 
        ///     [0] - ID do cliente.
        ///     [1] - Nome do cliente.
        ///     [2] - Telefone do cliente.
        ///     [3] - Email do cliente.
        /// </summary>
        public static List<string[]> listaCliente = new ();

        /// <summary>
        /// Lista para armazenar os dados da conta corrente do cliente no sistema.
        /// Posição dos campos no array: 
        ///     [0] - ID do cliente.
        ///     [1] - Saldo
        /// </summary>
        public static List<string[]> listaClienteConta = new ();

        /// <summary>
        /// Ontem dados do cliente.
        /// </summary>
        /// <returns>Array com dados do cliente.</returns>
        public static string[]? ObtemCliente()
        {           

            Console.WriteLine("Informe o E-mail do cliente:");
            string email = Console.ReadLine() ?? string.Empty;
            var busca = listaCliente.Find(delegate (string[] p) { return p[3] == email; });
            if (busca == null)
            {
                Console.WriteLine($"Não foi encontrado nenhum cliente com o E-mail : {email}");

                if (OperacaoNovamente())
                {
                    return ObtemCliente();
                }
            }

            return busca;
        }

        public static double ObtemSaldoCliente(string id)
        {
            double saldo = 0;
            
            saldo = listaClienteConta.FindAll(delegate (string[] p) { return p[0] == id; }).Sum(x => double.Parse(x[1]));

            return saldo;
        }

        /// <summary>
        /// Método para obter dados da conta do cliente.
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <returns>Array conta do cliente</returns>
        public static List<string[]> ObtemClienteConta(string id)
        {            
           var busca = listaClienteConta.FindAll(delegate (string[] p) { return p[0] == id; });
            
            return busca;
        }

        /// <summary>
        /// Função para obter valor para o campo informado.
        /// </summary>
        /// <param name="titulo">Label do campo</param>
        /// <param name="nome">Nome do campo</param>
        /// <returns>Valor do campo</returns>
        public static string CampoTexto(string titulo, string nome, bool isValidaEmail = false)
        {
            Console.WriteLine(titulo);
            string valor = Console.ReadLine() ?? string.Empty;
            if (valor.Equals(string.Empty))
            {
                Console.WriteLine($"Preencha o campo : {nome}");
                return CampoTexto(titulo, nome, false);
            }

            if (isValidaEmail)
            {
                string mensagem = string.Empty;
                if(!ValidaEmail(valor, ref mensagem))
                {
                    Console.WriteLine($"{mensagem}");
                    return CampoTexto(titulo, nome, true);
                }
            }

            return valor;
        }

        /// <summary>
        /// Função para validar o campo email.
        /// </summary>
        /// <param name="email">Email a ser validado.</param>
        /// <param name="mensagem">Mensagem de retorno.</param>
        /// <returns>True/False</returns>
        public static bool ValidaEmail(string email, ref string mensagem)
        {
            var busca = listaCliente.Find(delegate (string[] p) { return p[3] == email; });
            if (busca != null)
            {
                mensagem = "E-mail já cadastrado no sistema.";
                return false;
            }


            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!match.Success)
            {
                mensagem = "E-mail inválido.";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Função para cadastro do cliente.
        /// </summary>
        public static void Cadastro()
        {
            Console.Clear();

            Console.WriteLine("============================[Cadastro de cliente]============================");

            var id = Guid.NewGuid();
            
            var nomeCliente = CampoTexto("Informe o nome do cliente", "nome do cliente", false);            
            var telefone = CampoTexto($"Informe o telefone do cliente {nomeCliente}", "telefone", false);            
            var email = CampoTexto($"Informe o email do cliente {nomeCliente}: ", "e-mail", true);

            string[] cliente = new string[4];

            cliente[0] = id.ToString();
            cliente[1] = nomeCliente;
            cliente[2] = telefone;
            cliente[3] = email;

            listaCliente.Add(cliente);

            Console.WriteLine($"""
                -----------------------------------------------------------------------------
                Cliente {nomeCliente} cadastrado com sucesso.             
                -----------------------------------------------------------------------------
                """);

            if (OperacaoNovamente())
            {
                Cadastro();
            }
        }

        /// <summary>
        /// Função para cadastrar debito para o cliente.
        /// </summary>
        /// <param name="cliente">Array Informações do cliente.</param>
        public static void Debito(string[]? cliente)
        {
            Console.Clear();

            if (cliente == null)
            {
                Console.WriteLine("===========================[Fazer débito em conta]===========================");

                ListarClientes();

                cliente = ObtemCliente();
            }


            if(cliente != null)
            {
                Console.WriteLine($"Cliente encontrado: {cliente[1]}");
                //Verificar se o cliente já possui algum saldo.
                var id = cliente[0];
                double saldo = ObtemSaldoCliente(id);

                if(saldo > 0)
                {
                    Console.WriteLine($"Informe o valor a ser debitado na conta de {cliente[1]}");
                    double.TryParse(Console.ReadLine(), out double valorDebito);

                    if (valorDebito > saldo)
                    {
                        Console.WriteLine($"O valor do resgate é maior que o saldo em conta: {saldo}");
                    }
                    else
                    {                        
                        var conta = new string[3];
                        conta[0] = cliente[0];
                        conta[1] = string.Concat("-", valorDebito);                        
                        conta[2] = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                        listaClienteConta.Add(conta);

                        saldo = ObtemSaldoCliente(id);

                        Console.WriteLine("Debito realizado com sucesso.");
                        Console.WriteLine($"Saldo atualizado: {saldo}");
                    }
                }               

                if (OperacaoNovamente())
                {
                    Debito(cliente);
                }
            }
        }

        /// <summary>
        /// Função para cadastrar credito para o cliente.
        /// </summary>
        /// <param name="cliente">Array Informações do cliente.</param>
        public static void Credito(string[]? cliente)
        {
            Console.Clear();            

            if (cliente == null)
            {
                Console.WriteLine("===========================[Fazer credito em conta]==========================");

                ListarClientes();

                cliente = ObtemCliente();
            }
            

            if (cliente != null)
            {
                Console.WriteLine($"Cliente encontrado: {cliente[1]}");

                Console.WriteLine($"Informe o valor a ser creditado na conta de {cliente[1]}");

                double valorCredito = 0;
                double.TryParse(Console.ReadLine(), out valorCredito);
                
                string[] conta = new string[3];
                conta[0] = cliente[0];
                conta[1] = valorCredito.ToString();
                conta[2] = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                listaClienteConta.Add(conta);

                string id = cliente[0];
                double saldo = ObtemSaldoCliente(id);

                Console.WriteLine($"Valor creditado com sucesso R$ {saldo}");

                if (OperacaoNovamente())
                {
                    Credito(cliente);
                }
            }            
        }

        /// <summary>
        /// Função para listar todos os clientes
        /// </summary>
        public static void ListarClientes()
        {
            Console.Clear();

            Console.WriteLine("============================[Lista de clientes]==============================");            
            if (listaCliente.Count() > 0)
            {
                foreach (var cliente in listaCliente)
                {
                    Console.WriteLine($"""
                    Id      : {cliente[0]}
                    Nome    : {cliente[1]}
                    Telefone: {cliente[2]}
                    E-mail  : {cliente[3]}
                    -----------------------------------------------------------------------------
                    """);
                }
            }
            else
            {
                Console.WriteLine("Nenhum cliente cadastrado");
            }            
        }

        /// <summary>
        /// Função para mostrar as informações de conta do cliente informado.
        /// </summary>
        public static void VerConta()
        {
            Console.Clear();

            Console.WriteLine("=============================[Ver conta corrente]============================");

            if (listaCliente.Count() > 0)
            {
                var cliente = ObtemCliente();

                if (cliente != null)
                {
                    Console.WriteLine($"""
                        Id      : {cliente[0]}
                        Nome    : {cliente[1]}
                        Telefone: {cliente[2]}
                        E-mail  : {cliente[3]}
                        -----------------------------------------------------------------------------
                        """);

                    var id = cliente[0];

                    var conta = ObtemClienteConta(id);
                    if (conta != null)
                    {
                        foreach (var item in conta)
                        {

                            Console.WriteLine($"""                                
                                Valor: {item[1]}
                                Data : {item[2]}
                                -----------------------------------------------------------------------------
                                """);                            
                        }

                        double saldo = ObtemSaldoCliente(id);

                        Console.WriteLine($"Total R$ {saldo}");
                    }
                    else
                    {
                        Console.WriteLine($"O Cliente {cliente[1]} não possiu creditos.");
                    }
                }
                else
                {
                    Console.WriteLine("Cliente não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
            }
        }

        /// <summary>
        /// Método para realizar a pergunta se deseja fazer o procedimento novamente.
        /// </summary>
        /// <returns>True/False</returns>
        public static bool OperacaoNovamente()
        {            
            Console.WriteLine("""
                Deseja realizar a operação novamente ?                                    
                Digite 1 - Para Sim
                Digite 2 - Para Não
                """);

            int opcaoSelecionada = 0;
            int.TryParse(Console.ReadLine(), out opcaoSelecionada);

            if(opcaoSelecionada == 1)
                return true;

            return false;
        }

        static void Main(string[] args)
        {
            while (true)
            {                

                Console.WriteLine("""
                    =======================[Seja bem vindo a empresa Lina]=======================                       
                    O que você deseja fazer ?
                    1 - Cadastro o cliente
                    2 - Ver conta corrente
                    3 - Fazer crédito em conta
                    4 - Fazer débito em conta
                    5 - Listar clientes.
                    6 - Sair do sistema
                    """);

                int opcaoSelecionada = 0;
                int.TryParse(Console.ReadLine(), out opcaoSelecionada);

                switch (opcaoSelecionada)
                {
                    case 1:
                        Cadastro();
                        break;
                    case 2:
                        VerConta();
                        break;
                    case 3:
                        Credito(null);                        
                        break;
                    case 4:                        
                        Debito(null);
                        break;                    
                    case 5:
                        ListarClientes();
                        break;
                    case 6:
                        Console.WriteLine("Saindo do sistema");
                        return;                        
                    default:
                        Console.WriteLine("Opção do menu inválida");
                        break;
                }
            }            
        }
    }
}