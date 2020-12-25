using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required][EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Birthday")]
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Photo { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
