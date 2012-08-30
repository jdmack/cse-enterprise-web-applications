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
    public class SLPlayer : ISLPlayer
    {
        public Player GetPlayer(int id, ref List<string> errors)
        {
            return BLPlayer.GetPlayer(id, ref errors);
        }

        public void InsertPlayer(Player player, ref List<string> errors)
        {
            BLPlayer.InsertPlayer(player, ref errors);
        }

        public void UpdatePlayer(Player player, ref List<string> errors)
        {
            BLPlayer.UpdatePlayer(player, ref errors);
        }

        public void DeletePlayer(int id, ref List<string> errors)
        {
            BLPlayer.DeletePlayer(id, ref errors);
        }

        public List<Player> GetPlayerList(ref List<string> errors)
        {
            return BLPlayer.GetPlayerList(ref errors);
        }
    }
}
