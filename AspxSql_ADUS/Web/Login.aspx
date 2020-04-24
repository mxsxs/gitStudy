<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        html,body{
            width:100%;
            height:100%;
            margin:0;
        }
        body{
            background-image:url("img/bg.jpg");
            background-repeat:no-repeat;
            background-size:100%;
        }
        input{
            width:200px;
            height:30px;
            background-color:rgba(255,255,255,0.7);
            background-repeat:no-repeat;
            background-size:100%;
        }
        #Button1{
            color:white;
            background-color:rgba(0,125,255,0.7);
        }
        #login{
            width:300px;
            margin:280px auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="login">
         用户名:<asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
                <br />
        <br />
        <br />
        密&nbsp;&nbsp; 码:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
                <br />
    </div>
    </form>
</body>
</html>
