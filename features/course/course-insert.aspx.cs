using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class features_course_course_insert : System.Web.UI.Page
{
    OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["odb"].ConnectionString);



    private List<InstructorForeignPayload> FetchInstructorsFromDatabase()
    {
        List<InstructorForeignPayload> instructors = new List<InstructorForeignPayload>();

        // SQL query
        string query = "SELECT INSTRUCTOR_ID AS id, ci.INSTRUCTOR_NAME AS name FROM COURSE_INSTRUCTOR ci "; // Assuming your table is named Instructors


        using (OracleCommand command = new OracleCommand(query, con))
        {
            con.Open();
            using (OracleDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    InstructorForeignPayload instructor = new InstructorForeignPayload
                    {
                        id = Convert.ToInt32(reader["ID"]),
                        name = reader["Name"].ToString()
                    };
                    instructors.Add(instructor);
                }
            }
        }


        return instructors;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Fetch data from the database
            List<InstructorForeignPayload> instructors = FetchInstructorsFromDatabase();

            foreach (InstructorForeignPayload instructor in instructors)
            {
                ddlOptions.Items.Add(new ListItem(instructor.name, instructor.id.ToString()));
            }
        }
    }

    //protected void ddlOptions_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    // Get the selected item from the dropdown list
    //    ListItem selectedItem = ddlOptions.SelectedItem;
    //    ListItem selectedItem = ddlOptions.SelectedItem;

    //    // Print the ID of the selected item
    //    Response.Write("Selected ID: " + selectedItem.Value);
    //}

    protected void Button1_Click(object sender, EventArgs e)
    {
        String name = courseNameBox.Text;
        int selectedInstructorId = int.Parse((ddlOptions.SelectedItem).Value);

        con.Open();
        string sqlQuery = @"INSERT INTO ""C##ROHAN"".COURSE
(COURSE_ID, COURSE_NAME, INSTRUCTOR_ID)
VALUES(:1, :2, :3)";
        OracleCommand cmd = new OracleCommand(sqlQuery, con);

        OracleCommand sequenceCommand = con.CreateCommand();
        sequenceCommand.CommandText = "SELECT course_seq.NEXTVAL FROM DUAL";

        // Execute the query to get the next value from the sequence
        object nextVal = sequenceCommand.ExecuteScalar();

        decimal instructorSequenceValue;

        // Check if the nextVal is a valid numeric value before parsing
        OracleParameter courseId = new OracleParameter();

        if (nextVal != null && decimal.TryParse(nextVal.ToString(), out instructorSequenceValue))
        {
            courseId.OracleDbType = OracleDbType.Decimal;
            courseId.Value = instructorSequenceValue;
        }
        else
        {
            throw new Exception("Invalid sequence value retrieved from database.");
        }

        OracleParameter courseName = new OracleParameter();
        courseName.OracleDbType = OracleDbType.Varchar2;
        courseName.Value = name;

        OracleParameter instructorId = new OracleParameter();
        instructorId.OracleDbType = OracleDbType.Decimal;
        instructorId.Value = selectedInstructorId;

        cmd.Parameters.Add(courseId);
        cmd.Parameters.Add(courseName);
        cmd.Parameters.Add(instructorId);
        cmd.ExecuteNonQuery();
    }


}