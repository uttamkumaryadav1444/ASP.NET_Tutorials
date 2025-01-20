using System;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void LoginUser(object sender, EventArgs e)
    {
        // Get user input
        string email = txtUsername.Text.Trim();
        string password = txtPassword.Text.Trim();

        // Database connection string from Web.config
        string connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        try
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND Password = @Password";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password); // Note: Use hashed passwords in production

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        Response.Write("<script>alert('Login successful!');</script>");
                        Response.Redirect("Welcome.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid email or password.');</script>");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write($"<script>alert('Error: {ex.Message}');</script>");
        }
    }
}
