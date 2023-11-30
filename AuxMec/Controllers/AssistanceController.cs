using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineMechanic.Data;
using OnlineMechanic.Entities;
using OnlineMechanic.GlobalParametes;
using OnlineMechanic.Models;

namespace OnlineMechanic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssistanceController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;

        public AssistanceController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("CreateAssistance")]
        public async Task<ActionResult> CreateAssistance(AssitanceModel assistance)
        {
            try
            {
                Assistance assistanceToCreate = new Assistance()
                {
                    DateTime = DateTime.Now,
                    Description = assistance.Description,
                    GpsLocationLatitude = assistance.GpsLocationLatitude,
                    GpsLocationLongitude = assistance.GpsLocationLongitude,
                    Address = assistance.Address,
                    ClientId = assistance.ClientId,
                    StatusId = (int)GlobalParametes.Status.Created
                };

                await _dbContext.Assistances.AddAsync(assistanceToCreate);
                await _dbContext.SaveChangesAsync();

                return Created("Assistance created!", assistanceToCreate);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("GetAssistances")]
        public async Task<ActionResult> GetAssistances()
        {
            try
            {

                List<Assistance> assistances = await _dbContext.Assistances.ToListAsync();

                return Ok(assistances);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
