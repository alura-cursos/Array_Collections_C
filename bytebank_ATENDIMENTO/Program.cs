using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Atendimento;
using bytebank_ATENDIMENTO.bytebank.Util;
using System.Runtime.CompilerServices;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

#region Aula 01
//TestaArraysInt();

void TestaArraysInt() {
    var intArray = new int[] { 32, 48, 31, 12, 43, 12, 22 };

    int acc = 0;

    for (int i = 0; i < intArray.Length; i++)
    {
        acc += intArray[i];
    }

    try
    {
        var media = acc / intArray.Length;
        Console.WriteLine($"A média é: {media}");
    } 
    catch(DivideByZeroException) {
        Console.WriteLine("Tamanho da lista é zero. Impossível fazer a média.");
    }

}


//TestaBuscarPalavra();
void TestaBuscarPalavra()
{
    string[] palavras = { "André", "Pedro", "João", "Ana", "Luiza" };

    foreach (var item in palavras)
    {
        Console.WriteLine(item);
    }

    Console.WriteLine(palavras.Contains("João"));
}

Array amostra = Array.CreateInstance(typeof(double), 5);

amostra.SetValue(5.9, 0);
amostra.SetValue(1.8, 1);
amostra.SetValue(7.1, 2);
amostra.SetValue(10, 3);
amostra.SetValue(6.9, 4);

//TestaMediana(amostra);
void TestaMediana(Array array)
{
    if (amostra == null || array.Length == 0)
    {
        Console.WriteLine("Lista vazia");
        return;
    }

    double[] numerosOrdenados = (double[])array.Clone();
    Array.Sort(numerosOrdenados);

    int length = numerosOrdenados.Length;
    int meio = length / 2;
    double mediana = (length%2 != 0) ? 
        numerosOrdenados[meio] : 
        (numerosOrdenados[meio] + numerosOrdenados[meio - 1]) / 2;

    Console.WriteLine(String.Join(' ', numerosOrdenados));

    Console.WriteLine($"Com base na amostra a mediana é igual a {mediana}");
}
#endregion

#region Aula 02
//TestaArrayDeContasCorrentes();
void TestaArrayDeContasCorrentes()
{
    ListaDeContasCorrentes listaDeContasCorrente = new ListaDeContasCorrentes();
    listaDeContasCorrente.Adicionar(new ContaCorrente(874, "5381348-A"));
    listaDeContasCorrente.Adicionar(new ContaCorrente(874, "2389342-B"));
    listaDeContasCorrente.Adicionar(new ContaCorrente(874, "4582908-C"));
    listaDeContasCorrente.Adicionar(new ContaCorrente(874, "4448984-D"));

    listaDeContasCorrente.ExibeLista();
}
#endregion


new ByteBankAtendimento().AtendimentoCliente();
