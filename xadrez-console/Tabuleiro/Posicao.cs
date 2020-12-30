namespace Tabuleiro
{
    class Posicao
    {
        public int Linha { get; set; }
        public int coluna { get; set; }

        public Posicao(int linha, int coluna)
        {
            Linha = linha;
            coluna = coluna;
        }

        public override string ToString()
        {
            return $"{Linha}, {Coluna}";
        }
    }
}