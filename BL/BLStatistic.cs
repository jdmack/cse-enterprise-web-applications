using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DomainModel;

namespace BL
{
    public static class BLStatistic
    {
        public static int InsertStatistic(Statistic statistic, ref List<string> errors)
        {
            if (statistic == null)
            {
                errors.Add("Statistic cannot be null");
            }

            if (errors.Count > 0)
            {
                AsynchLog.LogNow(errors);
                return 0;
            }

            return DALStatistic.InsertStatistic(statistic, ref errors);
        }

        public static void UpdateStatistic(Statistic statistic, ref List<string> errors)
        {
            if (statistic == null)
            {
                errors.Add("Statistic cannot be null");
            }

            if (errors.Count > 0)
            {
                AsynchLog.LogNow(errors);
                return;
            }

            DALStatistic.UpdateStatistic(statistic, ref errors);
        }

        public static Statistic GetStatistic(int id, ref List<string> errors)
        {
            if (id == null)
            {
                errors.Add("Invalid statistic ID");
            }

            if (Convert.ToInt32(id) < 0)
            {
                errors.Add("The statistic ID cannot be negative");
            }

            if (errors.Count > 0)
            {
                AsynchLog.LogNow(errors);
                return null;
            }

            return (DALStatistic.GetStatisticDetail(id, ref errors));
        }

        public static void DeleteStatistic(int id, ref List<string> errors)
        {
            if (id == null)
            {
                errors.Add("Invalid statistic ID");
            }

            if (Convert.ToInt32(id) < 0)
            {
                errors.Add("The statistic ID cannot be negative");
            }

            if (errors.Count > 0)
            {
                AsynchLog.LogNow(errors);
                return;
            }

            DALStatistic.DeleteStatistic(id, ref errors);
        }

        public static List<Statistic> GetStatisticList(ref List<string> errors)
        {
            return DALStatistic.GetStatisticList(ref errors);
        }
    }
}