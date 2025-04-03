using LuxMed.BusinessLogic.Core;
using LuxMed.BusinessLogic.Interfaces;
using LuxMed.Domain.Entities.Product;
using LuxMed.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuxMed.Domain.Entities.User.Global;

namespace LuxMed.BusinessLogic
{
    class ProductBL : UserApi, IProduct
    {
        public ProductDetail GetDetailProduct(int id)
        {
            return GetProdUser(id);
        }

        private ProductDetail GetProdUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
