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
    public interface ISLRace
    {

        [OperationContract]
        Race GetRace(int id, ref List<string> errors);

        [OperationContract]
        void InsertRace(Race race, ref List<string> errors);

        [OperationContract]
        void UpdateRace(Race race, ref List<string> errors);

        [OperationContract]
        void DeleteRace(int id, ref List<string> errors);

        [OperationContract]
        List<Race> GetRaceList(ref List<string> errors);
    }
}
