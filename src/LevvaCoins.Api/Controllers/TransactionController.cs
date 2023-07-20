using LevvaCoins.Api.ApiModel.Transaction;
using LevvaCoins.Api.Common;
using LevvaCoins.Application.UseCases.Categories.GetCategory;
using LevvaCoins.Application.UseCases.Transactions.Common;
using LevvaCoins.Application.UseCases.Transactions.CreateTransaction;
using LevvaCoins.Application.UseCases.Transactions.GetAllTransactions;
using LevvaCoins.Application.UseCases.Transactions.GetTransaction;
using LevvaCoins.Application.UseCases.Transactions.RemoveTransaction;
using LevvaCoins.Application.UseCases.Transactions.SearchTransactionByDescription;
using LevvaCoins.Application.UseCases.Transactions.UpdateTransaction;
using LevvaCoins.Application.UseCases.Users.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LevvaCoins.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/transaction")]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<TransactionDetailsOutput>>> GetAllTransactionsAsync()
        {
            var userId = User.GetUserId();

            return Ok(await _mediator.Send(new GetAllTransactionsInput(userId)));
        }

        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<TransactionDetailsOutput>>> SearchAllTransactionsByDescriptionAsync([FromQuery] string query)
        {
            var userId = User.GetUserId();
            return Ok(await _mediator.Send(new SearchTransactionsByDescriptionInput(userId, query)));
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<TransactionOutput>> GetByIdAsync([FromRoute] Guid id) =>
            Ok(await _mediator.Send(new GetTransactionInput(id)));

        [HttpPost]
        [ProducesResponseType(typeof(TransactionDetailsOutput), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> PostAsync([FromBody] CreateTransactionApiInput body)
        {
            var userId = User.GetUserId();
            var transaction = await _mediator.Send(new CreateTransactionInput(
                    body.Description,
                    body.Amount,
                    body.Type,
                    body.CategoryId,
                    userId
                ));

            return Created("", transaction);
        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> PutAsync([FromRoute] Guid id, [FromBody] UpdateTransactionApiInput body)
        {
            await _mediator.Send(new UpdateTransactionInput(
                    id,
                    body.Description,
                    body.Amount,
                    body.Type,
                    body.CategoryId
                ));
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            await _mediator.Send(new RemoveTransactionInput(id));

            return NoContent();
        }
    }
}
