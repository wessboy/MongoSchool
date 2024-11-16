using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Entities;
     public class Student
    {
        public string? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Major {  get; set; }

       // [BsonRepresentation(BsonType.ObjectId)]
       // public List<string> Courses { get; set; }
       // [BsonIgnore]
        //public List<Course> CoursesList { get; set; }
    }
