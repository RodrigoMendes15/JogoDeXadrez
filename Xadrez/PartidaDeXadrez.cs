using System;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8,8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            ColocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.removerPeca(origem);
            p.incrementarQtdMovimentos();
            Peca pecaCapturada = tab.removerPeca(destino);
            tab.colocarPeca(p, destino);
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }

        public void validarPosicaoOrigem(Posicao pos)
        {
            if(tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição escolhida!");
            }
            if(jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("A peça escolhida pertence ao outro jogador!");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça selecionada!");
            }
        }

        private void mudaJogador()
        {
            if(jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        private void ColocarPecas()
        {
            tab.colocarPeca(new Torre(tab, Cor.Preta), new posicaoXadrex('a', 8).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new posicaoXadrex('h', 8).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Preta), new posicaoXadrex('d', 8).toPosicao());

            tab.colocarPeca(new Torre(tab, Cor.Branca), new posicaoXadrex('a', 1).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new posicaoXadrex('h', 1).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Branca), new posicaoXadrex('d', 1).toPosicao());
        }
    }
}
