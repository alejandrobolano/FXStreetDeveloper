using System;
using System.Collections.Generic;
using System.Text;
using Football.API.Common.Models;

namespace Football.API.Business.Contracts
{
    public interface IStatisticsService
    {
        public List<CardResponse> GetYellowCards();
        public List<CardResponse> GetRedCards();
    }
}
