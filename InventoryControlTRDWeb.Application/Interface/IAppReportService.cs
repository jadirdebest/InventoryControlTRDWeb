using InventoryControlTRDWeb.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Application.Interface
{
    public interface IAppReportService
    {
        IEnumerable<RequestReportDto> GetRequestReport(DateTime startDate, DateTime finalDate);
        IEnumerable<InventoryOutReportDto> GetInventoryOutReport(DateTime startDate, DateTime finalDate);
    }
}
