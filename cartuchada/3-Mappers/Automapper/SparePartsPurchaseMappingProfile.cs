using _1_Domain.Purchase_Entities;
using _3_Data.Models.Spare_Parts_Models;
using _3_Mappers.DTOs.Purchase_Dtos;
using AutoMapper;

namespace _3_Mappers.Automapper
{
    public class SparePartsPurchaseMappingProfile : Profile
    {
        public SparePartsPurchaseMappingProfile()
        {
            // From SparePartsPurchaseModel to SparePartsPurchase
            CreateMap<SparePartsPurchaseModel, SparePartsPurchase>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.SparePartType.Name));

            // From SparePartsPurchase to SparePartsPurchaseModel
            CreateMap<SparePartsPurchase, SparePartsPurchaseModel>();

            // From SparePartsPurchaseeDto to SparePartsPurchase
            CreateMap<SparePartsPurchaseDto, SparePartsPurchase>();
        }
    }
}
