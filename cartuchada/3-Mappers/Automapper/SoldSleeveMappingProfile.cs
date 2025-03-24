
using _1_Domain.Sold_Product_Entities;
using _3_Data.Models.SaleModels;
using _3_Mappers.DTOs.Sale_Dtos;
using AutoMapper;

namespace _3_Mappers.Automapper
{
    public class SoldSleeveMappingProfile : Profile
    {
        public SoldSleeveMappingProfile() 
        {
            // From SoldSleeveModel to SoldSleeve
            CreateMap<SoldSleeveModel, SoldSleeve>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.SparePartType.Name));

            // From SoldSleeve to SoldSleeveModel
            CreateMap<SoldSleeve, SoldSleeveModel>();

            // From SleeveSaleDto to SoldSleeve
            CreateMap<SleeveSaleDto, SoldSleeve>();
        }
    }
}
