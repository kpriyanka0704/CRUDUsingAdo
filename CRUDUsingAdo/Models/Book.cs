using System.ComponentModel.DataAnnotations;

namespace CRUDUsingAdo.Models
{
    public class Book
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public string Authorname { get; set; }
        [Required]
        public int Price { get; set; }

    }
}
