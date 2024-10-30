using MongoDB.Driver;
using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Interfaces;
     public interface IStudentService
    {
      Task<Student?> Create(Student student);
     Task<DeleteResult> Delete(string id);
      Task<List<Student>> GetAll(); 
      Task<Student?> GetById(string id);
      Task<Student?> GetByName(string firstName, string lastName);
      Task<ReplaceOneResult> Update(string id,Student student);
    }

