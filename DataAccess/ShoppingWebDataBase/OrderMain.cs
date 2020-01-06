namespace DataAccess.ShoppingWebDataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderMain")]
    public partial class OrderMain
    {
        [Key]
        [StringLength(50)]
        public string OrderId { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderUser { get; set; }

        public int TotalPrice { get; set; }

        public DateTime CreateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string CreateUser { get; set; }

        public DateTime? UpdateTime { get; set; }

        [StringLength(50)]
        public string UpdateUser { get; set; }
    }
}
