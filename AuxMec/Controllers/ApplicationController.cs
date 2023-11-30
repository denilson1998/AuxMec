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
    public class ApplicationController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ApplicationController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("CreateApplication")]
        public async Task<ActionResult> CreateApplication(ApplicationModel application)
        {
            try
            {
                var mechanicalWorkShopId = await _dbContext.WorkShopMechanicalMechanics
                                            .Where(m => m.MechanicId == application.MechanicId)
                                            .FirstOrDefaultAsync();

                var assistance = await _dbContext.Assistances.Where(a => a.Id == application.AssistanceId).FirstOrDefaultAsync();

                Application applicationToCreate = new Application()
                {
                    ApplicationDateTime = DateTime.Now,
                    ArrivalTimeStimated = application.ArrivalTimeStimated,
                    BaseCost = application.BaseCost,
                    WorkShopMechanicalMechanicId = mechanicalWorkShopId.Id,
                    AssistanceId = application.AssistanceId,
                    ClientId = assistance.ClientId,
                    StatusId = (int)GlobalParametes.Status.InProgress
                };

                await _dbContext.Applications.AddAsync(applicationToCreate);
                await _dbContext.SaveChangesAsync();

                return Created("Application created!", applicationToCreate);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("GetApplications/{ClientId}")]
        public async Task<ActionResult> GetApplications(int ClientId)
        {
            try
            {

                List<Application> applications = await _dbContext.Applications.ToListAsync();

                return Ok(applications);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut("UpdateApplication")]
        public async Task<ActionResult> UpdateApplication(ApplicationModel application)
        {
            try
            {
                var applicationToUpdate = await _dbContext.Applications
                                          .Where(a => a.AssistanceId == application.AssistanceId)
                                          .FirstOrDefaultAsync();
                var assistanceToUpdate = await _dbContext.Assistances
                                         .Where(a => a.Id == application.AssistanceId)
                                         .FirstOrDefaultAsync();

                assistanceToUpdate.StatusId = (int)GlobalParametes.Status.InProgress;
                applicationToUpdate.StatusId = (int)GlobalParametes.Status.Accepted;

                await _dbContext.AddAsync(assistanceToUpdate);
                await _dbContext.AddAsync(applicationToUpdate);
                await _dbContext.SaveChangesAsync();

                return Ok("Assistance and Application Status Updated");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
