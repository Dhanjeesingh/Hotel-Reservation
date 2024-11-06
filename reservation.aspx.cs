using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class reservation : System.Web.UI.Page
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
            cmd.CommandText = "select * from client";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DropDownList1.Items.Add(dr.GetValue(0).ToString());
            }
        conn.Close();
        conn.Open();
         cmd.CommandText = "select * from date";
          dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DropDownList2.Items.Add(dr.GetValue(0).ToString());
            }
        conn.Close();
         conn.Open();
         cmd.CommandText = "select * from city";
          dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DropDownList3.Items.Add(dr.GetValue(0).ToString());
            }
        conn.Close();
         conn.Open();
         cmd.CommandText = "select * from hotelier";
          dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DropDownList4.Items.Add(dr.GetValue(0).ToString());
            }
        
        conn.Close();
        }
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        // Save the record 
        try
        {
            conn.Close();
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "insert into reservation values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "')";
            cmd.ExecuteNonQuery();
            Response.Write("<script> alert('Record save')</script>");
            SqlDataSource1.SelectCommand = "select * from reservation";
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
            cmd.CommandText = "update  reservation set id_date='" + TextBox2.Text + "',id_city='" + TextBox3.Text + "',id_hotelier='" + TextBox4.Text + "',Number_of_overnight='" + TextBox5.Text + "',price='" + TextBox6.Text + "' where Id_client='" + TextBox1.Text + "' ";
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('Record Updated')</script>");
            SqlDataSource1.SelectCommand = "select * from reservation";
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
        SqlDataSource1.SelectCommand = "select * from reservation";
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
            cmd.CommandText = "select * from reservation where Id_client='" + TextBox1.Text + "'";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TextBox2.Text = dr.GetValue(1).ToString();
                TextBox3.Text = dr.GetValue(2).ToString();
                TextBox4.Text = dr.GetValue(3).ToString();
                TextBox5.Text = dr.GetValue(4).ToString();
                TextBox6.Text = dr.GetValue(5).ToString();

            }
            SqlDataSource1.SelectCommand = "select * from  reservation where Id_client='" + TextBox1.Text + "'";
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
            cmd.CommandText = "delete from reservation where Id_client='" + TextBox1.Text + "'";
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('Record Deleted')</script>");
            SqlDataSource1.SelectCommand = "select * from reservation";
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
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox2.Text = DropDownList2.SelectedValue.ToString();

    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox3.Text = DropDownList3.SelectedValue.ToString();

    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox4.Text = DropDownList4.SelectedValue.ToString();

    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.open('Menu.aspx','_self')</script>");
    }
}