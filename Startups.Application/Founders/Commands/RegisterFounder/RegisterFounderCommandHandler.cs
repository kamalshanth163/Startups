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
            var existingFounder = await _founderRepository.GetByEmailAsync(request.Founder.Email);

            if (existingFounder != null) throw new Exception("Founder with this email already exists.");

            _authService.CreatePasswordHash(request.Founder.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var newFounder = new Founder(request.Founder.Name, request.Founder.Email, passwordHash, passwordSalt);

            var registeredFounder = await _founderRepository.RegisterAsync(newFounder);

            var founderDto = _mapper.Map<FounderDto>(registeredFounder);

            var token = _authService.CreateToken(registeredFounder);

            founderDto.Token = token;

            return founderDto;
        }
    }
}

