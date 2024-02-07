using MediatR;
using Microsoft.AspNetCore.Identity;
using Nadin_Application.Common;
using Nadin_Application.Features.identitiesFeature.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadin_Application.Features.identitiesFeature.Command
{
    public class LoginCommand : IRequest<OperationResault<IdentityUserProfileDto>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
