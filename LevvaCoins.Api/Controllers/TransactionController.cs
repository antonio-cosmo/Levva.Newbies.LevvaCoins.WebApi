
using LevvaCoins.Application.Accounts.Extensions;
using LevvaCoins.Application.Common.Dtos;
using LevvaCoins.Application.Transactions.Dtos;
using LevvaCoins.Application.Transactions.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LevvaCoins.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("transaction")]
    public class TransactionController : ControllerBase
    {
        readonly ITransactionServices _transactionServices;


        public TransactionController(ITransactionServices transactionServices)
        {
            _transactionServices = transactionServices;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<ActionResult> Post([FromBody] CreateTransactionDto body)
        {
            var userId = User.GetUserId();
            await _transactionServices.CreateTransactionAsync(body, userId);
            return Created("", null);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> Get()
        {
            var list = await _transactionServices.GetAllTransactionsAsync();

            return Ok(list);
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<ActionResult<TransactionDto>> Get([FromRoute] Guid id)
        {
            var category = await _transactionServices.GetByIdTransaction(id);

            return Ok(category);
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _transactionServices.DeleteByIdTransaction(id);

            return NoContent();
        }

        [HttpGet("user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> GetTransactionsByUser()
        {
            var userId = User.GetUserId();
            var transactionsList = await _transactionServices.SearchTransactionByuser(new Guid(userId));
            return Ok(transactionsList);
        }
    }
}
