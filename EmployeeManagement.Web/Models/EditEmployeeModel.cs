using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Models
{
    public class EditEmployeeModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [CompareProperty(nameof(Email), ErrorMessage = "Email and Confirm Email must match")]
        public string ConfirmEmail { get; set; }
        [Required]
        [Display(Name = "Birthday")]
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Photo { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
