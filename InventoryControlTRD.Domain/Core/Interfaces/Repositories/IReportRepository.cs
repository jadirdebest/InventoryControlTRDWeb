using InventoryControlTRD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.Domain.Core.Interfaces.Repositories
{
    public interface IReportRepository
    {
        IEnumerable<Report> GetRequestReport(DateTime startDate, DateTime finalDate);
        IEnumerable<Report> InventoryOutReport(DateTime startDate, DateTime finalDate);
    }
}
