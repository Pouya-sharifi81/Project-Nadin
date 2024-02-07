using MediatR;
using Microsoft.EntityFrameworkCore;
using Nadin_Application.Common;
using Nadin_Application.Enums;
using Nadin_Application.Features.UserFeature.Query;
using Nadin_DAL;
using Nadin_Domain.Models.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadin_Application.Features.UserFeature.QueryHandler
{
    public class GetUserProfileByIdHandler : IRequestHandler<GetUserProfileById, OperationResault<UserProfile>>
    {
            public readonly NadinDbContex _ctr;
        public GetUserProfileByIdHandler(NadinDbContex ctr)
        {
            _ctr = ctr;
        }
 
        public async Task<OperationResault<UserProfile>> Handle(GetUserProfileById request, CancellationToken cancellationToken)
        {
            var result = new OperationResault<UserProfile>();
            var profile = await _ctr.userProfiles.FirstOrDefaultAsync(up => up.UserProfileId == request.UserProfileId);

            if (profile is null)
            {
                result.IsError = true;
                var error = new Error() { code = ErrorCode.NotFound, Massage = $"no user profile with id{request.UserProfileId}" };
                result.Errors.Add(error);
                return result;
            }
            result.PayLoad = profile;
            return result;
        }
    }
}
