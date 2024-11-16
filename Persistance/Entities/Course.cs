using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Entities;
     public class Course
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
         public required string Code { get; set; }
    }

