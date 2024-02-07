using AutoMapper;
using MediatR;
using Nadin_Application.Common;
using Nadin_Application.Enums;
using Nadin_Application.Features.ProductFeatures.CommandProduct;
using Nadin_DAL;
using Nadin_Domain.Models.Pruducts;
using Nadin_Domain.Models.user;
using Nadin_Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadin_Application.Features.ProductFeatures.CommandHandlerProduct
{
    public class ProductCreateHandler : IRequestHandler<ProductCreate, OperationResault<Product>>
    {
        private readonly NadinDbContex _ctx;
        private readonly IMapper _mapper;
        public ProductCreateHandler(NadinDbContex ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        public async Task<OperationResault<Product>> Handle(ProductCreate request, CancellationToken cancellationToken)
        {
            var result = new OperationResault<Product>();
            try
            {
                var product = Product.CreateProduct(request.UserId, request.Name, request.Email, request.Phone,
                            request.Date, request.IsAvailable);
                _ctx.Products.Add(product);
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
