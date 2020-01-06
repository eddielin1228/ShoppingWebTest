using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Domain
{
    public class OrderDetailModel
    {
        /// <summary>
        /// 訂單ID
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// 數量
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 單價
        /// </summary>
        public int Price { get; set; }


    }
}
