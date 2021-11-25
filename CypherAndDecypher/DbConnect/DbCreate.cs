using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CypherAndDecypher.Logger;
using CypherAndDecypher.DbConnect;
using System.Data.SqlClient;

namespace CypherAndDecypher.DbConnect
{
    public class DbCreate
    {
        public static void Create()
        {
            SqlConnection con = new SqlConnection(DbConnect.conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string qCreateDb = "IF OBJECT_ID(N'LogData', N'U') Is Null Begin CREATE TABLE LogData(ID[int] Identity(1,1) Not Null, Date[datetime] null, CypherFrom[ntext] null, CypherTo[ntext] null, CypherFromText[ntext] null, CypherToText[ntext] null PRIMARY KEY(ID)) End";
                SqlCommand cmd = new SqlCommand(qCreateDb, con);
                cmd.ExecuteNonQuery();
            }
            con.Close();
            LogLoad.Load();
        }
    }
}
