

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        bool FilterByPrice(Product? p) {
            return (p?.Price ?? 0) >= 20;
        }
        public ViewResult Index() {
           IproductSelection cart = new ShoppingCart( 
           new Product {Name = "kayak", Price = 275M},
           new  Product {Name = "lifejacket", Price = 19.50M},  
           new  Product {Name = "soccer ball", Price = 34.95M}
           );
           
        return View(cart.Names);
        }
    }
}