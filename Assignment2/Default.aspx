<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment2.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Date Display</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblCurrentDate" runat="server" Font-Size="Large" ForeColor="Blue"></asp:Label>
            <hr />
            <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
            <hr />
            <asp:Label ID="lblSelectedDate" runat="server" Font-Size="Large" ForeColor="Green"></asp:Label>
        </div>
    </form>
</body>
</html>
