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
/*
        public Player()
        {
            id =  -1;
            name = "";
	    code = -1;
	    race = -1;	
	    league = -1;	
        }

        public Player(int id, string name, int code, int race, int league)
        {
            this.id = id;
            this.name = name;
	    this.code = code;
   	    this.race = race;
	    this.league = league;
        }
        
        ~Player()
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
*/
    }
}