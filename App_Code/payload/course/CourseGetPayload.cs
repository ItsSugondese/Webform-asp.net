using Oracle.ManagedDataAccess.Client;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StudentPayload
/// </summary>
public class CourseGetPayload
{
    public int id;
    public String name;

    public static List<CourseGetPayload> FetchCoursePayloadFromDatabase(OracleConnection con)
    {
        List<CourseGetPayload> courses = new List<CourseGetPayload>();

        // SQL query
        string query = "SELECT c.COURSE_ID  AS id, c.COURSE_NAME  AS name FROM COURSE c"; // Assuming your table is named Instructors


        using (OracleCommand command = new OracleCommand(query, con))
        {
            using (OracleDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    CourseGetPayload instructor = new CourseGetPayload
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
    
    public static List<CourseGetPayload> FetchEnrolledCoursePayloadFromDatabase(OracleConnection con)
    {
        List<CourseGetPayload> courses = new List<CourseGetPayload>();

        // SQL query
        string query = @"SELECT c.COURSE_ID as id , c.COURSE_NAME as name 
FROM INSTRUCTOR_COURSE_STUDENT ics JOIN COURSE c ON c.COURSE_ID = ics.COURSE_ID
GROUP BY c.COURSE_ID, c.COURSE_NAME";


        using (OracleCommand command = new OracleCommand(query, con))
        {
            using (OracleDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    CourseGetPayload instructor = new CourseGetPayload
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

    public static CourseGetPayload GetCourseById(OracleConnection con, int id)
    {
        CourseGetPayload instructor = new CourseGetPayload();

        // SQL query
        string query = @"SELECT COURSE_ID AS id, COURSE_NAME AS name
FROM COURSE c
WHERE c.COURSE_ID = " + id; 


        using (OracleCommand command = new OracleCommand(query, con))
        {
            using (OracleDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    instructor = new CourseGetPayload
                    {
                        id = Convert.ToInt32(reader["ID"]),
                        name = reader["Name"].ToString()
                    };
                }
            }
        }


        return instructor;
    }
}