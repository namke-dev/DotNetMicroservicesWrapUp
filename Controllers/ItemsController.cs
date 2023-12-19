using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Play.Catalog.Service.Dtos;

namespace Play.Catalog.Service.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private static readonly List<ItemDto> items = new()
        {
            new ItemDto(Guid.NewGuid(), "Potion", "Restores small amount of HP", 5, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Antidote", "Cure poison", 7, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Bronze armor", "Block small amount of Damges", 1, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Bronze Sword", "Deal small amount of Damge", 1, DateTimeOffset.UtcNow)
        };

        [HttpGet]
        public IEnumerable<ItemDto> Get()
        {
            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetById(Guid id)
        {
            var item = items.Find(i => i.Id == id);
            if (item is null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public ActionResult<ItemDto> Post(CreateItemDto createItemDto)
        {
            var item = new ItemDto(Guid.NewGuid(), createItemDto.Name, createItemDto.Description, createItemDto.Price, DateTimeOffset.UtcNow);
            items.Add(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public ActionResult<ItemDto> Put(Guid id, UpdateItemDto updateItemDto)
        {
            int targetItemIndex = items.FindIndex(s => s.Id == id);
            if (targetItemIndex == -1)
            {
                return NotFound();
            }

            var newItem = new ItemDto
            (
                id,
                updateItemDto.Name,
                updateItemDto.Description,
                updateItemDto.Price,
                items[targetItemIndex].CreateDate
            );
            items[targetItemIndex] = newItem;
            return NoContent();
        }

        [HttpDelete]
        public ActionResult<ItemDto> Delete(Guid id)
        {
            int targetItemIndex = items.FindIndex(s => s.Id == id);
            if (targetItemIndex == -1)
            {
                return NotFound();
            }

            items.RemoveAt(targetItemIndex);
            return NoContent();
        }
    }
}