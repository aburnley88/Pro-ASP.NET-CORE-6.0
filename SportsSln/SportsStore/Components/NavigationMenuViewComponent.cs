using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Reflection.Metadata.Ecma335;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IStoreRepository _storeRepository;

        public NavigationMenuViewComponent(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(_storeRepository.Products
                .Select(p => p.ProductCategory)
                .Distinct()
                .OrderBy(p => p));
        }
    }
}
