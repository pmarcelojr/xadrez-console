using System.Collections.Generic;
using tabuleiro;
using tabuleiro.Enums;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            Terminada = false;
            JogadorAtual = Cor.Branca;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public void ExecutarMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQtdMovimentos();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
            if(pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutarMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }

        public void ValidarPosicaoOrigem(Posicao pos)
        {
            if(Tab.Peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            } else if (JogadorAtual != Tab.Peca(pos).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é a sua!");
            } else if (!Tab.Peca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if(!Tab.Peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino Inválida!");
            }
        }

        private void MudaJogador()
        {
            if(JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Capturadas)
            {
                if(x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Pecas)
            {
                if(x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        public void ColocarNewPeca(char linha, int coluna, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(linha, coluna).ToPosicao());
            Pecas.Add(peca);
        }

        private void ColocarPecas()
        {
            ColocarNewPeca('c', 1, new Torre(Tab, Cor.Branca));
            ColocarNewPeca('c', 2, new Torre(Tab, Cor.Branca));
            ColocarNewPeca('d', 1, new Rei(Tab, Cor.Branca));
            ColocarNewPeca('d', 2, new Torre(Tab, Cor.Branca));
            ColocarNewPeca('e', 1, new Torre(Tab, Cor.Branca));
            ColocarNewPeca('e', 2, new Torre(Tab, Cor.Branca));

            ColocarNewPeca('c', 8, new Torre(Tab, Cor.Preta));
            ColocarNewPeca('c', 7, new Torre(Tab, Cor.Preta));
            ColocarNewPeca('d', 8, new Rei(Tab, Cor.Preta));
            ColocarNewPeca('d', 7, new Torre(Tab, Cor.Preta));
            ColocarNewPeca('e', 8, new Torre(Tab, Cor.Preta));
            ColocarNewPeca('e', 7, new Torre(Tab, Cor.Preta));
        }
    }
}