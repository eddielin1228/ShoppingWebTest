namespace DataAccess.ShoppingWebDataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductMain")]
    public partial class ProductMain
    {
        [Key]
        [StringLength(50)]
        public string ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public bool CanSale { get; set; }

        [StringLength(100)]
        public string Address { get; set; }
    }
}
