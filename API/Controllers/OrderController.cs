using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderRepository _OrderRepository;

        #region Order Repository
        public OrderController(OrderRepository OrderRepository)
        {
            _OrderRepository = OrderRepository;
        }
        #endregion

        #region Order Get
        [HttpGet]
        public IActionResult OrderGet()
        {
            var Orders = _OrderRepository.OrderSelectAll();
            return Ok(Orders);
        }
        #endregion

        #region Order Get By ID
        [HttpGet("{id}")]
        public IActionResult OrderGetByID(int id)
        {
            var Orders = _OrderRepository.SelectByID(id);
            return Ok(Orders);
        }
        #endregion

        #region Order Delete
        [HttpDelete("{id}")]
        public IActionResult OrderDelete(int id)
        {
            var Orders = _OrderRepository.OrderDelete(id);
            return Ok(Orders);
        }
        #endregion

        #region Order Insert
        [HttpPost]
        public IActionResult OrderInsert([FromBody] OrderModel Order)
        {
            var Orders = _OrderRepository.OrderInsert(Order);
            return Ok(Orders);
        }
        #endregion

        #region Order Update
        [HttpPut("{id}")]
        public IActionResult OrderUpdate(int id, [FromBody] OrderModel Order)
        {
            var Orders = _OrderRepository.OrderUpdate(id, Order);
            return Ok(Orders);
        }
        #endregion
    }
}
