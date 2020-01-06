using DataAccess.ShoppingWebDataBase;

namespace Repository.ShoppingWebRepository
{
    /// <summary>
    /// 商品清單
    /// </summary>
    public interface IProductManiRepository : IRepository<ProductMain>
    {
        
    }
    /// <summary>
    /// 訂單主檔
    /// </summary>
    public interface IOrderMainRepository : IRepository<OrderMain>
    {

    }
    /// <summary>
    /// 訂單明細
    /// </summary>
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {

    }
}