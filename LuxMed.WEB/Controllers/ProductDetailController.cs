using System.Web.Mvc;
using LuxMed.BusinessLogic.Interfaces;
using LuxMed.BusinessLogic;
using LuxMed.Domain.Entities.Product;
using LuxMed.BusinesLogic;
namespace LuxMed.Web.Controllers
{
    public class ProductDetailController : Controller
    {
        private IProduct _product;

        // GET: ProductDetail
        ProductDetailController()
        {
            BussinesLogic bussines1 = new BussinesLogic();
            _product = bussines1.GetProductBL();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetProduct(int id)
        {
            ProductDetail prodDetail = _product.GetDetailProduct(id);
            return View();
        }
    }
}