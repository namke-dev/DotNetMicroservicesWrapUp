using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Play.Catalog.Service.Dtos;
using Play.Catalog.Service.Entities;
using Play.Catalog.Service.Repositories;

namespace Play.Catalog.Service.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository itemsRepository;
        public ItemsController(IItemsRepository itemsRepository)
        {
            this.itemsRepository = itemsRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetAsync()
        {
            var listItem = await itemsRepository.GetAllAsync();
            return listItem.Select(s => s.AsDto());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetByIdAsync(Guid id)
        {
            var item = await itemsRepository.GetAsync(id);
            if (item is null)
            {
                return NotFound();
            }
            return item.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> PostAsync(CreateItemDto createItemDto)
        {
            var item = new Item
            {
                Name = createItemDto.Name,
                Description = createItemDto.Description,
                Price = createItemDto.Price,
                CreateDate = DateTimeOffset.UtcNow
            };
            await itemsRepository.CreateAsync(item);
            //item.Id property is set during the database insertion process
            return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ItemDto>> PutAsync(Guid id, UpdateItemDto updateItemDto)
        {
            var targetItem = await itemsRepository.GetAsync(id);
            if (targetItem is null)
            {
                return NotFound();
            }

            var newItem = new Item
            {
                Id = id,
                Name = updateItemDto.Name,
                Description = updateItemDto.Description,
                Price = updateItemDto.Price,
                CreateDate = targetItem.CreateDate
            };
            await itemsRepository.UpdateAsync(newItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemDto>> DeleteAsync(Guid id)
        {
            var targetItem = await itemsRepository.GetAsync(id);
            if (targetItem is null)
            {
                return NotFound();
            }

            await itemsRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}