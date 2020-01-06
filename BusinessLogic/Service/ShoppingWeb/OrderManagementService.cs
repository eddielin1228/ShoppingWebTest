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
        /// SampleService
        /// </summary>

        protected readonly DbContext _dbContext;


        public OrderManagementService()
        {
            _dbContext = new ShoppingWebContext();
            _dbContext.Configuration.ProxyCreationEnabled = false;
            _dbContext.Configuration.LazyLoadingEnabled = false;
            base.OrderMainRepository = new GenericRepository<OrderMain>(_dbContext);
            base.OrderDetailRepository = new GenericRepository<OrderDetail>(_dbContext);

        }

        /// <summary>
        /// Repository DI
        /// </summary>
        /// <param name="accountRepository">AccountRepository</param>
        public OrderManagementService(IRepository<OrderMain> orderMainRepository, IRepository<OrderDetail> orderDetailRepository)
        {
            base.OrderMainRepository = orderMainRepository;
            base.OrderDetailRepository = orderDetailRepository;

        }

        /// <summary>
        /// 取得全部資料
        /// </summary>
        /// <returns></returns>
        public List<OrderViewModel> GetAll()
        {
            return base.OrderMainRepository.FindAll().Select(x => new OrderViewModel
            {
                OrderId = x.OrderId,
                OrderUser = x.OrderUser,
                TotalPrice = x.TotalPrice,
                CreateTime = x.CreateTime,
                orderItems = GetOrderDetailList(x.OrderId)
            }).ToList();
        }
        /// <summary>
        /// 取得單一訂單
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public OrderViewModel Get(OrderViewModel model)
        {

            var query = base.OrderMainRepository.Find(x => x.OrderId == model.OrderId);

            OrderViewModel orderViewModel = new OrderViewModel()
            {
                OrderId = query.OrderId,
                OrderUser = query.OrderUser,
                TotalPrice = query.TotalPrice,
                CreateTime = query.CreateTime,
                orderItems = GetOrderDetailList(model.OrderId)
            };

            return orderViewModel;
        }
        /// <summary>
        /// 取得訂單明細
        /// </summary>
        /// <param name="orderId"></param>
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
                    Quantity = x.Quantity,
                    Price = x.Price,
                };
                orderDetailModels.Add(order);
            });
            return orderDetailModels;
        }


        /// <summary>
        /// 建立新資料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ResponseMessage Create(OrderViewModel model)
        {
            ResponseMessage result = new ResponseMessage();

            OrderMain orderMain = new OrderMain()
            {
                OrderId = model.OrderId,
                TotalPrice = model.TotalPrice,
                OrderUser = model.OrderUser,
                CreateTime = DateTime.Now,
                CreateUser = model.OrderUser
            };


            result.success = base.OrderMainRepository.Add(orderMain);
            if (result.success)
            {
                model.orderItems.ForEach(x =>
                {
                    OrderDetail orderDetail = new OrderDetail
                    {
                        OrderId = model.OrderId,
                        ProductId = x.ProductId,
                        Quantity = x.Quantity,
                        Price = x.Price,
                        CreateTime = DateTime.Now,
                        CreateUser = model.OrderUser
                    };
                    base.OrderDetailRepository.Add(orderDetail);
                });
            }

            return result;
        }

        /// <summary>
        /// 修改資料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ResponseMessage Update(OrderViewModel model)
        {
            throw new Exception();
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ResponseMessage Delete(OrderViewModel model)
        {
            throw new Exception();
        }
    }
}
