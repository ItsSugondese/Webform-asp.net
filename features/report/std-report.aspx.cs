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
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            List<StudentPayload> students = StudentPayload.FetchStudentPayloadFromDatabase(con);

            foreach (StudentPayload student in students)
            {

                studentOptions.Items.Add(new ListItem(student.email, student.id.ToString()));
            }


        }
        }

    private void BindDataToRepeater(int id)
    {
        string query = @"SELECT s.STUDENT_NAME AS std, s.email as email, s.S_NO as sid, 
c.course_id as cid, c.COURSE_NAME AS course, 
to_Char(se.ENROLL_DATE, 'YYYY-MM-DD') AS enrollDate, 
COALESCE (TO_CHAR(s.DOB, 'YYYY-MM-DD'), '-') AS dob, COALESCE (s.country, '-') AS country,
COALESCE (s.CONTACT , '-')  AS contact
FROM STUDENT_ENROLLMENT se  JOIN STUDENTS s ON s.S_NO  = se.S_NO 
JOIN COURSE c ON c.COURSE_ID = se.COURSE_ID WHERE se.S_NO = :id";

        // Execute the query and retrieve data into a DataTable or other data structure
        DataTable dataTable = GetDataFromDatabase(query, id);

        if (dataTable.Rows.Count > 0)
        {
            DataRow row = dataTable.Rows[0];
            detail_card.Attributes["style"] = "display: flex; justify-content: end; align-items: center; margin-bottom: 10px";
            country.InnerText = row["country"].ToString();
            naming.InnerText = row["std"].ToString();
            dob.InnerText = "(" + row["dob"].ToString() + ")";
            country.InnerText = row["country"].ToString();

        }
        else
        {
            detail_card.Attributes["style"] = "display:none; ";

        }

        // Bind the DataTable to the Repeater control
        repeater.DataSource = dataTable;
        repeater.DataBind();
    }

    private DataTable GetDataFromDatabase(string query, int  id)
    {
        DataTable dataTable = new DataTable();
        
            using (OracleCommand command = new OracleCommand(query, con))
            {
                // Add parameters if necessary
                command.Parameters.Add("cid", OracleDbType.Int32).Value = id;
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

        // If a value other than the default one is selected, hide the "Select a student" ListItem
        if (!string.IsNullOrEmpty(selectedValue))
        {
            // Find the "Select a student" ListItem and set its Visible property to false
            ListItem selectItem = studentOptions.Items.FindByValue("");
            if (selectItem != null)
            {
                selectItem.Enabled = false;
                selectItem.Attributes["style"] = "display:none"; // Hide the item using CSS
            }
        }
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        BindDataToRepeater(int.Parse((studentOptions.SelectedItem).Value));
        
    }





    protected void countryDropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(countryDropdown.SelectedIndex == 0)
        {
            Response.Redirect("std-report.aspx");
        } else if(countryDropdown.SelectedIndex == 1)
        {
            Response.Redirect("cou-report.aspx");
        }
        else if(countryDropdown.SelectedIndex == 2)
        {
            Response.Redirect("top-report.aspx");
        }
    }
}