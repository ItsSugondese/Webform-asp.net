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
    public String email;
    public string contact;
    public string dob;
    public string country;
    public static List<StudentPayload> FetchStudentPayloadFromDatabase(OracleConnection con)
    {
        List<StudentPayload> students = new List<StudentPayload>();

        // SQL query
        string query = "SELECT s.S_NO AS id, s.STUDENT_NAME AS name, s.email as email FROM STUDENT s"; // Assuming your table is named Instructors


        using (OracleCommand command = new OracleCommand(query, con))
        {
            using (OracleDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    StudentPayload instructor = new StudentPayload
                    {
                        id = Convert.ToInt32(reader["ID"]),
                        name = reader["Name"].ToString(),
                        email = reader["email"].ToString()
                    };
                    students.Add(instructor);
                }
            }
        }


        return students;
    }
    
    public static StudentPayload FetchStudentPayloadByIdFromDatabase(OracleConnection con, int id)
    {
        StudentPayload students = new StudentPayload();

        // SQL query
        string query = "SELECT s.S_NO AS id, s.STUDENT_NAME AS name, s.CONTACT,to_char(s.DOB, 'YYYY-MM-DD') as dob , s.EMAIL, s.country  FROM STUDENT s \r\nWHERE s.S_NO  = " + id; 


        using (OracleCommand command = new OracleCommand(query, con))
        {
            using (OracleDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                     students = new StudentPayload
                    {
                        id = Convert.ToInt32(reader["ID"]),
                        name = reader["Name"].ToString(),
                        contact = reader["contact"].ToString(),
                        dob = reader["dob"].ToString(),
                        email = reader["email"].ToString(),
                        country = reader["country"].ToString()
                    };
                }
            }
        }


        return students;
    }
}