using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Interfaces;
     public interface ICourseService
    {
      Task<Course?> Create(Course course);
      Task<Course?> GetById(string id);

    }

