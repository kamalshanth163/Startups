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
        /// <summary>
        /// Retrieve all startups (Requires authorization)
        /// </summary>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllStartups()
        {
            // Fetches a list of all startups
            var startups = await Mediator.Send(new GetStartupsQuery());

            // Returns a successful response with all startups
            return Ok(startups); 
        }

        /// <summary>
        /// Retrieve a specific startup by ID (Requires authorization)
        /// </summary>        
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetStartupById(Guid id)
        {
            try
            {
                // Fetches a single startup by its ID
                var startup = await Mediator.Send(new GetStartupByIdQuery(id));

                // If the startup is not found, returns a 'Not Found' response
                if (startup == null) return NotFound(); 

                // Returns a successful response with the requested startup
                return Ok(startup); 
            }
            catch (Exception ex)
            {
                // Returns a 'Bad Request' response with the error message if an exception occurs
                return BadRequest(ex.Message); 
            }
        }

        /// <summary>
        /// Retrieve startups by Founder ID (Requires authorization)
        /// </summary>
        [HttpGet("founder/{founderId}")]
        [Authorize]
        public async Task<IActionResult> GetStartupsByFounderId(Guid founderId)
        {
            try
            {
                // Fetches startups associated with a specific founder by their Founder ID
                var startups = await Mediator.Send(new GetStartupsByFounderIdQuery(founderId));

                // If no startups found for the founder, returns a 'Not Found' response
                if (startups == null) return NotFound(); 

                // Returns a successful response with the startups associated with the founder
                return Ok(startups); 
            }
            catch (Exception ex)
            {
                // Returns a 'Bad Request' response with the error message if an exception occurs
                return BadRequest(ex.Message); 
            }
        }

        /// <summary>
        /// Create a new startup (Requires authorization with 'Founder' role)
        /// </summary>        
        [HttpPost]
        [Authorize(Roles = "Founder")]
        public async Task<IActionResult> CreateNewStartup(CreateStartupDto startupDto)
        {
            try
            {
                // Executes a command to create a new startup using the provided DTO
                var createdStartup = await Mediator.Send(new CreateStartupCommand(startupDto));

                // Returns a '201 Created' response with the newly created startup's details
                return CreatedAtAction(nameof(GetStartupById), new { id = createdStartup.Id }, createdStartup);
            }
            catch (Exception ex)
            {
                // Returns a '400 Bad Request' response with the specific error message if an exception occurs
                return BadRequest($"Failed to create startup: {ex.Message}");
            }
        }

        /// <summary>
        /// Update an existing startup (Requires authorization with 'Founder' role)
        /// </summary>        
        [HttpPut]
        [Authorize(Roles = "Founder")]
        public async Task<IActionResult> UpdateExistingStartup(UpdateStartupDto startupDto)
        {
            try
            {
                // Executes a command to update an existing startup using the provided DTO
                var updatedStartup = await Mediator.Send(new UpdateStartupCommand(startupDto));

                // Returns a '201 Created' response with the updated startup's details
                return CreatedAtAction(nameof(GetStartupById), new { id = updatedStartup.Id }, updatedStartup);
            }
            catch (Exception ex)
            {
                // Returns a '400 Bad Request' response with the specific error message if an exception occurs
                return BadRequest($"Failed to update startup: {ex.Message}");
            }
        }

        /// <summary>
        /// Delete a startup by ID (Requires authorization with 'Founder' role)
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Founder")]
        public async Task<IActionResult> DeleteStartup(Guid id)
        {
            try
            {
                // Executes a command to delete a startup by its ID
                var deletedStartupId = await Mediator.Send(new DeleteStartupCommand(id));

                // Returns a '200 OK' response with the ID of the deleted startup
                return Ok(deletedStartupId); 
            }
            catch (Exception ex)
            {
                // Returns a '400 Bad Request' response with the specific error message if an exception occurs
                return BadRequest($"Failed to delete startup: {ex.Message}");
            }
        }
    }
}
