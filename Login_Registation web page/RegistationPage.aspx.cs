using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

public partial class Register : System.Web.UI.Page
{
    protected void RegisterUser(object sender, EventArgs e)
    {
        // Get user input
        string name = txtName.Text.Trim();
        string email = txtEmail.Text.Trim();
        string password = txtPassword.Text.Trim();
        string confirmPassword = txtConfirmPassword.Text.Trim();

        // Validate empty fields
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('All fields are required!');", true);
            return;
        }

        // Validate password confirmation
        if (password != confirmPassword)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Passwords do not match!');", true);
            return;
        }

        // Validate email format (basic regex)
        if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Invalid email format!');", true);
            return;
        }

        // Check if terms and conditions are accepted
        if (!chkTerms.Checked)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please accept the terms and conditions.');", true);
            return;
        }

        // Database connection string from Web.config
        string connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        try
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                // Check if email already exists
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@Email", email);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Email already registered!');", true);
                        return;
                    }
                }

                // Insert new user
                string query = "INSERT INTO Users (Name, Email, Password) VALUES (@Name, @Email, @Password)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", HashPassword(password)); // Store hashed password

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Registration successful!');", true);
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Registration failed. Please try again.');", true);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);
        }
    }

    // Hash password using SHA256
    public string HashPassword(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
