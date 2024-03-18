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
            countryDropdown.SelectedIndex = 1;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            List<CourseGetPayload> courses = CourseGetPayload.FetchEnrolledCoursePayloadFromDatabase(con);

            foreach (CourseGetPayload course in courses)
            {

                studentOptions.Items.Add(new ListItem(course.name, course.id.ToString()));
            }

            BindDataToRepeater(null);


        }
        }

    private void BindDataToRepeater(int? id)
    {
        string query = studentOptions.SelectedIndex != 0 ? @"SELECT ci.INSTRUCTOR_NAME AS name  FROM INSTRUCTOR_COURSE_STUDENT ics 
JOIN COURSE_INSTRUCTOR ci ON ci.INSTRUCTOR_ID = ics.INSTRUCTOR_ID 
WHERE ics.COURSE_ID = :id" : @"SELECT ci.INSTRUCTOR_NAME AS name  FROM INSTRUCTOR_COURSE_STUDENT ics
JOIN COURSE_INSTRUCTOR ci ON ci.INSTRUCTOR_ID = ics.INSTRUCTOR_ID 
GROUP BY ci.INSTRUCTOR_NAME  
HAVING COUNT(DISTINCT ics.COURSE_ID) >= 2";

        // Execute the query and retrieve data into a DataTable or other data structure
        DataTable dataTable = GetDataFromDatabase(query, id);

        

        // Bind the DataTable to the Repeater control
        repeater.DataSource = dataTable;
        repeater.DataBind();
    }
    
  

    private DataTable GetDataFromDatabase(string query, int?  id)
    {
        DataTable dataTable = new DataTable();
        
            using (OracleCommand command = new OracleCommand(query, con))
            {
            // Add parameters if necessary
            if (studentOptions.SelectedIndex != 0)
            {
                command.Parameters.Add("id", OracleDbType.Int32).Value = id;
            }
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
            }

        
        return dataTable;
    }


    


    protected void studentOptions_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedValue = studentOptions.SelectedValue;

        
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        BindDataToRepeater(studentOptions.SelectedIndex == 0 ? (int?) null : int.Parse((studentOptions.SelectedItem).Value));
        
    }





    protected void countryDropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(countryDropdown.SelectedIndex == 0)
        {
            Response.Redirect("std-report.aspx");
        } else if(countryDropdown.SelectedIndex == 1)
        {
            //Response.Redirect("std-report.aspx");
        } else if(countryDropdown.SelectedIndex == 2)
        {
            Response.Redirect("top-report.aspx");
        }
    }
}