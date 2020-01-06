using System.Collections.Generic;
using DataAccess.Domain;
using DataAccess.ShoppingWebDataBase;

namespace BusinessLogic.Service.ShoppingWeb
{
    public interface IProductManagementService
    {
        ResponseMessage Create(ProductViewModel model);
        ResponseMessage Delete(ProductViewModel model);
        ProductViewModel Get(ProductViewModel model);
        List<ProductViewModel> GetAll();
        ResponseMessage Update(ProductViewModel model);
    }
}