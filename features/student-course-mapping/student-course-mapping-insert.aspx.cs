using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class features_student_course_mapping_student_course_mapping_insert : System.Web.UI.Page
{
    OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["odb"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

        // Set default selected date
        //calendarControl.SelectedDate = DateTime.Today;
        con.Open();
        List<StudentPayload> students = StudentPayload.FetchStudentPayloadFromDatabase(con);
        List<CoursePayload> courses = CoursePayload.FetchCoursePayloadFromDatabase(con);

        foreach (StudentPayload student in students)
        {
            stdDown.Items.Add(new ListItem(student.name, student.id.ToString()));
        }
        
        foreach (CoursePayload course in courses)
        {
            courseDown.Items.Add(new ListItem(course.name, course.id.ToString()));
        }



    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        DateTime enrollDate = DateTime.Parse(dateBox.Text);

        int selectedCourseId = int.Parse((courseDown.SelectedItem).Value);
        int selectedStudentId = int.Parse((stdDown.SelectedItem).Value);

        string sqlQuery = @"INSERT INTO ""C##ROHAN"".STUDENT_COURSE_MAPPING
(S_NO, COURSE_ID, ENROLL_DATE)
VALUES(:1, :2, :3)";
        OracleCommand cmd = new OracleCommand(sqlQuery, con);

     

        OracleParameter enrollDateParam = new OracleParameter();
        enrollDateParam.OracleDbType = OracleDbType.Date;
        enrollDateParam.Value = enrollDate;

        OracleParameter courseIdParam = new OracleParameter();
        courseIdParam.OracleDbType = OracleDbType.Decimal;
        courseIdParam.Value = selectedCourseId;
        
        OracleParameter studentIdParam = new OracleParameter();
        studentIdParam.OracleDbType = OracleDbType.Decimal;
        studentIdParam.Value = selectedStudentId;

        cmd.Parameters.Add(studentIdParam);
        cmd.Parameters.Add(courseIdParam);
        cmd.Parameters.Add(enrollDateParam);
        cmd.ExecuteNonQuery();
    }
}