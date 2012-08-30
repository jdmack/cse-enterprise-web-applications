using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DomainModel
{
    [DataContract]
    public class Race
    {
        [DataMember]
        public int id = -1;
        [DataMember]
        public string name = "";
        [DataMember]
        public char code = ' ';
    }
}
