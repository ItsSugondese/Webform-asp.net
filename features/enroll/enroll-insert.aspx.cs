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
    EnrollGetPayload payload = new EnrollGetPayload();



    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            String param = Request.QueryString["id"];
            String param2 = Request.QueryString["cid"];
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            List<CourseGetPayload> courses = CourseGetPayload.FetchCoursePayloadFromDatabase(con);
            List<StudentPayload> students = StudentPayload.FetchStudentPayloadFromDatabase(con);
            List<InstructorForeignPayload> instructors = InstructorForeignPayload.FetchInstructorPayloadFromDatabase(con);

            foreach (CourseGetPayload course in courses)
            {

                ddlOptions.Items.Add(new ListItem(course.name, course.id.ToString()));
            }
            foreach (StudentPayload student in students)
            {

                studentOptions.Items.Add(new ListItem(student.email, student.id.ToString()));
            }
            foreach (InstructorForeignPayload ins in instructors)
            {

                insOptions.Items.Add(new ListItem(ins.name, ins.id.ToString()));
            }

            // Perform the existence check
            if (!string.IsNullOrEmpty(param) && !string.IsNullOrEmpty(param2))
            {
                int id = int.Parse(param);
                int cid = int.Parse(param2);
                payload = EnrollGetPayload.GetEnrollDetailsById(con, id, cid);
                enrollDateBox.Text = payload.enrollDate;
                snackbarSpan.InnerText = "Enroll Details Updated Successfully.";
                registerSpan.InnerText = "Update Enrollment Details";
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

                if(payload.insId != null)
                {
                    InstructorGetPayload ins = InstructorGetPayload.GetInstructorById(con, (int)payload.insId);

                    foreach (ListItem item in insOptions.Items)
                    {
                        // Check if the item's value matches the value you want to select
                        if (item.Text == ins.name)
                        {
                            // Set the item as selected
                            item.Selected = true;

                            // Break out of the loop since we found the item to select
                            break;
                        }
                    }
                }
            }
            else
            {
                registerSpan.InnerText = "Enroll Student";
                snackbarSpan.InnerText = "Student Enrolled Successfully.";
                Button1.Text = "Enroll";
            }
            // Fetch data from the database
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        String name = enrollDateBox.Text;
        int selectedCourseId = int.Parse((ddlOptions.SelectedItem).Value);
        int selectedStudentId = int.Parse((studentOptions.SelectedItem).Value);
        bool exists = EditHelper.checkIfExits(Request);
        con.Open();
        string sqlQuery = !exists ? @"INSERT INTO ""C##ROHAN"".STUDENT_ENROLLMENT
(S_NO, COURSE_ID, ENROLL_DATE)
VALUES(:sid, :cid, :en_date)" : @"UPDATE ""C##ROHAN"".STUDENT_ENROLLMENT
SET ENROLL_DATE=:en_date
WHERE S_NO=:sid AND COURSE_ID=:cid";
        OracleCommand cmd = new OracleCommand(sqlQuery, con);












        cmd.BindByName = true;
        cmd.Parameters.Add("sid", OracleDbType.Decimal).Value = selectedStudentId;
        cmd.Parameters.Add("en_date", OracleDbType.Date).Value = DateTime.Parse(enrollDateBox.Text);
        cmd.Parameters.Add("cid", OracleDbType.Decimal).Value = selectedCourseId;
        cmd.ExecuteNonQuery();


        if (insOptions.SelectedIndex > 0)
        {
            // An item other than the default one has been selected
            string selectedValue = insOptions.SelectedValue;
            payload = EnrollGetPayload.GetEnrollDetailsById(con, selectedStudentId, selectedCourseId);
            bool wasThere = payload.insId != null;

            string query = !wasThere ? @"INSERT INTO ""C##ROHAN"".INSTRUCTOR_COURSE_STUDENT
(INSTRUCTOR_ID, COURSE_ID, STUDENT_NO)
VALUES(:insId, :cid, :sid)" : @"UPDATE ""C##ROHAN"".INSTRUCTOR_COURSE_STUDENT
SET INSTRUCTOR_ID=:insId where  COURSE_ID=:cid and STUDENT_NO=:sid";
            OracleCommand mappingCmd = new OracleCommand(query, con);
            mappingCmd.BindByName = true;
            mappingCmd.Parameters.Add("sid", OracleDbType.Decimal).Value = selectedStudentId;
            mappingCmd.Parameters.Add("insId", OracleDbType.Decimal).Value = int.Parse((insOptions.SelectedItem).Value);

            mappingCmd.Parameters.Add("cid", OracleDbType.Decimal).Value = selectedCourseId;
            mappingCmd.ExecuteNonQuery();
        }

        if (!exists)
        {
            Thread.Sleep(1000);

            // Redirect to another page
            Response.Redirect("enroll-inspect.aspx");
        }
    }


}