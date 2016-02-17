using Models;
using MongoDB.Driver;

namespace Repository
{
    public interface IMongoProvider
    {
        IMongoProvider ForCollection(string collectionName);
        bool Insert<T>(T model);
        bool Update<T>(T user);
    }
}
