using AuctriaProject.Application.Models;

namespace AuctriaProject.Application.Interfaces.Services
{
    public interface IShoppingCardService
    {
        Task<List<ShoppingCardViewModel>> GetAllShoppingItems(int userId);

        Task<bool> AddToShoppingCard(ShoppingCardViewModel model);

        Task<bool> UpdateItemQuantity(ShoppingCardViewModel model);

        Task<bool> DeleteItemsFromShoppingCard(int itemId);
    }
}
