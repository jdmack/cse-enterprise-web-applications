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
        private int id;

        [DataMember]
        private string name;

        [DataMember]
        private int spawns;

        [DataMember]
        private string size;

        public Map()
        {
            id = -1;
            name = "";
            spawns = -1;
            size = "";
        }

        public Map(int id, string name, int spawns, string size)
        {
            this.id = id;
            this.name = name;
            this.spawns = spawns;
            this.size = size;
        }
        
        ~Map()
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
        }
         
        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public int getSpawns()
        {
            return spawns;
        }

        public void setSpawns(int spawns)
        {
            this.spawns = spawns;
        }

        public string getSize()
        {
            return size;
        }

        public void setSize(string size)
        {
            this.size = size;  
        }

    }
}
