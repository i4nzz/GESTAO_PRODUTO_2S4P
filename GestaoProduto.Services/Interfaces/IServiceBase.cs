using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProduto.Services.Interfaces
{
    public interface IServiceBase<T>
    {
        public bool Adcionar(T entidade);
        public T GetByCodigoBarra(string codigo);
        public T GetByNome(string nome);
        public bool BaixarEstoque(int produtoID, int quantidade);

        public void AtualizarEstoque(T entidade);
    }
}
