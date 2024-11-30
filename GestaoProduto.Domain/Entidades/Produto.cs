namespace GestaoProduto.Domain.Entidades
{
    public class Produto : EntidadeBase
    {
        public Produto()
        {
            
        }

        public string nome { get; set; }
        public string descricao { get; set; }
        public string codigoBarra { get; set; }
        public int valor { get; set; }
        public int estoque { get; set; }

        public Produto( string NOME, string DESCRICAO, string CODIGOBARRA, int VALOR, int ESTOQUE)
        {
            nome = NOME;
            descricao = DESCRICAO;
            codigoBarra = CODIGOBARRA;
            valor = VALOR;
            estoque = ESTOQUE;
        }
    }
}
