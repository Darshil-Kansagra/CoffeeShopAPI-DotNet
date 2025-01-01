using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepository _CustomerRepository;

        #region Customer Repository
        public CustomerController(CustomerRepository CustomerRepository)
        {
            _CustomerRepository = CustomerRepository;
        }
        #endregion

        #region Customer Get
        [HttpGet]
        public IActionResult CustomerGet()
        {
            var Customers = _CustomerRepository.CustomerSelectAll();
            return Ok(Customers);
        }
        #endregion

        #region Customer Get By ID
        [HttpGet("{id}")]
        public IActionResult CustomerGetByID(int id)
        {
            var Customers = _CustomerRepository.SelectByID(id);
            return Ok(Customers);
        }
        #endregion

        #region Customer Delete
        [HttpDelete("{id}")]
        public IActionResult CustomerDelete(int id)
        {
            var Customers = _CustomerRepository.CustomerDelete(id);
            return Ok(Customers);
        }
        #endregion

        #region Customer Insert
        [HttpPost]
        public IActionResult CustomerInsert([FromBody] CustomerModel Customer)
        {
            var Customers = _CustomerRepository.CustomerInsert(Customer);
            return Ok(Customers);
        }
        #endregion

        #region Customer Update
        [HttpPut("{id}")]
        public IActionResult CustomerUpdate(int id, [FromBody] CustomerModel Customer)
        {
            var Customers = _CustomerRepository.CustomerUpdate(id, Customer);
            return Ok(Customers);
        }
        #endregion
    }
}
