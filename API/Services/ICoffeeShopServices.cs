using API.Models;

namespace API.Services
{
    public interface ICoffeeShopServices
    {
        Task<List<CoffeeShopModel>> List();
    }
}
