<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form_Serch.aspx.cs" Inherits="WebOrderManagement.Form_Serch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label6" runat="server" BackColor="#FFFFCC" Font-Size="XX-Large" Text="検索画面"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="商品名："></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox_merchandise" runat="server" Width="210px" MaxLength="50"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="お客様："></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox_customer" runat="server" Width="210px" MaxLength="50"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="納期："></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox_deadline" runat="server" Width="116px"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="ステータス："></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="TextBox_status" runat="server" Width="174px" MaxLength="10"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="ButtonSerch" runat="server" Text="検索" OnClick="ButtonSerch_Click" />
            <asp:Button ID="ButtonCancel" runat="server" Text="キャンセル" style="position:relative; left:100px; top:0px;" PostBackUrl="~/Form_Management.aspx"/>
        </div>
    </form>
</body>
</html>
