using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuxMed.Domain.Entities.Product;

namespace LuxMed.BusinessLogic.Interfaces
{
    public interface IProduct
    {
        ProductDetail GetDetailProduct(int id);
    }
}