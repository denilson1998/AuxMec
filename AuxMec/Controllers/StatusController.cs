using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineMechanic.Data;
using OnlineMechanic.Entities;
using OnlineMechanic.Models;

namespace OnlineMechanic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public StatusController(ApplicationDbContext dbContext)
        { 
            _dbContext = dbContext;
        }

        [HttpPost("CreateState")]
        public async Task<ActionResult> CreateState(StatusModel status)
        {
            try
            {
                Status statusToCreate = new Status()
                {
                    Description = status.Description,
                };

                await _dbContext.Status.AddAsync(statusToCreate);
                await _dbContext.SaveChangesAsync();

                return Created("Status created", statusToCreate);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
