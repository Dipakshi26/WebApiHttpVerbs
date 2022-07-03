using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebApiHttpVerbs.Entities
{
    
    public class EmployeeInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        public  int EmpId { get; set; }
        public string? EmployeeName { get; set; }  = null!;
        public int EmployeeAge { get; set; } 
        public string? EmployeeAddress { get; set; } = null!;



    }
}
