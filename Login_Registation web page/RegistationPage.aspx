<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>
<!DOCTYPE html>
<html>
<head>
    <title>Register</title>
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
        <h2>Register</h2>
        <form runat="server">
            <div class="form-control">
                <label for="name">Enter your name</label>
                <asp:TextBox ID="txtName" runat="server" Placeholder="Name"></asp:TextBox>
            </div>
            <div class="form-control">
                <label for="email">Enter your email</label>
                <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email"></asp:TextBox>
            </div>
            <div class="form-control">
                <label for="password">Create a password</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Password"></asp:TextBox>
            </div>
            <div class="form-control">
                <label for="confirm-password">Confirm password</label>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Placeholder="Confirm Password"></asp:TextBox>
            </div>
            <div class="form-control">
                <label>
                    <asp:CheckBox ID="chkTerms" runat="server" /> I accept terms & conditions
                </label>
            </div>
            <asp:Button ID="btnRegister" runat="server" Text="Register Now" CssClass="btn" OnClick="RegisterUser" />
        </form>
        <div class="footer">
            <span>Already have an account? <a href="Login.aspx">Sign in now</a></span>
        </div>
    </div>
</body>
</html>       