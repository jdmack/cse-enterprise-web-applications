using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization; // this is required

namespace DomainModel
{
    [DataContract]
    public class Player
    {
        [DataMember]
        public int id = -1;
        [DataMember]
        public string name = "";
        [DataMember]
        public int code = -1;
        [DataMember]
        public int race = -1;
        [DataMember]
        public int league = -1;
    }
}