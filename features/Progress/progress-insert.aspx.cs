using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class features_course_course_insert : System.Web.UI.Page
{
    OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["odb"].ConnectionString);
    ProgessGetPayload payload = new ProgessGetPayload();



    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            String param = Request.QueryString["id"];
            String param2 = Request.QueryString["cid"];
            String param3 = Request.QueryString["lid"];
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            List<CourseGetPayload> courses = LessonGetPayload.GetAllCourseHavingLesson(con);
            List<StudentPayload> students = StudentPayload.FetchStudentPayloadFromDatabase(con);
            
            //List<InstructorForeignPayload> instructors = InstructorForeignPayload.FetchInstructorPayloadFromDatabase(con);

            foreach (CourseGetPayload course in courses)
            {
                ddlOptions.Items.Add(new ListItem(course.name, course.id.ToString()));
            }
            foreach (StudentPayload student in students)
            {

                studentOptions.Items.Add(new ListItem(student.email, student.id.ToString()));
            }
           

            // Perform the existence check
            if (!string.IsNullOrEmpty(param) && !string.IsNullOrEmpty(param2))
            {
                int id = int.Parse(param);
                int cid = int.Parse(param2);
                int lid = int.Parse(param3);
                addValueInLessonDropdown(cid);

                payload = ProgessGetPayload.GetProgressById(con, id, cid, lid);
                statusBox.Text = payload.status;
                accessBox.Text = payload.accDate;
                snackbarSpan.InnerText = "Progress Updated Successfully.";
                registerSpan.InnerText = "Update Progess";
                Button1.Text = "Update";

                foreach (ListItem item in ddlOptions.Items)
                {
                    // Check if the item's value matches the value you want to select
                    if (item.Text == payload.course)
                    {
                        // Set the item as selected
                        item.Selected = true;

                        // Break out of the loop since we found the item to select
                        break;
                    }
                }
                
                foreach (ListItem item in studentOptions.Items)
                {
                    // Check if the item's value matches the value you want to select
                    if (item.Text == payload.email)
                    {
                        // Set the item as selected
                        item.Selected = true;

                        // Break out of the loop since we found the item to select
                        break;
                    }
                }
                
                foreach (ListItem item in insOptions.Items)
                {
                    // Check if the item's value matches the value you want to select
                    if (item.Text == payload.title)
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
                registerSpan.InnerText = "Add progess";
                snackbarSpan.InnerText = "Progress Created Successfully.";
                Button1.Text = "Create";
            }
            // Fetch data from the database
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        String name = statusBox.Text;
        int selectedCourseId = int.Parse((ddlOptions.SelectedItem).Value);
        int selectedStudentId = int.Parse((studentOptions.SelectedItem).Value);
        int selectedLessonId = int.Parse((insOptions.SelectedItem).Value);
        bool exists = EditHelper.checkIfExits(Request);
        con.Open();
        string sqlQuery = !exists ? @"INSERT INTO ""C##ROHAN"".STUDENT_PROGRESS
(S_NO, LESSON_ID, COURSE_ID, LESSON_STATUS, LAST_ACCESSED_DATE)
VALUES(:sid, :lid, :cid, :status, :accDate)" : @"UPDATE ""C##ROHAN"".STUDENT_PROGRESS
SET LESSON_STATUS=:status, LAST_ACCESSED_DATE=:accDate
WHERE S_NO=:sid AND LESSON_ID=:lid AND COURSE_ID=:cid";
        OracleCommand cmd = new OracleCommand(sqlQuery, con);




        cmd.BindByName = true;
        cmd.Parameters.Add("sid", OracleDbType.Decimal).Value = selectedStudentId;
        cmd.Parameters.Add("lid", OracleDbType.Decimal).Value = selectedLessonId;
        cmd.Parameters.Add("accDate", OracleDbType.Date).Value = DateTime.Parse(accessBox.Text);
        cmd.Parameters.Add("status", OracleDbType.Varchar2).Value = statusBox.Text;
        cmd.Parameters.Add("cid", OracleDbType.Decimal).Value = selectedCourseId;
        cmd.ExecuteNonQuery();


       

        if (!exists)
        {
            Thread.Sleep(1000);

            // Redirect to another page
            Response.Redirect("progress.aspx");
        }
    }



    protected void ddlOptions_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        addValueInLessonDropdown(int.Parse((ddlOptions.SelectedItem).Value));
    }

    private void addValueInLessonDropdown(int id)
    {
        insOptions.Items.Clear();
        List<LessonGetPayload> lessons = LessonGetPayload.GetLessonByCourseId(con, id);

        foreach (LessonGetPayload ins in lessons)
        {

            insOptions.Items.Add(new ListItem(ins.name, ins.id.ToString()));
        }
    }
}