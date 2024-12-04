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
        public void OnNewStudentAdded(Object sender,OnNewStudentAddedArgs newStudent)
        {
            Console.WriteLine($"new Student with name : {newStudent.FirstName} {newStudent.LastName} , major : {newStudent.Major}");
        }
         
        public void SubscribeToEvent(IStudentService studentService)
        {
            studentService.OnNewStudentAdded.AddEventHandler(OnNewStudentAdded!);
        }

        public void UnsbscribeFromEvent(IStudentService studentService)
        {
            studentService.OnNewStudentAdded.RemoveEventHandler(OnNewStudentAdded!);
        }
    }
}
