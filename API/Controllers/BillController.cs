using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly BillRepository _billRepository;

        #region Bill Repository
        public BillController(BillRepository billRepository)
        {
            _billRepository = billRepository;
        }
        #endregion

        #region Bill Get
        [HttpGet]
        public IActionResult BillGet()
        {
            var Bills = _billRepository.BillSelectAll();
            return Ok(Bills);
        }
        #endregion

        #region Bill Get By ID
        [HttpGet("{id}")]
        public IActionResult BillGetByID(int id)
        {
            var Bills = _billRepository.SelectByID(id);
            return Ok(Bills);
        }
        #endregion

        #region Bill Delete
        [HttpDelete("{id}")]
        public IActionResult BillDelete(int id)
        {
            var Bills = _billRepository.BillDelete(id);
            return Ok(Bills);
        }
        #endregion

        #region Bill Insert
        [HttpPost]
        public IActionResult BillInsert([FromBody] BillModel Bill)
        {
            var Bills = _billRepository.BillInsert(Bill);
            return Ok(Bills);
        }
        #endregion

        #region Bill Update
        [HttpPut("{id}")]
        public IActionResult BillUpdate(int id, [FromBody] BillModel Bill)
        {
            var Bills = _billRepository.BillUpdate(id, Bill);
            return Ok(Bills);
        }
        #endregion
    }
}
