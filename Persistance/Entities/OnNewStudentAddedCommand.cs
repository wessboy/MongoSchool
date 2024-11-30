using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Entities;
    public record OnNewStudentAddedCommand(string FirstName, string LastName, string Major) : IRequest;
    
       
        
           
     
    

