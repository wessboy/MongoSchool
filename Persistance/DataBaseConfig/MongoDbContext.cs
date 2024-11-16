using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Persistance.Entities;


namespace Persistance.DataBaseConfig
{
     public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IMongoDatabase database) 
        { 
           _database = database;

            MappStudent();
        }


        private static void MappStudent()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Student)))
            {


                BsonClassMap.RegisterClassMap<Student>(cm =>
                {
                    cm.AutoMap();
                    cm.MapIdMember(st => st.Id).SetSerializer(new ObjectIdStringSerializer());
                    cm.MapField(st => st.FirstName).SetIsRequired(true);
                    cm.MapField(st => st.LastName).SetIsRequired(true);
                    cm.MapField(st => st.Major);


                });
            }
        }
        public IMongoCollection<T> setCollection<T>(string collectionName) 
        { 
           var collection = _database.GetCollection<T>(collectionName);

            return collection;
        }
    }
}
