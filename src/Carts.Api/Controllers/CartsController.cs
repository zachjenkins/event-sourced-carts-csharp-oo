using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using System.Threading.Tasks;
using Carts.Application.Features;

namespace Carts.Api.Controllers
{
    [ApiController]
    [Route("api/v1/carts")]
    public class CartsController : Controller
    {
        private readonly IMediator mediator;

        public CartsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("users/{userId}/cart")]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            var query = new GetCartByUserId.Query
            {
                UserId = userId
            };

            var cart = await mediator.Send(query);

            return Ok(cart);
        }
    }
}
