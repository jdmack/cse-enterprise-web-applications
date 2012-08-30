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
    public interface ISLLeague
    {

        [OperationContract]
        League GetLeague(int id, ref List<string> errors);

        [OperationContract]
        void InsertLeague(League league, ref List<string> errors);

        [OperationContract]
        void UpdateLeague(League league, ref List<string> errors);

        [OperationContract]
        void DeleteLeague(int id, ref List<string> errors);

        [OperationContract]
        List<League> GetLeagueList(ref List<string> errors);
    }
}
