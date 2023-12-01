using Microsoft.AspNetCore.Mvc;
using AuctriaProject.Application.Interfaces.Services;
using AuctriaProject.Application.Models;

namespace AuctriaProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingItemsController : ControllerBase
    {
        private readonly IShoppingCardService _shoppingCardService;
        public ShoppingItemsController(IShoppingCardService shoppingCardService)
        {
            _shoppingCardService = shoppingCardService;
        }

        [HttpGet("GetAllShoppingItems")]
        public async Task<ActionResult<List<ShoppingCardViewModel>>> GetAllShoppingItems(int userId)
        {
            return Ok(await _shoppingCardService.GetAllShoppingItems(userId));
        }


        [HttpPost("AddToShoppingCard")]
        public async Task<ActionResult> AddToShoppingCard([FromBody] ShoppingCardViewModel model)
        {
            return Ok(await _shoppingCardService.AddToShoppingCard(model));
        }

        [HttpPut("UpdateItemQuantity")]
        public async Task<ActionResult> UpdateItem([FromBody] ShoppingCardViewModel model)
        {
            return Ok(await _shoppingCardService.UpdateItemQuantity(model));
        }

        [HttpDelete("DeleteItemsFromShoppingCard/{id}")]
        public async Task<ActionResult> Delete(int itemId)
        {
            return Ok(await _shoppingCardService.DeleteItemsFromShoppingCard(itemId));
        }
    }
}
