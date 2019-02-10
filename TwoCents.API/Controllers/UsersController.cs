using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TwoCents.Data;
using TwoCents.Data.Entities;

namespace TwoCents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TwoCentsDbContext _dbContext;

        public UsersController(TwoCentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<UserEntity>), 200)]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            return Ok(_dbContext.Users.ToList());
        }
    }
}
