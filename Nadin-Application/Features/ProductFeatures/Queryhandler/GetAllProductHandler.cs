using MediatR;
using Microsoft.EntityFrameworkCore;
using Nadin_Application.Common;
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
    public class GetAllProductHandler : IRequestHandler<GetAllProduct, OperationResault<List<Product>>>
    {
        private readonly NadinDbContex _ctx;
        public GetAllProductHandler(NadinDbContex ctx)
        {
                _ctx = ctx;
        }
        public async Task<OperationResault<List<Product>>> Handle(GetAllProduct request, CancellationToken cancellationToken)
        {
            var result = new OperationResault<List<Product>>();
            try
            {
                var product = await _ctx.Products.ToListAsync();
                result.PayLoad = product;
            }
            catch (Exception e)
            {
                var error = new Error() { code = Enums.ErrorCode.ServerError , Massage = e.Message };
                result.IsError = true;
                result.Errors.Add(error);
                
            }
            return result;
        }
    }
}
