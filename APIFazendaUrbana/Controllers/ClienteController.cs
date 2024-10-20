using APIFazendaUrbana.Dto.Cliente;
using APIFazendaUrbana.Model;
using APIFazendaUrbana.Services.Cliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIFazendaUrbana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteInterface _clienteInterface;
        public ClienteController(IClienteInterface clienteInterface)
        {
            _clienteInterface = clienteInterface;
        }

        [HttpGet("ListarClientes")]
        public async Task<ActionResult<ResponseModel<List<ClienteModel>>>> ListarClientes()
        {
            var clientes = await _clienteInterface.ListarClientes();
            return Ok(clientes);
        }

        [HttpPost("CriarCliente")]
        public async Task<ActionResult<ResponseModel<List<ClienteModel>>>> CriarCliente(ClienteCriacaoDto clienteCriacaoDto)
        {
            var clientes = await _clienteInterface.CriarCliente(clienteCriacaoDto);
            return Ok(clientes);
        }
    }
}
