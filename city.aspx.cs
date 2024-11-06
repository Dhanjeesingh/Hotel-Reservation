using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class city : System.Web.UI.Page
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
        if (!Page.IsPostBack == true)
        {

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from city";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DropDownList1.Items.Add(dr.GetValue(0).ToString());
            }

        }
        conn.Close();


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        // Save the record

        try
        {
            conn.Close();
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "insert into city values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "')";
            cmd.ExecuteNonQuery();
            Response.Write("<script> alert('Record save')</script>");
            SqlDataSource1.SelectCommand = "select * from city";
            GridView1.DataSourceID = "SqlDataSource1";
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        // update the record
        try
        {
            conn.Close();
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "update city set region='" + TextBox2.Text + "',country='" + TextBox3.Text + "' where id_city='" + TextBox1.Text + "' ";
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('Record Updated')</script>");
            SqlDataSource1.SelectCommand = "select * from city";
            GridView1.DataSourceID = "SqlDataSource1";
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        //All search
        SqlDataSource1.SelectCommand = "select * from city";
        GridView1.DataSourceID = "SqlDataSource1";

    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        //Particular search
        try
        {
            conn.Close();
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from city where id_city='" + TextBox1.Text + "'";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TextBox2.Text = dr.GetValue(1).ToString();
                TextBox3.Text = dr.GetValue(2).ToString();

            }
            SqlDataSource1.SelectCommand = "select * from city where id_city='" + TextBox1.Text + "'";
            GridView1.DataSourceID = "SqlDataSource1";
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        // delete the record
        try
        {
            conn.Close();
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "delete from city where id_city='" + TextBox1.Text + "'";
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('Record Deleted')</script>");
            SqlDataSource1.SelectCommand = "select * from city";
            GridView1.DataSourceID = "SqlDataSource1";
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox1.Text = DropDownList1.SelectedValue.ToString();

    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.open('Menu.aspx','_self')</script>");
    }
}