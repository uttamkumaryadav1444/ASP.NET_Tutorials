<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TemperatureConverter.aspx.cs" Inherits="Assignment1.TemperatureConverter" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Temperature Converter</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center; margin-top: 50px;">
            <h1>Temperature Converter</h1>
            <asp:Label ID="lblInput" runat="server" Text="Enter Temperature: " />
            <asp:TextBox ID="txtTemperature" runat="server" />
            <br /><br />
            <asp:Label ID="lblConversion" runat="server" Text="Convert to: " />
            <asp:DropDownList ID="ddlConversion" runat="server">
                <asp:ListItem Text="Celsius to Fahrenheit" Value="CtoF" />
                <asp:ListItem Text="Fahrenheit to Celsius" Value="FtoC" />
            </asp:DropDownList>
            <br /><br />
            <asp:Button ID="btnConvert" runat="server" Text="Convert" OnClick="btnConvert_Click" />
            <br /><br />
            <asp:Label ID="lblResult" runat="server" ForeColor="Blue" Font-Bold="True" />
        </div>
    </form>
</body>
</html>
