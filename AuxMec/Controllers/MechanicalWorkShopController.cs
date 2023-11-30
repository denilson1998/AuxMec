using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineMechanic.Data;
using OnlineMechanic.Entities;

namespace OnlineMechanic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MechanicalWorkShopController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public MechanicalWorkShopController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetMechanicalWorkShops")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetMechanicalWorkShops()
        {
            try
            {

                List<MechanicalWorkshop> mechanicalWorkshops = await _dbContext.MechanicalWorkshops.ToListAsync();

                return Ok(mechanicalWorkshops);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
