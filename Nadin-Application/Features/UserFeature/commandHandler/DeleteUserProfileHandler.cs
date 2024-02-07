using MediatR;
using Microsoft.EntityFrameworkCore;
using Nadin_Application.Common;
using Nadin_Application.Enums;
using Nadin_Application.Features.UserFeature.command;
using Nadin_DAL;
using Nadin_Domain.Models.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadin_Application.Features.UserFeature.commandHandler
{
    public class DeleteUserProfileHandler : IRequestHandler<DeleteUserProfile, OperationResault<UserProfile>>
    {

        private readonly NadinDbContex _ctx;
        public DeleteUserProfileHandler(NadinDbContex ctx) 
        {
            _ctx = ctx;
        }
        public async Task<OperationResault<UserProfile>> Handle(DeleteUserProfile request, CancellationToken cancellationToken)
        {
            var result = new OperationResault<UserProfile>();

            var userProfile = await _ctx.userProfiles.FirstOrDefaultAsync(x => x.UserProfileId == request.UserProfileId);
            _ctx.userProfiles.Remove(userProfile);
            await _ctx.SaveChangesAsync();

            if (userProfile is null)
            {
                result.IsError = true;
                var error = new Error() { code = ErrorCode.NotFound, Massage = $"no user profile with id{request.UserProfileId}" };
                result.Errors.Add(error);
                return result;
            }
            result.PayLoad = userProfile;

            return result;
        }
    }
}
