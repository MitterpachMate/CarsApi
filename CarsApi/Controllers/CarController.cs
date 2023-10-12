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

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            using (var context = new CarContext())
            {
                var result = context.Cars.Where(x => x.Id == id);
                return Ok(result.ToList());

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

        [HttpPut("{id}")]
        public ActionResult<CarDto> Post(Guid id, UpdateCarDto updateCarDto) 
        {

            using (var context = new CarContext())
            {

                var existingCar = context.Cars.FirstOrDefault(x => x.Id == id);

                existingCar.Name = updateCarDto.Name;
                existingCar.Description = updateCarDto.Description;

                context.Cars.Add(existingCar);
                context.SaveChanges();
                return Ok();

            }


        }



        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {

            using (var context = new CarContext())
            {
                var existingCar = context.Cars.FirstOrDefault(x => x.Id == id);
                context.Cars.Remove(existingCar);
                context.SaveChanges();
                return Ok();
            }
        }
    
    
    
    
    
    
    
    }

}
