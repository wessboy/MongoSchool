using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Entities
{
    public class OnNewStudentAddedEventArgs : EventArgs
    {
        public OnNewStudentAddedEventArgs(string firstName,string lastName,string major)
        {
            FirstName = firstName;
            LastName = lastName;
            Major = major;
            
        }
        public string FirstName { get;}
        public string LastName { get;}
        public string Major { get;}
    }
}
