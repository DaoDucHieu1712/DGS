using DGS.BusinessObjects;
using DGS.BusinessObjects.Enums;
using DGS.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.Repository.Impls
{
    public class DashboardRepository : IDashboardRepository
    {

        private readonly ApplicationDbContext _context;

        public DashboardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Chart>> GetChart()
        {
            var charts = await _context.Orders.
                Where(x => x.Status == OrderStatus.Complete)
                .Select(o =>
                    new
                    {
                        Id = o.Id,
                        Month = o.CreatedAt.Month,
                        Year = o.CreatedAt.Year,
                        TotalPrice = o.TotalPrice,
                    }).GroupBy(x => new
                    {
                        x.Year,
                        x.Month,
                    }).Select(x => new Chart()
                    {
                        Year = x.Key.Year,
                        Month = x.Key.Month,
                        TotalPrice = (decimal)x.Sum(x => x.TotalPrice)
                    })
                    .Where(x => x.Year == DateTime.Now.Year)
                    .OrderBy(x => x.Year).ThenBy(x => x.Month).ToListAsync();
            return charts;
        }

        public async Task<DashboardTotal> GetDashboardTotal()
        {
            var dashboardTotal = new DashboardTotal();
            dashboardTotal.Products = _context.Products.Count();
            dashboardTotal.Orders = _context.Orders.Count();
            dashboardTotal.Categories = _context.Categories.Count();  
            dashboardTotal.Users = _context.Users.Count();
            return dashboardTotal;
        }
    }
}
