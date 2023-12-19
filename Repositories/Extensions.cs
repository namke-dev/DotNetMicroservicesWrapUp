using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Play.Catalog.Service.Entities;
using Play.Catalog.Service.Setting;

namespace Play.Catalog.Service.Repositories
{
    public static class Extensions
    {
        public static IServiceCollection AddMongoDbSetting(this IServiceCollection serviceCollection)
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

            serviceCollection.AddSingleton(serviceCollection =>
            {
                var configuration = serviceCollection.GetService<IConfiguration>();
                
                var serviceSettings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
                var mongoDbSettings = configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
                var mongoDbClient = new MongoClient(mongoDbSettings.ConnectionString);
                return mongoDbClient.GetDatabase(serviceSettings.ServiceName);
            });

            return serviceCollection;
        }

        public static IServiceCollection AddMongoRepository<T>(this IServiceCollection serviceCollection, string collectionName)
        where T : IEntity
        {
            serviceCollection.AddSingleton<IRepository<T>>(serviceCollection =>
            {
                var database = serviceCollection.GetService<IMongoDatabase>();
                return new MongoRepository<T>(database, collectionName);
            });

            return serviceCollection;
        }

    }
}