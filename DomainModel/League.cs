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
	public string name = "";
/*
        public League()
        {
            id = null;
            name = null;
        }

        public League(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        
        ~League()
        {
            // cleanup code
        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
         
        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }
*/
    }
}
