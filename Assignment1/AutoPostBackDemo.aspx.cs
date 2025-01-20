using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment1
{
    public partial class AutoPostBackDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Optional: Any initialization logic
        }

        protected void ddlColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Change background color based on the selected value
            string selectedColor = ddlColors.SelectedValue;
            lblResult.Text = $"You selected: {selectedColor}";
            lblResult.Style["background-color"] = selectedColor;
            lblResult.Style["color"] = "white";
            lblResult.Style["padding"] = "10px";
        }

        protected void chkEnable_CheckedChanged(object sender, EventArgs e)
        {
            // Enable or disable the TextBox based on the checkbox status
            txtName.Enabled = chkEnable.Checked;

            if (chkEnable.Checked)
            {
                lblResult.Text = "TextBox is now enabled. You can type your name.";
            }
            else
            {
                lblResult.Text = "TextBox is now disabled.";
            }
        }
    }
}
