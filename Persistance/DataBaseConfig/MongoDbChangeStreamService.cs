using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Persistance.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.DataBaseConfig;
     public class MongoDbChangeStreamService : IMongoDbChangeStreamService
{
         private IMongoCollection<BsonDocument> _collection;
        private readonly ILogger<MongoDbChangeStreamService> _logger;
         public MongoDbChangeStreamService(ILogger<MongoDbChangeStreamService> logger) 
         { 
            
            _logger = logger;
         }

        public void InitiateStreamService(string connection,string databaseName,string collectionName)
        {
            var client = new MongoClient(connection);
            var database = client.GetDatabase(databaseName);

            _collection = database.GetCollection<BsonDocument>(collectionName);
        }
         
        public void StartListening()
        {
           var pipeline = new EmptyPipelineDefinition<ChangeStreamDocument<BsonDocument>>()
                         .Match(change => change.OperationType == ChangeStreamOperationType.Insert);

          using var changeStream = _collection.Watch(pipeline);

        foreach (var change in changeStream.ToEnumerable()) 
        {
            _logger.LogInformation($"Inserted Document Id : {change.FullDocument["_id"]}");
        }
        }
    }

