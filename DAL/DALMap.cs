using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel;  // must add this...
using System.Configuration; // must add this... make sure to add "System.Configuration" first
using System.Data.SqlClient; // must add this...
using System.Data; // must add this...

namespace DAL
{
  public static class DALMap
  {
		static string connection_string = ConfigurationManager.AppSettings["dsn"];

    public static int InsertMap(Map map, ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);
      try
      {
        string strSQL = "spInsertMapInfo";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@map_name", SqlDbType.VarChar, 50));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@spawns", SqlDbType.Int));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@size", SqlDbType.VarChar, 50));

        mySA.SelectCommand.Parameters["@map_name"].Value = map.name;
        mySA.SelectCommand.Parameters["@spawns"].Value = map.spawns;
        mySA.SelectCommand.Parameters["@size"].Value = map.size;

        DataSet myDS = new DataSet();
        mySA.Fill(myDS);
        return Convert.ToInt32(myDS.Tables[0].Rows[0][0].ToString());

      }
      catch (Exception e)
      {
        errors.Add("Error: " + e.ToString());
        return -1;
      }
      finally
      {
        conn.Dispose();
        conn = null;
      }
    }

    public static void UpdateMap(Map map, ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);
      try
      {
        string strSQL = "spUpdateMapInfo";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

        mySA.SelectCommand.Parameters.Add(new SqlParameter("@map_id", SqlDbType.Int));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 50));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@spawns", SqlDbType.Int));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@size", SqlDbType.VarChar, 50));

        mySA.SelectCommand.Parameters["@map_id"].Value = map.id;
        mySA.SelectCommand.Parameters["@name"].Value = map.name;
        mySA.SelectCommand.Parameters["@spawns"].Value = map.spawns;
        mySA.SelectCommand.Parameters["@size"].Value = map.size;

        DataSet myDS = new DataSet();
        mySA.Fill(myDS);

      }
      catch (Exception e)
      {
        errors.Add("Error: " + e.ToString());
      }
      finally
      {
        conn.Dispose();
        conn = null;
      }
    }

    public static void DeleteMap(int id, ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);

      try
      {
        string strSQL = "spDeleteMapInfo";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@map_id", SqlDbType.Int));

        mySA.SelectCommand.Parameters["@map_id"].Value = id;

        DataSet myDS = new DataSet();
        mySA.Fill(myDS);

      }
      catch (Exception e)
      {
        errors.Add("Error: " + e.ToString());
      }
      finally
      {
        conn.Dispose();
        conn = null;
      }
    }

    public static Map GetMapDetail(int id, ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);
      Map map = null;

      try
      {
        string strSQL = "spGetMapDetail";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@map_id", SqlDbType.Int));

        mySA.SelectCommand.Parameters["@map_id"].Value = id;

        DataSet myDS = new DataSet();
        mySA.Fill(myDS);

        if (myDS.Tables[0].Rows.Count == 0)
          return null;

        map = new Map();
        map.id = id;
        map.name = myDS.Tables[0].Rows[0]["name"].ToString();
        map.spawns = Convert.ToInt32(myDS.Tables[0].Rows[0]["spawns"].ToString());
        map.size = myDS.Tables[0].Rows[0]["size"].ToString();

      }
      catch (Exception e)
      {
        errors.Add("Error: " + e.ToString());
      }
      finally
      {
        conn.Dispose();
        conn = null;
      }

      return map;
    }

    public static List<Map> GetMapList(ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);
      Map map = null;
      List<Map> mapList = new List<Map>();

      try
      {
        string strSQL = "spGetMapList";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

        DataSet myDS = new DataSet();
        mySA.Fill(myDS);

        if (myDS.Tables[0].Rows.Count == 0)
          return null;

        for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
        {
            map = new Map();
            map.id = Convert.ToInt32(myDS.Tables[0].Rows[0]["id"].ToString());
            map.name = myDS.Tables[0].Rows[0]["name"].ToString();
            map.spawns = Convert.ToInt32(myDS.Tables[0].Rows[0]["spawns"].ToString());
            map.size = myDS.Tables[0].Rows[0]["size"].ToString();
            mapList.Add(map);
        }
      }
      catch (Exception e)
      {
        errors.Add("Error: " + e.ToString());
      }
      finally
      {
        conn.Dispose();
        conn = null;
      }

      return mapList;
    }
  }
}
