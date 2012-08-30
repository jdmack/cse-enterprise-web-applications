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
    public class SLStatistic : ISLStatistic
    {
        public Statistic GetStatistic(int id, ref List<string> errors)
        {
            return BLStatistic.GetStatistic(id, ref errors);
        }

        public void InsertStatistic(Statistic statistic, ref List<string> errors)
        {
            BLStatistic.InsertStatistic(statistic, ref errors);
        }

        public void UpdateStatistic(Statistic statistic, ref List<string> errors)
        {
            BLStatistic.UpdateStatistic(statistic, ref errors);
        }

        public void DeleteStatistic(int id, ref List<string> errors)
        {
            BLStatistic.DeleteStatistic(id, ref errors);
        }

        public List<Statistic> GetStatisticList(ref List<string> errors)
        {
            return BLStatistic.GetStatisticList(ref errors);
        }
    }
}
