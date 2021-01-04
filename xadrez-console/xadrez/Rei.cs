using tabuleiro;
using tabuleiro.Enums;

namespace xadrez 
{
    class Rei : Peca
    {
        public Rei(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p == null || p.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new Posicao(0,0);

            // Acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            // Nordeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            // Direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;
            
            // Sudeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            // Abaixo
            pos.DefinirValores(Posicao.Linha + 1, pos.Coluna);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            // Sudoeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;
            
            // Esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;
            
            // Noroeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            return mat;
        }
    }
}