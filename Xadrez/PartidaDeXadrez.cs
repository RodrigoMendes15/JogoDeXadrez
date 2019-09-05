using System;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        private int turno;
        private Cor jogadorAtual;
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
