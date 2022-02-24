using AutoMapper;
using ShopWithDiscountProject.Dtos.ShopItems;
using ShopWithDiscountProject.Models;
using ShopWithDiscountProject.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopWithDiscountProject.Services
{
    public class ShopItemService
    {
        private IMapper _mapper;
        private IShopItemRepository _shopItemRepository;

        public ShopItemService(IMapper mapper, IShopItemRepository shopItemRepository)
        {
            _mapper = mapper;
            _shopItemRepository = shopItemRepository;
        }

        public async Task<decimal> CalculatePriceAsync(BuyInformation buyInformation)
        {
            decimal overallPrice = 0.0M;

            foreach (var shopItemInfo in buyInformation.BuyDtos)
            {
                var shopItemEntity = await _shopItemRepository.GetShopByNameAsync(shopItemInfo.ShopItemName);
                if (shopItemEntity == null)
                {
                    throw new ArgumentException($"ShopItem {shopItemInfo.ShopItemName} not found");
                }
                //
                overallPrice += shopItemEntity.Price * shopItemInfo.Quantity;
            }

            return overallPrice;
        }

        public async Task<List<ShopItemDto>> GetAllAsync()
        {
            var entities = await _shopItemRepository.GetAllAsync();

            //var dtos = new List<ShopItemDto>();

            //foreach (var item in entities)
            //{
            //    var dto = _mapper.Map<ShopItemDto>(item);
            //    dtos.Add(dto);
            //}

            //return dtos;

            //return entities.Select(e => _mapper.Map<ShopItemDto>(e)).ToList();

            return _mapper.Map<List<ShopItemDto>>(entities);
        }

        public async Task<ShopItemDto> CreateAsync(CreateShopItem createShopItem)
        {
            // map dto to entity

            var entity = _mapper.Map<ShopItem>(createShopItem);

            //var entity = new ShopItem()
            //{
            //    Name = createShopItem.Name,
            //    Price = createShopItem.Price
            //};

            await _shopItemRepository.CreateAsync(entity);

            // create entity with ef core, we get the id
            // map from entity to dto

            //var dto = new ShopItemDto()
            //{
            //    Id = entity.Id,
            //    Name = entity.Name,
            //    CreatedUtc = entity.CreatedUtc,
            //    Price = entity.Price
            //};

            var dto = _mapper.Map<ShopItemDto>(entity);

            return dto;
        }
    }
}
