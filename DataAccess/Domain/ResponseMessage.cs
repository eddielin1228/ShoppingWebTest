using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Domain
{
    public class ResponseMessage
    {
        /// <summary>
        /// 回傳狀態
        /// </summary>
        public bool success { get; set; }
        /// <summary>
        /// 回傳訊息
        /// </summary>
        public string Message { get; set; }
    }
}
