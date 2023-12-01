using AuctriaProject.Domain.Entities;

namespace AuctriaProject.Application.Interfaces.Persistence
{
    public interface IShoppingCardRepository
    {
        Task<IEnumerable<ShoppingItem>> GetAllShoppingItems(int userId);

        Task<bool> AddToShoppingCard(ShoppingItem model);

        Task<bool> UpdateItemQuantity(ShoppingItem model);

        Task<bool> DeleteItemsFromShoppingCard(int itemId);
    }
}
