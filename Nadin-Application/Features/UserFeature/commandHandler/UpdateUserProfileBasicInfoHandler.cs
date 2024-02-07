using MediatR;
using Microsoft.EntityFrameworkCore;
using Nadin_Application.Common;
using Nadin_Application.Enums;
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
    public class UpdateUserProfileBasicInfoHandler : IRequestHandler<UpdateUserProfileBasicInfo, OperationResault<UserProfile>>
    {
        private readonly NadinDbContex _ctx;
        public UpdateUserProfileBasicInfoHandler(NadinDbContex ctx)
        {
                _ctx = ctx;
        }
        public async Task<OperationResault<UserProfile>> Handle(UpdateUserProfileBasicInfo request, CancellationToken cancellationToken)
        {
            var result = new OperationResault<UserProfile>();

            try
            {

                var userProfile = await _ctx.userProfiles.FirstOrDefaultAsync(x => x.UserProfileId == request.UserProfileId);
                if (userProfile is null)
                {
                    result.IsError = true;
                    var error = new Error() { code = ErrorCode.NotFound, Massage = $"no user profile with id{request.UserProfileId}" };
                    result.Errors.Add(error);
                    return result;
                }
                var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName, request.EmailAddress,
                    request.Phone, request.DateOfBirth, request.CurrentCity);
                userProfile.UpdateBasicInfo(basicInfo);

                _ctx.userProfiles.Update(userProfile);
                await _ctx.SaveChangesAsync();
                result.PayLoad = userProfile;
                return result;
            }
            catch (Exception e)
            {
                var error = new Error() { code = ErrorCode.ServerError, Massage = e.Message };
                result.IsError = true;
                result.Errors.Add(error);
            }



            return result;
        }
    }
}
