using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Interfaces;
    public interface IAdminstrationService
    {
     public void OnNewStudentAdded(object sender,OnNewStudentAddedEventArgs args);
     public void SubscribeToNewStudentEvent(IStudentService studentService);
     public void UnsubscribeToNewStudentEvent(IStudentService studentService);
    }

