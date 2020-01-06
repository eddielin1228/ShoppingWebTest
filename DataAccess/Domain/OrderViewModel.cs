using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Domain
{
    public class OrderViewModel
    {
        /// <summary>
        /// 訂單ID
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 訂單總金額
        /// </summary>
        public int TotalPrice { get; set; }
        /// <summary>
        /// 購買人
        /// </summary>
        public string OrderUser { get; set; }
        /// <summary>
        /// 訂購日期
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 訂單明細
        /// </summary>
        public List<OrderDetailModel> OrderItems { get; set; }
    }
}
