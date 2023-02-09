using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Football.API.DataAccess.Contracts;

namespace Football.API.DataAccess.Implementations
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private readonly FootballContext _footballContext;
        private IManagerRepository _managerRepository;
        public IManagerRepository ManagerRepository
        {
            get { return _managerRepository ??= new ManagerRepository(_footballContext); }
        }
        public RepositoryWrapper(FootballContext repositoryContext)
        {
            _footballContext = repositoryContext;
        }
        public Task SaveAsync()
        {
            return _footballContext.SaveChangesAsync();
        }
    }
}
