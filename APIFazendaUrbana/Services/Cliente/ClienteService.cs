using APIFazendaUrbana.Data;
using APIFazendaUrbana.Dto.Cliente;
using APIFazendaUrbana.Model;
using Microsoft.EntityFrameworkCore;

namespace APIFazendaUrbana.Services.Cliente
{
    public class ClienteService : IClienteInterface
    {
        private readonly AppDbContext _context;

        public ClienteService(AppDbContext context)
        {
            _context = context;

        }

        public async  Task<ResponseModel<List<ClienteModel>>> CriarCliente(ClienteCriacaoDto clienteCriacaoDto)
        {
            ResponseModel<List<ClienteModel>> resposta = new ResponseModel<List<ClienteModel>>();

            try
            {
                var cliente = new ClienteModel()
                {
                   NomeCliente = clienteCriacaoDto.NomeCliente,
                   CPF = clienteCriacaoDto.CPF,
                   Email = clienteCriacaoDto.Email,
                   Senha = clienteCriacaoDto.Senha
                };

                _context.Add(cliente);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Clientes.ToListAsync();
                resposta.Mensagem = "Cliente criado com sucesso!!!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ClienteModel>>> ListarClientes()
        {
            ResponseModel<List<ClienteModel>> resposta = new ResponseModel<List<ClienteModel>>();
            try
            {
                var clientes = await _context.Clientes.ToListAsync();

                resposta.Dados = clientes;
                resposta.Mensagem = "Todos os clientes foram listados";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
