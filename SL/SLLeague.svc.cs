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
    public class SLLeague : ISLLeague
    {
        public League GetLeague(int id, ref List<string> errors)
        {
            return BLLeague.GetLeague(id, ref errors);
        }

        public void InsertLeague(League league, ref List<string> errors)
        {
            BLLeague.InsertLeague(league, ref errors);
        }

        public void UpdateLeague(League league, ref List<string> errors)
        {
            BLLeague.UpdateLeague(league, ref errors);
        }

        public void DeleteLeague(int id, ref List<string> errors)
        {
            BLLeague.DeleteLeague(id, ref errors);
        }

        public List<League> GetLeagueList(ref List<string> errors)
        {
            return BLLeague.GetLeagueList(ref errors);
        }
    }
}
