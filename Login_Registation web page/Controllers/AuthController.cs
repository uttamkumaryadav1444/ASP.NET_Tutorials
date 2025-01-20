using System.IO;
using System.Threading.Tasks;
using Login_Registation_web_page.Models;
using MySql.Data.MySqlClient;
using System.Web.Mvc;

namespace Login_Registation_web_page.Controllers
{
    public class AuthController : Controller
    {
        private readonly string connectionString = "Server=localhost;Database=YourDatabase;Uid=YourUsername;Pwd=YourPassword;";

        // Register GET
        public IActionResult Register()
        {
            return (IActionResult)View();
        }

        // Register POST
        [HttpPost]
        public async Task<IActionResult> Register(User user, IFormFile profilePic)
        {
            if (ModelState.IsValid)
            {
                if (profilePic != null)
                {
                    // Save profile picture to the wwwroot folder
                    var filePath = Path.Combine("wwwroot/profilepics", profilePic.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await profilePic.CopyToAsync(stream);
                    }
                    user.ProfilePicPath = "/profilepics/" + profilePic.FileName;
                }

                // Hash the password before saving it
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                using (var connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    var command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO Users (Name, Username, Email, Gender, DateOfBirth, ProfilePicPath, Password) " +
                                          "VALUES (@Name, @Username, @Email, @Gender, @DateOfBirth, @ProfilePicPath, @Password)";
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Gender", user.Gender);
                    command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                    command.Parameters.AddWithValue("@ProfilePicPath", user.ProfilePicPath);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    await command.ExecuteNonQueryAsync();
                }

                // Redirect to login after successful registration
                return (IActionResult)RedirectToAction("Login");
            }

            // If model validation fails, return to the Register view
            return (IActionResult)View(user);
        }

        // Login GET
        public IActionResult Login()
        {
            return (IActionResult)View();
        }

        // Login POST
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.Message = "Please provide both username and password.";
                return (IActionResult)View();
            }

            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Users WHERE Username = @Username";
                command.Parameters.AddWithValue("@Username", username);
                var reader = await command.ExecuteReaderAsync();
                if (reader.Read())
                {
                    var hashedPassword = reader["Password"].ToString();
                    if (BCrypt.Net.BCrypt.Verify(password, hashedPassword))
                    {
                        // Store session values securely
                        HttpContext.Session.SetString("UserId", reader["Id"].ToString());
                        HttpContext.Session.SetString("Username", reader["Username"].ToString());

                        return (IActionResult)RedirectToAction("Dashboard");
                    }
                }
            }

            ViewBag.Message = "Invalid credentials.";
            return (IActionResult)View();
        }

        // Dashboard GET
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return (IActionResult)RedirectToAction("Login");
            }

            ViewBag.Username = HttpContext.Session.GetString("Username");
            return (IActionResult)View();
        }

        // Forgot Password GET
        public IActionResult ForgotPassword()
        {
            return (IActionResult)View();
        }

        // Forgot Password POST
        [HttpPost]
        public IActionResult ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                ViewBag.Message = "Please enter your registered email.";
                return (IActionResult)View();
            }

            // Add logic to send a password reset email (e.g., via SMTP)
            ViewBag.Message = "If the email exists, a password reset link has been sent.";
            return (IActionResult)View();
        }
    }
}
