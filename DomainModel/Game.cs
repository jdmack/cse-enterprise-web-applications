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
    public string  length = "0:00";
	[DataMember]
	public int player1 = -1;
	[DataMember]
	public int player1_race = -1;
	[DataMember]
 	public int player2 = -1;
	[DataMember]
	public int player2_race = -1;
	[DataMember]
 	public int winner = -1;
	[DataMember]
	public int map = -1;
/*
        public Game()
        {
            id = null;
            name = null;
        }

        public Game(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        
        ~Game()
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
