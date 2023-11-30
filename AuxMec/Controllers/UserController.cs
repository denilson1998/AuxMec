using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineMechanic.Models;
using OnlineMechanic.Entities;
using OnlineMechanic.Data;
using Microsoft.EntityFrameworkCore;
using OnlineMechanic.GlobalParametes;
using System.Linq;

namespace OnlineMechanic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public UserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("CreateUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> CreateUser(UserModel user)
        {
            try
            {
                User userToCreate = new User()
                {
                    Name = user.Name,
                    Email = user.Email,
                    Password = user.Password,
                    RoleId = user.RoleId
                };

                await _dbContext.Users.AddAsync(userToCreate);
                await _dbContext.SaveChangesAsync();

                var userCreated = await _dbContext.Users.Where(u => u.Name == userToCreate.Name && 
                                    u.Email == userToCreate.Email).FirstOrDefaultAsync();

                if (user.RoleId == (int)Roles.Client)
                {
                    Client client = new Client
                    {
                        UserId = userCreated.Id
                    };

                    await _dbContext.Clients.AddAsync(client);
                }

                if (user.RoleId == (int)Roles.MechanicalWorkShop)
                {
                    MechanicalWorkshop mechanicalWorkshop = new MechanicalWorkshop()
                    {
                        UserId = userCreated.Id
                    };
                    await _dbContext.MechanicalWorkshops.AddAsync(mechanicalWorkshop);
                }

                await _dbContext.SaveChangesAsync();

                return Created("User created!", userToCreate);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("GetClients")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetClients()
        {
            try
            {
                List<User> userClients = await _dbContext.Users
                                        .Where(c => c.RoleId == 1).ToListAsync();
               
                return Created("Clients List", userClients);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginModel login)
        {
            try
            {
                var user = await _dbContext.Users
                            .Where(u => u.Email == login.Email && u.Password == login.Password)
                            .FirstOrDefaultAsync();

                if (user is null)
                {
                    return BadRequest("User incorrect");
                }

                return Ok(user);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
