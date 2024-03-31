using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using InventroyManagement.Models; // Check and adjust the namespace as per your project structure


namespace InventroyManagement.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [StringLength(100)]
        public String ProductName { get; set; }
        [StringLength(200)]
        public String Description { get; set; }

    }
}
