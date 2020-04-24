<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showAll.aspx.cs" Inherits="Web.showAll" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        html, body {
            width: 100%;
            height: 100%;
            margin: 0;
        }

        body {
            background-color: #262822;
            color: white;
        }

        table,tbody,div{
            margin:20px auto;
            text-align:center;
        }
        #top{
            margin:0;
            width:100%;
            height:60px;
            background-color:#4BAE76;
            font-size:24px;
            text-align:left;
            padding-top:40px;
            /*font-family:*/
        }
    </style>
</head>
<body>
    <div id="top">你好:<%=name %>,欢迎使用学生管理系统!</div>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="student_id" DataSourceID="SqlDataSource1" Height="416px" Width="1094px" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="student_id" HeaderText="学号" ReadOnly="True" SortExpression="student_id" />
                    <asp:BoundField DataField="student_name" HeaderText="姓名" SortExpression="student_name" />
                    <asp:BoundField DataField="student_sex" HeaderText="性别" SortExpression="student_sex" />
                    <asp:BoundField DataField="born_date" HeaderText="出生日期" SortExpression="born_date" />
                    <asp:BoundField DataField="class_no" HeaderText="班号" SortExpression="class_no" />
                    <asp:BoundField DataField="tele_number" HeaderText="电话号码" SortExpression="tele_number" />
                    <asp:BoundField DataField="ru_date" HeaderText="入学时间" SortExpression="ru_date" />
                    <asp:BoundField DataField="address" HeaderText="家庭地址" SortExpression="address" />
                    <asp:BoundField DataField="comment" HeaderText="老师评价" SortExpression="comment" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#A1ADDD" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <asp:Button ID="Button1" runat="server" Height="43px" OnClick="Button1_Click" Text="添加" Width="83px" />
            <asp:Button ID="Button2" runat="server" Height="43px" Text="删除" Width="75px" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" Height="43px" Text="修改密码" Width="90px" OnClick="Button3_Click" />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:db1ConnectionString %>" SelectCommand="SELECT * FROM [student]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
