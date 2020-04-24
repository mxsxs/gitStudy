using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace threeTest.DAL
{
    public class SqlHelper
    {
        public readonly string connstr = "Data Source=.;Initial Catalog=db1;Integrated Security=True;User ID=sa;Password=saPass";

        public int ExecuteNonQuery(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = cmdText;
                    cmd.Parameters.AddRange(parameters);
                    int succLine = -1;
                    try
                    {
                        succLine = cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                    }
                    return succLine;
                }
            }
        }

        public int ExecuteScalar(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = cmdText;
                    cmd.Parameters.AddRange(parameters);
                    int succLine = -1;
                    try
                    {
                        succLine = (int)cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        succLine = 999;
                    }
                    return succLine;
                }
            }
        }

        public DataTable ExecuteDataTable(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = cmdText;
                    cmd.Parameters.AddRange(parameters);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public SqlDataReader ExecuteDataReader(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = cmdText;
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
        }
        public object FromDbValue(object value)
        {
            if (value == DBNull.Value)
            {
                return null;
            }
            else
            {
                return value;
            }
        }
        public object ToDbValue(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        public string[,] query(string sql = "select * from student", int l = 9, bool temp = true, string uname = "", string upass = "")
        {
            int i = 1;
            try
            {
                SqlConnection sc = new SqlConnection(connstr);
                SqlCommand cmd;
                SqlParameter sp1 = new SqlParameter("@name", uname);

                if (temp)//查询学生表
                {
                    SqlCommand cmd0 = new SqlCommand("select count(*) from " + tName(sql), sc);
                    sc.Open();
                    i = (int)cmd0.ExecuteScalar();
                    sc.Close();
                    cmd = new SqlCommand(sql, sc);
                    cmd.Parameters.Add(sp1);
                }
                else
                {
                    SqlParameter sp2 = new SqlParameter("@pass", upass);
                    cmd = new SqlCommand(sql, sc);
                    cmd.Parameters.Add(sp1);
                    cmd.Parameters.Add(sp2);
                }

                sc.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                string[,] a = new string[i, l];
                int o = 0, p = 0;
                while (reader.Read())
                {
                    for (o = 0; o < l; o++)
                    {
                        a[p, o] = reader[o].ToString();
                    }
                    p++;
                }
                sc.Close();
                return a;
            }
            catch (Exception ex)
            {
                string[,] b = { { ex.Message + "-" + i.ToString() + "-" + l.ToString() + tName(sql), "-errorLine132" }, { "", "" } };
                return b;
            }
        }

        public string tName(string sql)
        {
            int tsIndex = sql.IndexOf("from") + 5;
            string tS = sql.Substring(tsIndex).ToString();
            int tnIndex = tS.IndexOf(" ");
            if (tnIndex >= 0)
                return tS.Substring(0, tnIndex).ToString();
            else
                return tS;
            //int action = sql.IndexOf("from") + 5, ending = sql.IndexOf(" ");
            //return sql.Substring(action, (ending - action)).ToString();
        }

    }
}
