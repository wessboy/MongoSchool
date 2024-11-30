using Microsoft.Extensions.DependencyInjection;
using Persistance.Entities;
using Persistance.Interfaces;

namespace Persistance.Repositories
{
    public class AdminstrationService : IAdminstrationService
    {
        
        public AdminstrationService()
        {
           
        }
        public void OnNewStudentAdded(OnNewStudentAddedCommand newStudent)
        {
            Console.WriteLine($"new Student with name : {newStudent.FirstName} {newStudent.LastName} , major : {newStudent.Major}");
        }

        
    }
}
