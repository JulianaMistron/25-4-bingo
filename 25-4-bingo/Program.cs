/*Vamos desenvolver um jogo?
Simples, um jogo de bingo.As regras do bingo são as seguintes:
As cartelas possuem 25 números escritos em ordem aleatória.
Os números sorteados vão de 1 a 99.
Cada jogador pode ter mais de uma cartela.
O jogo deve ser capaz de ser jogado por mais de 2 jogadores, onde o usuário informa 
no inicio do programa a quantidade de jogadores que ele deseja
Se algum jogador completar uma linha a pontuação para todos passa a valer somente a coluna de qualquer cartela
e vice-versa.
A partir daí, só vale a pontuação de cartela cheia.
Os sorteios devem acontecer até algum jogador completar a cartela (BINGO!).
São 3 possibilidades de pontos:
Ao completar uma linha, o jogador recebe 1 ponto.
Ao completar uma coluna, o jogador recebe 1 ponto.
Ao completar a cartela, o jogador recebe 5 pontos.
Você vai precisar controlar o sorteio, onde não podem acontecer números repetidos, e também controlar as cartelas, 
onde cadacartela 
deve ter marcado os números sorteados para verificação do preenchimento da linha / coluna / cartela para contabilizar
os pontos.
Ao final do jogo, deverá ser mostrado quem foram os jogadores vencedores e a pontuação de cada um.
Recursos opcionais:
.*/
using System.Drawing;

int qtlinhas = 5, qtcolunas = 5;

int[,] cartela1 = new int[qtlinhas, qtcolunas];
int[,] cartela2 = new int[qtlinhas, qtcolunas];
int[,] cartela3 = new int[qtlinhas, qtcolunas];
int[] numerosDoSorteio = new int[99];



void PreencherNumerosDoSorteio(int tamanho, int[] numeros)
{
    int digito = 1;

    for (int i = 0; i < tamanho; i++)
    {
        numeros[i] = digito;
        digito++;
    }
}

void ImprimirNumeros(int[] numeros)
{
    for (int i = 0; i < numeros.Length; i++)
    {
        Console.Write(numeros[i].ToString("00") + " ");
    }
}

void ImprimirCartela(int[,] matriz, string titulo)
{
    Console.WriteLine(titulo);
    for (int linha = 0; linha < qtlinhas; linha++)
    {
        Console.WriteLine();
        for (int coluna = 0; coluna < qtcolunas; coluna++)
        {
            Console.Write(matriz[linha, coluna].ToString ("00") + "|");
        }
    }
}
int[,] CriarCartela()
{
    int[] numerosCartela = new int[25];
    for (int i = 0; i < 25; i++)
    {
        bool repetido;
        int numeroAleatorio = -1;

        do
        {
            numeroAleatorio = new Random().Next(1, 99);
            repetido = false;

            for (int j = 0; j < i; j++)
            {
                if (numerosCartela[j] == numeroAleatorio)
                {
                    repetido = true;
                    break;
                }
            }
        } while (repetido);

        numerosCartela[i] = numeroAleatorio;
    }

    int indiceCartela = 0;
    int[,] cartelaPreenchida = new int[qtlinhas, qtcolunas];
    for (int linha = 0; linha < qtlinhas; linha++)
    {
        for (int coluna = 0; coluna < qtcolunas; coluna++)
        {
            cartelaPreenchida[linha, coluna] = numerosCartela[indiceCartela];
            indiceCartela++;
        }
    }
    return cartelaPreenchida;
}

void RealizarSorteio()
{

}

cartela1 = CriarCartela();

ImprimirCartela(cartela1, "Jogador 1");

PreencherNumerosDoSorteio(99, numerosDoSorteio);

Console.WriteLine("\n\nNúmeros a sortear: ");

ImprimirNumeros(numerosDoSorteio);


Console.ReadKey();
Console.Clear();
