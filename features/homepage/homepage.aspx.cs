using Oracle.ManagedDataAccess.Client;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
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
        //if(con.)
        year.InnerHtml = DateTime.UtcNow.Year.ToString();

        if (!IsPostBack)
        {
            // Set font size programmatically
            Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font("Arial", 10f);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

             courseCount.InnerHtml =  getCourseCount().ToString();
             studentCount.InnerHtml =  getStudentCount().ToString();
             lessonCount.InnerHtml =  getLessonCount().ToString();
             instructorCount.InnerHtml =  getInstructorCount().ToString();
        }




    }

    private int getCourseCount()
    {
        string query = "SELECT COUNT(*) AS total  FROM COURSE c "; 


        using (OracleCommand command = new OracleCommand(query, con))
        {
            using (OracleDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    return Convert.ToInt32(reader["total"]);
                }
            }
        }
        return 0;
    }
    
    private int getStudentCount()
    {
        string query = "SELECT COUNT(*) AS total  FROM student c ";


        using (OracleCommand command = new OracleCommand(query, con))
        {
            using (OracleDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    return Convert.ToInt32(reader["total"]);
                }
            }
        }
        return 0;
    }
    
    private int getLessonCount()
    {
        string query = "SELECT COUNT(*) AS total  FROM lesson c ";


        using (OracleCommand command = new OracleCommand(query, con))
        {
            using (OracleDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    return Convert.ToInt32(reader["total"]);
                }
            }
        }
        return 0; ;
    }
    
    private int getInstructorCount()
    {
        string query = "SELECT COUNT(*) AS total  FROM COURSE_INSTRUCTOR c ";


        using (OracleCommand command = new OracleCommand(query, con))
        {
            using (OracleDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    return Convert.ToInt32(reader["total"]);
                }
            }
        }
        return 0;
    }

   
}