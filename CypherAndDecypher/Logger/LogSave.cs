using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CypherAndDecypher.Models;
using CypherAndDecypher.Logger;
using CypherAndDecypher.DbConnect;
using System.Data.SqlClient;


namespace CypherAndDecypher.Logger
{
    public class LogSave
    {
        public static void Save(LogData logData)
        {
            SqlConnection con = new SqlConnection(DbConnect.DbConnect.conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "INSERT into LogData(Date,CypherFrom,CypherTo,CypherFromText,CypherToText)values('"+logData.date.ToString("yyyy-MM-dd HH:mm:ss")+"','"+logData.cypherFrom+"','"+logData.cypherTo+"','"+logData.cypherFromText+"','"+logData.cypherToText+"')";
                SqlCommand cmd = new SqlCommand(q,con);
                cmd.ExecuteNonQuery();
            }
            con.Close();
            LogLoad.Load();
        }

    }
}
