using DemoEventStore.Dtos;
using DemoEventStore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DemoEventStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public IActionResult Post(SalvarPedidoDto pedidoDto)
        {
            int codigoPedido = _pedidoService.SalvarPedido(pedidoDto);
            return Ok(codigoPedido);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _pedidoService.ObterEventosPedido(id));
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await _pedidoService.ObterTodos());
        }
    }
}
