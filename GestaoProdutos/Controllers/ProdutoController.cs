using Microsoft.AspNetCore.Mvc;
using GestaoProduto.Services.Interfaces;
using GestaoProdutos.DTO;
using GestaoProduto.Domain.Entidades;

namespace GestaoProdutos.Controllers
{
    [ApiController]
    [Route("Api/contoller")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoServices _produtoServices;

        public ProdutoController(IProdutoServices produtoServices)
        {
            _produtoServices = produtoServices;
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult AddProduto(ProdutoDTO produtoDTO)
        {
            bool status = _produtoServices.Adcionar
                (
                    new Produto
                    (
                      produtoDTO.nome,
                      produtoDTO.descricao,
                      produtoDTO.codigoBarra,
                      produtoDTO.valor,
                      produtoDTO.estoque
                    )
                );

            if (status is true)
                return Ok("Produto cadastrado");

            return BadRequest("Erro no cadastro");
        }

        [HttpGet]
        [Route("GetByCodigoDeBarras")]
        public IActionResult GetCodigoDeBarras(string codigo)
        {
            return Ok(_produtoServices.GetByCodigoBarra(codigo));
        }


        [HttpGet]
        [Route("GetByNomeDoProduto")]
        public IActionResult GetNomeProduto(string nomeProduto)
        {
            return Ok(_produtoServices.GetByNome(nomeProduto));
        }


        [HttpPost]
        [Route("BaixarEstoque")]
        public IActionResult BaixarEstoque(int produtoID, int quantidade)
        {

            bool status = _produtoServices.BaixarEstoque(produtoID, quantidade);

            if (status)
                return Ok($"Estoque do produto {produtoID} baixado em {quantidade} unidades.");

            return BadRequest("Erro ao baixar estoque. Produto inexistente ou estoque insuficiente.");
        }


    }
}
