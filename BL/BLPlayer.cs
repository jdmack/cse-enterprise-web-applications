using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DomainModel;

namespace BL
{
    public static class BLPlayer
    {
        public static void InsertPlayer(Player player, ref List<string> errors)
        {
            if (player == null)
            {
                errors.Add("Player cannot be null");
            }

            if (player.name == null)
            {
                errors.Add("Player name cannot be null");
            }

            if (player.code < 0)
            {
                errors.Add("Player code cannot be negative");
            }

            if (player.race == null)
            {
                errors.Add("Player race cannot be null");
            }

            if (player.league == null)
            {
                errors.Add("Player leauge cannot be null");
            }
            if (errors.Count > 0)
                return;

            DALPlayer.InsertPlayer(player, ref errors);
        }

        public static void UpdatePlayer(Player player, ref List<string> errors)
        {
            if (player == null)
            {
                errors.Add("Player cannot be null");
            }

            if (player.name == null)
            {
                errors.Add("Player name cannot be null");
            }

            if (player.code < 0)
            {
                errors.Add("Player code cannot be negative");
            }

            if (player.race == null)
            {
                errors.Add("Player race cannot be null");
            }
            if (player.league == null)
            {
                errors.Add("Player leauge cannot be null");
            }
            if (errors.Count > 0)
                return;

            DALPlayer.UpdatePlayer(player, ref errors);
        }

        public static Player GetPlayer(int id, ref List<string> errors)
        {
            if (id == null)
            {
                errors.Add("Invalid player ID");
            }

            if (id < 0)
            {
                errors.Add("The player ID cannot be negative");
            }

            if (errors.Count > 0)
                return null;

            return (DALPlayer.GetPlayerDetail(id, ref errors));
        }

        public static void DeletePlayer(int id, ref List<string> errors)
        {
            if (id == null)
            {
                errors.Add("Invalid player ID");
            }

            if (id < 0)
            {
                errors.Add("The player ID cannot be negative");
            }

            if (errors.Count > 0)
                return;

            DALPlayer.DeletePlayer(id, ref errors);
        }

        public static List<Player> GetPlayerList(ref List<string> errors)
        {
            return DALPlayer.GetPlayerList(ref errors);
        }
    }
}