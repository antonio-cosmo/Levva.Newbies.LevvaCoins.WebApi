using LevvaCoins.Api.ApiModels.Transaction;
using LevvaCoins.Api.Common;
using LevvaCoins.Application.Extensions;
using LevvaCoins.Application.UseCases.Transactions.Common;
using LevvaCoins.Application.UseCases.Transactions.CreateTransaction;
using LevvaCoins.Application.UseCases.Transactions.GetAllTransactions;
using LevvaCoins.Application.UseCases.Transactions.GetTransaction;
using LevvaCoins.Application.UseCases.Transactions.RemoveTransaction;
using LevvaCoins.Application.UseCases.Transactions.SearchTransactionByDescription;
using LevvaCoins.Application.UseCases.Transactions.UpdateTransaction;
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
        [ProducesResponseType(typeof(ErrorResponseModelOutput), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<TransactionDetailsModelResponse>>> GetAllTransactionsAsync()
        {
            var userId = User.GetUserId();

            return Ok(await _mediator.Send(new GetAllTransactions(userId)));
        }

        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModelOutput), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<TransactionDetailsModelResponse>>> SearchAllTransactionsByDescriptionAsync([FromQuery] string query)
        {
            var userId = User.GetUserId();
            return Ok(await _mediator.Send(new SearchTransactionsByDescription(userId, query)));
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModelOutput), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModelOutput), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<TransactionModelResponse>> GetByIdAsync([FromRoute] Guid id) =>
            Ok(await _mediator.Send(new GetTransaction(id)));

        [HttpPost]
        [ProducesResponseType(typeof(TransactionDetailsModelResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponseModelOutput), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModelOutput), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> PostAsync([FromBody] CreateTransactionApiInput body)
        {
            var userId = User.GetUserId();
            var transaction = await _mediator.Send(new CreateTransaction(
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
        [ProducesResponseType(typeof(ErrorResponseModelOutput), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModelOutput), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> PutAsync([FromRoute] Guid id, [FromBody] UpdateTransactionApiInput body)
        {
            await _mediator.Send(new UpdateTransaction(
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
        [ProducesResponseType(typeof(ErrorResponseModelOutput), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModelOutput), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            await _mediator.Send(new RemoveTransaction(id));

            return NoContent();
        }
    }
}
