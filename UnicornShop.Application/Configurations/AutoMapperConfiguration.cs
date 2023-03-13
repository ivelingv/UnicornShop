using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicornShop.Application.Models;
using UnicornShop.Application.Services.DTO;

namespace UnicornShop.Application.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddMappings(
            this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductProfile).Assembly);
            return services;
        }
    }

    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDTO, Product>(MemberList.None)
                .ForMember(dest => dest.Quanitity, opt => opt.MapFrom(src => src.Quanitity))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => new Price
                {
                    Amount = src.PriceAmount,
                    Currency = src.PriceCurrency,
                }));

            CreateMap<UpdateProductDTO, Product>(MemberList.None)
               .ForMember(dest => dest.Quanitity, opt => opt.MapFrom(src => src.Quanitity))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
