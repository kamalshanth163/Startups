using AutoMapper;
using MediatR;
using Startups.Application.Founders.Dtos;
using Startups.Domain.Repositories;
using Startups.Domain.Services;

namespace Startups.Application.Founders.Queries.LoginFounder
{
    public class LoginFounderQueryHandler : IRequestHandler<LoginFounderQuery, FounderDto>
    {
        private readonly IFounderRepository _founderRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public LoginFounderQueryHandler(IFounderRepository founderRepository, IAuthService authService, IMapper mapper)
        {
            _founderRepository = founderRepository;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<FounderDto> Handle(LoginFounderQuery request, CancellationToken cancellationToken)
        {
            var existingFounder = await _founderRepository.GetByEmailAsync(request.Founder.Email);

            if (existingFounder == null) throw new Exception("Founder doesn't exist.");

            var passwordVerified = _authService.VerifyPasswordHash(request.Founder.Password, existingFounder.PasswordHash, existingFounder.PasswordSalt);

            if (!passwordVerified) throw new Exception("Password is invalid.");

            var founderDto = _mapper.Map<FounderDto>(existingFounder);

            var token = _authService.CreateToken(existingFounder);

            founderDto.Token = token;

            return founderDto;
        }
    }
}


