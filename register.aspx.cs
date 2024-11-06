using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class register : System.Web.UI.Page
{
    SqlConnection conn;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\HotelRser.mdf;Integrated Security=True");
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
        }
        conn.Open();
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "insert into login values('" + TextBox1.Text + "','" + TextBox2.Text + "')";
            cmd.ExecuteNonQuery();
            Response.Write("<script> alert('Record save')</script>");
            SqlDataSource1.SelectCommand = "select * from login";
            GridView1.DataSourceID = "SqlDataSource1";
       

    }
}