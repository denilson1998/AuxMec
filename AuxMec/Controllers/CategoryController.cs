using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineMechanic.Data;
using OnlineMechanic.Entities;
using OnlineMechanic.Models;

namespace OnlineMechanic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("CreateCategory")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> CreateCategory(CategoryModel category)
        {
            try
            {
                Category categoryToCreate = new Category()
                {
                    Description = category.Description
                };

                await _dbContext.Categories.AddAsync(categoryToCreate);
                await _dbContext.SaveChangesAsync();

                return Created("Category created!", categoryToCreate);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("GetCategories")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetCategories()
        {
            try
            {
                List<Category> categories = await _dbContext.Categories.ToListAsync();

                return Ok(categories);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
