using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Football.API.Common.Models;

namespace Football.API.DataAccess.Contracts
{
    public interface IManagerRepository : IRepositoryBase<ManagerResponse>
    {
        Task<IEnumerable<ManagerResponse>> GetAllAsync();
        Task<ManagerResponse> GetByIdAsync(int id);
    }
}
