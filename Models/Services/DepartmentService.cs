using SalesWebMVC.Models.Entities;
using SalesWebMVC.Data;

namespace SalesWebMVC.Models.Services
{
    public class DepartmentService
    {
        private readonly SalesWebContext _context;

        public DepartmentService(SalesWebContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Departments.OrderBy(d=>d.Name).ToList();
        }
    }
}
