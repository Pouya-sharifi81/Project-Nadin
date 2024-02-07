using MediatR;
using Nadin_Application.Common;
using Nadin_Application.Features.UserFeature.command;
using Nadin_DAL;
using Nadin_Domain.Models.user;
using Nadin_Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadin_Application.Features.UserFeature.commandHandler
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, OperationResault<UserProfile>>
    {
        public readonly NadinDbContex _ctx;
        public CreateUserCommandHandler(NadinDbContex ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResault<UserProfile>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResault<UserProfile>();
            var bacisInfo = BasicInfo.CreateBasicInfo(
                request.FirstName, request.LastName, request.EmailAddress,
                request.Phone, request.DateOfBirth, request.CurrentCity
                );
            var userProfile = UserProfile.CreateUserProfile(Guid.NewGuid().ToString(), bacisInfo);
            _ctx.userProfiles.Add(userProfile);
            await _ctx.SaveChangesAsync();

            result.PayLoad = userProfile;

            return result;
        }
    }
}
