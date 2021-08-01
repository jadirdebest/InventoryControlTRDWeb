using InventoryControlTRD.Domain.Core.Interfaces.Repositories;
using InventoryControlTRD.Domain.Core.Interfaces.Services;
using InventoryControlTRD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.Domain.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _repo;

        public ReportService(IReportRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Report> GetRequestReport(DateTime startDate, DateTime finalDate)
        {
            if (startDate.CompareTo(finalDate) > 1) throw new Exception("");
            return _repo.GetRequestReport(startDate, finalDate);
        }

        public IEnumerable<Report> InventoryOutReport(DateTime startDate, DateTime finalDate)
        {
            if (startDate.CompareTo(finalDate) > 1) throw new Exception("");
            return _repo.GetRequestReport(startDate, finalDate);
        }
    }
}
