using DGS.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.Repository
{
    public interface IDashboardRepository
    {
        Task<List<Chart>> GetChart();
        Task<DashboardTotal> GetDashboardTotal();
    }
}
