using AutoMapper;
using Nadin_Application.Features.ProductFeatures.CommandProduct;
using Nadin_Application.Features.UserFeature.command;
using Nadin_Domain.Models.Pruducts;
using Nadin_Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadin_Application.Mapping
{
    public class MappingItems : Profile
    {
        public MappingItems()
        {
            CreateMap<CreateUserCommand, BasicInfo>();
            CreateMap<ProductCreate, Product>();
           
        }
    }
}
