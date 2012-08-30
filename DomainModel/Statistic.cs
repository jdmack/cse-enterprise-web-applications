using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DomainModel
{
    [DataContract]
    public class Statistic
    {
        [DataMember]
        public int id = -1;
        [DataMember]
        public Player player = null;
        [DataMember]
        public Game game = null;
        [DataMember]
        public int apm = -1;
        [DataMember]
        public int resources = -1;
        [DataMember]
        public int units = -1;
        [DataMember]
        public int structures = -1;
    }
}
