<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form_Management.aspx.cs" Inherits="WebOrderManagement.Form_Management" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form_order" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" BackColor="#FFCC99" Font-Bold="True" Font-Size="XX-Large" Text="注文支援ツール"></asp:Label>
        </div>
        <asp:Button ID="ButtonAdd" runat="server" Text="登録" OnClick="ButtonAdd_Click"/>
        <asp:Button ID="ButtonMod" runat="server" Text="修正" style="position:relative; left:100px; top:0px" OnClick="ButtonMod_Click"/>
        <asp:Button ID="ButtonDelete" runat="server" Text="削除" style="position:relative; left:200px; top:0px" BackColor="#FFFF66" BorderColor="#FF99FF" BorderStyle="Solid" Font-Bold="True" OnClick="ButtonDelete_Click"/>
        <asp:GridView ID="GridView_OM" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="order_code" HeaderText="注文コード" SortExpression="order_code" />
                <asp:BoundField DataField="merchandise" HeaderText="商品" SortExpression="merchandise" />
                <asp:BoundField DataField="quantity" HeaderText="数量" SortExpression="quantity" />
                <asp:BoundField DataField="customer" HeaderText="顧客" SortExpression="customer" />
                <asp:BoundField DataField="deadline" HeaderText="納期" SortExpression="deadline" DataFormatString="{0:yyyy/MM/dd}" />
                <asp:BoundField DataField="status" HeaderText="ステータス" SortExpression="status" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="OrderData" runat="server" ConnectionString="<%$ ConnectionStrings:OM_DATA %>" SelectCommand="SELECT * FROM [View_OM]"></asp:SqlDataSource>
        <asp:Button ID="Button_All" runat="server" OnClick="Button_All_Click" Text="全件表示" />
        <asp:Button ID="ButtonSerch" runat="server" Text="検索" style="position:relative; left:100px; top:0px" OnClick="ButtonSerch_Click"/>
        <!-- #include file="./DeleteCheck.html" -->
    </form>
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="DeleteCheck.js"></script>
</body>
</html>
