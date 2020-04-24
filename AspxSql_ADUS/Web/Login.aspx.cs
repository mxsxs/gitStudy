using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using threeTest.BLL;

namespace Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            studentBLL sb = new studentBLL();
            string uname = TextBox1.Text, upass = TextBox2.Text;
            string[,] b = sb.Get(20000301, uname, upass);
            bool loginSucc = false;
            try
            {//存在[数组b索引不超界限切账号密码正确->默认的false改为true]
                loginSucc = b[0, 0].Replace(" ", "") == uname && b[0, 1].Replace(" ", "") == upass;
                //string tempDebugStr = b.GetLength(0).ToString() + "-" + b.GetLength(1).ToString();
            }
            catch
            {
            }
            if (loginSucc)
            {
                Response.Write("<script>alert(\"loginSucc\");</script>");
                Response.Redirect("showAll.aspx?name="+uname);
            }
            else
            {
                Response.Write("<script>alert(\"loginError\");</script>");
            }
        }
    }
}