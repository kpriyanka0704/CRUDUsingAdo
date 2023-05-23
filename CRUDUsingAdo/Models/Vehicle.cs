using System.ComponentModel.DataAnnotations;

namespace CRUDUsingAdo.Models
{
    public class Vehicle
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int Price { get; set;}
    }
}

