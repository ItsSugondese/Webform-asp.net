using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;

public partial class features_student_details : System.Web.UI.Page
{
    OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["odb"].ConnectionString);
    StudentPayload payload = new StudentPayload();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String param = Request.QueryString["id"];

            // Perform the existence check
            if (!string.IsNullOrEmpty(param))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                int id = int.Parse(param);
                payload = StudentPayload.FetchStudentPayloadByIdFromDatabase(con, id);
                nameBox.Text = payload.name;
                emailBox.Text = payload.email;
                dobBox.Text = payload.dob;
                contactBox.Text = payload.name;
                countryDropdown.SelectedValue = payload.country;
                snackbarSpan.InnerText = "Student Updated Successfully.";
                registerSpan.InnerText = "Update Student";
                Button1.Text = "Update";
            }
            else
            {
                registerSpan.InnerText = "Register Student";
                snackbarSpan.InnerText = "Student Saved Successfully.";
                Button1.Text = "Create";
            }
        }

    }

    protected void countryDropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
    
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Page.Validate("emailField");

        // Check if the specified control passes validation
        if (Page.IsValid)
        {
            String name = nameBox.Text;
            String email = emailBox.Text;


            String contactGet = contactBox.Text;
            String dobGet = dobBox.Text;
            String countryGet = countryDropdown.SelectedValue;
            bool exists = EditHelper.checkIfExits(Request);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sqlQuery = !exists? @"INSERT INTO ""C##ROHAN"".STUDENT
                    ( STUDENT_NAME, CONTACT, EMAIL, COUNTRY, s_no, dob)
                    VALUES(  :name, :contact, :email, :country, :id, :dob)" : @"UPDATE ""C##ROHAN"".STUDENT
SET STUDENT_NAME=:name, CONTACT=:contact, DOB=:dob, COUNTRY=:country, EMAIL=:email
WHERE s_no=:id";


            OracleCommand cmd = new OracleCommand(sqlQuery, con);


            object nextVal;
            if (!exists)
            {
                OracleCommand sequenceCommand = con.CreateCommand();
                sequenceCommand.CommandText = "SELECT student_seq.NEXTVAL FROM DUAL";
                nextVal = sequenceCommand.ExecuteScalar();
            }
            else
            {
                nextVal = EditHelper.getIdIfEdit(Request);
            }





            cmd.BindByName = true;
            cmd.Parameters.Add("id", OracleDbType.Decimal).Value = nextVal;
            cmd.Parameters.Add("contact", OracleDbType.Varchar2).Value = contactGet;
            cmd.Parameters.Add("country", OracleDbType.Varchar2).Value = countryGet;
            cmd.Parameters.Add("email", OracleDbType.Varchar2).Value = email;
            cmd.Parameters.Add("name", OracleDbType.Varchar2).Value = name;
            cmd.Parameters.Add("dob", OracleDbType.Date).Value = DateTime.Parse(dobGet);
            cmd.ExecuteNonQuery();


        if (!exists)
        {
            Thread.Sleep(1000);

            // Redirect to another page
            Response.Redirect("student-inspect.aspx");
        }
        }



    }
}