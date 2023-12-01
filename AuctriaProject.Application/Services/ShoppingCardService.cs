using AuctriaProject.Application.Interfaces.Services;
using AuctriaProject.Application.Interfaces.Persistence;
using AutoMapper;
using AuctriaProject.Application.Models;
using AuctriaProject.Domain.Entities;

namespace AuctriaProject.Application.Services
{
    public class ShoppingCardService : IShoppingCardService
    {
        private readonly IShoppingCardRepository _shoppingCardRepository;
        private readonly IMapper _mapper;
        public ShoppingCardService(IShoppingCardRepository shoppingCardRepository, IMapper mapper)
        {
            _shoppingCardRepository = shoppingCardRepository;
            _mapper = mapper;
        }
        public async Task<List<ShoppingCardViewModel>> GetAllShoppingItems(int userId)
        {
            var res = await _shoppingCardRepository.GetAllShoppingItems(userId);
            return _mapper.Map<List<ShoppingCardViewModel>>(res);
        }

        public async Task<bool> AddToShoppingCard(ShoppingCardViewModel model)
        {
            var shoppingItem = _mapper.Map<ShoppingItem>(model);
            return await _shoppingCardRepository.AddToShoppingCard(shoppingItem);
        }

        public async Task<bool> UpdateItemQuantity(ShoppingCardViewModel model)
        {
            var shoppingItem = _mapper.Map<ShoppingItem>(model);
            return await _shoppingCardRepository.UpdateItemQuantity(shoppingItem);
        }

        public async Task<bool> DeleteItemsFromShoppingCard(int itemId)
        {
            return await _shoppingCardRepository.DeleteItemsFromShoppingCard(itemId);
        }
    }
}
