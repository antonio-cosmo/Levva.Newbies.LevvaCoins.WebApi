﻿using LevvaCoins.Application.Common;
using LevvaCoins.Application.UseCases.Categories.GetCategory;
using LevvaCoins.Application.UseCases.Transactions.Dtos;
using LevvaCoins.Application.UseCases.Transactions.Interfaces;
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
        readonly ITransactionServices _transactionServices;
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator,ITransactionServices transactionServices )
        {
            _transactionServices = transactionServices;
            _mediator = mediator;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<TransactionDetailsDto>>> GetAllTransactionsAsync()
        {
            var userId = User.GetUserId();

            return Ok(await _transactionServices.GetAllAsync(userId));
        }

        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<TransactionDetailsDto>>> SearchAllTransactionsByDescriptionAsync([FromQuery] string query)
        {
            var userId = User.GetUserId();
            return Ok(await _transactionServices.SearchByDescriptionAsync(userId, query));
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<TransactionDetailsDto>> GetByIdAsync([FromRoute] Guid id) =>
            Ok(await _transactionServices.GetByIdAsync(id));

        [HttpPost]
        [ProducesResponseType(typeof(TransactionDetailsDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> PostAsync([FromBody] CreateTransactionDto body)
        {
            var userId = User.GetUserId();
            var category = await _mediator.Send(new GetCategoryInput(body.CategoryId));
            var transaction = await _transactionServices.SaveAsync(userId, body);

            transaction.Category = category;

            return Created("", transaction);
        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> PutAsync([FromRoute] Guid id, [FromBody] UpdateTransactionDto updateTransactionDto)
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
