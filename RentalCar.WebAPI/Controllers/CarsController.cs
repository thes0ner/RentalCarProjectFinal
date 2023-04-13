using Microsoft.AspNetCore.Mvc;
using RentalCar.Business.Abstract;
using RentalCar.Entities.Concrete;

namespace RentalCar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }


        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }


        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }

        [HttpGet("getbybrand")]
        public IActionResult GetByBrandId(int id)
        {
            var result = _carService.GetByBrandId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }


        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }

    }
}
