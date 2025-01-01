using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly OrderDetailRepository _OrderDetailRepository;

        #region OrderDetail Repository
        public OrderDetailController(OrderDetailRepository OrderDetailRepository)
        {
            _OrderDetailRepository = OrderDetailRepository;
        }
        #endregion

        #region OrderDetail Get
        [HttpGet]
        public IActionResult OrderDetailGet()
        {
            var OrderDetails = _OrderDetailRepository.OrderDetailSelectAll();
            return Ok(OrderDetails);
        }
        #endregion

        #region OrderDetail Get By ID
        [HttpGet("{id}")]
        public IActionResult OrderDetailGetByID(int id)
        {
            var OrderDetails = _OrderDetailRepository.SelectByID(id);
            return Ok(OrderDetails);
        }
        #endregion

        #region OrderDetail Delete
        [HttpDelete("{id}")]
        public IActionResult OrderDetailDelete(int id)
        {
            var OrderDetails = _OrderDetailRepository.OrderDetailDelete(id);
            return Ok(OrderDetails);
        }
        #endregion

        #region OrderDetail Insert
        [HttpPost]
        public IActionResult OrderDetailInsert([FromBody] OrderDetailModel OrderDetail)
        {
            var OrderDetails = _OrderDetailRepository.OrderDetailInsert(OrderDetail);
            return Ok(OrderDetails);
        }
        #endregion

        #region OrderDetail Update
        [HttpPut("{id}")]
        public IActionResult OrderDetailUpdate(int id, [FromBody] OrderDetailModel OrderDetail)
        {
            var OrderDetails = _OrderDetailRepository.OrderDetailUpdate(id, OrderDetail);
            return Ok(OrderDetails);
        }
        #endregion
    }
}
