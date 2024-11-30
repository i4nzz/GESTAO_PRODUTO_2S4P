using GestaoProduto.Data.Context;
using GestaoProduto.Domain.Entidades;
using GestaoProduto.Domain.Interfaces;
using GestaoProduto.Data.Context;

namespace GestaoProduto.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly AppDBContext _context;  // Supondo que você tenha um DbContext chamado AppDbContext

        public ProdutoRepository(AppDBContext context)
        {
            _context = context;
        }

        public void Adcionar(Produto produto)
        {
            _context.Produto.Add(produto);
            _context.SaveChanges();
        }

        public void AtualizarEstoque(Produto produto)
        {
            _context.Produto.Update(produto);  // Marca a entidade como modificada
            _context.SaveChanges();  // Persiste a alteração no banco
        }


        public Produto? GetByCodigoBarra(string codigo)
        {
            return _context.Produto.Where(a => a.codigoBarra == codigo).FirstOrDefault();
        }

        public Produto? GetByNome(string nomeProduto)
        {
            return _context.Produto.Where(a => a.nome == nomeProduto).FirstOrDefault();
           
        }

        public Produto? GetProdutoByID(int produtoID)
        {
            return _context.Produto.Where(a => a.id == produtoID).FirstOrDefault();
        }

        public void  BaixarEstoque(int produtoID, int quantidade)
        {
            Produto? produto = GetProdutoByID(produtoID);

            if (produto is null)
                throw new KeyNotFoundException("Produto não encontrado.");

            if (produto.estoque < quantidade)
                throw new InvalidOperationException("Estoque insuficiente.");

            produto.estoque -= quantidade;
            _context.SaveChanges(); 
        }

        public Produto? GetProdutoByCodigoBarras(string codBarras)
        {
            return _context.Produto.Where(a => a.codigoBarra == codBarras).FirstOrDefault();
        }
    }
}
