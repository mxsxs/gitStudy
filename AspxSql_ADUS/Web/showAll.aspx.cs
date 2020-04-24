using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using threeTest.BLL;
using System.Drawing;
using threeTest.Model;

namespace Web
{
    public partial class showAll : System.Web.UI.Page
    {
        public static string selectId = "", name = "";
        studentBLL sb = new studentBLL();
        protected void Page_Load(object sender, EventArgs e)
        {


            name = Request["name"];
            Button1.BackColor = Button2.BackColor = Button3.BackColor = Color.FromArgb(160, 0, 125, 255);
            Button1.ForeColor = Button2.ForeColor = Button3.ForeColor = Color.White;
            Button1.Style.Add("margin-top", "20px");
            Button2.Style.Add("margin-left", "10px");
            Button3.Style.Add("margin-left", "10px");
            int succLine = -1;
            try
            {
                succLine = Int32.Parse(Request["succLine"]);
            }
            catch { }
            if (succLine >= 1)
                Response.Write("<script>alert('执行成功" + succLine.ToString() + "行');location.href='showAll.aspx?name=" + name + "';</script>");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {//add
            Response.Redirect("Add.aspx?name=" + name);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {//del
            try
            {
                Response.Write("<script>alert('" + (sb.Delete(Int32.Parse(selectId)) ? "delSucc" : "delError_未选中") + "');location.href='showAll.aspx?name=" + name + "';</script>");
            }
            catch (Exception ex)
            {
                if (ex.Message == "输入字符串的格式不正确。")
                {
                    Response.Write("<script>alert('未选中');location.href='showAll.aspx?name="+name+"';</script>");
                }
                else
                {
                    Response.Write("<script>alert('" + ex.Message + "');location.href='showAll.aspx?name="+name+"';</script>");
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {//update
            string[,] b = sb.Get(20000301, selectId);
            string sqlId = "", sqlName = "", sex = "", born_date = "", class_no = "", tele_number = "", ru_date = "", address = "", comment = "";

            try
            {//存在[数组b索引不超界限切账号密码正确->默认的false改为true]
                sqlId = selectId;
                sqlName = b[0, 1].Replace(" ", "");
                sex = b[0, 2].Replace(" ", "");
                born_date = b[0, 3];
                class_no = b[0, 4].Replace(" ", "");
                tele_number = b[0, 5].Replace(" ", "");
                ru_date = b[0, 6];
                address = b[0, 7].Replace(" ", "");
                comment = b[0, 8].Replace(" ", "");
                //string tempDebugStr = b.GetLength(0).ToString() + "-" + b.GetLength(1).ToString();
                Response.Redirect("update.aspx?name=" + name + "&sqlId=" + sqlId + "&sqlName=" + sqlName + "&sex=" + sex + "&born_date=" + born_date + "&class_no=" + class_no + "&tele_number=" + tele_number + "&ru_date=" + ru_date + "&address=" + address + "&comment=" + comment + "");
            }
            catch (Exception ex)
            {
                if (ex.Message == "未将对象引用设置到对象的实例。")
                {
                    Response.Write("<script>alert('未选中');</script>");
                }
                else
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectId = (Int64.Parse(GridView1.SelectedValue.ToString())).ToString();
            }
            catch
            {
                selectId = "selectError";
            }
            //Response.Write("<script>alert('line66-"+selectId+"');</script>");
        }

    }
}