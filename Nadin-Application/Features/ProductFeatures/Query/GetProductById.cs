using MediatR;
using Nadin_Application.Common;
using Nadin_Domain.Models.Pruducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadin_Application.Features.ProductFeatures.Query
{
    public class GetProductById : IRequest<OperationResault<Product>>
    {
        public Guid ProducttId
        {
            get; set;
        }
    }
}
