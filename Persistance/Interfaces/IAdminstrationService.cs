using Persistance.Entities;


namespace Persistance.Interfaces;
    public interface IAdminstrationService
    {
     void OnNewStudentAdded(Object sender, OnNewStudentAddedArgs newStudent);
     void SubscribeToEvent(IStudentService studentService);
    void UnsbscribeFromEvent(IStudentService studentService);
    
     }

