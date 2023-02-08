using System;
using System.Collections.Generic;
using System.Text;

namespace Football.API.Business.Contracts
{
    internal interface IStatisticsService
    {
        public int GetYellowCards();
        public int GetRedCards();
    }
}
