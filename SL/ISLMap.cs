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
    public interface ISLMap
    {

        [OperationContract]
        Map GetMap(int id, ref List<string> errors);

        [OperationContract]
        void InsertMap(Map map, ref List<string> errors);

        [OperationContract]
        void UpdateMap(Map map, ref List<string> errors);

        [OperationContract]
        void DeleteMap(int id, ref List<string> errors);

        [OperationContract]
        List<Map> GetMapList(ref List<string> errors);
    }
}
