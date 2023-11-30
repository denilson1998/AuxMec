using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using OnlineMechanic.Data;
using OnlineMechanic.Entities;
using OnlineMechanic.GlobalParametes;
using OnlineMechanic.Models;

namespace OnlineMechanic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MechanicController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public MechanicController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("CreateMechanic")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> CreateMechanic(MechanicModel mechanic)
        {
            try
            {

                var user = await _dbContext.Users.Where(u => u.Name == mechanic.Name).FirstOrDefaultAsync();

                Mechanic mechanicToCreate = new Mechanic()
                {
                    Id = user.Id,
                    Name = mechanic.Name,
                    CategoryId = mechanic.CategoryId,
                    RoleId = (int)Roles.Mechanic
                };

                await _dbContext.Mechanics.AddAsync(mechanicToCreate);
                await _dbContext.SaveChangesAsync();

                var mechanicalWorkShop = await _dbContext.MechanicalWorkshops.Where(m => m.UserId == mechanic.UserId).FirstOrDefaultAsync();

                WorkShopMechanicalMechanic workShopMechanicalMechanic = new WorkShopMechanicalMechanic()
                {
                    MechanicalWorkShopId = mechanicalWorkShop.UserId,
                    MechanicId = user.Id
                };

                await _dbContext.WorkShopMechanicalMechanics.AddAsync(workShopMechanicalMechanic);
                await _dbContext.SaveChangesAsync();

                return Created("Mechanic created!", mechanicToCreate);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("GetMechanics")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetMechanics()
        {
            try
            {
                List<Mechanic> mechanics = await _dbContext.Mechanics.ToListAsync();

                return Ok(mechanics);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
