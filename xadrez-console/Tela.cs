using System;
using tabuleiro;
using tabuleiro.Enums;

namespace xadrez_console
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for(int i = 0; i < tab.Linhas; i++)
            {
                Console.Write($"{tab.Linhas - i} ");
                for(int j = 0; j < tab.Colunas; j++)
                {
                    if(tab.Peca(i, j) == null)
                        Console.Write("- ");
                    else
                    {
                        ImprimirPeca(tab.Peca(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.Write("  ");
            //char letra = 'a';
            for(int i = 0; i < tab.Colunas; i++)
            {
                Console.Write($"{(char)('a' + i)} ");
            }
            //Console.WriteLine("* a b c d e f g h");
        }

        public static void ImprimirPeca(Peca peca)
        {
            if(peca.Cor == Cor.Branca)
                Console.Write(peca);
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
    }
}