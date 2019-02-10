using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwoCents.API.Models;
using TwoCents.Data;
using TwoCents.Data.Entities;

namespace TwoCents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetitionsController : Controller
    {
        private readonly TwoCentsDbContext _dbContext;

        public PetitionsController(TwoCentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PetitionEntity>), 200)]
        public async Task<IActionResult> GetAllPetitions([FromQuery] PetitionCategory? category = null)
        {
            var petitions = category == null ?
                await _dbContext.Petitions
                    .ToListAsync() :
                await _dbContext.Petitions
                    .Where(o => o.Category == category)
                    .ToListAsync();
            return Ok(petitions);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PetitionEntity), 200)]
        public async Task<IActionResult> GetPetition([FromRoute] Guid id)
        {
            var petition = await _dbContext.Petitions.Where(o => o.Id == id).FirstOrDefaultAsync();
            return Ok(petition);
        }

        [HttpPost("create")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> CreatePetition(CreatePetitionModel model)
        {
            var petition = new PetitionEntity()
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Description = model.Description,
                Category = model.Category,
                Status = GovStatus.UNNOTICED,
                DownVotes = 0,
                UpVotes = 0
            };

            await _dbContext.Petitions.AddAsync(petition);
            await _dbContext.SaveChangesAsync();

            var createdUri = Url.Action("GetPetition", new
            {
                id = petition.Id
            });

            return Created(createdUri, petition.Id);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeletePetition([FromRoute] Guid id)
        {
            var petition = await _dbContext.Petitions.Where(o => o.Id == id).FirstOrDefaultAsync();

            if (petition == null)
            {
                return NotFound();
            }

            _dbContext.Petitions.Remove(petition);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}/upvote")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> UpvotePetition([FromRoute] Guid id)
        {
            var petition = await _dbContext.Petitions.Where(o => o.Id == id).FirstOrDefaultAsync();

            if (petition == null)
            {
                return NotFound();
            }

            petition.UpVotes += 1;

            _dbContext.Petitions.Update(petition);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}/downvote")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DownvotePetition([FromRoute] Guid id)
        {
            var petition = await _dbContext.Petitions.Where(o => o.Id == id).FirstOrDefaultAsync();

            if (petition == null)
            {
                return NotFound();
            }

            petition.DownVotes += 1;

            _dbContext.Petitions.Update(petition);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
