using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using threeTest.Model;

namespace threeTest.DAL
{
    public class studentDAL
    {
        SqlHelper sh = new SqlHelper();
        public int AddNew(student model)
        {
            int succLine = sh.ExecuteScalar(
                "INSERT INTO student(student_id,student_name,student_sex,born_date,class_no,tele_number,ru_date,address,comment) VALUES (@student_id,@student_name,@student_sex,@born_date,@class_no,@tele_number,@ru_date,@address,@comment);SELECT @@identity"
                , new SqlParameter("@student_id", model.student_id)
                , new SqlParameter("@student_name", model.student_name)
                , new SqlParameter("@student_sex", model.student_sex)
                , new SqlParameter("@born_date", model.born_date)
                , new SqlParameter("@class_no", model.class_no)
                , new SqlParameter("@tele_number", model.tele_number)
                , new SqlParameter("@ru_date", model.ru_date)
                , new SqlParameter("@address", model.address)
                , new SqlParameter("@comment", model.comment)
            );
            return succLine;
        }

        public bool Delete(int id)
        {
            int rows = sh.ExecuteNonQuery("DELETE student WHERE student_id = @id", new SqlParameter("@id", id));
            return rows > 0;
        }

        public int Update(student model)
        {//UPDATE student SET student_id=@student_id,student_name=@student_name,student_sex=@student_sex,born_date=@born_date,class_no=@class_no,tele_number=@tele_number,ru_date=@ru_date,address=@address,comment=@comment WHERE student_id=@student_id
            string sql = "UPDATE student SET student_id=@student_id,student_name=@student_name,student_sex=@student_sex,born_date=@born_date,class_no=@class_no,tele_number=@tele_number,ru_date=@ru_date,address=@address,comment=@comment WHERE student_id=@student_id";
            int rows = sh.ExecuteNonQuery(sql
                , new SqlParameter("@student_id", model.student_id)
                , new SqlParameter("@student_name", model.student_name)
                , new SqlParameter("@student_sex", model.student_sex)
                , new SqlParameter("@born_date", model.born_date)
                , new SqlParameter("@class_no", model.class_no)
                , new SqlParameter("@tele_number", model.tele_number)
                , new SqlParameter("@ru_date", model.ru_date)
                , new SqlParameter("@address", model.address)
                , new SqlParameter("@comment", model.comment)
            );
            return rows;
        }

        //public student Get(int id)
        //{
        //    DataTable dt = SqlHelper.ExecuteDataTable("SELECT * FROM student WHERE student_id=@student_id", new SqlParameter("@student_id", id));
        //    if (dt.Rows.Count > 1)
        //    {
        //        throw new Exception("more than 1 row was found");
        //    }
        //    if (dt.Rows.Count <= 0)
        //    {
        //        return null;
        //    }
        //    DataRow row = dt.Rows[0];
        //    student model = ToModel(row);
        //    return model;
        //}

        public string[,] Get(int id, string uname, string upass)
        {
            try
            {
                bool loginOrShow = upass == "";//无参数,默认为空[show]
                if (loginOrShow)
                {
                    string[,] a = sh.query("select * from student where student_id=@name", 9, false,uname);//@student_id
                    return a;
                }
                else
                {
                    string[,] c = sh.query("select * from users where  name = @name and pass=@pass", 2, loginOrShow, uname, upass);//@student_id
                    //student sd = new student();
                    //sd.student_id = 4;
                    return c;
                }
            }
            catch (Exception ex)
            {
                string[,] b = { { "00", "01" }, { "10", "11" } };
                b[0, 0] = ex.Message;
                return b;
            }
        }

        public static student ToModel(DataRow row)
        {
            student model = new student();
            model.student_id = (int)row["student_id"];
            model.student_name = (string)row["student_name"];
            model.student_sex = (string)row["student_sex"];
            model.born_date = (DateTime)row["born_date"];
            model.class_no = (int)row["class_no"];
            model.tele_number = (string)row["tele_number"];
            model.ru_date = (DateTime)row["ru_date"];
            model.address = (string)row["address"];
            model.comment = (string)row["comment"];
            return model;
        }

        public IEnumerable<student> ListAll()
        {
            List<student> list = new List<student>();
            DataTable dt = sh.ExecuteDataTable("select * from student");
            foreach (DataRow row in dt.Rows)
            {
                list.Add(ToModel(row));
            }
            return list;
        }
    }
}
