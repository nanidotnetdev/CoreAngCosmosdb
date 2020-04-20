using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreAngCosmos.Models;
using CoreAngCosmos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreAngCosmos.API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ItemApiController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IItemService _itemService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemService"></param>
        public ItemApiController(IItemService itemService)
        {
            _itemService = itemService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _itemService.GetAsync("select * from c");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/ItemsApi/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Item> GetByIdAsync(string id)
        {
            return await _itemService.GetByIdAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        // POST: api/ItemsApi
        [HttpPost(Name = "Save")]
        public async Task SaveAsync(Item item)
        {
            if (ModelState.IsValid)
            {
                //create new
                if (string.IsNullOrEmpty(item.Id))
                {
                    item.Id = Guid.NewGuid().ToString();
                    await _itemService.CreateAsync(item);
                }
                else
                {
                    await _itemService.UpdateAsync(item);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(string id)
        {
            await _itemService.DeleteItemAsync(id);
        }
    }
}