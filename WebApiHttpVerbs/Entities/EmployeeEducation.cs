using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiHttpVerbs.Entities
{
    public partial class EmployeeEducation
    {
       
        public int Id { get; set; }
        public string? CourseName { get; set; } = null!;
        public string? UniName { get; set; } = null!;
        public int MarksPercentage { get; set; }
        public int EmpId { get; set; }


    }
}
