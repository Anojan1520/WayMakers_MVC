﻿using System.ComponentModel.DataAnnotations;

namespace ECommerce.Web.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; } = 0;
        public string Image {  get; set; } = string.Empty;
       
    }
}
