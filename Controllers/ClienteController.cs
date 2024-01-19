using Loja.API.Entities;
using Loja.API.Entities.DTOs.response;
using Loja.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Loja.API.Controllers
{
    [Route("/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _service;

        public ClienteController(ClienteService service)
        {
            _service = service;
        }

        [HttpPost("/criar")]
        public IActionResult PostCliente([FromBody] Cliente cliente)
        {
            try
            {
                _service.CreateCliente(cliente);
                return Created();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Message: {ex.Message}");
            }
        }

        [HttpGet("/listar")]
        public IActionResult GetAllClientesWithParams([FromQuery] string? nome = null, [FromQuery] string? email = null, [FromQuery] string? cpf = null)
        {
            try
            {
                List<ClienteResponseDTO> response = _service.GetClienteWithParams(nome, email, cpf);
                return Ok(response);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Message: {ex.Message}");
            }
        }


        [HttpPut("/atualizar/{id}")]
        public IActionResult PutClienteById(int id, [FromBody] Cliente clienteAtualizado)
        {
            try
            {
                Cliente response = _service.UpdateCliente(id, clienteAtualizado);
                return Ok(response);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Message: {ex}");
            }
        }

        [HttpDelete("/remover/{id}")]
        public IActionResult DeleteClienteById(int id)
        {
            try
            {
                _service.DeteleCliente(id);
                return NoContent();
            } catch (Exception ex)
            {
                return StatusCode(500, $"Message: {ex.Message}");
            }
        }

    }
}
