using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DomainModel;
using BL;

namespace SL
{
    public class SLGame : ISLGame
    {
        public Game GetGame(int id, ref List<string> errors)
        {
            return BLGame.GetGame(id, ref errors);
        }

        public void InsertGame(Game game, ref List<string> errors)
        {
            BLGame.InsertGame(game, ref errors);
        }

        public void UpdateGame(Game game, ref List<string> errors)
        {
            BLGame.UpdateGame(game, ref errors);
        }

        public void DeleteGame(int id, ref List<string> errors)
        {
            BLGame.DeleteGame(id, ref errors);
        }

        public List<Game> GetGameList(ref List<string> errors)
        {
            return BLGame.GetGameList(ref errors);
        }
    }
}
