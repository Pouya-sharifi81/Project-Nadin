using MediatR;
using Nadin_Application.Common;
using Nadin_Domain.Models.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadin_Application.Features.UserFeature.command
{
    public class DeleteUserProfile : IRequest<OperationResault<UserProfile>>

    {
        public Guid UserProfileId { get; set; }
    }
}
