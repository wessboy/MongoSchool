using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Interfaces;
     public interface IMongoDbChangeStreamService
    {
        public void InitiateStreamService(string connection, string databaseName, string collectionName);
        public void StartListening();
    }

