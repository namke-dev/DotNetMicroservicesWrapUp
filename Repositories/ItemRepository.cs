using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Play.Catalog.Service.Entities;

namespace Play.Catalog.Service.Repositories
{
    public class ItemsRepository : IItemsRepository
    {
        private const string colectionName = "items";
        private readonly IMongoCollection<Item> dbCollection;
        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;
        public ItemsRepository(IMongoDatabase mongoDatabase)
        {
            // var mongoClient = new MongoClient("mongodb://localhost:27017");
            // var database = mongoClient.GetDatabase("Catalog");
            dbCollection = mongoDatabase.GetCollection<Item>(colectionName);
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

        public async Task CreateAsync(Item item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            await dbCollection.InsertOneAsync(item);
        }

        public async Task UpdateAsync(Item item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var filter = filterBuilder.Eq(i => i.Id, item.Id);
            await dbCollection.ReplaceOneAsync(filter, item);
        }

        public async Task DeleteAsync(Guid id)
        {
            var filter = filterBuilder.Eq(i => i.Id, id);
            await dbCollection.DeleteOneAsync(filter);
        }
    }
}