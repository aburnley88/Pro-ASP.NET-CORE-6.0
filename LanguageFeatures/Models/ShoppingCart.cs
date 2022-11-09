

namespace LanguageFeatures.Models
{
    public class ShoppingCart : IproductSelection
    {

         private List<Product> products = new();

        public ShoppingCart(params Product[] prods) {
            products.AddRange(prods);
        }

        public IEnumerable<Product>? Products {get => products; }
        // public IEnumerable<Product?>? Products { get; set; }
        
        // public IEnumerator<Product?> GetEnumerator()=> Products?.GetEnumerator()
        //     ?? Enumerable.Empty<Product?>().GetEnumerator();
        
        // IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}