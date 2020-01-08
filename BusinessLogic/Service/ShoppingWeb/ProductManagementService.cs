using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using BusinessLogic.Base;
using BusinessLogic.Interface;
using DataAccess.Domain;
using DataAccess.SampleDataBase;
using DataAccess.ShoppingWebDataBase;
using Repository;

namespace BusinessLogic.Service.ShoppingWeb
{
    /// <summary>
    /// 商品管理功能服務
    /// </summary>
    public class ProductManagementService : ShoppingWebDataBase, IProductManagementService
    {
        /// <summary>
        /// ProductManagementService
        /// </summary>
        public ProductManagementService()
        {
            DbContext dbContext = new ShoppingWebContext();
            dbContext.Configuration.ProxyCreationEnabled = false;
            dbContext.Configuration.LazyLoadingEnabled = false;
            base.ProductMainRepository = new GenericRepository<ProductMain>(dbContext);
        }

        /// <summary>
        /// Repository DI
        /// </summary>
        /// <param name="productMainRepository"></param>
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
        public List<ProductViewModel> GetAllProduct()
        {
            var query = base.ProductMainRepository.FindAll().Select(x => new ProductViewModel
            {
                isBuy = false,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                Price = x.Price,
                CanSale = x.CanSale,
                Count = 0,
                Quantity = x.Quantity,
                Address = x.Address
            }).ToList();

            return query;
        }

        /// <summary>
        /// 取得單一商品資料
        /// </summary>
        /// <param name="productId">商品Id</param>
        /// <returns></returns>
        public ProductViewModel GetProductData(string productId)
        {
            var query = base.ProductMainRepository.Find(x => x.ProductId == productId);
            ProductViewModel data = new ProductViewModel()
            {
                ProductId = query.ProductId,
                ProductName = query.ProductName,
                Price = query.Price,
                CanSale = query.CanSale,
                Quantity = query.Quantity,
                Address = query.Address
            };
            return data;
        }
        /// <summary>
        /// 建立新資料
        /// </summary>
        /// <param name="model">商品資料</param>
        /// <returns></returns>
        public ResponseMessage CreateProduct(ProductViewModel model)
        {
            ResponseMessage result = new ResponseMessage()
            {
                success = true
            };
            try
            {
                if (model.FileUpload != null)
                {
                    result = CheckPicture(model);
                }

                if (result.success)
                {
                    ProductMain product = new ProductMain()
                    {
                        ProductName = model.ProductName,
                        ProductId = model.ProductId,
                        Price = model.Price,
                        Quantity = model.Quantity,
                        CanSale = model.CanSale,
                        Address = model.Address
                    };

                    result.success = base.ProductMainRepository.Add(product);
                    if (!result.success)
                    {
                        result.Message = "商品建立失敗";
                    }
                }
            }
            catch (Exception ex)
            {
                base.Log.Error(ex);
                base.Log.SendException("BusinessLogic.Service.ShoppingWeb.ProductManagementService.CreateProduct()",
                    ex);
            }
            return result;
        }

        /// <summary>
        /// 修改資料
        /// </summary>
        /// <param name="model">商品資料</param>
        /// <returns></returns>
        public ResponseMessage UpdateProduct(ProductViewModel model)
        {
            ResponseMessage result = new ResponseMessage()
            {
                success = true
            };
            try
            {
                if (model.FileUpload != null)
                {
                    result = CheckPicture(model);
                }
                var oldData = base.ProductMainRepository.Find(x => x.ProductId == model.ProductId);
                oldData.Price = model.Price;
                oldData.ProductName = model.ProductName;
                oldData.Quantity = model.Quantity;
                oldData.CanSale = model.CanSale;
                if (model.FileUpload != null)
                {
                    oldData.Address = model.Address;
                }
                result.success = base.ProductMainRepository.Update(oldData);
                if (!result.success)
                {
                    result.Message = "商品修改失敗";
                }
            }
            catch (Exception ex)
            {
                base.Log.Error(ex);
                base.Log.SendException("BusinessLogic.Service.ShoppingWeb.ProductManagementService.UpdateProduct()",
                    ex);
            }
            return result;
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="productId">商品ID</param>
        /// <returns></returns>
        public ResponseMessage DeleteProduct(string productId)
        {
            ResponseMessage result = new ResponseMessage()
            {
                success = true
            };
            try
            {
                var product = ProductMainRepository.Find(x => x.ProductId == productId);
                result.success = ProductMainRepository.Remove(product);
                if (!result.success)
                {
                    result.Message = "商品刪除失敗";
                }
            }
            catch (Exception ex)
            {
                base.Log.Error(ex);
                base.Log.SendException("BusinessLogic.Service.ShoppingWeb.OrderManagementService.DeleteProduct()", ex);
            }
            return result;
        }

        /// <summary>
        /// 檢查圖片
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private ResponseMessage CheckPicture(ProductViewModel model)
        {
            ResponseMessage result = new ResponseMessage()
            {
                success = true
            };
            //圖片結尾是否為gif|png|jpg|bmp
            if (!isPicture(model.FileUpload.FileName))
            {
                result.success = false;
                result.Message = "內容不為圖片";
            }
            //檔案是否為圖片
            if (IsImage(model.FileUpload) == null)
            {
                result.success = false;
                result.Message = "檔案不為圖片";
            }
            //大小>0byte
            if (model.FileUpload.ContentLength > 0)
            {
                //檔案名
                var fileName = model.ProductName + ".jpg";
                string pathString = "/FileUploads/" + model.ProductId;
                model.Address = pathString + "/" + fileName;
                //路徑
                var path = Path.Combine(HttpContext.Current.Server.MapPath(pathString));
                //路徑加檔案名
                var pathName = Path.Combine(HttpContext.Current.Server.MapPath(pathString), fileName);
                //資料夾不存在的話創一個
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //有此檔名的話把他刪了
                if (File.Exists(pathName))
                {
                    File.Delete(pathName);
                }
                Image photo = Image.FromStream(model.FileUpload.InputStream);
                photo.Save(pathName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }

            return result;
        }
        /// <summary>
        /// 判斷副檔名是否為圖片檔
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private bool isPicture(string fileName)
        {
            string extensionName = fileName.Substring(fileName.LastIndexOf('.') + 1);
            var reg = new Regex("^(gif|png|jpg|bmp)$", RegexOptions.IgnoreCase);
            return reg.IsMatch(extensionName);
        }

        /// <summary>
        /// 判斷檔案是否為圖片
        /// </summary>
        /// <param name="photofile"></param>
        /// <returns></returns>
        private Image IsImage(HttpPostedFileBase photofile)
        {
            try
            {
                Image img = Image.FromStream(photofile.InputStream);
                return img;
            }
            catch
            {
                return null;
            }
        }
    }
}
