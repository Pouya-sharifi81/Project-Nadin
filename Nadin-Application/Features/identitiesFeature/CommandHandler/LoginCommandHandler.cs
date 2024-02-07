using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nadin_Application.Common;
using Nadin_Application.Enums;
using Nadin_Application.Features.identitiesFeature.Command;
using Nadin_Application.Features.identitiesFeature.Dto;
using Nadin_Application.Services;
using Nadin_DAL;
using Nadin_Domain.Models.user;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Nadin_Application.Features.identitiesFeature.CommandHandler
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, OperationResault<IdentityUserProfileDto>>
    {
        private readonly NadinDbContex _ctx;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IdentityService _identityService;
        private readonly IMapper _mapper;
        private OperationResault<IdentityUserProfileDto> _result = new();

        public LoginCommandHandler(NadinDbContex ctx, UserManager<IdentityUser> userManager,
            IdentityService identityService, IMapper mapper)
        {
            _ctx = ctx;
            _userManager = userManager;
            _identityService = identityService;
            _mapper = mapper;
        }

        public async Task<OperationResault<IdentityUserProfileDto>> Handle(LoginCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var identityUser = await ValidateAndGetIdentityAsync(request);
                if (_result.IsError) return _result;

                var userProfile = await _ctx.userProfiles
                    .FirstOrDefaultAsync(up => up.IdentityId == identityUser.Id, cancellationToken:
                        cancellationToken);


                _result.PayLoad = _mapper.Map<IdentityUserProfileDto>(userProfile);
                _result.PayLoad.UserName = identityUser.UserName;
                _result.PayLoad.Token = GetJwtString(identityUser, userProfile);
                return _result;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return _result;
        }

        private async Task<IdentityUser> ValidateAndGetIdentityAsync(LoginCommand request)
        {
            var identityUser = await _userManager.FindByEmailAsync(request.Username);

           

            var validPassword = await _userManager.CheckPasswordAsync(identityUser, request.Password);

            if (!validPassword)
            {
                var error = new Error() { code = ErrorCode.IdentityCreationFailed, Massage = "Identity Errore " };
               _result.IsError = true;
                _result.Errors.Add(error);
            }

            return identityUser;
        }

        private string GetJwtString(IdentityUser identityUser, UserProfile userProfile)
        {
            var claimsIdentity = new ClaimsIdentity(new Claim[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, identityUser.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, identityUser.Email),
            new Claim("IdentityId", identityUser.Id),
            new Claim("UserProfileId", userProfile.UserProfileId.ToString())
            });

            var token = _identityService.CreateSecurityToken(claimsIdentity);
            return _identityService.WriteToken(token);
        }
    }
}
