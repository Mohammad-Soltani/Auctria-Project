using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AuctriaProject.Application.Interfaces.Services;
using AuctriaProject.Application.Models;

namespace AuctriaProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        //in this controller, Authentication has been implemented

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        [HttpGet("GetAllItems")]
        public async Task<ActionResult<List<ItemViewModel>>> GetAllItems()
        {
            return Ok(await _itemService.GetAllItems());
        }

        [HttpGet("GetItemById/{id}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<ItemViewModel>> GetItemById(int id)
        {
            return Ok(await _itemService.GetItemById(id));
        }

        [HttpPost("AddNewItem")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<ItemViewModel>> AddNewItem([FromBody] ItemViewModel model)
        {
            return Ok(await _itemService.AddOrUpdateItem(model));
        }

        [HttpDelete("DeleteItem/{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return Ok(await _itemService.DeleteItem(id));
        }
    }
}
