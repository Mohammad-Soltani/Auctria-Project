using AuctriaProject.Application.Interfaces.Persistence;
using AuctriaProject.Domain.Entities;
using AuctriaProject.Infrastructure.Interfaces;
using AuctriaProject.Infrastructure.SQL;
using Microsoft.EntityFrameworkCore;

namespace AuctriaProject.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ISharedContext _sharedContext;
        public ItemRepository(ISharedContext sharedContext)
        {
            _sharedContext = sharedContext;
        }
        public async Task<IEnumerable<Item>> GetAllItems()
        {
            try
            {
                return await _sharedContext.QueryAsync<Item>(Queries.GetAllItems);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Item> GetItemById(int id)
        {
            try
            {
                return (await _sharedContext.QueryAsync<Item>(Queries.GetItemById, new { id = id })).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddOrUpdateItem(Item item)
        {
            try
            {
                if (item.Id > 0)
                {
                    await _sharedContext.ExecuteAsync(Queries.UpdateItem, new { id = item.Id, title = item.Title, price = item.Price });
                }
                else
                {
                    await _sharedContext.ExecuteAsync(Queries.AddNewItem, new { title = item.Title, price = item.Price });
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteItem(int id)
        {
            try
            {
                if (id > 0)
                {
                    await _sharedContext.ExecuteAsync(Queries.DeleteItem, new { id = id });
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
