using AutoMapper;
using Football.API.Common.Models;
using Football.API.DataAccess.Models;

namespace Football.API
{
    public class Mapping: Profile
    {
        public Mapping()
        {
            CreateMap<ManagerRequest, ManagerResponse>();
        }
    }
}
