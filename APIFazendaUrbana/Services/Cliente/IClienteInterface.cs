using APIFazendaUrbana.Dto.Cliente;
using APIFazendaUrbana.Model;

namespace APIFazendaUrbana.Services.Cliente
{
    public interface IClienteInterface
    {
        Task<ResponseModel<List<ClienteModel>>> ListarClientes();
        Task<ResponseModel<List<ClienteModel>>> CriarCliente(ClienteCriacaoDto clienteCriacaoDto);


    }
}
