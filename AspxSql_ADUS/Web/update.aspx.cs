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
    public partial class update : System.Web.UI.Page
    {
        public static string name = "", sqlId = "", sqlName = "", sex = "", born_date = "", class_no = "", tele_number = "", ru_date = "", address = "", comment = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            name = Request["name"];
            sqlId = Request["sqlId"];
            sqlName = Request["sqlName"];
            sex = Request["sex"];
            born_date = Request["born_date"];
            class_no = Request["class_no"];
            tele_number = Request["tele_number"];
            ru_date = Request["ru_date"];
            address = Request["address"];
            comment = Request["comment"];
            //string index = Request["SelectIndex"];
            //Response.Write(name);
            TextBox1.Style.Add("margin-top", "20px");
            Response.Write("<h2 align='center'>welcome to there " + name + "</h2><script type='text/javascript'>window.onload=function() {document.getElementById('TextBox1').value='" + sqlId + "';document.getElementById('TextBox2').value='" + sqlName + "';document.getElementById('TextBox3').value='" + sex + "';document.getElementById('TextBox4').value='" + born_date + "';document.getElementById('TextBox5').value='" + class_no + "';document.getElementById('TextBox6').value='" + tele_number + "';document.getElementById('TextBox7').value='" + ru_date + "';document.getElementById('TextBox8').value='" + address + "';document.getElementById('TextBox9').value='" + comment + "';}</script>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            studentBLL sb = new studentBLL();
            student s = new student();
            try
            {
                s.student_id = Int32.Parse(TextBox1.Text);
                s.student_name = TextBox2.Text;
                s.student_sex = TextBox3.Text.ToString();
                s.born_date = DateTime.Parse(TextBox4.Text);
                //s.born_date = DateTime.Parse(TextBox4.Text);
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
                s.student_sex = "t";
                s.born_date = DateTime.Parse("2060/01/01 0:00:00");
                s.class_no = 88888888;
                s.tele_number = "temp";
                s.ru_date = DateTime.Parse("2060/01/01 0:00:00");
                s.address = "temp";
                s.comment = "temp";
            }
            Response.Redirect("showAll.aspx?name=" + name + "&succLine=" + sb.Update(s).ToString());
            //    Response.Write("<script>alert('未登录,无权限');location.href='showAll.aspx';</script>");
        }
    }
}