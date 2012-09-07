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
    public interface ISLGame
    {

        [OperationContract]
        Game GetGame(int id, ref List<string> errors);

        [OperationContract]
        int InsertGame(Game game, ref List<string> errors);

        [OperationContract]
        void UpdateGame(Game game, ref List<string> errors);

        [OperationContract]
        void DeleteGame(Game game, ref List<string> errors);

        [OperationContract]
        List<Game> GetGameList(ref List<string> errors);
    }
}
