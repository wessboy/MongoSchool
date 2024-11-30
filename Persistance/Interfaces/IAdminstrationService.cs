using Persistance.Entities;


namespace Persistance.Interfaces;
    public interface IAdminstrationService
    {
     public void OnNewStudentAdded(OnNewStudentAddedCommand newStudent);
   
    }

