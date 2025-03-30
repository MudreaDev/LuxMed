using LuxMed.BusinessLogic.Core;
using LuxMed.BusinessLogic.Interfaces;
using LuxMed.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxMed.BusinesLogic
{
    class ProductBL : UserApi, IProduct
    {
        public ProductDetail GetDetailProduct(int id)
        {
            return GetProdUser(id);
        }
    }
}