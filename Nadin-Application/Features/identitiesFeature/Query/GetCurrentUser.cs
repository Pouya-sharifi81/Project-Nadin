using MediatR;
using Nadin_Application.Common;
using Nadin_Application.Features.identitiesFeature.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Nadin_Application.Features.identitiesFeature.Query
{
    public class GetCurrentUser : IRequest<OperationResault<IdentityUserProfileDto>>
    {
        public Guid UserProfileId { get; set; }
        public ClaimsPrincipal ClaimsPrincipal { get; set; }
    }
}
