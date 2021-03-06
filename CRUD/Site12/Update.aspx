﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Site12.Update" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update</title>
    <link href="CSS.css" rel="stylesheet" />
    <style type="text/css">
        #Button2 {
            width: 70px;
            height: 44px;
            margin-left: 621px;
            margin-top: 59px;
        }
    </style>
</head>
<body style="height: 406px; margin-right: 0px;">
    <form id="form1" runat="server">
    <div id="headertext"style="  font-size: 30px; font-weight: bold; font-style: normal; background-color: #C0C0C0;">
        Read </div>

        <asp:GridView ID="gridUsers" runat="server" GridLines="None" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" Height="190px" ShowFooter="True" style="margin-top: 25px; margin-left: 186px;" Width="970px" DataKeyNames="ID" DataSourceID="SqlDataSource1" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID">
                </asp:BoundField>
                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" >
                </asp:BoundField>
                <asp:BoundField DataField="Firstname" HeaderText="Firstname" SortExpression="Firstname" >
                </asp:BoundField>
                <asp:BoundField DataField="Lastname" HeaderText="Lastname" SortExpression="Lastname" >
                </asp:BoundField>
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" >
                </asp:BoundField>
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" >
               
                </asp:BoundField>
               
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle  BackColor="#FFFBD6" ForeColor="#333333" />

            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />

        </asp:GridView>
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ALEXConnectionString %>" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [ID], [Username], [Firstname], [Lastname], [Email], [Address] FROM [Users]">
        </asp:SqlDataSource>
        
        <a href="Home.aspx"><input id="Button2" type="button" value="Back" /></a>
    </form>
</body>
</html>
