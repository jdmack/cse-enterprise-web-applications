using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization; // this is required

namespace DomainModel
{
    [DataContract]
    public class League
    {
        [DataMember]
        public int id = -1;
        [DataMember]
        public string name = null;
    }
}
