namespace GestaoProdutos.DTO
{
    public class ProdutoDTO
    {

        // DTO(Data Transfer Object) é uma classe anêmica projetada exclusivamente para transportar dados entre diferentes camadas da aplicação.
        public string nome { get; set; }
        public string descricao { get; set; }
        public string codigoBarra { get; set; }
        public int valor { get; set; }
        public int estoque { get; set; }
    }
}
