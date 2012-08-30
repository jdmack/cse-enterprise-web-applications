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
    [ServiceContract]
    public interface ISLStatistic
    {

        [OperationContract]
        Statistic GetStatistic(int id, ref List<string> errors);

        [OperationContract]
        void InsertStatistic(Statistic statistic, ref List<string> errors);

        [OperationContract]
        void UpdateStatistic(Statistic statistic, ref List<string> errors);

        [OperationContract]
        void DeleteStatistic(int id, ref List<string> errors);

        [OperationContract]
        List<Statistic> GetStatisticList(ref List<string> errors);
    }
}
