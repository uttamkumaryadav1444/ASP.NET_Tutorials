<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlgebraicOperations.aspx.cs" Inherits="Assignment1.AlgebraicOperations" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Algebraic Operations</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center; margin-top: 50px;">
            <h1>Algebraic Operations</h1>
            <asp:Label ID="lblNum1" runat="server" Text="Enter Number 1: " />
            <asp:TextBox ID="txtNum1" runat="server" />
            <br /><br />
            <asp:Label ID="lblNum2" runat="server" Text="Enter Number 2: " />
            <asp:TextBox ID="txtNum2" runat="server" />
            <br /><br />
            <asp:Label ID="lblOperation" runat="server" Text="Select Operation: " />
            <asp:DropDownList ID="ddlOperation" runat="server">
                <asp:ListItem Text="Addition" Value="Add" />
                <asp:ListItem Text="Subtraction" Value="Subtract" />
                <asp:ListItem Text="Multiplication" Value="Multiply" />
                <asp:ListItem Text="Division" Value="Divide" />
            </asp:DropDownList>
            <br /><br />
            <asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click" />
            <br /><br />
            <asp:Label ID="lblResult" runat="server" ForeColor="Blue" Font-Bold="True" />
        </div>
    </form>
</body>
</html>
