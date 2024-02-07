using MediatR;
using Microsoft.EntityFrameworkCore;
using Nadin_Application.Common;
using Nadin_Application.Enums;
using Nadin_Application.Features.ProductFeatures.Query;
using Nadin_DAL;
using Nadin_Domain.Models.Pruducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadin_Application.Features.ProductFeatures.Queryhandler
{
    public class GetProductByIdHandler : IRequestHandler<GetProductById, OperationResault<Product>>
    {
        private readonly NadinDbContex _ctx;
        public GetProductByIdHandler(NadinDbContex ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResault<Product>> Handle(GetProductById request, CancellationToken cancellationToken)
        {
            var result = new OperationResault<Product>();

            var product = await _ctx.Products.FirstOrDefaultAsync(x=>x.UserId== request.ProducttId);
            if (product is null)
            {
                var error = new Error() { code = ErrorCode.ServerError, Massage = "this product is empty" };
                result.IsError = true;
                result.Errors.Add(error);
            }
            result.PayLoad = product;
            return result;

        }
    }
}
