using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Including Library
using System.Data.SqlClient;

namespace ECommerce_Prog
{
    public partial class Payment : System.Web.UI.Page
    {
        SqlCommand com;
        SqlConnection con;
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string path = @"Data Source=DESKTOP-K59HESF\SQLEXPRESS;Initial Catalog=eCommerce;Integrated Security=True";
            con = new SqlConnection(path);
            con.Open();

            string k = "SELECT SUM(total) as [total] FROM cardDB";
            com = new SqlCommand(k, con);
            dr = com.ExecuteReader();

            GridView1.DataSource = dr;
            GridView1.DataBind();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerDetails.aspx");
        }
    }
}