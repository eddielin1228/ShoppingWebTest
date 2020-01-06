namespace DataAccess.ShoppingWebDataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string OrderId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string ProductId { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Quantity { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Price { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime CreateTime { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string CreateUser { get; set; }

        [Column(Order = 6)]
        public DateTime? UpdateTime { get; set; }

        [Column(Order = 7)]
        [StringLength(50)]
        public string UpdateUser { get; set; }
    }
}
