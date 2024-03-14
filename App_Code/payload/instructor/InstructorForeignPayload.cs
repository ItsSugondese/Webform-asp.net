using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class InstructorForeignPayload
{
    public int id;
    public String name;

    public static List<InstructorForeignPayload> FetchStudentPayloadFromDatabase(OracleConnection con)
    {
        List<InstructorForeignPayload> instructors = new List<InstructorForeignPayload>();

        // SQL query
        string query = "SELECT INSTRUCTOR_ID AS id, ci.INSTRUCTOR_NAME AS name FROM COURSE_INSTRUCTOR ci "; // Assuming your table is named Instructors


        using (OracleCommand command = new OracleCommand(query, con))
        {
            using (OracleDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    InstructorForeignPayload instructor = new InstructorForeignPayload
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
}