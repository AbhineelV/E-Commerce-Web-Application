using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Including Database Library
using System.Data.SqlClient;

namespace ECommerce_Prog
{

    //Product Insert Code
    public partial class Product : System.Web.UI.Page
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

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string path = @"Data Source=DESKTOP-K59HESF\SQLEXPRESS;Initial Catalog=eCommerce;Integrated Security=True";
            con = new SqlConnection(path);
            con.Open();

            string k = "INSERT INTO productDB(name, cost, photo) VALUES(@name, @cost, @photo)";
            com = new SqlCommand(k, con);
            com.Parameters.AddWithValue("@name", txtName.Text);
            com.Parameters.AddWithValue("@cost", txtCost.Text);
            com.Parameters.AddWithValue("@photo", photoupload.FileName);


            com.ExecuteNonQuery();
        }

        //product Show Code
        protected void btnshow_Click(object sender, EventArgs e)
        {
            string path = @"Data Source=DESKTOP-K59HESF\SQLEXPRESS;Initial Catalog=eCommerce;Integrated Security=True";
            con = new SqlConnection(path);
            con.Open();

            string k = "SELECT * FROM productDB";
            com = new SqlCommand(k, con);

            dr = com.ExecuteReader();

            //Data Binding With Datalist
            DataList1.DataSource = dr;
            DataList1.DataBind();
        }


        //Add Cart Code
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string path = @"Data Source=DESKTOP-K59HESF\SQLEXPRESS;Initial Catalog=eCommerce;Integrated Security=True";
            con = new SqlConnection(path);
            con.Open();

            if (e.CommandName=="btnAdd")
            {
                Label l1 = (Label)e.Item.FindControl("Label1");
                Label l2 = (Label)e.Item.FindControl("Label2");

                string i = "INSERT INTO cardDB (name,cost) VALUES (@name, @cost)";
                com = new SqlCommand(i, con);
                com.Parameters.AddWithValue("@name", l1.Text);
                com.Parameters.AddWithValue("@cost", l2.Text);
                com.ExecuteNonQuery();
            }
        }

        //Add Cart Code
        protected void Button1_Click(object sender, EventArgs e)
        {
          
         }

        protected void btnviewcart_Click(object sender, EventArgs e)
        {
            Response.Redirect("cartpage.aspx");
        }
    }
}