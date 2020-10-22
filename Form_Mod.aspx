<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form_Mod.aspx.cs" Inherits="WebOrderManagement.Form_Mod" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label10" runat="server" BackColor="#CCFFFF" Font-Size="XX-Large" Text="登録内容修正"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="注文コード："></asp:Label>
&nbsp;<asp:Label ID="Label_order" runat="server" Text="コード数値"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="商品名："></asp:Label>
&nbsp;<asp:Label ID="Label_merchandise" runat="server" Text="品名"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="数量："></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox_quantity" runat="server" Width="110px" MaxLength="5"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="お客様："></asp:Label>
&nbsp;<asp:Label ID="Label_Customer" runat="server" Text="お客様名"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label_deadline" runat="server" Text="納期："></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox_deadline" runat="server" style="margin-left: 0px" Width="110px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label9" runat="server" Text="ステータス："></asp:Label>
&nbsp;<asp:TextBox ID="TextBox_status" runat="server" Width="170px" MaxLength="10"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="ButtonMod" runat="server" Text="修正" OnClick="ButtonMod_Click" />
            <asp:Button ID="ButtonCancel" runat="server" Text="キャンセル" style="position:relative; left:100px; top:0px" PostBackUrl="~/Form_Management.aspx"/>
        </div>
    </form>
</body>
</html>
