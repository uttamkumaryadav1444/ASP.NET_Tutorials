using System;
using System.IO;

namespace Assignment
{
    public partial class Default : System.Web.UI.Page
    {
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                try
                {
                    // Ensure the folder exists
                    string folderPath = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    // Get file name and save path
                    string fileName = Path.GetFileName(FileUpload1.FileName);
                    string filePath = Path.Combine(folderPath, fileName);

                    // Save the file
                    FileUpload1.SaveAs(filePath);

                    // Display success message
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = $"File uploaded successfully!<br />File Name: {fileName}<br />File Size: {FileUpload1.PostedFile.ContentLength / 1024} KB";
                }
                catch (Exception ex)
                {
                    // Handle errors
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please select a file to upload.";
            }
        }
    }
}
