using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwoCents.API.Models;
using TwoCents.Data;
using TwoCents.Data.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TwoCents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : Controller
    {
        private readonly TwoCentsDbContext _dbContext;

        public CommentsController(TwoCentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<PetitionCommentEntity>), 200)]
        public async Task<IActionResult> GetComments([FromRoute] Guid id)
        {
            var comments = await _dbContext.Comments
                .Where(o => o.PetitionEntityId == id)
                .OrderByDescending(o => o.TimeStamp)
                .ToListAsync();

            return Ok(comments);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> AddComment([FromRoute] Guid id, [FromBody] AddCommentModel model)
        {
            var comment = new PetitionCommentEntity()
            {
                Id = Guid.NewGuid(),
                Comment = model.Comment,
                PetitionEntityId = id,
                TimeStamp = DateTime.Now
            };

            await _dbContext.Comments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
