using System;
using System.Collections.Generic;
using System.Linq;
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
        public ItemDto GetById(Guid id)
        {
            var item = items.Where(i => i.Id == id).SingleOrDefault();
            return item;
        }
    }
}