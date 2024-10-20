using APIFazendaUrbana.Dto.Funcionario;
using APIFazendaUrbana.Dto.Produto;
using APIFazendaUrbana.Model;
using APIFazendaUrbana.Services.Funcionario;
using APIFazendaUrbana.Services.Produto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIFazendaUrbana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoInterface _produtoInterface;
        public ProdutoController(IProdutoInterface produtoInterface)
        {
            _produtoInterface = produtoInterface;
        }

        [HttpGet("ListarProdutos")]
        public async Task<ActionResult<ResponseModel<List<ProdutoModel>>>> ListarProdutos()
        {
            var produto = await _produtoInterface.ListarProdutos();
            return Ok(produto);
        }

        [HttpPost("CriarProduto")]
        public async Task<ActionResult<ResponseModel<List<ProdutoModel>>>> CriarProduto(ProdutoCriacaoDto produtoCriacaoDto )
        {
            var produto = await _produtoInterface.CriarProduto(produtoCriacaoDto);
            return Ok(produto);
        }

        [HttpPut("EditarProduto")]
        public async Task<ActionResult<ResponseModel<List<ProdutoModel>>>> EditarProduto()
        {
            var produto = await _produtoInterface.EditarProduto();
            return Ok(produto);
        }

    }
}
