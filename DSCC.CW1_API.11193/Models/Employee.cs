using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DSCC.CW1_API._11193.Models
{
    public class Employee
    {
        [Required]
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public decimal Salary { get; set; }

        [Required]
        [ForeignKey(nameof(Department))]
        public int EmployeeDepartmentId { get; set; }

        public virtual Department EmployeeDepartment { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
