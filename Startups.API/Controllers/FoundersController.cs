using Microsoft.AspNetCore.Mvc;
using Startups.Application.Founders.Commands.RegisterFounder;
using Startups.Application.Founders.Dtos;
using Startups.Application.Founders.Queries.LoginFounder;
using Startups.Domain.Entities;

namespace Startups.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoundersController : BaseController
    {
        [HttpPost("register")]
        public async Task<ActionResult<Founder>> Register(RegisterFounderDto founder)
        {
            try
            {
                var registeredFounder = await Mediator.Send(new RegisterFounderCommand(founder));
                return Ok(registeredFounder);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginFounderDto founder)
        {
            try
            {
                var loggedFounder = await Mediator.Send(new LoginFounderQuery(founder));
                return Ok(loggedFounder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}


