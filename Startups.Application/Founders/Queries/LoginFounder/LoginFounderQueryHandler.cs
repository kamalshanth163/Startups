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
            // Gets the existing founder by founder's email address
            var existingFounder = await _founderRepository.GetByEmailAsync(request.Founder.Email);

            // Checks if the founder already exists. If no, then throw an exception
            if (existingFounder == null) throw new Exception("Founder doesn't exist.");

            // Verifies whether the saved password is equal to the request password by decoding hash and salt values
            var passwordVerified = _authService.VerifyPasswordHash(request.Founder.Password, existingFounder.PasswordHash, existingFounder.PasswordSalt);

            // Throws an exception if the password is not equal and verified
            if (!passwordVerified) throw new Exception("Password is invalid.");

            // Maps founder entity to the DTO
            var founderDto = _mapper.Map<FounderDto>(existingFounder);

            // Creates a new token based on the founder
            var token = _authService.CreateToken(existingFounder);

            // Assigns the created token to the founder
            founderDto.Token = token;

            // Returns the founder DTO
            return founderDto;
        }
    }
}


