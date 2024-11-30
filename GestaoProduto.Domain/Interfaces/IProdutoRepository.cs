using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoProduto.Domain.Entidades;

namespace GestaoProduto.Domain.Interfaces
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        public Produto GetProdutoByID(int id);
        public Produto GetProdutoByCodigoBarras(string codBarras);
    }
}
