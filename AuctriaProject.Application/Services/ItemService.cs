using AuctriaProject.Application.Interfaces.Services;
using AuctriaProject.Application.Interfaces.Persistence;
using AutoMapper;
using AuctriaProject.Application.Models;
using AuctriaProject.Domain.Entities;

namespace AuctriaProject.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        public async Task<List<ItemViewModel>> GetAllItems()
        {
            var res = await _itemRepository.GetAllItems();
            return _mapper.Map<List<ItemViewModel>>(res);
        }

        public async Task<ItemViewModel> GetItemById(int id)
        {
            var res = await _itemRepository.GetItemById(id);
            return _mapper.Map<ItemViewModel>(res);
        }

        public async Task<bool> AddOrUpdateItem(ItemViewModel item)
        {
            var itemModel = _mapper.Map<Item>(item);
            return await _itemRepository.AddOrUpdateItem(itemModel);
        }

        public async Task<bool> DeleteItem(int id)
        {
            return await _itemRepository.DeleteItem(id);
        }
    }
}
