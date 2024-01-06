using AutoMapper;
using MediatR;
using Startups.Application.Founders.Dtos;
using Startups.Domain.Entities;
using Startups.Domain.Repositories;
using Startups.Domain.Services;

namespace Startups.Application.Founders.Commands.RegisterFounder
{
    public class RegisterFounderCommandHandler : IRequestHandler<RegisterFounderCommand, FounderDto>
    {
        private readonly IFounderRepository _founderRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public RegisterFounderCommandHandler(IFounderRepository founderRepository, IAuthService authService, IMapper mapper)
        {
            _founderRepository = founderRepository;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<FounderDto> Handle(RegisterFounderCommand request, CancellationToken cancellationToken)
        {
            // Gets the founder by email
            var existingFounder = await _founderRepository.GetByEmailAsync(request.Founder.Email);

            // Checks if the founder is already registered
            if (existingFounder != null) throw new Exception("Founder with this email already exists.");

            // Creates secure encoded password
            _authService.CreatePasswordHash(request.Founder.Password, out byte[] passwordHash, out byte[] passwordSalt);

            // Registers a new founder
            var newFounder = new Founder(request.Founder.Name, request.Founder.Email, passwordHash, passwordSalt);
            var registeredFounder = await _founderRepository.RegisterAsync(newFounder);

            // Maps founder to limit accessbility of properties
            var founderDto = _mapper.Map<FounderDto>(registeredFounder);

            // Creates a new token for authentication
            var token = _authService.CreateToken(registeredFounder);

            // Assigns the new token for the founder
            founderDto.Token = token;

            // Returns founder DTO
            return founderDto;
        }
    }
}

