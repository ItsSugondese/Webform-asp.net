using Oracle.ManagedDataAccess.Client;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class features_instructor_instructor_inspect : System.Web.UI.Page
{
    OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["odb"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            countryDropdown.SelectedIndex = 2;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
           


        }
        }

    private void BindDataToRepeater()
    {
        string query = @"SELECT c.COURSE_ID AS cid, c.COURSE_NAME AS course, COUNT(*) AS total, 
   sum(CASE WHEN EXTRACT(DAY FROM enroll_date)= :day THEN 1 ELSE 0 end) AS byDay  FROM STUDENT_ENROLLMENT se 
   JOIN COURSE c ON c.COURSE_ID = se.course_id
  WHERE EXTRACT(MONTH FROM enroll_date) = :month
  AND EXTRACT(YEAR FROM enroll_date) = :year
 GROUP BY c.COURSE_NAME, c.COURSE_ID ORDER BY total desc ";

        // Execute the query and retrieve data into a DataTable or other data structure
        DataTable dataTable = GetDataFromDatabase(query);

       

        // Bind the DataTable to the Repeater control
        repeater.DataSource = dataTable;
        repeater.DataBind();
    }

    private DataTable GetDataFromDatabase(string query)
    {
        DateTime date = DateTime.Parse(dateBox.Text);
        DataTable dataTable = new DataTable();
        
            using (OracleCommand command = new OracleCommand(query, con))
            {
                // Add parameters if necessary
                command.Parameters.Add("day", OracleDbType.Int32).Value = date.Day;
                command.Parameters.Add("month", OracleDbType.Int32).Value = date.Month;
                command.Parameters.Add("year", OracleDbType.Int32).Value = date.Year;
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
            }

        
        return dataTable;
    }




    protected void countryDropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(countryDropdown.SelectedIndex == 0)
        {
            Response.Redirect("std-report.aspx");
        } else if(countryDropdown.SelectedIndex == 1)
        {
            Response.Redirect("cou-report.aspx");
        } else if(countryDropdown.SelectedIndex == 2)
        {
            Response.Redirect("top-report.aspx");
        }
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }

        BindDataToRepeater();


    }
}