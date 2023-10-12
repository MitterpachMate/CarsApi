using CarsApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarsApi.Controllers
{
    [Route("cars")]
    [ApiController]
    public class CarController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get() {

            using (var context = new CarContext())
            {
                return Ok(context.Cars.ToList());
            }
        
        }


        [HttpPost]
        public ActionResult<CarDto> Post(CreatedCarDto car)
        {

            using (var context = new CarContext())
            {
                var request = new Car
                {
                    Id = Guid.NewGuid(),
                    Name = car.Name,
                    Description = car.Description,
                    CreatedTime = DateTime.Now,
                };
                
                context.Cars.Add(request);
                context.SaveChanges();

            }
            return Ok();
        }


    }
}
