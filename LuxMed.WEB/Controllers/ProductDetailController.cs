using LuxMed.BusinesLogic;
using LuxMed.BusinessLogic.Interfaces;
using LuxMed.Domain.Entities.Product;
using System.Web.Mvc;

namespace LuxMed.WEB.Controllers
{
    public class ProductDetailController : Controller
    {
        private IProduct _product;

        // GET: ProductDetail
        ProductDetailController()
        {
            BussinesLogic bussinesl = new BussinesLogic();
            _product = bussinesl.GetProductBL();
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