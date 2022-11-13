using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository _storeRepository;
        public int PageSize = 4;

        public HomeController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public ViewResult Index(string? category, int productPage = 1)
            => View(new ProductListViewModel
            {
                Products = _storeRepository.Products
                    .Where(p => category == null || p.ProductCategory == category)
                    .OrderBy(p => p.ProductID)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null
                            ? _storeRepository.Products.Count()
                            : _storeRepository.Products
                            .Where(p => p.ProductCategory == category).Count()
                },
                CurrentCategory = category
            });
    }
}
