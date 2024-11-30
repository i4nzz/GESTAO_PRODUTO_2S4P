using GestaoProduto.Domain.Entidades;
using GestaoProduto.Domain.Interfaces;
using GestaoProduto.Services.Interfaces;

namespace GestaoProduto.Services.Services
{
    public class ProdutoServices : IProdutoServices
    {

        private readonly IProdutoRepository _produtoRepository;

        public ProdutoServices(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public bool Adcionar(Produto produto)
        {
            Produto statusProduto = _produtoRepository.GetProdutoByCodigoBarras(produto.codigoBarra);

            if (statusProduto is null)
            {
                _produtoRepository.Adcionar(produto);
                return true;
            }
            return false;
        }

        public void AtualizarEstoque(Produto produto)
        {
            _produtoRepository.AtualizarEstoque(produto);
        }

        /*
            BaixarEstoque: O método BaixarEstoque reduz o estoque do produto e, em seguida, chama AtualizarEstoque para persistir essa alteração no banco de dados. 
         
            AtualizarEstoque: Esse método permite que o estoque de um produto seja atualizado diretamente, com a persistência ocorrendo através do repositório.
         */

        public bool BaixarEstoque(int produtoID, int quantidade)
        {
            Produto statusEstoque = _produtoRepository.GetProdutoByID(produtoID);

            if(statusEstoque is null) // estoque nulo
                return false;

            if (statusEstoque.estoque < quantidade) // estoque < quantidade solicitada
                return false;

            statusEstoque.estoque -= quantidade;


            _produtoRepository.AtualizarEstoque(statusEstoque);
            return true;
        }

        public Produto GetByCodigoBarra(string codigo)
        {
            return _produtoRepository.GetByCodigoBarra(codigo);
        }

        public Produto GetByNome(string nome)
        {
            return _produtoRepository.GetByNome(nome);
        }
    }
}
