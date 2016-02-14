using MongoDB.Driver;

namespace Repository
{
    public interface IMongoProvider
    {
        IMongoProvider ForCollection(string collectionName);
        bool Insert<T>(T model);
    }
}
