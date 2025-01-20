<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdRotatorExample.aspx.cs" Inherits="YourNamespace.AdRotatorExample" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Ad Rotator Example</title>
    <style>
        .container {
            margin: 50px auto;
            width: 300px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Ad Rotator Example</h1>
            <asp:AdRotator 
                ID="AdRotator1" 
                runat="server" 
                AdvertisementFile="~/Advertisements.xml" 
                Width="300px" 
                Height="200px" 
                BorderStyle="Solid" 
                BorderWidth="1px" />
        </div>
    </form>
</body>
</html>
