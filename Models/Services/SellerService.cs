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
        public Seller Find(int? id)
        {
            return _context.Sellers.Find(id);
        }
        public void Insert(Seller newSeller)
        {
            _context.Sellers.Add(newSeller);
            _context.SaveChanges();
        }
        public void Remove(int? Id)
        {
            var seller = _context.Sellers.Find(Id);
            _context.Sellers.Remove(seller);
            _context.SaveChanges();
        }
    }
}
