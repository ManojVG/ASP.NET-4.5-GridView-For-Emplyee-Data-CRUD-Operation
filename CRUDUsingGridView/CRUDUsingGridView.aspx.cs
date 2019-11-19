using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace CRUDUsingGridView
{
    public partial class CRUDUsingGridView : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = SqlDataSource1;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
            Label9.Text = "";
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
            Label9.Text = "";
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label EmployeeID = GridView1.Rows[e.RowIndex].FindControl("Label8") as Label;
            TextBox EmployeeName = GridView1.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;
            TextBox DOB = GridView1.Rows[e.RowIndex].FindControl("TextBox2") as TextBox;
            TextBox Gender = GridView1.Rows[e.RowIndex].FindControl("TextBox3") as TextBox;
            TextBox EmailID = GridView1.Rows[e.RowIndex].FindControl("TextBox4") as TextBox;
            TextBox ContactNumber = GridView1.Rows[e.RowIndex].FindControl("TextBox5") as TextBox;
            TextBox Address = GridView1.Rows[e.RowIndex].FindControl("TextBox6") as TextBox;
            String myCon = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CRUDUsingGridView;Integrated Security=True;";
            String updateData = "Update Employee Set EmployeeName='" + EmployeeName.Text + "', DOB='" + DOB.Text + "', Gender='" + Gender.Text + "', EmailID='" + EmailID.Text + "', ContactNumber='" + ContactNumber.Text + "', Address='" + Address.Text + "' Where EmployeeID=" + EmployeeID.Text;
            SqlConnection con = new SqlConnection(myCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = updateData;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            Label9.Text = "Row Data Has Been Updated Successfully";
            GridView1.EditIndex = -1;
            SqlDataSource1.DataBind();
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            TextBox EmployeeID = GridView1.FooterRow.FindControl("TextBox7") as TextBox;
            TextBox EmployeeName = GridView1.FooterRow.FindControl("TextBox8") as TextBox;
            TextBox DOB = GridView1.FooterRow.FindControl("TextBox9") as TextBox;
            TextBox Gender = GridView1.FooterRow.FindControl("TextBox10") as TextBox;
            TextBox EmailID = GridView1.FooterRow.FindControl("TextBox11") as TextBox;
            TextBox ContactNumber = GridView1.FooterRow.FindControl("TextBox12") as TextBox;
            TextBox Address = GridView1.FooterRow.FindControl("TextBox13") as TextBox;
            String query = "Insert Into Employee(EmployeeID,EmployeeName,DOB,Gender,EmailID,ContactNumber,Address) values('" + EmployeeID.Text + "','" + EmployeeName.Text + "','" + DOB.Text + "','" + Gender.Text + "', '" + EmailID.Text + "', '" + ContactNumber.Text + "', '" + Address.Text + "')";
            String myCon = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CRUDUsingGridView;Integrated Security=True;";
            SqlConnection con = new SqlConnection(myCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            Label9.Text = "New Row Inserted Successfully";
            SqlDataSource1.DataBind();
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label EmployeeID = GridView1.Rows[e.RowIndex].FindControl("Label1") as Label;
            String myCon = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CRUDUsingGridView;Integrated Security=True;";
            String updateData = "Delete From Employee Where EmployeeID=" + EmployeeID.Text;
            SqlConnection con = new SqlConnection(myCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = updateData;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            Label9.Text = "Row Data Has Been Deleted Successfully";
            GridView1.EditIndex = -1;
            SqlDataSource1.DataBind();
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }
    }
}