using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FRR
{
    public class Data : Connection
    {
        public static DataTable GetData(string QueryString)
        {
            try
            {
                conn = new SqlConnection(ConnectionString);
                SqlCommand Cmd = new SqlCommand(QueryString, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader Reader = Cmd.ExecuteReader();
                return GetData(Reader);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataTable GetData(string QueryString, Dictionary<string, object> Data)
        {
            try
            {
                conn = new SqlConnection(ConnectionString);
                SqlCommand Cmd = new SqlCommand(QueryString, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader Reader = Cmd.ExecuteReader();
                foreach (var item in Data)
                {
                    Cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                }
                return GetData(Reader);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int ModifyData(string QueryString, Dictionary<string, object> Data)
        {
            try
            {
                conn = new SqlConnection(ConnectionString);
                SqlCommand Cmd = new SqlCommand(QueryString, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                foreach (var item in Data)
                {
                    Cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                }
                return ModifyData(Cmd);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int ModifyData(string QueryString)
        {
            try
            {
                conn = new SqlConnection(ConnectionString);
                SqlCommand Cmd = new SqlCommand(QueryString, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                return ModifyData(Cmd);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
