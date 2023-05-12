
using LevvaCoins.Application.Accounts.Extensions;
using LevvaCoins.Application.Common.Dtos;
using LevvaCoins.Application.Transactions.Dtos;
using LevvaCoins.Application.Transactions.Interfaces;
using LevvaCoins.Domain.Common;
using LevvaCoins.Domain.Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LevvaCoins.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("transaction")]
    public class TransactionController : ControllerBase
    {
        readonly ITransactionServices _transactionServices;


        public TransactionController(ITransactionServices transactionServices)
        {
            _transactionServices = transactionServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PagedResultDto<TransactionDto>>> GetAllPagedAsync([FromQuery] int page = 1, [FromQuery] int size = 10)
        {
            var paginationOptions = new PaginationOptions(page, size);

            return Ok(await _transactionServices.GetAllTransactionsAsync(paginationOptions));
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> GetAllAsync()
        {
            var list = await _transactionServices.GetAllTransactionsAsync();

            return Ok(list);
        } 

        [HttpGet("description")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> GetByDescriptionAsync([FromQuery] string search)
        {

            return Ok(await _transactionServices.SearchTransactionByDescription(search));
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<ActionResult<TransactionDto>> GetByIdAsync([FromRoute] Guid id)
        {
            var category = await _transactionServices.GetByIdTransaction(id);

            return Ok(category);
        }

        [HttpGet("user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> GetTransactionsByUser()
        {
            var userId = User.GetUserId();
            var transactionsList = await _transactionServices.SearchTransactionByuser(new Guid(userId));
            return Ok(transactionsList);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<ActionResult> PostAsync([FromBody] CreateTransactionDto body)
        {
            var userId = User.GetUserId();
            await _transactionServices.CreateTransactionAsync(body, userId);
            return Created("", null);
        }


        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<ActionResult> PutAsync([FromRoute] Guid id, [FromBody] UpdateTransactionDto updateTransactionDto )
        {
            await _transactionServices.UpdateTransaction(id, updateTransactionDto);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            await _transactionServices.DeleteByIdTransaction(id);

            return NoContent();
        }

    }
}
