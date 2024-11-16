namespace Persistance.Interfaces;
     public interface IMongoDbChangeStreamService
    {
        public void InitiateStreamService(string connection, string databaseName, string collectionName);
        public void StartListening();
    }

