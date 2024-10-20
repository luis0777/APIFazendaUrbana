using APIFazendaUrbana.Data;
using APIFazendaUrbana.Dto.Funcionario;
using APIFazendaUrbana.Dto.Produto;
using APIFazendaUrbana.Model;
using Microsoft.EntityFrameworkCore;

namespace APIFazendaUrbana.Services.Produto
{
    public class ProdutoService : IProdutoInterface
    {
        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<ResponseModel<List<ProdutoModel>>> CriarProduto(ProdutoCriacaoDto produtoCriacaoDto)
        {
            ResponseModel<List<ProdutoModel>> resposta = new ResponseModel<List<ProdutoModel>>();

            try
            {
                var produto = new ProdutoModel()
                {
                    Produto = produtoCriacaoDto.Produto,
                    Quantidade = produtoCriacaoDto.Quantidade,
                    Preco = produtoCriacaoDto.Preco
                };

                _context.Add(produto);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Produtos.ToListAsync();
                resposta.Mensagem = "Produto criado com sucesso!!!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async  Task<ResponseModel<List<ProdutoModel>>> EditarProduto()
        {
            ResponseModel<List<ProdutoModel>> resposta = new ResponseModel<List<ProdutoModel>>();

            try
            {
                var produtos = await _context.Produtos.FirstOrDefaultAsync(produtoBanco => produtoBanco.Id == produtoBanco.Id);

                if (produtos == null)
                {
                    resposta.Mensagem = "Nenhum produto localizado";
                    return resposta;
                }

                produtos.Produto = produtos.Produto;
                produtos.Quantidade = produtos.Quantidade;
                produtos.Preco = produtos.Preco;

                _context.Update(produtos);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Produtos.ToListAsync();
                resposta.Mensagem = "Alterações feitas com sucesso!!!";

                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ProdutoModel>>> ListarProdutos()
        {
            ResponseModel<List<ProdutoModel>> resposta = new ResponseModel<List<ProdutoModel>>();
            try
            {
                var produtos = await _context.Produtos.ToListAsync();

                resposta.Dados = produtos;
                resposta.Mensagem = "Todos os produtos foram listados";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            };
        }
    }
}
