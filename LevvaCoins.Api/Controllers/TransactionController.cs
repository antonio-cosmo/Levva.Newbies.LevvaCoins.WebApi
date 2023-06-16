using LevvaCoins.Application.Accounts.Extensions;
using LevvaCoins.Application.Categories.Interfaces;
using LevvaCoins.Application.Common.Dtos;
using LevvaCoins.Application.Transactions.Dtos;
using LevvaCoins.Application.Transactions.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LevvaCoins.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/transaction")]
    public class TransactionController : ControllerBase
    {
        readonly ITransactionServices _transactionServices;
        readonly ICategoryServices _categoryServices;

        public TransactionController(ITransactionServices transactionServices, ICategoryServices categoryServices)
        {
            _transactionServices = transactionServices;
            _categoryServices = categoryServices;
        }

        [HttpGet()]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<TransactionViewDto>>> GetAllTransactionsAsync()
        {
            var userId = new Guid(User.GetUserId());

            return Ok(await _transactionServices.GetAllAsync(userId));

        }

        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<TransactionViewDto>>> SearchAllTransactionsByDescriptionAsync([FromQuery] string query)
        {
            var userId = new Guid(User.GetUserId());

            return Ok(await _transactionServices.SearchByDescriptionAsync(userId,query));

        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<TransactionViewDto>> GetByIdAsync([FromRoute] Guid id)
        {
            return Ok(await _transactionServices.GetByIdAsync(id));
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(TransactionViewDto),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> PostAsync([FromBody] SaveTransactionDto body)
        {
            var userId = new Guid(User.GetUserId());
            var category = _categoryServices.GetByIdAsync(body.CategoryId);
            var transaction = await _transactionServices.SaveAsync(body, userId);

            transaction.Category = await category;

            return Created("", transaction);
        }


        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> PutAsync([FromRoute] Guid id, [FromBody] UpdateTransactionDto updateTransactionDto )
        {
            await _transactionServices.UpdateAsync(id, updateTransactionDto);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            await _transactionServices.RemoveAsync(id);

            return NoContent();
        }

    }
}
