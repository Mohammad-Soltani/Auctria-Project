using AuctriaProject.Application.Interfaces.Persistence;
using AuctriaProject.Domain.Entities;
using AuctriaProject.Infrastructure.Interfaces;
using AuctriaProject.Infrastructure.SQL;

namespace AuctriaProject.Infrastructure.Repositories
{
    public class ShoppingCardRepository : IShoppingCardRepository
    {
        private readonly ISharedContext _sharedContext;
        public ShoppingCardRepository(ISharedContext sharedContext)
        {
            _sharedContext = sharedContext;
        }
        public async Task<IEnumerable<ShoppingItem>> GetAllShoppingItems(int userId)
        {
            try
            {
                return await _sharedContext.QueryAsync<ShoppingItem>(Queries.GetAllShppingCardItems, new { userId = userId});
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddToShoppingCard(ShoppingItem model)
        {
            try
            {
                await _sharedContext.ExecuteAsync(Queries.AddItemToShppingCard, new { id = model.Id, userId = model.UserId, itemId = model.ItemId, quantity = model.Quantity });

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateItemQuantity(ShoppingItem model)
        {
            try
            {
                await _sharedContext.ExecuteAsync(Queries.UpdateItemQuantity, new { id = model.Id, quantity = model.Quantity });
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteItemsFromShoppingCard(int itemId)
        {
            try
            {
                await _sharedContext.ExecuteAsync(Queries.DeleteItemFromShppingCard, new { itemId = itemId });

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
