using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Persistance.Entities;
using Persistance.Interfaces;
using Persistance.ValueObjects;


namespace Persistance.Repositories;
     public class StudentRepository : IStudentService
    {
    private readonly IMongoCollection<Student> _studentCollection;
        public StudentRepository(IOptions<SchoolDatabaseSettings> schoolDatabaseSettings,IMongoClient client)
        {
          var database = client.GetDatabase(schoolDatabaseSettings.Value.DatabaseName);
        _studentCollection = database.GetCollection<Student>(schoolDatabaseSettings.Value.StudentCollectionName);
        }

    public async Task<Student?> Create(Student student)
    {
       student.Id = ObjectId.GenerateNewId().ToString();
        await _studentCollection.InsertOneAsync(student);   

        return student;
    }

    public async Task<DeleteResult> Delete(string id)
    {
        return await _studentCollection.DeleteOneAsync(s => s.Id == id);
    }

    public async Task<List<Student>> GetAll()
    {
        return await _studentCollection.Find(s => true).ToListAsync();
    }

    public async Task<Student?> GetById(string id)
    {
        return await _studentCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Student?> GetByName(string firstName,string lastName)
    {
        return await _studentCollection.Find(s => s.FirstName == firstName && s.LastName == lastName).FirstOrDefaultAsync();   
    }

    public async Task<ReplaceOneResult> Update(string id, Student student)
    {
        student.Id = id;

        return await _studentCollection.ReplaceOneAsync(s => s.Id == id, student);
    }
}

