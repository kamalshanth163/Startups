using Microsoft.AspNetCore.Mvc;
using Startups.Application.Startups.Dtos;
using Startups.Application.Startups.Commands.CreateStartup;
using Startups.Application.Startups.Commands.DeleteStartup;
using Startups.Application.Startups.Commands.UpdateStartup;
using Startups.Application.Startups.Queries.GetStartupById;
using Startups.Application.Startups.Queries.GetStartups;

namespace Startups.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StartupsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var startups = await Mediator.Send(new GetStartupsQuery());
            return Ok(startups);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var startup = await Mediator.Send(new GetStartupByIdQuery(id));

            if (startup == null) NotFound();
            return Ok(startup);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStartupDto startup)
        {
            var createdStartup = await Mediator.Send(new CreateStartupCommand(startup));
            return CreatedAtAction(nameof(GetById), new { id = createdStartup.Id }, createdStartup);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateStartupDto startup)
        {
            var updatedStartup = await Mediator.Send(new UpdateStartupCommand(startup));
            return CreatedAtAction(nameof(GetById), new { id = updatedStartup.Id }, updatedStartup);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedStartupId = await Mediator.Send(new DeleteStartupCommand(id));
            return Ok(deletedStartupId);
        }
    }
}
