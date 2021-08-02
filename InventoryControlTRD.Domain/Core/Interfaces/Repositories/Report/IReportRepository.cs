using InventoryControlTRD.Domain.Models;
using System;
using System.Collections.Generic;

namespace InventoryControlTRD.Domain.Core.Interfaces.Repositories
{
    public interface IReportRepository
    {
        IEnumerable<Report> GetRequestReport(DateTime startDate, DateTime finalDate);
        IEnumerable<Report> GetInventoryOutReport(DateTime startDate, DateTime finalDate);
    }
}
