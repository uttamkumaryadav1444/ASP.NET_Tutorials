using System;
using System.Xml.Linq;

namespace Assignment1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Optional: Code for page initialization
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            if (!string.IsNullOrEmpty(name))
            {
                lblMessage.Text = $"Welcome, {name}!";
            }
            else
            {
                lblMessage.Text = "Please enter your name.";
            }
        }
    }
}
