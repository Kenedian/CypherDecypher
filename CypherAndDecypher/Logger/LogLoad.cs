using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CypherAndDecypher.DbConnect;
using CypherAndDecypher.Logger;
using CypherAndDecypher.Models;
using System.Data.SqlClient;

namespace CypherAndDecypher.Logger
{
    public class LogLoad
    {
        
        public static void Load()
        {
            LoggerList.history.Clear();
            SqlConnection con = new SqlConnection(DbConnect.DbConnect.conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {

                string q = "SELECT * FROM LogData";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LogData ld = new LogData();
                    ld.date = Convert.ToDateTime(reader["Date"].ToString());
                    ld.cypherFrom = reader["CypherFrom"].ToString();
                    ld.cypherTo = reader["CypherTo"].ToString();
                    ld.cypherFromText = reader["CypherFromText"].ToString();
                    ld.cypherToText = reader["CypherToText"].ToString();
                    LoggerList.history.Add(ld);
                }
            }
            con.Close();

        }
    }
}
