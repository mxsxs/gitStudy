<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Web.Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        html,body{
            height:314px;
            width:100%;
            margin:0;
        }
        body{
            background-image:url("img/bg.jpg");
            background-size:100%;
            background-repeat:no-repeat;
        }
        input{
            margin:10px;
            background-color:rgba(255,255,255,0.7);
            height:30px;
            width:90px;
        }
        #div{
            width:238px;
            margin:40px auto;
            height: 277px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="div">
    
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    
        <br />
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="确认添加" OnClick="Button1_Click" />
    
    </div>
    </form>
</body>
</html>
