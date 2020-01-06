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
    /// 功能服務(範例)
    /// </summary>
    public class ProductManagementService : ShoppingWebDataBase, IProductManagementService
    {
        /// <summary>
        /// SampleService
        /// </summary>

        protected readonly DbContext _dbContext;


        public ProductManagementService()
        {
            _dbContext = new ShoppingWebContext();
            _dbContext.Configuration.ProxyCreationEnabled = false;
            _dbContext.Configuration.LazyLoadingEnabled = false;
            base.ProductMainRepository = new GenericRepository<ProductMain>(_dbContext);
        }

        /// <summary>
        /// Repository DI
        /// </summary>
        /// <param name="accountRepository">AccountRepository</param>
        public ProductManagementService(IRepository<ProductMain> productMainRepository)
        {
            base.ProductMainRepository = productMainRepository;

            if (productMainRepository == null)
            {
                throw new Exception($"AccountRepository is null");
            }
        }

        /// <summary>
        /// 取得全部資料
        /// </summary>
        /// <returns></returns>
        public List<ProductViewModel> GetAll()
        {
            return base.ProductMainRepository.FindAll().Select(x=>new ProductViewModel {
                isBuy = false,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                Price = x.Price,
                CanSale = x.CanSale,
                Count = 0,
                Quantity = x.Quantity
            }).ToList();
        }
        public ProductViewModel Get(ProductViewModel model)
        {
            var query =  base.ProductMainRepository.Find(x => x.ProductId== model.ProductId);
            ProductViewModel data = new ProductViewModel()
            {
                ProductId = query.ProductId,
                ProductName = query.ProductName,
                Price = query.Price,
                CanSale = query.CanSale,
                Quantity = query.Quantity
            };
            return data;
        }
        /// <summary>
        /// 建立新資料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ResponseMessage Create(ProductViewModel model)
        {
            ResponseMessage result = new ResponseMessage();
            ProductMain product = new ProductMain() {
                ProductName = model.ProductName,
                ProductId = model.ProductId,
                Price = model.Price,
                Quantity = model.Quantity,
                CanSale = model.CanSale
            };

            result.success = base.ProductMainRepository.Add(product);


            return result;
        }

        /// <summary>
        /// 修改資料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ResponseMessage Update(ProductViewModel model)
        {
            ResponseMessage result = new ResponseMessage();
            var oldData = base.ProductMainRepository.Find(x=>x.ProductId==model.ProductId);
            oldData.Price = model.Price;
            oldData.ProductName = model.ProductName;
            oldData.Quantity = model.Quantity;
            oldData.CanSale = model.CanSale;
            result.success = base.ProductMainRepository.Update(oldData);
            return result;
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ResponseMessage Delete(ProductViewModel model)
        {
            ResponseMessage result = new ResponseMessage();
            var oldData = base.ProductMainRepository.Find(x => x.ProductId == model.ProductId);
            result.success = base.ProductMainRepository.Remove(oldData);
            return result;
        }
    }
}
