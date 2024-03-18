using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LessonGetPayload
/// </summary>
public class LessonGetPayload
{
    public int id;
    public int lessonNo;
    public String name;
    public String courseName;
    

    public static List<LessonGetPayload> FetchLessonPayloadFromDatabase(OracleConnection con)
    {
        List<LessonGetPayload> lessons = new List<LessonGetPayload>();

        // SQL query
        string query = "SELECT l.id AS id, l.LESSON_NO AS lessonNo, ROW_NUMBER() OVER (ORDER BY id) AS sno, l.LESSON_TITLE AS name, c.COURSE_NAME AS course FROM LESSON l JOIN COURSE c ON c.COURSE_ID = l.COURSE_ID"; // Assuming your table is named Instructors


        using (OracleCommand command = new OracleCommand(query, con))
        {
            using (OracleDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    LessonGetPayload lesson = new LessonGetPayload
                    {
                        id = Convert.ToInt32(reader["ID"]),
                        name = reader["Name"].ToString(),
                        lessonNo = Convert.ToInt32(reader["lessonNo"]),
                        courseName = reader["course"].ToString()
                    };
                    lessons.Add(lesson);
                }
            }
        }


        return lessons;
    }
    

    public static LessonGetPayload GetLessonById(OracleConnection con, int id)
    {
        LessonGetPayload lesson = new LessonGetPayload();

        // SQL query
        string query = @"SELECT l.id AS id, l.LESSON_NO AS lessonNo, ROW_NUMBER() OVER (ORDER BY id) AS sno, l.LESSON_TITLE AS name, 
c.COURSE_NAME AS course FROM LESSON l 
JOIN COURSE c ON c.COURSE_ID = l.COURSE_ID where id = " + id;


        using (OracleCommand command = new OracleCommand(query, con))
        {
            using (OracleDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    lesson = new LessonGetPayload
                    {

                        id = Convert.ToInt32(reader["ID"]),
                        name = reader["Name"].ToString(),
                        lessonNo = Convert.ToInt32(reader["lessonNo"]),
                        courseName = reader["course"].ToString()
                    };
                }
            }
        }


        return lesson;
    }
    
    public static List<LessonGetPayload> GetLessonByCourseId(OracleConnection con, int id)
    {
        List<LessonGetPayload> lessons = new List<LessonGetPayload>();



        // SQL query
        string query = @"SELECT l.ID AS id, l.LESSON_NO || '. ' || l.LESSON_TITLE AS name, l.LESSON_NO AS lessonNo, c.COURSE_NAME AS course FROM LESSON l 
JOIN COURSE c ON c.COURSE_ID  = l.COURSE_ID 
WHERE l.COURSE_ID = " + id;


        using (OracleCommand command = new OracleCommand(query, con))
        {
            using (OracleDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    LessonGetPayload lesson = new LessonGetPayload

                    {

                        id = Convert.ToInt32(reader["ID"]),
                        name = reader["Name"].ToString(),
                        lessonNo = Convert.ToInt32(reader["lessonNo"]),
                        courseName = reader["course"].ToString()
                    };
                    lessons.Add(lesson);
                }
            }
        }


        return lessons;
    }
    public static List<CourseGetPayload> GetAllCourseHavingLesson(OracleConnection con)
    {
        List<CourseGetPayload> courses = new List<CourseGetPayload>();

        // SQL query
        string query = @"SELECT  c.COURSE_ID as id, c.COURSE_NAME as name  FROM LESSON l JOIN COURSE c ON c.COURSE_ID = l.COURSE_ID 
GROUP BY c.COURSE_ID, c.COURSE_NAME"; // Assuming your table is named Instructors


        using (OracleCommand command = new OracleCommand(query, con))
        {
            using (OracleDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    CourseGetPayload course = new CourseGetPayload
                    {
                        id = Convert.ToInt32(reader["ID"]),
                        name = reader["Name"].ToString()
                    };
                    courses.Add(course);
                }
            }
        }


        return courses;
    }
    
   
  
}