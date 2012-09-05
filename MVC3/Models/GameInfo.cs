using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC3.Models
{
    public class GameInfo
    {
        public int id { get; set; }
        public string player1Name { get; set; }
        public string player2Name { get; set; }
        public string matchup { get; set; }
        public int downloadCount { get; set; }

        public GameInfo(int id_in, string player1Name_in, string player2Name_in, string matchup_in, int downloadCount_in)
        {
            this.id = id_in;
            this.player1Name = player1Name_in;
            this.player2Name = player2Name_in;
            this.matchup = matchup_in;
            this.downloadCount = downloadCount_in;
        }
    }
}