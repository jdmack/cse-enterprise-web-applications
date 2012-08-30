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
    public interface ISLPlayer
    {

        [OperationContract]
        Player GetPlayer(int id, ref List<string> errors);

        [OperationContract]
        void InsertPlayer(Player player, ref List<string> errors);

        [OperationContract]
        void UpdatePlayer(Player player, ref List<string> errors);

        [OperationContract]
        void DeletePlayer(int id, ref List<string> errors);

        [OperationContract]
        List<Player> GetPlayerList(ref List<string> errors);
    }
}
