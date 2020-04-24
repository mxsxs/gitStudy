using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using threeTest.BLL;
using threeTest.Model;

namespace Web
{
    public partial class Add : System.Web.UI.Page
    {
        public string name = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            name  = Request["name"];
            string index = Request["SelectIndex"];
            //Response.Write(name);
            TextBox1.Style.Add("margin-top", "20px");
            Response.Write("<h2 align='center'>welcome " + name + "</h2>"+index);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            studentBLL sb = new studentBLL();
            student s = new student();
            try
            {
                s.student_id = Int32.Parse(TextBox1.Text);
                s.student_name = TextBox2.Text;
                s.student_sex = TextBox3.Text;
                s.born_date = DateTime.Parse(TextBox4.Text);
                s.class_no = Int32.Parse(TextBox5.Text);
                s.tele_number = TextBox6.Text;
                s.ru_date = DateTime.Parse(TextBox7.Text);
                s.address = TextBox8.Text;
                s.comment = TextBox9.Text;
            }
            catch (Exception ex)
            {
                s.student_id = 99999999;
                s.student_name = ex.Message;
                s.student_sex = "temp";
                s.born_date = DateTime.Parse("2060/01/01 0:00:00");
                s.class_no = 88888888;
                s.tele_number = "temp";
                s.ru_date = DateTime.Parse("2060/01/01 0:00:00");
                s.address = "temp";
                s.comment = "temp";
            }
            Response.Redirect("showAll.aspx?name=" + name + "&succLine=" + sb.AddNew(s).ToString());
        }
    }
}