using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ECommerce_Prog
{
    public partial class CustomerDetails : System.Web.UI.Page
    {
        string path = @"Data Source=DESKTOP-K59HESF\SQLEXPRESS;Initial Catalog=eCommerce;Integrated Security=True";
        SqlConnection con;
        SqlCommand com;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Fetch the total as soon as the user arrives on this page
                GetCartTotal();
            }
        }

        private void GetCartTotal()
        {
            con = new SqlConnection(path);
            // Query to sum up the 'total' column from the cart
            string query = "SELECT SUM(total) FROM cardDB";
            com = new SqlCommand(query, con);

            try
            {
                con.Open();
                // ExecuteScalar is used when you only need one value back
                object result = com.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    lblGrandTotal.Text = result.ToString();
                }
                else
                {
                    lblGrandTotal.Text = "0";
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        protected void btncustomer_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(path);
            con.Open();

            // 1. Insert Customer Details
            string k = "INSERT INTO customerDB (name, email, mobile, address, total) VALUES (@name, @email, @mobile, @address, @total)";
            com = new SqlCommand(k, con);
            com.Parameters.AddWithValue("@name", txtcustname.Text);
            com.Parameters.AddWithValue("@email", txtcustemail.Text);
            com.Parameters.AddWithValue("@mobile", txtcustmobile.Text);
            com.Parameters.AddWithValue("@address", txtcustaddress.Text);
            com.Parameters.AddWithValue("@total", lblGrandTotal.Text);
            com.ExecuteNonQuery();

            // 2. Optional: Clear the cart after the order is placed so it's empty for the next session
            string clearCart = "DELETE FROM cardDB";
            SqlCommand cmdClear = new SqlCommand(clearCart, con);
            cmdClear.ExecuteNonQuery();

            // 3. Pop Up Message
            string script = "alert('Order placed successfully! Total Amount: " + lblGrandTotal.Text + "');";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
        }
    }
}