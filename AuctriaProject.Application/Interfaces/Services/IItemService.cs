using AuctriaProject.Application.Models;

namespace AuctriaProject.Application.Interfaces.Services
{
    public interface IItemService
    {
        Task<List<ItemViewModel>> GetAllItems();

        Task<ItemViewModel> GetItemById(int id);

        Task<bool> AddOrUpdateItem(ItemViewModel item);

        Task<bool> DeleteItem(int id);
    }
}
