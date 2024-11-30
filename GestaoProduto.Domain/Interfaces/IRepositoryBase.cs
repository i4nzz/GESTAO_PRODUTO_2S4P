using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProduto.Domain.Interfaces
{
    public interface IRepositoryBase<T>
    {
        public void Adcionar(T entidade);
        public T GetByCodigoBarra(string codigo);
        public T GetByNome(string nome);
        public void BaixarEstoque(int produtoID, int quantidade);

        public void AtualizarEstoque(T entidade);


    }
}
