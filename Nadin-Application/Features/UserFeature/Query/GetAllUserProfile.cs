﻿using MediatR;
using Nadin_Application.Common;
using Nadin_Domain.Models.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadin_Application.Features.UserFeature.Query
{
    public class GetAllUserProfile : IRequest<OperationResault<IEnumerable<UserProfile>>>
    {
    }
}
