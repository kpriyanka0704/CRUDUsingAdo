﻿using System.ComponentModel.DataAnnotations;

namespace CRUDUsingAdo.Models
{
    public class Product
    {
        [Key] // to define Id is a PK in the DB table
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public int Price { get; set; }

    }
}
