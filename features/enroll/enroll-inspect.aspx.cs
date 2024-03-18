using Oracle.ManagedDataAccess.Client;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class features_instructor_instructor_inspect : System.Web.UI.Page
{
    OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["odb"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

       


    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        // Retrieve the ID of the row being edited
        Button btnEdit = (Button)sender;
        GridViewRow row = (GridViewRow)btnEdit.NamingContainer;
        int sid = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values["sid"]);
        int cid = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values["cid"]);

        // Redirect to the edit page, passing the ID as a query parameter
        Response.Redirect("enroll-insert.aspx?id=" + sid + "&cid=" + cid);



    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        // Retrieve the ID of the row being edited
        Button btnDelete = (Button)sender;
        GridViewRow row = (GridViewRow)btnDelete.NamingContainer;
        int sid = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values["sid"]);
        int cid = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values["cid"]);

        string sqlQuery = @"DELETE FROM ""C##ROHAN"".INSTRUCTOR_COURSE_STUDENT
WHERE COURSE_ID=:cid AND STUDENT_NO=:sid";

        OracleCommand cmd = new OracleCommand(sqlQuery, con);



        cmd.BindByName = true;
        cmd.Parameters.Add("sid", OracleDbType.Decimal).Value = sid;
        cmd.Parameters.Add("cid", OracleDbType.Decimal).Value = cid;
        cmd.ExecuteNonQuery();


    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Get the ID of the row being deleted
        //int id = int.Parse((GridView1.DataKeys[e.RowIndex].Value).ToString());

        int sid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["sid"]);
        int cid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["cid"]);

        // Delete the row from the database using SqlDataSource control
        SqlDataSource1.DeleteParameters.Clear();
        SqlDataSource1.DeleteParameters.Add("sid", sid.ToString());
        SqlDataSource1.DeleteParameters.Add("cid", cid.ToString());
        SqlDataSource1.Delete();
    }


    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Your edit button click handling logic
    }




    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}