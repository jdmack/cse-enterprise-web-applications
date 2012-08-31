using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DomainModel;

namespace BL
{
    public static class BLLeague
    {
        public static int InsertLeague(League league, ref List<string> errors)
        {
            if (league == null)
            {
                errors.Add("League cannot be null");
            }

            else
            {
                if (league.name == null)
                {
                    errors.Add("League name cannot be null");
                }

            }
            if (errors.Count > 0)
                return 0;

            return DALLeague.InsertLeague(league, ref errors);
        }

        public static void UpdateLeague(League league, ref List<string> errors)
        {
            if (league == null)
            {
                errors.Add("League cannot be null");
            }

            if (league.name == null)
            {
                errors.Add("League name cannot be null");
            }

            if (errors.Count > 0)
                return;

            DALLeague.UpdateLeague(league, ref errors);
        }

        public static League GetLeague(int id, ref List<string> errors)
        {
            if (id == null)
            {
                errors.Add("Invalid league ID");
            }

            if (id < 0)
            {
                errors.Add("The league ID cannot be negative");
            }

            if (errors.Count > 0)
                return null;

            return (DALLeague.GetLeagueDetail(id, ref errors));
        }

        public static void DeleteLeague(int id, ref List<string> errors)
        {
            if (id == null)
            {
                errors.Add("Invalid league ID");
            }

            if (id < 0)
            {
                errors.Add("The league ID cannot be negative");
            }

            if (errors.Count > 0)
                return;

            DALLeague.DeleteLeague(id, ref errors);
        }

        public static List<League> GetLeagueList(ref List<string> errors)
        {
            return DALLeague.GetLeagueList(ref errors);
        }
    }
}