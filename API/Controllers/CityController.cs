using System.Data;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityRepository _cityRepository;

        #region City Repository
        public CityController(CityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        } 
        #endregion

        #region Get City
        [HttpGet]
        public IActionResult GetCity()
        {
            var cities = _cityRepository.SelectAll();
            return Ok(cities);
        }
        #endregion

        #region CityGet by id
        [HttpGet("{id}")]
        public IActionResult GetCityByID(int id)
        {
            var cities = _cityRepository.SelectByID(id);
            return Ok(cities);
        }
        #endregion

        #region City Delete
        [HttpDelete("{id}")]
        public IActionResult CityDelete(int id)
        {
            var cities = _cityRepository.DeleteCity(id);
            return Ok(cities);
        }
        #endregion

        #region City Insert
        [HttpPost]
        public IActionResult InsertCity([FromBody] CityModel city)
        {
            var cities = _cityRepository.InsertCity(city);
            return Ok(cities);
        }
        #endregion

        #region City Update
        [HttpPut("{id}")]
        public IActionResult UpdateCity(int id, [FromBody] CityModel city)
        {
            var cities = _cityRepository.UpdateCity(id, city);
            return Ok(cities);
        }
        #endregion

        #region Get Country
        [HttpGet("Countrydropdown")]
        public IActionResult GetCountry()
        {
            var country = _cityRepository.CountrySelectAll();
            return Ok(country);
        }
        #endregion

        #region StateGet by Countryid
        [HttpGet("Statedropdown/{id}")]
        public IActionResult GetStateByCountryID(int id)
        {
            var state = _cityRepository.StateSelectByCountyID(id);
            return Ok(state);
        }
        #endregion
    }
}
