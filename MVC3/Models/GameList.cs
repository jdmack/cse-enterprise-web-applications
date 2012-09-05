using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC3.Models
{
    public class GameList
    {
        List<GameInfo> games = new List<GameInfo>();

        public GameList()
        {
            for (int i = 0; i < 10; i++)
            {
                games.Add(new GameInfo(i, i.ToString(), i.ToString(), i.ToString(), i));
            }
        }

        public List<GameInfo> GetGameList()
        {
            return games;
        }

        public GameInfo GetGameDetail(int id)
        {
            return games[id];
        }
    }
}