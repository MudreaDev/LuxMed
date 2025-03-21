using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuxMed.WEB.Domain.Entities.Product;

namespace LuxMed.WEB.BusinessLogic.Interfaces
{
    public interface IProduct
    {
        ProductDetail GetDetailProduct(int id);
    }
}