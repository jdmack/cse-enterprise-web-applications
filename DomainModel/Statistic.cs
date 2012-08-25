using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DomainModel
{
    [DataContract]
    public class Statistic
    {
        [DataMember]
        private int id;

        [DataMember]
        private int player;

        [DataMember]
        private int game;

        [DataMember]
        private int apm;

        [DataMember]
        private int resources;

        [DataMember]
        private int units;

        [DataMember]
        private int structures;

        public Statistic()
        {
            id = -1;
            player = -1;
            game = -1;
            apm = -1;
            resources = -1;
            units = -1;
            structures = -1;
        }

        public Statistic(int id, int player, int game, int apm, int resources, int units, int structures)
        {
            this.id = id;
            this.player = player;
            this.game = game;
            this.apm = apm;
            this.resources = resources;
            this.units = units;
            this.structures = structures;
        }
        
        ~Statistic()
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

        public int getPlayer()
        {
            return player;
        }

        public void setPlayer(int player)
        {
            this.player = player;
        }
        public int getGame()
        {
            return game;
        }

        public void setGame(int game)
        {
            this.game = game;
        }

        public int getAPM()
        {
            return apm;
        }

        public void setAPM(int apm)
        {
            this.apm = apm;
        }

        public int getResources()
        {
            return resources;
        }

        public void setResources(int resources)
        {
            this.resources = resources;
        }

        public int getUnits()
        {
            return units;
        }

        public void setUnits(int units)
        {
            this.units = units;
        }
        public int getStructures()
        {
            return structures;
        }

        public void setStructures(int structures)
        {
            this.structures = structures;
        }

    }
}
