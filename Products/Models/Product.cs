using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Products.Models
{
   [Table("Product")]
   public class Product
   {
      [Key]
      public int Id { get; set; }
      [Required]
      public string Name { get; set; }
      [Required]
      public DateTime ArrivalDate { get; set; }
      [Required]
      public int Count { get; set; }
      [Required]
      public decimal Price { get; set; }
      [Required]
      public bool IsPromo { get; set; }
   }
}