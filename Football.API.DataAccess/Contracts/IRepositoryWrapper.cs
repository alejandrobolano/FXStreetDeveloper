using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.API.DataAccess.Contracts
{
    public interface IRepositoryWrapper
    {
        IManagerRepository ManagerRepository { get; }
        Task SaveAsync();
    }
}
