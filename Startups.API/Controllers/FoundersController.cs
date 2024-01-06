using Microsoft.AspNetCore.Mvc;
using Startups.Application.Founders.Commands.RegisterFounder;
using Startups.Application.Founders.Dtos;
using Startups.Application.Founders.Queries.GetFounderById;
using Startups.Application.Founders.Queries.LoginFounder;
using Startups.Domain.Entities;
using System;

namespace Startups.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoundersController : BaseController
    {
        /// <summary>
        /// Registers a new founder
        /// </summary>
        [HttpPost("register")]
        public async Task<ActionResult<Founder>> Register(RegisterFounderDto founderDto)
        {
            try
            {
                // Calls Mediator to register a new founder
                var registeredFounder = await Mediator.Send(new RegisterFounderCommand(founderDto));

                // Returns a 201 Created status code with the registered founder's details
                return CreatedAtAction(nameof(GetById), new { id = registeredFounder.Id }, registeredFounder);
            }
            catch (Exception ex)
            {
                // Returns a 400 Bad Request status code with a specific error message for registration failure
                return BadRequest($"Registration failed: {ex.Message}");
            }
        }

        /// <summary>
        /// Logs in a founder
        /// </summary>
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginFounderDto founderDto)
        {
            try
            {
                // Calls Mediator to log in a founder and generate a token
                var loggedFounderToken = await Mediator.Send(new LoginFounderQuery(founderDto));

                // Returns a 200 OK status code with the generated token upon successful login
                return Ok(loggedFounderToken);
            }
            catch (Exception ex)
            {
                // Returns a 401 Unauthorized status code with a specific error message for login failure
                return Unauthorized($"Login failed: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves a founder by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Founder>> GetById(Guid id)
        {
            try
            {
                // Retrieve founder by ID using Mediator pattern
                var founder = await Mediator.Send(new GetFounderByIdQuery(id));

                // If founder not found, return Not Found status
                if (founder == null) NotFound();

                // Return the retrieved founder
                return Ok(founder);
            }
            catch (Exception ex)
            {
                // If an exception occurs, return a BadRequest with the exception message
                return BadRequest(ex.Message);
            }
        }
    }
}
