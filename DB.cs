using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_DATA_ACCESS
{
    public class DB
    {
        private SqlConnection con = null;
        private SqlCommand command = null;
        private DataSet ds = null;
        private SqlDataAdapter dataAdapter = null;

        public DB()
        {
            var ts =ConfigurationManager.ConnectionStrings[0].ConnectionString;
            con = new SqlConnection("Server=LAPTOP-OTC2AJOB\\SQLEXPRESS;DataBase= example;Integrated Security=true");
            con.Open();
        }

        public void open()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void close()
        {
            if(con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }

        public int execNonQuery(string text, params object[] parameters)
        {
            command = new SqlCommand(text,con);
            for (int i = 0; i < parameters.Length; i++)
            {
                command.Parameters.AddWithValue("@"+i, parameters[i]);
            }
            return command.ExecuteNonQuery();
        }

        public DataSet GetDataSet(string text, params object[] parameters)
        {
            DataSet ds = new DataSet();
            command = new SqlCommand(text,con);
            for (int i = 0; i < parameters.Length; i++)
            {
                command.Parameters.AddWithValue("@" + i, parameters[i]);
            }
            dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(ds);
            return ds;
        }
    }
}
