using System;
using System.ComponentModel.DataAnnotations;

namespace TwoHr.Employees
{
    public class EmployeeCreateUpdateDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public bool Active { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Salary { get; set; }
    }
}
