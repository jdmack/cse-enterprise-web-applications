using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DomainModel;

namespace BL
{
    public static class BLRace
    {
        public static void InsertRace(Race race, ref List<string> errors)
        {
            if (race == null)
            {
                errors.Add("Race cannot be null");
            }

            if (race.name == null)
            {
                errors.Add("Race name cannot be null");
            }

            if (errors.Count > 0)
                return;

            DALRace.InsertRace(race, ref errors);
        }

        public static void UpdateRace(Race race, ref List<string> errors)
        {
            if (race == null)
            {
                errors.Add("Race cannot be null");
            }

            if (race.name == null)
            {
                errors.Add("Race name cannot be null");
            }
            if (errors.Count > 0)
                return;

            DALRace.UpdateRace(race, ref errors);
        }

        public static Race GetRace(int id, ref List<string> errors)
        {
            if (id == null)
            {
                errors.Add("Invalid race ID");
            }

            if (id < 0)
            {
                errors.Add("The race ID cannot be negative");
            }

            if (errors.Count > 0)
                return null;

            return (DALRace.GetRaceDetail(id, ref errors));
        }

        public static void DeleteRace(int id, ref List<string> errors)
        {
            if (id == null)
            {
                errors.Add("Invalid race ID");
            }

            if (id < 0)
            {
                errors.Add("The race ID cannot be negative");
            }

            if (errors.Count > 0)
                return;

            DALRace.DeleteRace(id, ref errors);
        }

        public static List<Race> GetRaceList(ref List<string> errors)
        {
            return DALRace.GetRaceList(ref errors);
        }
    }
}