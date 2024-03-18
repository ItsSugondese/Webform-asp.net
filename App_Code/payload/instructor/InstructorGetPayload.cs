using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class InstructorGetPayload
{
    public int? id;
    public String name;

    public static List<InstructorGetPayload> FetchInstructorPayloadFromDatabase(OracleConnection con)
    {
        List<InstructorGetPayload> instructors = new List<InstructorGetPayload>();

        // SQL query
        string query = "SELECT INSTRUCTOR_ID AS id, ci.INSTRUCTOR_NAME AS name FROM COURSE_INSTRUCTOR ci "; // Assuming your table is named Instructors


        using (OracleCommand command = new OracleCommand(query, con))
        {
            using (OracleDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    InstructorGetPayload instructor = new InstructorGetPayload
                    {
                        id = Convert.ToInt32(reader["ID"]),
                        name = reader["Name"].ToString()
                    };
                    instructors.Add(instructor);
                }
            }
        }


        return instructors;
    }
    
    public static InstructorGetPayload GetInstructorById(OracleConnection con, int id)
    {
        InstructorGetPayload instructor = new InstructorGetPayload();

        // SQL query
        string query = "SELECT INSTRUCTOR_ID AS id, ci.INSTRUCTOR_NAME AS name FROM COURSE_INSTRUCTOR ci where ci.Instructor_id = " + id; // Assuming your table is named Instructors


        using (OracleCommand command = new OracleCommand(query, con))
        {
            using (OracleDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                     instructor = new InstructorGetPayload
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