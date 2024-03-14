using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StudentPayload
/// </summary>
public class StudentPayload
{
    public int id;
    public String name;

    public static List<StudentPayload> FetchStudentPayloadFromDatabase(OracleConnection con)
    {
        List<StudentPayload> students = new List<StudentPayload>();

        // SQL query
        string query = "SELECT s.S_NO AS id, s.STUDENT_NAME AS name FROM STUDENTS s"; // Assuming your table is named Instructors


        using (OracleCommand command = new OracleCommand(query, con))
        {
            using (OracleDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    StudentPayload instructor = new StudentPayload
                    {
                        id = Convert.ToInt32(reader["ID"]),
                        name = reader["Name"].ToString()
                    };
                    students.Add(instructor);
                }
            }
        }


        return students;
    }
}