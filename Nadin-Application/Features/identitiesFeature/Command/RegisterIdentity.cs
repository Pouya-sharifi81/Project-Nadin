using MediatR;
using Nadin_Application.Common;
using Nadin_Application.Features.identitiesFeature.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadin_Application.Features.identitiesFeature.Command
{
    public class RegisterIdentity : IRequest<OperationResault<IdentityUserProfileDto>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string CurrentCity { get; set; }
    }
}
