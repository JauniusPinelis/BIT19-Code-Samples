using AutoMapper;
using ShopWithDiscountProject.Dtos.ShopItems;
using ShopWithDiscountProject.Models;

namespace ShopWithDiscountProject.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateShopItem, ShopItem>();
            CreateMap<ShopItem, ShopItemDto>();
        }
    }
}
