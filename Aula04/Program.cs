namespace Aula04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int myValue = 7;

            switch (myValue)
            {
               case <= 0:
                    Console.WriteLine("Less than or equal to 0");
                    break;
                case > 0 and <= 10:
                    Console.WriteLine($"More than 0 but less than or equal to 10 {myValue}");
                    break;
                default:
                    Console.WriteLine("More than 10");
                    break;
            }

            Console.WriteLine("==============================[Posto de gasolina]==============================");
            

            Console.WriteLine("Informe a quantidade de litros do posto de combustivel: ");
            double qtdeLitroPosto = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Informe o preço por litro de combustivel: ");
            double precoPorLitro = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Informe o nome do cliente: ");
            var nomeCliente = Console.ReadLine();

            Console.WriteLine($"Informe o valor R$ que o cliente {nomeCliente} deseja abastecer: ");
            double valorAbastecido = Convert.ToDouble(Console.ReadLine());

            double qtdeLitroClienteAbastecido = valorAbastecido / precoPorLitro;

            Console.WriteLine("==================================[Resultado]==================================");

            Console.WriteLine($"O cliente {nomeCliente} abasteceu {qtdeLitroClienteAbastecido} litros(s).");

            double totalVenda = qtdeLitroClienteAbastecido * precoPorLitro;
            Console.WriteLine($"Valor do abastecido: {totalVenda}");

            double totalQtdeLitroPosto = qtdeLitroPosto - qtdeLitroClienteAbastecido;
            Console.WriteLine($"Sobrou a quantidade de litros de combustivel para o posto {totalQtdeLitroPosto}.");

        }
    }
}