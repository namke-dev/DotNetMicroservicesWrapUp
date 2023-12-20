using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Play.Common;

namespace Play.Catalog.Service.Entities
{
    public class Item : IEntity
    {
        // Guid Id, string Name, string Description, decimal Price, DateTimeOffset CreateDate
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset CreateDate { get; set; }
    }
}