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
    public class SLRace : ISLRace
    {
        public Race GetRace(int id, ref List<string> errors)
        {
            return BLRace.GetRace(id, ref errors);
        }

        public void InsertRace(Race race, ref List<string> errors)
        {
            BLRace.InsertRace(race, ref errors);
        }

        public void UpdateRace(Race race, ref List<string> errors)
        {
            BLRace.UpdateRace(race, ref errors);
        }

        public void DeleteRace(int id, ref List<string> errors)
        {
            BLRace.DeleteRace(id, ref errors);
        }

        public List<Race> GetRaceList(ref List<string> errors)
        {
            return BLRace.GetRaceList(ref errors);
        }
    }
}
