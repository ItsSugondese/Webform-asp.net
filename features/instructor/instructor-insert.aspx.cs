using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data;

public partial class features_instructor_instructor_insert : System.Web.UI.Page
{
    OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["odb"].ConnectionString);
    InstructorGetPayload payload = new InstructorGetPayload();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String param = Request.QueryString["id"];

            // Perform the existence check
            if (!string.IsNullOrEmpty(param))
            {
                con.Open();
                int id = int.Parse(param);
                payload = InstructorGetPayload.GetInstructorById(con, id);
                nameBox.Text = payload.name;
            }
        }
    }
        
    


    protected void Button1_Click(object sender, EventArgs e)
    {
        if(con.State == ConnectionState.Closed){
            con.Open();
        }

        bool exists = EditHelper.checkIfExits(Request);
        String name = nameBox.Text;

      
        string sqlQuery = !exists ?  @"INSERT INTO ""C##ROHAN"".COURSE_INSTRUCTOR
                    (instructor_id, instructor_name)
                    VALUES( :id, :name)" : @"UPDATE ""C##ROHAN"".COURSE_INSTRUCTOR
SET INSTRUCTOR_NAME= :name
WHERE INSTRUCTOR_ID= :id";
        OracleCommand cmd = new OracleCommand(sqlQuery, con);


        

        // Execute the query to get the next value from the sequence
        object nextVal;
        if (!exists)
        {
            OracleCommand sequenceCommand = con.CreateCommand();
            sequenceCommand.CommandText = "SELECT instructor_seq.NEXTVAL FROM DUAL";
            nextVal = sequenceCommand.ExecuteScalar();
        }
        else
        {
            nextVal = EditHelper.getIdIfEdit(Request);
        }



        

        cmd.BindByName = true;
        cmd.Parameters.Add("id", OracleDbType.Decimal).Value = nextVal;
        cmd.Parameters.Add("name", OracleDbType.Varchar2).Value = name;
        cmd.ExecuteNonQuery();
    }

   
}