using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DomainModel;

namespace BL
{
    public static class BLMap
    {
        public static void InsertMap(Map map, ref List<string> errors)
        {
            if (map == null)
            {
                errors.Add("Map cannot be null");
            }

            if (map.getName() == null)
            {
                errors.Add("Map name cannot be null");
            }

            if (map.getSpawns() < 0)
            {
                errors.Add("Map spawn cannot be negative");
            }

            if (errors.Count > 0)
                return;

            DALMap.InsertMap(map, ref errors);
        }

        public static void UpdateMap(Map map, ref List<string> errors)
        {
            if (map == null)
            {
                errors.Add("Map cannot be null");
            }

            if (map.getName() == null)
            {
                errors.Add("Map name cannot be null");
            }

            if (map.getSpawns() < 0)
            {
                errors.Add("Map spawn cannot be negative");
            }

            if (errors.Count > 0)
                return;

            DALMap.UpdateMap(map, ref errors);
        }

        public static Map GetMap(int id, ref List<string> errors)
        {
            if (id == null)
            {
                errors.Add("Invalid map ID");
            }

            if (id < 0)
            {
                errors.Add("The map ID cannot be negative");
            }

            if (errors.Count > 0)
                return null;

            return (DALMap.GetMapDetail(id, ref errors));
        }

        public static void DeleteMap(int id, ref List<string> errors)
        {
            if (id == null)
            {
                errors.Add("Invalid map ID");
            }

            if (id < 0)
            {
                errors.Add("The map ID cannot be negative");
            }

            if (errors.Count > 0)
                return;

            DALMap.DeleteMap(id, ref errors);
        }

        public static List<Map> GetMapList(ref List<string> errors)
        {
            return DALMap.GetMapList(ref errors);
        }
    }
}