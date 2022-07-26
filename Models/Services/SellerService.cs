using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models.Entities;
using System.Linq;

namespace SalesWebMVC.Models.Services
{
    public class SellerService
    {
        private readonly SalesWebContext _context;

        public SellerService(SalesWebContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Sellers.ToList();
        }

    }
}
