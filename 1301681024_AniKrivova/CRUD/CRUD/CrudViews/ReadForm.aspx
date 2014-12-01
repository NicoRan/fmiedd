﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReadForm.aspx.cs" Inherits="CRUD.CrudViews.ReadForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Member.aspx" Target="_parent"  CssClass="logoutlink" Font-Underline="True">← Back to Manager</asp:HyperLink>
    <div>
        <h1>Read all Contacts</h1>
    </div>
        <asp:TextBox ID="readdata" runat="server" Height="499px" ReadOnly="True" Width="489px" Wrap="False" TextMode="MultiLine" cssclass="font"></asp:TextBox>
    </form>
</body>
</html>
