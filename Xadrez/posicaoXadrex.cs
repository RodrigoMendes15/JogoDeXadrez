using tabuleiro;


namespace xadrez
{
    class posicaoXadrex
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        public posicaoXadrex(char coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;
        }

        public Posicao toPosicao()
        {
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        public override string ToString()
        {
            return "" + Coluna + Linha;
        }
    }
}
