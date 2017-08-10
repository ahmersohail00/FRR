using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace FRR
{
    public class Connection
    {
        protected internal static string ConnectionStringName = "";
        private static string DecryptRijndael(string cipherText, string Password)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = pdb.GetBytes(32);
            alg.IV = pdb.GetBytes(16);
            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(cipherBytes, 0, cipherBytes.Length);
            cs.Close();
            byte[] decryptedData = ms.ToArray();
            return Encoding.Unicode.GetString(decryptedData);
        }

        protected static SqlConnection conn;
        protected static readonly string ConnectionString = DecryptRijndael(ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString, "123");
        static DataTable dt = new DataTable("ReceiveData");
        static SqlDataReader Reader;
        static SqlCommand Cmd;

        protected static DataTable GetData(SqlDataReader Data)
        {
            try
            {
                dt = new DataTable();
                Reader = Data;
                dt.Load(Reader);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected static int ModifyData(SqlCommand Data)
        {
            try
            {
                if (Data.Connection.State != ConnectionState.Broken && Data.Connection.State == ConnectionState.Closed && Data.Connection.State != ConnectionState.Connecting && Data.Connection.State != ConnectionState.Executing && Data.Connection.State != ConnectionState.Fetching && Data.Connection.State != ConnectionState.Open)
                    Data.Connection.Open();
                Cmd = Data;
                return Cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (Data.Connection.State != ConnectionState.Broken && conn.State != ConnectionState.Closed && Data.Connection.State != ConnectionState.Connecting && Data.Connection.State != ConnectionState.Executing && Data.Connection.State != ConnectionState.Fetching && Data.Connection.State == ConnectionState.Open)
                    Data.Connection.Close();
            }
        }
    }
}
