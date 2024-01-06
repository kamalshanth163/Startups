using Microsoft.AspNetCore.Mvc;
using Startups.Application.Startups.Dtos;
using Startups.Application.Startups.Commands.CreateStartup;
using Startups.Application.Startups.Commands.DeleteStartup;
using Startups.Application.Startups.Commands.UpdateStartup;
using Startups.Application.Startups.Queries.GetStartupById;
using Startups.Application.Startups.Queries.GetStartups;
using Microsoft.AspNetCore.Authorization;

namespace Startups.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StartupsController : BaseController
    {
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var startups = await Mediator.Send(new GetStartupsQuery());
            return Ok(startups);
        }

        [HttpGet("id")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var startup = await Mediator.Send(new GetStartupByIdQuery(id));

                if (startup == null) NotFound();
                return Ok(startup);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("founder/founderId")]
        [Authorize]
        public async Task<IActionResult> GetByFounderId(Guid founderId)
        {
            try
            {
                var startups = await Mediator.Send(new GetStartupsByFounderIdQuery(founderId));

                if (startups == null) NotFound();
                return Ok(startups);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Founder")]
        public async Task<IActionResult> Create(CreateStartupDto startup)
        {
            try
            {
                var createdStartup = await Mediator.Send(new CreateStartupCommand(startup));
                return CreatedAtAction(nameof(GetById), new { id = createdStartup.Id }, createdStartup);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "Founder")]
        public async Task<IActionResult> Update(UpdateStartupDto startup)
        {
            try
            {
                var updatedStartup = await Mediator.Send(new UpdateStartupCommand(startup));
                return CreatedAtAction(nameof(GetById), new { id = updatedStartup.Id }, updatedStartup);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("id")]
        [Authorize(Roles = "Founder")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var deletedStartupId = await Mediator.Send(new DeleteStartupCommand(id));
                return Ok(deletedStartupId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
