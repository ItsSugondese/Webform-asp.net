﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class features_course_course_insert : System.Web.UI.Page
{
    OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["odb"].ConnectionString);
    CourseGetPayload payload = new CourseGetPayload();



    protected void Page_Load(object sender, EventArgs e)
    {
        snackbarSpan.InnerText = "Course Updated Successfully.";
        registerSpan.InnerText = "Update Course";
        Button1.Text = "Update";
        if (!IsPostBack)
        {
            String param = Request.QueryString["id"];
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
         

            // Perform the existence check
            if (!string.IsNullOrEmpty(param))
            {
                int id = int.Parse(param);
                payload = CourseGetPayload.GetCourseById(con, id);
                courseNameBox.Text = payload.name;
                snackbarSpan.InnerText = "Course Updated Successfully.";
                registerSpan.InnerText = "Update Course";
                Button1.Text = "Update";

            }
            else
            {
                registerSpan.InnerText = "Create Course";
                snackbarSpan.InnerText = "Course Saved Successfully.";
                Button1.Text = "Create";
            }
            // Fetch data from the database
        }
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        String name = courseNameBox.Text;
        bool exists = EditHelper.checkIfExits(Request);
        con.Open();
        string sqlQuery = !exists ? @"INSERT INTO ""C##ROHAN"".COURSE
(COURSE_ID, COURSE_NAME)
VALUES(:id, :name)" : @"UPDATE ""C##ROHAN"".COURSE
SET COURSE_NAME=:name
WHERE COURSE_ID= :id";
        OracleCommand cmd = new OracleCommand(sqlQuery, con);

       

        // Execute the query to get the next value from the sequence
       
        

        object nextVal;
        if (!exists)
        {
            OracleCommand sequenceCommand = con.CreateCommand();
        sequenceCommand.CommandText = "SELECT course_seq.NEXTVAL FROM DUAL";
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

        if (!exists)
        {
            Thread.Sleep(1000);

            // Redirect to another page
            Response.Redirect("course-inspect.aspx");
        }
    }


}