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
public class EnrollGetPayload
{
    public int sid;
    public int? insId;
    public int cid;
    public String course;
    public String std;
    public String email;
    public String enrollDate;


    public static List<EnrollGetPayload> FetchCoursePayloadFromDatabase(OracleConnection con)
    {
        List<EnrollGetPayload> courses = new List<EnrollGetPayload>();

        // SQL query
        string query = "SELECT ROW_NUMBER() OVER (ORDER BY se.S_NO) AS sno,\r\ns.STUDENT_NAME AS std, s.S_NO as sid, c.course_id as cid, c.COURSE_NAME AS course, to_Char(se.ENROLL_DATE, 'YYYY-MM-DD') AS enrollDate \r\nFROM STUDENT_ENROLLMENT se  JOIN STUDENTS s ON s.S_NO  = se.S_NO \r\nJOIN COURSE c ON c.COURSE_ID = se.COURSE_ID"; // Assuming your table is named Instructors


        using (OracleCommand command = new OracleCommand(query, con))
        {
            using (OracleDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    EnrollGetPayload instructor = new EnrollGetPayload
                    {
                        sid = Convert.ToInt32(reader["sid"]),
                        cid =  Convert.ToInt32(reader["cid"]),
                        std = reader["std"].ToString(),
                        course = reader["course"].ToString(),
                        enrollDate = reader["enrollDate"].ToString(),
                        insId = reader["insId"] != DBNull.Value ? Convert.ToInt32(reader["insId"]) : (int?)null,

                    };
                    courses.Add(instructor);
                }
            }
        }


        return courses;
    }

    public static EnrollGetPayload GetEnrollDetailsById(OracleConnection con, int stdId, int courseId)
    {
        EnrollGetPayload instructor = new EnrollGetPayload();

        // SQL query
        string query = @"SELECT ROW_NUMBER() OVER (ORDER BY se.S_NO) AS sno,
s.STUDENT_NAME AS std, s.S_NO as sid, c.course_id as cid, s.email as email, c.COURSE_NAME AS course, to_Char(se.ENROLL_DATE, 'YYYY-MM-DD') AS enrollDate ,
 ics.INSTRUCTOR_ID AS insId
FROM STUDENT_ENROLLMENT se  JOIN STUDENTS s ON s.S_NO  = se.S_NO 
JOIN COURSE c ON c.COURSE_ID = se.COURSE_ID 
LEFT JOIN INSTRUCTOR_COURSE_STUDENT ics ON ics.COURSE_ID = se.COURSE_ID AND ics.STUDENT_NO = se.S_NO 
WHERE se.COURSE_ID = " + courseId + " and se.S_NO = " + stdId; 


        using (OracleCommand command = new OracleCommand(query, con))
        {
            using (OracleDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    instructor = new EnrollGetPayload
                    {
                        sid = Convert.ToInt32(reader["sid"]),
                        cid = Convert.ToInt32(reader["cid"]),
                        std = reader["std"].ToString(),
                        email = reader["email"].ToString(),
                        course = reader["course"].ToString(),
                        enrollDate = reader["enrollDate"].ToString(),
                        insId = reader["insId"] != DBNull.Value ? Convert.ToInt32(reader["insId"]) : (int?)null,

                    };
                }
            }
        }


        return instructor;
    }
}