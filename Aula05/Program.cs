using System.Drawing;

namespace Aula05
{
    internal class Program
    {
        /// <summary>
        /// PayBank é uma startup do sistema financeiro.
        /// eles precisam de um programa que cadastre um cliente 
        /// com o saldo do investimento do mesmo.
        /// 
        /// criar um programa que solicite o investidor e o saldo que deseja colocar.
        /// após colocar o dinheiro do cliente desconte uma taxa de 0.05%
        /// após essa operação, pergunte algo cliente eo mesmo deseja sacar o dinheiro
        /// se o cliente deseja sacar , coloque para o mesmo para digitar o valor do saque
        /// se o saque for maior que o valor depositado em conta - o desconto de taxa
        /// mostrar a mensagem na tela falando que o valor do resgate é maior que o saldo em conta.
        // 
        /// </summary>
        public static void Exercicio03()
        {
            Console.WriteLine("============================[PayBank]============================");
            Console.WriteLine("Digite o nome do investidor: ");
            var nomeInvestidor = Console.ReadLine();

            Console.WriteLine($"{nomeInvestidor} informe o valor a ser investido: ");
            double valorInvestido = 0;
            double.TryParse(Console.ReadLine(), out valorInvestido);

            double taxa = valorInvestido * 0.05 / 100;

            valorInvestido = valorInvestido - taxa;

            Console.WriteLine($"{nomeInvestidor} você deseja sacar o dinheiro ? Digite 1 para Sim - 0 para Não");
            int sacarDinheiro = 0;
            int.TryParse(Console.ReadLine(), out sacarDinheiro);
            if (sacarDinheiro == 1)
            {
                Console.WriteLine("Informe o valor do saque: ");
                double valorSaque = 0;
                double.TryParse(Console.ReadLine(), out valorSaque);

                if (valorSaque > valorInvestido)
                {
                    Console.WriteLine($"O valor do resgate é maior que o saldo em conta: {valorInvestido}");
                }
                else
                {
                    Console.WriteLine("Saque realizado com sucesso.");
                    Console.WriteLine($"Saldo atualizado: {valorInvestido - valorSaque}");
                }
            }
        }

        public static void Menu()
        {
            while (true)
            {
                Console.WriteLine("""
                    1 - Para fazer algo
                    2 - Para fazer algo
                    3 - Para sair do programa
                    """);
                int opcaoSelecionada = 0;
                int.TryParse(Console.ReadLine(), out opcaoSelecionada);

                if (opcaoSelecionada == 3) break;

                switch (opcaoSelecionada)
                {
                    case 1:
                        Console.WriteLine("");
                        break;
                    case 2:
                        Console.WriteLine("");
                        break;
                    default:
                        Console.WriteLine("Opção do menu inválida");
                        break;
                }
            }
        }

        /// <summary>        
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Program.Menu();
        }
    }
}