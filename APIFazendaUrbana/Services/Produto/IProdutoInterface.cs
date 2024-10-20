using APIFazendaUrbana.Dto.Funcionario;
using APIFazendaUrbana.Dto.Produto;
using APIFazendaUrbana.Model;

namespace APIFazendaUrbana.Services.Produto
{
    public interface IProdutoInterface
    {
        Task<ResponseModel<List<ProdutoModel>>> ListarProdutos();
        Task<ResponseModel<List<ProdutoModel>>> EditarProduto();
        Task<ResponseModel<List<ProdutoModel>>> CriarProduto(ProdutoCriacaoDto produtoCriacaoDto);

    }
}
