using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// Including Librarry
using System.Data.SqlClient;

namespace ECommerce_Prog
{
    public partial class cartpage : System.Web.UI.Page
    {
        // Creating Databse Object
        SqlConnection con;
        SqlCommand com;
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        //Showing Cart Items
        protected void Button1_Click(object sender, EventArgs e)
        {
            string path = @"Data Source=DESKTOP-K59HESF\SQLEXPRESS;Initial Catalog=eCommerce;Integrated Security=True";
            con = new SqlConnection(path);
            con.Open();

            string k = "SELECT * FROM cardDB";
            com = new SqlCommand(k, con);
            dr = com.ExecuteReader();

            //Displaying Data In Grid View
            GridView1.DataSource = dr;
            GridView1.DataBind();

            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string path = @"Data Source=DESKTOP-K59HESF\SQLEXPRESS;Initial Catalog=eCommerce;Integrated Security=True";
            con = new SqlConnection(path);
            con.Open();

            int cost;
            int quantity;
            int total;

            foreach (GridViewRow objr1 in GridView1.Rows)
            {
                TextBox objid = (TextBox)objr1.FindControl("txtID");
                TextBox objcost = (TextBox)objr1.FindControl("TextBox3");
                TextBox objqty = (TextBox)objr1.FindControl("TextBox4");
                TextBox objtotal = (TextBox)objr1.FindControl("TextBox5");

                cost = int.Parse(objcost.Text);
                quantity = int.Parse(objqty.Text);
                total = cost * quantity;
                objtotal.Text = total.ToString();

                string i = "UPDATE cardDB SET quantity=@quantity, total=@total WHERE id=@id";
                com = new SqlCommand(i, con);
                com.Parameters.AddWithValue("@quantity", objqty.Text);
                com.Parameters.AddWithValue("@total", objtotal.Text);
                com.Parameters.AddWithValue("@id", objid.Text);

                com.ExecuteNonQuery();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("Payment.aspx");
        }
    }

       
 }