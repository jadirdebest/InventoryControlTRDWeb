using InventoryControlTRD.Domain.Core.Interfaces.Repositories;
using InventoryControlTRD.Domain.Models;
using InventoryControlTRD.Infrastructure.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.Infrastructure.Data.Repositories
{
    public class RequestRepository : IBaseRepository<Request>, IRequestRepository
    {
        private readonly IDataCore<Request> _data;

        public RequestRepository(IDataCore<Request> data)
        {
            _data = data;
        }

        public void AddAsync(Request obj)
        {
            throw new NotImplementedException();
        }

        public async Task<Request> AddWithReturnAsync(Request obj)
        {
            await _data.ExecuteAsync(@"insert into Request(Id,UserId,TotalCostPrice,TotalSalePrice,MovimentType,Date,CreatedOn) 
                                        values(@Id,@UserId,@TotalCostPrice,@TotalSalePrice,@MovimentType,@Date,sysdatetime())",obj);
            return obj;
        }

        public Task<IEnumerable<Request>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Request> GetByIdAsync(Guid? id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Request>> GetMovementsByDateAsync(DateTime startDate, DateTime finalDate)
        {
            return await _data.QueryAsync(@"select * from Request where Date between @StartDate and @FinalDate", new { StartDate = startDate, FinalDate = finalDate } );
        }

        public void RemoveAsync(Request obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(Request obj)
        {
            throw new NotImplementedException();
        }
    }
}
