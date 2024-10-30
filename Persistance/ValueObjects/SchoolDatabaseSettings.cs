using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.ValueObjects;
     public class SchoolDatabaseSettings
    {
       public required string StudentCollectionName { get; set; }
       public required string CoursesCollectionName { get; set; }
       public required string ConnectionString { get; set; }
       public required string DatabaseName { get; set; }
    }

