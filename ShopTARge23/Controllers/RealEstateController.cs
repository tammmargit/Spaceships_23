using Microsoft.AspNetCore.Mvc;
using ShopTARge23.ApplicationServices.Services;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Data;
using ShopTARge23.Models.RealEstates;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Models.RealEstates;

namespace ShopTARge23.Controllers
{
    public class RealEstatesController : Controller
    {
        private readonly ShopTARge23Context _context;
        private readonly IRealEstateServices _realEstateServices;
        public RealEstatesController
            (
            ShopTARge23Context context,
            IRealEstateServices realEstatesServices
            )
        {
            _context = context;
            _realEstateServices = realEstatesServices;
        }
        public IActionResult Index()
        {

            var result = _context.RealEstates
                .Select(x => new Models.RealEstates.RealEstateIndexViewModel
                {
                    Id = x.Id,
                    Size = x.Size,
                    Location = x.Location,
                    RoomNumber = x.RoomNumber,
                    BuildingType = x.BuildingType,
                });
            return View(result);
        }
    }
}
