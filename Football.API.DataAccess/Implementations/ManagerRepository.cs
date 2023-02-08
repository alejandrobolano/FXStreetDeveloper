using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football.API.Common.Models;
using Football.API.DataAccess.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Football.API.DataAccess.Implementations
{
    public class ManagerRepository: RepositoryBase<ManagerResponse>, IManagerRepository
    {
        public ManagerRepository(FootballContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<ManagerResponse>> GetAllAsync() => await GetAll().OrderBy(manager => manager.Name).ToListAsync();

        public async Task<ManagerResponse> GetByIdAsync(int id) => await FindByCondition(manager => manager.Id.Equals(id)).FirstOrDefaultAsync();
    }
}
