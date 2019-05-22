using AngularNetCore.BusinessLogic.Interfaces;
using AngularNetCore.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AngularNetCore.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Order")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderLogic _logic;
        public OrderController(IOrderLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [Route("GetPaginatedOrders/{page:int}/{rows:int}")]
        public IActionResult GetPaginatedOrders(int page, int rows)
        {
            return Ok(_logic.getPaginatedOrders(page, rows));
        }

        [HttpGet]
        [Route("GetOrderById/{orderId:int}")]
        public IActionResult GetOrderById(int orderId)
        {
            return Ok(_logic.GetById(orderId));
        }
    }
}
