using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineMechanic.Data;
using OnlineMechanic.Entities;
using OnlineMechanic.Models;

namespace OnlineMechanic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public CarController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("CreateCar")]
        public async Task<ActionResult> CreateCar(CarModel car)
        {
            try
            {
                Car carToCreate = new Car()
                {
                    Brand = car.Brand,
                    Model = car.Model,
                    CarYear = car.CarYear,
                    ClientId = car.ClientId,
                };

                await _dbContext.Cars.AddAsync(carToCreate);
                await _dbContext.SaveChangesAsync();

                return Created("Car created", carToCreate);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
