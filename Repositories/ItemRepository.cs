
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MongoDB.Driver;
using Play.Catalog.Service.Dtos;
using Play.Catalog.Service.Entities;

namespace Play.Catalog.Service.Repositories
{
    public class ItemRepository
    {
        private const string colectionName = "items";
        private readonly IMongoCollection<Item> dbCollection;

        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;
        public ItemRepository()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("Catalog");
            dbCollection = database.GetCollection<Item>(colectionName);
        }

        public async Task<IReadOnlyCollection<Item>> GetAllAsync()
        {
            return await dbCollection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<Item> GetAsync(Guid id)
        {
            var filter = filterBuilder.Eq(i => i.Id, id);
            return await dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task Create(Item item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            await dbCollection.InsertOneAsync(item);
        }

        public async Task Update(Item item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var filter = filterBuilder.Eq(i => i.Id, item.Id);
            await dbCollection.ReplaceOneAsync(filter, item);
        }

        public async Task RemoveAsync(Guid id)
        {
            var filter = filterBuilder.Eq(i => i.Id, id);
            await dbCollection.DeleteOneAsync(filter);
        }
    }
}