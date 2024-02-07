using MediatR;
using Microsoft.EntityFrameworkCore;
using Nadin_Application.Common;
using Nadin_Application.Enums;
using Nadin_Application.Features.ProductFeatures.CommandProduct;
using Nadin_DAL;
using Nadin_Domain.Models.Pruducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadin_Application.Features.ProductFeatures.CommandHandlerProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProduct, OperationResault<Product>>
    {
        private readonly NadinDbContex _ctx;
        public DeleteProductHandler(NadinDbContex ctx)
        {
                _ctx = ctx;
        }
        public async Task<OperationResault<Product>> Handle(DeleteProduct request, CancellationToken cancellationToken)
        {
            var result = new OperationResault<Product>();

            try
            {
                var product = await _ctx.Products.FirstOrDefaultAsync(x => x.UserId == request.userId);
                if (product is null)
                {
                    var error = new Error() { code = ErrorCode.ServerError, Massage = "this product is empty" };
                    result.IsError = true;
                    result.Errors.Add(error);
                    return result;
                }
                _ctx.Products.Remove(product);

                await _ctx.SaveChangesAsync();

                result.PayLoad = product;
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
