using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Persistance.Entities;
using Persistance.Interfaces;
using Persistance.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories;
     public class CourseRepository : ICourseService
    {
        private readonly IMongoCollection<Course> _courseCollection;    
        public CourseRepository(IOptions<SchoolDatabaseSettings> schoolDatabaseSettings,IMongoClient client)
        {
            var database = client.GetDatabase(schoolDatabaseSettings.Value.DatabaseName);
            _courseCollection = database.GetCollection<Course>(schoolDatabaseSettings.Value.CoursesCollectionName);
        }

    public async Task<Course?> Create(Course course)
    {
        course.Id = ObjectId.GenerateNewId().ToString();
        await _courseCollection.InsertOneAsync(course);

        return course;
    }

    public async Task<Course?> GetById(string id)
    {
        return await _courseCollection.Find(c => c.Id == id).FirstOrDefaultAsync();   
    }
}

