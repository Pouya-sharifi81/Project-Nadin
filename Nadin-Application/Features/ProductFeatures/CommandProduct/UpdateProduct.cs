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
    public class UpdateProduct : IRequest<OperationResault<Product>>
    {
        public Guid UserId { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
    }
}
