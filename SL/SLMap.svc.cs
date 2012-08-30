using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DomainModel;
using BL;

namespace SL
{
    public class SLMap : ISLMap
    {
        public Map GetMap(int id, ref List<string> errors)
        {
            return BLMap.GetMap(id, ref errors);
        }

        public void InsertMap(Map map, ref List<string> errors)
        {
            BLMap.InsertMap(map, ref errors);
        }

        public void UpdateMap(Map map, ref List<string> errors)
        {
            BLMap.UpdateMap(map, ref errors);
        }

        public void DeleteMap(int id, ref List<string> errors)
        {
            BLMap.DeleteMap(id, ref errors);
        }

        public List<Map> GetMapList(ref List<string> errors)
        {
            return BLMap.GetMapList(ref errors);
        }
    }
}
