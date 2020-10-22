<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form_Add.aspx.cs" Inherits="WebOrderManagement.Form_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label5" runat="server" BackColor="#CCFFCC" Font-Size="XX-Large" Text="注文登録画面"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="商品名"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Text_Merchandise" runat="server" Width="250px" MaxLength="50"></asp:TextBox>
            <br />
            <br />
        </div>
        <asp:Label ID="Label2" runat="server" Text="注文数量"></asp:Label>
&nbsp;<asp:TextBox ID="Text_Quantity" runat="server" Width="96px" MaxLength="5"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="お客様"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Text_Customer" runat="server" Width="250px" MaxLength="50"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="納期"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Text_Deadline" runat="server" Width="95px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="ButtonAdd" runat="server" Text="登録" OnClick="ButtonAdd_Click" />
        <asp:Button ID="Button1" runat="server" Text="キャンセル" style="position:relative; left:100px; top:0px" PostBackUrl="~/Form_Management.aspx"/>
    </form>
</body>
</html>
