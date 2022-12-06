// See https://aka.ms/new-console-template for more information
/// <summary>
/// Sheila é uma analista de teste
/// ela precisa de uma automação que leia 3 nomes na tela
/// leia 3 sobrenomes
/// e no final do programa, mostre os nomes cadastrados junto com os sobrenomes
/// </summary>


Console.WriteLine("==========================================="); 
Console.WriteLine("============ Cadastro de nomes ============"); 
Console.WriteLine("==========================================="); 

Console.WriteLine("Informe o nome 1");
var nome1 = Console.ReadLine();

Console.WriteLine("Informe o nome 2");
var nome2 = Console.ReadLine();

Console.WriteLine("Informe o nome 3");
var nome3 = Console.ReadLine();

Console.WriteLine($"Informe o sobrenome do(a) {nome1}");
var sobreNome1 = Console.ReadLine();

Console.WriteLine($"Informe o sobrenome do(a) {nome2}");
var sobreNome2 = Console.ReadLine();

Console.WriteLine($"Informe o sobre nome do(a) {nome3}");
var sobreNome3 = Console.ReadLine();

Console.WriteLine("===========================================");

Console.WriteLine($"""
Nome 1: {nome1} {sobreNome1}
Nome 2: {nome2} {sobreNome2}
Nome 3: {nome3} {sobreNome3}
""");


int numero1 = 1;
int numero2 = 20;
int resultado;
resultado = numero1 + numero2;
Console.WriteLine($"O resultado da operação é: {resultado}");

double valor1 = 10.50;
double valor2 = 2.5;
double resultado1 = valor1 / valor2;
Console.WriteLine($"O resultado da operação é: {resultado1.ToString("0.##")}");