using API.Models;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class CoffeeShopService: ICoffeeShopServices
    {
        private readonly ApplicationDbContext _context;

        public CoffeeShopService(ApplicationDbContext context) { 
            _context = context;
        }

        public async Task<List<CoffeeShopModel>> List()
        {
            var coffeeShops = await (from shop in _context.CoffeeShops
                                     select new CoffeeShopModel() { 
                                        Id = shop.Id,
                                        Name= shop.Name,
                                        OpeningHours= shop.OpeningHours,
                                        Address= shop.Address
                                     }).ToListAsync();


            return coffeeShops;
        }
    }
}
