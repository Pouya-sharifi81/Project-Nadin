using MediatR;
using Nadin_Application.Common;
using Nadin_Domain.Models.Pruducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadin_Application.Features.ProductFeatures.CommandProduct
{
    public class DeleteProduct : IRequest<OperationResault<Product>>
    {
        public Guid userId { get; set; }
    }
}
