using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class ProgessGetPayload
{
    public String email;
    public String title;
    public String status;
    public String accDate;
    public String course;

    
    
    public static ProgessGetPayload GetProgressById(OracleConnection con, int id, int cid, int lid)
    {
        ProgessGetPayload progress = new ProgessGetPayload();

        // SQL query
        string query = $@"SELECT  s.STUDENT_NAME AS name, s.EMAIL as email, l.LESSON_NO || '. ' || l.LESSON_TITLE AS title, 
sp.LESSON_STATUS AS status , to_char(sp.LAST_ACCESSED_DATE, 'YYYY-MM-DD') AS accDate,
l.ID AS lid, l.COURSE_ID AS cid, s.S_NO AS sid,
c.COURSE_NAME as course 
FROM STUDENT_PROGRESS sp 
JOIN STUDENT s ON s.S_NO = sp.S_NO 
JOIN LESSON l ON l.ID = sp.LESSON_ID 
JOIN COURSE c ON c.COURSE_ID  = l.COURSE_ID  
WHERE l.COURSE_ID = {cid} AND sp.LESSON_ID = {lid} AND sp.S_NO = {id}";


        using (OracleCommand command = new OracleCommand(query, con))
        {
            using (OracleDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                     progress = new ProgessGetPayload
                     {
                        email = reader["email"].ToString(),
                        title = reader["title"].ToString(),
                        status = reader["status"].ToString(),
                        accDate = reader["accDate"].ToString(),
                        course = reader["course"].ToString(),
                    };
                }
            }
        }


        return progress;
    }

}