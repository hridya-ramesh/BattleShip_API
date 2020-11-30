using BattleShip_Application.Feature;
using BattleShip_Application.Feature.Attack;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BattleShip_API.Controllers
{
    [Route("Battleship")]
    [ApiController]
    public class BattleShipController : BaseApiController
    {
        private readonly ILogger _logger;
    
        public BattleShipController(ILoggerFactory logFactory)
        {
            _logger = logFactory.CreateLogger<BattleShipController>();
        }

        [HttpPost("board/create")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateBoard(CreateBoardCommand createBoardCommand)
        {
            var result = await Mediator.Send(createBoardCommand);
            return new JsonResult(result);
        }


        [HttpPost("board/ship/add")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(AddShipCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddShip(AddShipCommand addShipCommand)
        {
             var result = await Mediator.Send(addShipCommand);
            return new JsonResult(result);
        }

        [HttpPost("board/attack")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(AttackResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Attack(AttackCommand attackCommand)
        {
            var result = await Mediator.Send(attackCommand);
            return new JsonResult(result);
        }




    }
}
