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
        private int id;

        [DataMember]
        private string name;

        [DataMember]
        private char code;

        public Race()
        {
            id = -1;
            name = "";
            code = ' ';
        }

        public Race(int id, string name, char code)
        {
            this.id = id;
            this.name = name;
            this.code = code;
        }
        
        ~Race()
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

        public char getCode()
        {
            return code;
        }

        public void setCode(char code)
        {
            this.code = code;
        }
    }
}
