using System;

namespace Assignment1
{
    public partial class TemperatureConverter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Optional: Any initialization logic
        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the input temperature value
                double temperature = double.Parse(txtTemperature.Text);
                string conversionType = ddlConversion.SelectedValue;
                double result;

                // Perform conversion
                if (conversionType == "CtoF")
                {
                    result = (temperature * 9 / 5) + 32; // Celsius to Fahrenheit
                    lblResult.Text = $"{temperature}°C = {result:F2}°F";
                }
                else if (conversionType == "FtoC")
                {
                    result = (temperature - 32) * 5 / 9; // Fahrenheit to Celsius
                    lblResult.Text = $"{temperature}°F = {result:F2}°C";
                }
                else
                {
                    lblResult.Text = "Invalid conversion type selected.";
                }
            }
            catch (FormatException)
            {
                lblResult.Text = "Please enter a valid numeric temperature.";
            }
            catch (Exception ex)
            {
                lblResult.Text = $"An error occurred: {ex.Message}";
            }
        }
    }
}
