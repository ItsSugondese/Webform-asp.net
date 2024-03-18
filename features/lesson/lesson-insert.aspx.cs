using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class features_course_course_insert : System.Web.UI.Page
{
    OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["odb"].ConnectionString);
    LessonGetPayload payload = new LessonGetPayload();



    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            String param = Request.QueryString["id"];
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            List<CourseGetPayload> courses = CourseGetPayload.FetchCoursePayloadFromDatabase(con);

            foreach (CourseGetPayload course in courses)
            {

                ddlOptions.Items.Add(new ListItem(course.name, course.id.ToString()));
            }

            // Perform the existence check
            if (!string.IsNullOrEmpty(param))
            {
                int id = int.Parse(param);
                payload = LessonGetPayload.GetLessonById(con, id);
                lessonNameBox.Text = payload.name;
                lessonNoBox.Text = payload.lessonNo.ToString();
                snackbarSpan.InnerText = "Lesson Updated Successfully.";
                registerSpan.InnerText = "Update Lesson";
                Button1.Text = "Update";

                foreach (ListItem item in ddlOptions.Items)
                {
                    // Check if the item's value matches the value you want to select
                    if (item.Text == payload.courseName)
                    {
                        // Set the item as selected
                        item.Selected = true;

                        // Break out of the loop since we found the item to select
                        break;
                    }
                }
            }
            else
            {
                registerSpan.InnerText = "Create Lesson";
                snackbarSpan.InnerText = "Lesson Created Successfully.";
                Button1.Text = "Create";
            }
            // Fetch data from the database
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        String name = lessonNameBox.Text;
        int selectedCourseId = int.Parse((ddlOptions.SelectedItem).Value);
        bool exists = EditHelper.checkIfExits(Request);
        con.Open();
        string sqlQuery = !exists ? @"INSERT INTO ""C##ROHAN"".LESSON
(ID, LESSON_NO, LESSON_TITLE, COURSE_ID)
VALUES(:id, :lessonNo, :name, :course)" : @"UPDATE ""C##ROHAN"".LESSON
SET LESSON_NO=:lessonNo, LESSON_TITLE=:name, COURSE_ID=:course
WHERE ID= :id";
        OracleCommand cmd = new OracleCommand(sqlQuery, con);

       

        // Execute the query to get the next value from the sequence
       
        

        object nextVal;
        if (!exists)
        {
            OracleCommand sequenceCommand = con.CreateCommand();
        sequenceCommand.CommandText = "SELECT lesson_seq.NEXTVAL FROM DUAL";
            nextVal = sequenceCommand.ExecuteScalar();
        }
        else
        {
            nextVal = EditHelper.getIdIfEdit(Request);
        }





        cmd.BindByName = true;
        cmd.Parameters.Add("id", OracleDbType.Decimal).Value = nextVal;
        cmd.Parameters.Add("lessonNo", OracleDbType.Decimal).Value = int.Parse( lessonNoBox.Text);
        cmd.Parameters.Add("name", OracleDbType.Varchar2).Value = name;
        cmd.Parameters.Add("course", OracleDbType.Decimal).Value = selectedCourseId;
        cmd.ExecuteNonQuery();

        if (!exists)
        {
            Thread.Sleep(1000);

            // Redirect to another page
            Response.Redirect("lesson-inspect.aspx");
        }
    }


}