<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AutoPostBackDemo.aspx.cs" Inherits="Assignment1.AutoPostBackDemo" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AutoPostBack Demo</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center; margin-top: 50px;">
            <h1>AutoPostBack Property Demonstration</h1>

            <!-- DropDownList with AutoPostBack -->
            <asp:Label ID="lblSelect" runat="server" Text="Choose a Color: " />
            <asp:DropDownList 
                ID="ddlColors" 
                runat="server" 
                AutoPostBack="true" 
                OnSelectedIndexChanged="ddlColors_SelectedIndexChanged">
                <asp:ListItem Text="Red" Value="Red" />
                <asp:ListItem Text="Green" Value="Green" />
                <asp:ListItem Text="Blue" Value="Blue" />
            </asp:DropDownList>
            <br /><br />

            <!-- CheckBox with AutoPostBack -->
            <asp:CheckBox 
                ID="chkEnable" 
                runat="server" 
                AutoPostBack="true" 
                OnCheckedChanged="chkEnable_CheckedChanged" 
                Text="Enable TextBox" />
            <br /><br />

            <!-- TextBox -->
            <asp:Label ID="lblTextbox" runat="server" Text="Enter your name: " />
            <asp:TextBox ID="txtName" runat="server" Enabled="false" />
            <br /><br />

            <!-- Label to Display Result -->
            <asp:Label ID="lblResult" runat="server" Font-Bold="True" ForeColor="Blue" />
        </div>
    </form>
</body>
</html>
