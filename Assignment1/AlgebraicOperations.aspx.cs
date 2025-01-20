using System;

namespace Assignment1
{
    public partial class AlgebraicOperations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Optional: Any initialization logic
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate that input fields are not empty
                if (string.IsNullOrWhiteSpace(txtNum1.Text) || string.IsNullOrWhiteSpace(txtNum2.Text))
                {
                    lblResult.Text = "Error: Please enter both numbers.";
                    return;
                }

                // Get the numbers from the input fields
                double num1 = double.Parse(txtNum1.Text);
                double num2 = double.Parse(txtNum2.Text);
                string operation = ddlOperation.SelectedValue;
                double result;

                // Perform the selected operation
                switch (operation)
                {
                    case "Add":
                        result = num1 + num2;
                        lblResult.Text = $"The result of addition is: {result:F2}";
                        break;
                    case "Subtract":
                        result = num1 - num2;
                        lblResult.Text = $"The result of subtraction is: {result:F2}";
                        break;
                    case "Multiply":
                        result = num1 * num2;
                        lblResult.Text = $"The result of multiplication is: {result:F2}";
                        break;
                    case "Divide":
                        if (num2 != 0)
                        {
                            result = num1 / num2;
                            lblResult.Text = $"The result of division is: {result:F2}";
                        }
                        else
                        {
                            lblResult.Text = "Error: Division by zero is not allowed.";
                        }
                        break;
                    default:
                        lblResult.Text = "Please select a valid operation.";
                        break;
                }
            }
            catch (FormatException)
            {
                lblResult.Text = "Error: Please enter valid numeric values.";
            }
            catch (Exception ex)
            {
                lblResult.Text = $"An unexpected error occurred: {ex.Message}";
            }
        }
    }
}
