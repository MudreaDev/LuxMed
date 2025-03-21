using BusinesLogic.Core;
using LuxMed.WEB.BusinessLogic.Interfaces;
using LuxMed.WEB.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxMed.WEB.BusinesLogic
{
    class ProductBL : UserApi, IProduct
    {
        public ProductDetail GetDetailProduct(int id)
        {
            return GetProdUser(id);
        }
    }
}
