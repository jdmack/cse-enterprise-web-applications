using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization; // this is required

namespace DomainModel
{
    [DataContract]
    public class Game
    {
        [DataMember]
        public int id = -1;
        [DataMember]
        public string matchup = "";
        [DataMember]
        public DateTime time = new DateTime(1979, 12, 31, 11, 59, 59);
        [DataMember]
        public string length = "0:00";
        [DataMember]
        public Player player1 = null;
        [DataMember]
        public Race player1_race = null;
        [DataMember]
        public Player player2 = null;
        [DataMember]
        public Race player2_race = null;
        [DataMember]
        public Player winner = null;
        [DataMember]
        public Map map = null;
        [DataMember]
        public Statistic player1_statistic = null;
        [DataMember]
        public Statistic player2_statistic = null;
    }
}
