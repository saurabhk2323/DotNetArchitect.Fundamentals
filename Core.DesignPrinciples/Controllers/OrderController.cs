using Core.DesignPrinciples.Contracts;
using Core.DesignPrinciples.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core.DesignPrinciples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderHelper _orderHelper;

        public OrderController(IOrderHelper orderHelper)
        {
            _orderHelper = orderHelper;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateOrder(CreateOrderDto createOrderDto)
        {
            try
            {
                _orderHelper.CreateOrder(createOrderDto);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        [Route("update")]
        public IActionResult UpdateOrder(UpdateOrderDto updateOrderDto)
        {
            try
            {
                _orderHelper.UpdateOrder(updateOrderDto);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("cancel")]
        public IActionResult CancelOrder(string orderId)
        {
            try
            {
                _orderHelper.CancelOrder(orderId);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
