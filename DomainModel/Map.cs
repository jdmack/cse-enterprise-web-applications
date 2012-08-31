using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DomainModel
{
    [DataContract]
    public class Map
    {
        [DataMember]
        public int id = -1;
        [DataMember]
        public string name = null;
        [DataMember]
        public int spawns = -1;
        [DataMember]
        public string size = "0x0";
    }
}
