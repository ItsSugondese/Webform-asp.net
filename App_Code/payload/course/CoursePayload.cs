using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StudentPayload
/// </summary>
public class CoursePayload
{
    public int id;
    public String name;

    public static List<CoursePayload> FetchCoursePayloadFromDatabase(OracleConnection con)
    {
        List<CoursePayload> courses = new List<CoursePayload>();

        // SQL query
        string query = "SELECT c.COURSE_ID  AS id, c.COURSE_NAME  AS name FROM COURSE c"; // Assuming your table is named Instructors


        using (OracleCommand command = new OracleCommand(query, con))
        {
            using (OracleDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    CoursePayload instructor = new CoursePayload
                    {
                        id = Convert.ToInt32(reader["ID"]),
                        name = reader["Name"].ToString()
                    };
                    courses.Add(instructor);
                }
            }
        }


        return courses;
    }
}