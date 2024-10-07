using ShopTARge23.Data;
using ShopTARge23.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTARge23.Core.Domain;

namespace ShopTARge23.ApplicationServices.Services
{
    public class RealEstateServices : IRealEstateServices
    {
        private readonly ShopTARge23Context _context;

        public RealEstateServices
            (
            ShopTARge23Context context
            )
        {
            _context = context;
        }
    }
}
