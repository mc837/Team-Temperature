using CuttingEdge.Conditions;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Repository
{
    public class MongoProvider : IMongoProvider
    {
        private readonly MongoDatabase _database;
        private string _collectionName;

        public MongoProvider(MongoDatabase database)
        {
            _database = database;
        }

        public IMongoProvider ForCollection(string collectionName)
        {
            _collectionName = collectionName;
            return this;
        }

        public bool Insert<T>(T model)
        {
            Condition.Requires(_collectionName).IsNotNullOrEmpty();
            WriteConcernResult status = _database.GetCollection<T>(_collectionName).Insert(model);
            return status.DocumentsAffected > 0;
        }

    }
}