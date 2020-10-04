using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasmCrud.Models
{
    public class Employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId
        {
            get;
            set;
        }
        [Required]
        [StringLength(50, ErrorMessage = "First name is too long.")]
        public string FirstName
        {
            get;
            set;
        }
        [Required]
        [StringLength(50, ErrorMessage = "Last name is too long.")]
        public string LastName
        {
            get;
            set;
        }
        [Required]
        [EmailAddress]
        public string Email
        {
            get;
            set;
        }
        public string Street
        {
            get;
            set;
        }
        public string Zip
        {
            get;
            set;
        }
        public string City
        {
            get;
            set;
        }
        public string PhoneNumber
        {
            get;
            set;
        }
        [StringLength(1000, ErrorMessage = "Comment length can't exceed 1000 characters.")]
        public string Comment
        {
            get;
            set;
        }
    }
}
