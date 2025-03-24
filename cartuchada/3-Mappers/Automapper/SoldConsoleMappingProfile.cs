
using _1_Domain.Product_Entities;
using _1_Domain.Sold_Product_Entities;
using _3_Data.Models.SaleModels;
using AutoMapper;

namespace _3_Mappers.Automapper
{
    public class SoldConsoleMappingProfile : Profile
    {
        public SoldConsoleMappingProfile()
        {
            // From SoldConsoleModel to SoldVideoConsole
            CreateMap<SoldConsoleModel, SoldVideoConsole>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductType.Name));

            // From SoldVideoConsole to SoldConsoleModel
            CreateMap<SoldVideoConsole, SoldConsoleModel>();

            // From ConsolePurchaseDto to VideoConsole
            //CreateMap<ConsolePurchaseDto, VideoConsole>()
            //    .AfterMap((src, dest) =>
            //    {
            //        dest.CalculateTotalPrice();
            //    });

            //From VideoConsole to SoldVideoConsole
            CreateMap<VideoConsole, SoldVideoConsole>()
                .ForMember(dest => dest.IdConsole, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id, map => map.Ignore());
        }
    }
}
