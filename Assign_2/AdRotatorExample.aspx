<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdRotatorExample.aspx.cs" Inherits="AdRotatorDemo.AdRotatorExample" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Ad Rotator Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:AdRotator 
            ID="AdRotator1" 
            runat="server" 
            AdvertisementFile="~/Advertisements.xml" 
            Width="300px" 
            Height="200px" />
    </form>
</body>
</html>
