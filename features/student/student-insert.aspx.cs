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

public partial class features_student_details : System.Web.UI.Page
{
    OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["odb"].ConnectionString);
    StudentPayload payload = new StudentPayload();

    protected void Page_Load(object sender, EventArgs e)
    {
        String param = Request.QueryString["id"];

        // Perform the existence check
        if (!string.IsNullOrEmpty(param))
        {
            con.Open();
            int id = int.Parse(param);
            payload = StudentPayload.FetchStudentPayloadByIdFromDatabase(con, id);
            nameBox.Text = payload.name;
            emailBox.Text = payload.email;
            dobBox.Text = payload.name;
            contactBox.Text = payload.name;
            countryDropdown.SelectedValue = payload.country;
            snackbarSpan.InnerText = "Student Updated Successfully.";
            registerSpan.InnerText = "Update Instructor";
            Button1.Text = "Update";
        }
        else
        {
            registerSpan.InnerText = "Register Instructor";
            snackbarSpan.InnerText = "Student Saved Successfully.";
            Button1.Text = "Create";
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

            con.Open();
            string sqlQuery = @"INSERT INTO ""C##ROHAN"".STUDENTS
                    (STUDENT_NAME, CONTACT, EMAIL, COUNTRY, s_no, dob)
                    VALUES( :1, :2, :3, :4, :5, :6)";
            OracleCommand cmd = new OracleCommand(sqlQuery, con);

            OracleCommand sequenceCommand = con.CreateCommand();
            sequenceCommand.CommandText = "SELECT student_seq.NEXTVAL FROM DUAL";

            // Execute the query to get the next value from the sequence
            object nextVal = sequenceCommand.ExecuteScalar();

            decimal studentSequenceValue;

            // Check if the nextVal is a valid numeric value before parsing
                OracleParameter studentID = new OracleParameter();
            if (nextVal != null && decimal.TryParse(nextVal.ToString(), out studentSequenceValue))
            {
                studentID.OracleDbType = OracleDbType.Decimal;
                studentID.Value = studentSequenceValue;
            }
            else
            {
                throw new Exception("Invalid sequence value retrieved from database.");
            }

            OracleParameter studentName = new OracleParameter();
            studentName.OracleDbType = OracleDbType.Varchar2;
            studentName.Value = name;
            
            OracleParameter contact = new OracleParameter();
            contact.OracleDbType = OracleDbType.Varchar2;
            contact.Value = string.IsNullOrEmpty(contactGet) ? (object)DBNull.Value : contactGet;
            
            OracleParameter dob = new OracleParameter();
            dob.OracleDbType = OracleDbType.Date;
            dob.Value = string.IsNullOrEmpty(dobGet) ? (object) DBNull.Value : DateTime.Parse(dobGet);
            
            
            OracleParameter emailMeter = new OracleParameter();
            emailMeter.OracleDbType = OracleDbType.Varchar2;
            emailMeter.Value = email;

            OracleParameter country = new OracleParameter();
            country.OracleDbType = OracleDbType.Varchar2;
            country.Value = string.IsNullOrEmpty(countryGet) ? (object)DBNull.Value : countryGet;

           

            cmd.Parameters.Add(studentName);
            cmd.Parameters.Add(contact);
            cmd.Parameters.Add(emailMeter);
            cmd.Parameters.Add(country);
            cmd.Parameters.Add(studentID);
            cmd.Parameters.Add(dob);
            cmd.ExecuteNonQuery();
        }
        else
        {
            Response.Write("Invalid wala Fuck");
            //string emailAddress = emailBox.Text;
            // Validation failed, handle it accordingly
            // For example, display an error message
            // or prevent further processing
        }

    }
}