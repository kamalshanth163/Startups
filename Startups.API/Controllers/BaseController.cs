﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Startups.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private ISender _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    }
}
