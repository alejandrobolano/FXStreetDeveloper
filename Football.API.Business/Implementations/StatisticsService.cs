using System;
using System.Collections.Generic;
using System.Text;
using Football.API.Business.Contracts;
using Football.API.Common.Models;

namespace Football.API.Business.Implementations
{
    public class StatisticsService: IStatisticsService
    {
        public List<CardResponse> GetYellowCards()
        {
            //ToDo Steps:
            //Filter by Match, by Player and obtain yellow cards

            //Example response:
            var response = new List<CardResponse>
            {
                new CardResponse
                {
                    Id = 1,
                    Name = "Alejandro",
                    TeamName = "Barca",
                    Total = 2
                },
                new CardResponse
                {
                    Id = 1,
                    Name = "Alain",
                    TeamName = "Barca",
                    Total = 4
                },
                new CardResponse
                {
                    Id = 1,
                    Name = "Alfredo",
                    TeamName = "Madrid",
                    Total = 1
                },
                new CardResponse
                {
                    Id = 1,
                    Name = "Gorka",
                    TeamName = "Real Sociedad",
                    Total = 4
                },
                new CardResponse
                {
                    Id = 1,
                    Name = "Aitor",
                    TeamName = "Real Sociedad",
                    Total = 3
                },
            };
            return response;
        }

        public List<CardResponse> GetRedCards()
        {
            //ToDo Same steps that GetYellowCards but filter with red cards
            //Filter by Match, by Player and obtain red cards

            throw new NotImplementedException();
        }
    }
}
