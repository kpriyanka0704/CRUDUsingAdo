using System.ComponentModel.DataAnnotations;

namespace CRUDUsingAdo.Models
{
    public class Student
    {
        [Key] // to define Id is a PK in the DB table
        [ScaffoldColumn(false)]
        public int RollNo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Branch { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Percentage { get; set; }
        
    }
}
