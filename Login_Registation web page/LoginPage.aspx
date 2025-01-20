<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Login_Registation_web_page.LoginPage" %>

<!DOCTYPE html>
<html>
<head>
    <title>Login</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #3a6cf4; /* Blue background */
            margin: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            color: white;
        }
        .container {
            background-color: white;
            color: black;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 5px 15px rgba(0, 0, 0, 0.2);
            width: 300px;
        }
        .container h2 {
            text-align: center;
            margin-bottom: 20px;
        }
        .form-control {
            margin-bottom: 15px;
            display: flex;
            flex-direction: column;
        }
        .form-control label {
            font-weight: bold;
        }
        .form-control input {
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
        .form-control input:focus {
            outline: none;
            border-color: #3a6cf4;
        }
        .actions {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 15px;
        }
        .actions a {
            color: #3a6cf4;
            text-decoration: none;
        }
        .actions a:hover {
            text-decoration: underline;
        }
        .btn {
            width: 100%;
            padding: 10px;
            background-color: #3a6cf4;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
        }
        .btn:hover {
            background-color: #345bc1;
        }
        .footer {
            text-align: center;
            margin-top: 10px;
        }
        .footer a {
            color: #3a6cf4;
            text-decoration: none;
        }
    </style>
</head>
<body>
    <div class="container">
        <h2>Login</h2>
        <form runat="server">
            <div class="form-control">
                <label for="username">Enter your email</label>
                <asp:TextBox ID="txtUsername" runat="server" Placeholder="Email"></asp:TextBox>
            </div>
            <div class="form-control">
                <label for="password">Password</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Password"></asp:TextBox>
            </div>
            <div class="actions">
                <label>
                    <asp:CheckBox ID="chkRememberMe" runat="server" /> Remember me
                </label>
                <a href="#">Forgot password?</a>
            </div>
            <asp:Button ID="btnLogin" runat="server" Text="Login Now" CssClass="btn" OnClick="LoginUser" />
        </form>
        <div class="footer">
            <span>Don't have an account? <a href="Register.aspx">Sign up now</a></span>
        </div>
    </div>
</body>
</html>

