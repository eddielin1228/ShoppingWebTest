using System.Data.Entity;
using DataAccess.Interface;
using DataAccess.ShoppingWebDataBase;

namespace Repository.ShoppingWebRepository
{
    /// <summary>
    /// 商品清單
    /// </summary>
    internal class ProductMainRepository : GenericRepository<ProductMain>, IProductManiRepository
    {

        public ProductMainRepository(DbContext factory) : base(factory)
        {
        }

    }
    /// <summary>
    /// 訂單主檔
    /// </summary>
    internal class OrderMainRepository : GenericRepository<OrderMain>
    {
        public OrderMainRepository(DbContext factory) : base(factory)
        {
        }
    }
    /// <summary>
    /// 訂單明細
    /// </summary>
    internal class OrderDetailRepository : GenericRepository<OrderDetail>
    {
        public OrderDetailRepository(DbContext factory) : base(factory)
        {
        }
    }
}