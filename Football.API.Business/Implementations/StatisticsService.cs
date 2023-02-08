using System;
using System.Collections.Generic;
using System.Text;
using Football.API.Business.Contracts;

namespace Football.API.Business.Implementations
{
    public class StatisticsService: IStatisticsService
    {
        public int GetYellowCards()
        {
            return 2;
        }

        public int GetRedCards()
        {
            return 1;
        }
    }
}
