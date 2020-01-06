﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Domain
{
    public class ProductViewModel
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// 是否購買
        /// </summary>
        public bool isBuy { get; set; }
        /// <summary>
        /// 商品名稱
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 商品數量
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 商品價格
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// 購買數量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 是否上架
        /// </summary>
        public bool CanSale { get; set; }


    }
}
