using AuctriaProject.Domain.Entities;

namespace AuctriaProject.Application.Interfaces.Persistence
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllItems();

        Task<Item> GetItemById(int id);

        Task<bool> AddOrUpdateItem(Item item);

        Task<bool> DeleteItem(int id);
    }
}
