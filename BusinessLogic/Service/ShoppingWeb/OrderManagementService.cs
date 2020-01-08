using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BusinessLogic.Base;
using BusinessLogic.Interface;
using DataAccess.Domain;
using DataAccess.SampleDataBase;
using DataAccess.ShoppingWebDataBase;
using Repository;

namespace BusinessLogic.Service.ShoppingWeb
{
    /// <summary>
    /// 訂單服務
    /// </summary>
    public class OrderManagementService : ShoppingWebDataBase, IOrderManagementService
    {
        /// <summary>
        /// OrderManagementService
        /// </summary>

        /// <summary>
        /// 初始化
        /// </summary>
        public OrderManagementService()
        {
            DbContext dbContext = new ShoppingWebContext();
            dbContext.Configuration.ProxyCreationEnabled = false;
            dbContext.Configuration.LazyLoadingEnabled = false;
            base.OrderMainRepository = new GenericRepository<OrderMain>(dbContext);
            base.OrderDetailRepository = new GenericRepository<OrderDetail>(dbContext);
            base.ProductMainRepository = new GenericRepository<ProductMain>(dbContext);
        }

        /// <summary>
        /// Repository DI
        /// </summary>
        /// <param name="orderMainRepository"></param>
        /// <param name="orderDetailRepository"></param>
        /// <param name="productRepository"></param>
        public OrderManagementService(IRepository<OrderMain> orderMainRepository, IRepository<OrderDetail> orderDetailRepository, IRepository<ProductMain> productRepository)
        {
            base.OrderMainRepository = orderMainRepository;
            base.OrderDetailRepository = orderDetailRepository;
            base.ProductMainRepository = productRepository;
        }
        /// <summary>
        /// 取得訂單明細
        /// </summary>
        /// <param name="orderId">訂單ID</param>
        /// <returns></returns>
        private List<OrderDetailModel> GetOrderDetailList(string orderId)
        {
            var detail = base.OrderDetailRepository.FindAll(x => x.OrderId == orderId).ToList();

            List<OrderDetailModel> orderDetailModels = new List<OrderDetailModel>();
            detail.ForEach(x =>
            {
                OrderDetailModel order = new OrderDetailModel()
                {
                    OrderId = x.OrderId,
                    ProductId = x.ProductId,
                    Count = x.Quantity,
                    Price = x.Price,
                };
                orderDetailModels.Add(order);
            });
            return orderDetailModels;
        }


        /// <summary>
        /// 建立新資料
        /// </summary>
        /// <param name="model">訂單資料</param>
        /// <returns></returns>
        public ResponseMessage CreateOrder(OrderViewModel model)
        {
            ResponseMessage result = new ResponseMessage()
            {
                success = true
            };
            try
            {
                model.OrderItems.ForEach(x =>
                {
                    var product = base.ProductMainRepository.Find(p => p.ProductId == x.ProductId);
                    if ((product.Quantity - x.Count) < 0)
                    {
                        result.success = false;
                        result.Message = "訂購數量大於庫存數量";
                    }
                });

                if (result.success)
                {
                    OrderMain orderMain = new OrderMain()
                    {
                        OrderId = model.OrderId,
                        TotalPrice = model.TotalPrice,
                        OrderUser = model.OrderUser,
                        CreateTime = DateTime.Now,
                        CreateUser = model.OrderUser
                    };

                    result.success = base.OrderMainRepository.Add(orderMain);
                    if (!result.success)
                    {
                        result.Message = "訂單成立失敗";
                    }
                }

                if (result.success)
                {
                    model.OrderItems.ForEach(x =>
                    {
                        var product = base.ProductMainRepository.Find(p => p.ProductId == x.ProductId);
                        product.Quantity -= x.Count;
                        OrderDetail orderDetail = new OrderDetail
                        {
                            OrderId = model.OrderId,
                            ProductId = x.ProductId,
                            Quantity = x.Count,
                            Price = x.Price,
                            CreateTime = DateTime.Now,
                            CreateUser = model.OrderUser
                        };
                        base.OrderDetailRepository.Add(orderDetail);
                        base.ProductMainRepository.Update(product);
                    });
                }
            }
            catch (Exception ex)
            {
                base.Log.Error(ex);
                base.Log.SendException("BusinessLogic.Service.ShoppingWeb.OrderManagementService.CreateOrder()",
                    ex);
            }

            return result;
        }
    }
}
