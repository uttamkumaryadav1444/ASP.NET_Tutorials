using System;

namespace Assignment2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Display the current date when the page is first loaded
                lblCurrentDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            // Display the selected date
            lblSelectedDate.Text = Calendar1.SelectedDate.ToString("dddd, MMMM dd, yyyy");
        }
    }
}
// 