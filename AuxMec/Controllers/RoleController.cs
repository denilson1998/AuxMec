using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineMechanic.Data;
using OnlineMechanic.Entities;
using OnlineMechanic.Models;

namespace OnlineMechanic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public RoleController(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        [HttpPost("CreateRole")]
        public async Task<ActionResult> CreateRole(RoleModel role)
        {
            try
            {
                Role roleToCreate = new Role()
                {
                    Description = role.Description
                };

                await _dbContext.Roles.AddAsync(roleToCreate);
                await _dbContext.SaveChangesAsync();

                return Created("Role created!", roleToCreate);
            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }
}
