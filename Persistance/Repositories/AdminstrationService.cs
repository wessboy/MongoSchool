using Microsoft.Extensions.DependencyInjection;
using Persistance.Entities;
using Persistance.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class AdminstrationService : IAdminstrationService
    {
        

        public AdminstrationService()
        {
           
        }
        public void OnNewStudentAdded(object sender, OnNewStudentAddedEventArgs args)
        {
            Console.WriteLine($"new Student with name : {args.FirstName} {args.LastName} , major : {args.Major}");
        }

        public void SubscribeToNewStudentEvent(IStudentService studentService)
        {


            studentService.OnNewStudentAddedHandler += OnNewStudentAdded!;

            Console.WriteLine("Subscribe to student Added event before handling the request");
        }

        public void UnsubscribeToNewStudentEvent(IStudentService studentService)
        {

            studentService.OnNewStudentAddedHandler -= OnNewStudentAdded!;

            Console.WriteLine("Unsbscribe from student Added event before handling the request");
        }

        
    }
}
