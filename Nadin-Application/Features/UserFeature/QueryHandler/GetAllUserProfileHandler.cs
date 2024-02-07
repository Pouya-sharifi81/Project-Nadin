using MediatR;
using Microsoft.EntityFrameworkCore;
using Nadin_Application.Common;
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
    public class GetAllUserProfileHandler : IRequestHandler<GetAllUserProfile, OperationResault<IEnumerable<UserProfile>>>
    {
        public readonly NadinDbContex _ctx;
        public GetAllUserProfileHandler(NadinDbContex ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResault<IEnumerable<UserProfile>>> Handle(GetAllUserProfile request, CancellationToken cancellationToken)
        {
            var result = new OperationResault<IEnumerable<UserProfile>>();
            result.PayLoad = await _ctx.userProfiles.ToListAsync();
            return result;
        }
    }
}
