using InventoryControlTRDWeb.Application.Dto;
using System;
using System.Collections.Generic;

namespace InventoryControlTRDWeb.Application.Interface
{
    public interface IAppReportService
    {
        IEnumerable<RequestReportDto> GetRequestReport(DateTime startDate, DateTime finalDate);
        IEnumerable<InventoryOutReportDto> GetInventoryOutReport(DateTime startDate, DateTime finalDate);
    }
}
