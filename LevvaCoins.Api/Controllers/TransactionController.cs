
using LevvaCoins.Application.Accounts.Extensions;
using LevvaCoins.Application.Common.Dtos;
using LevvaCoins.Application.Transactions.Dtos;
using LevvaCoins.Application.Transactions.Interfaces;
using LevvaCoins.Domain.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LevvaCoins.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/transaction")]
    public class TransactionController : ControllerBase
    {
        readonly ITransactionServices _transactionServices;


        public TransactionController(ITransactionServices transactionServices)
        {
            _transactionServices = transactionServices;
        }


       

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PagedResult<TransactionViewDto>>> GetTransactionsByUser([FromQuery] int page = 1, [FromQuery] int size = 10)
        {
            var userId = new Guid(User.GetUserId());
            var paginationOpt = new PaginationOptions(page, size);

            return Ok(await _transactionServices.SearchTransactionByUser(userId, paginationOpt));
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<TransactionViewDto>>> GetAllTransactions()
        {
            var userId = new Guid(User.GetUserId());
            return Ok(await _transactionServices.GetAllTransactions(userId));
        }

        [HttpGet("description")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<TransactionViewDto>>> GetByDescriptionAsync([FromQuery] string search)
        {
            
            return Ok(await _transactionServices.SearchTransactionByDescription(search));
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<TransactionViewDto>> GetByIdAsync([FromRoute] Guid id)
        {
            return Ok(await _transactionServices.GetByIdTransaction(id));
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> PostAsync([FromBody] CreateTransactionDto body)
        {
            var userId = new Guid(User.GetUserId());
           

            await _transactionServices.CreateTransactionAsync(body, userId);

            return Created("", null);
        }


        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> PutAsync([FromRoute] Guid id, [FromBody] UpdateTransactionDto updateTransactionDto )
        {
            await _transactionServices.UpdateTransaction(id, updateTransactionDto);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            await _transactionServices.DeleteByIdTransaction(id);

            return NoContent();
        }

    }
}
