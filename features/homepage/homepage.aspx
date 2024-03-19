<%@ Page Language="C#" AutoEventWireup="true" CodeFile="homepage.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="features_instructor_instructor_inspect" %>


<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
        <div class="header bg-gradient-primary pb-8 pt-5 pt-md-8">
      <div class="container-fluid">
        <div class="header-body">
          <!-- Card stats -->
          <div class="row">
            <div class="col-xl-3 col-lg-6">
              <div class="card card-stats mb-4 mb-xl-0">
                <div class="card-body">
                  <div class="row">
                    <div class="col">
                      <h5 class="card-title text-uppercase text-muted mb-0">Student</h5>
                      <span class="h2 font-weight-bold mb-0" id="studentCount" runat="server">350,897</span>
                    </div>
                  </div>
                  <p class="mt-3 mb-0 text-muted text-sm">
                    <span class="text-nowrap view-details"> <a href="../student/student-inspect.aspx"> View details  <i class="fa fa-arrow-right" aria-hidden="true"></i> </a> </span>
                  </p>
                </div>
              </div>
            </div>
              <div class="col-xl-3 col-lg-6">
              <div class="card card-stats mb-4 mb-xl-0">
                <div class="card-body">
                  <div class="row">
                    <div class="col">
                      <h5 class="card-title text-uppercase text-muted mb-0">Course</h5>
                      <span class="h2 font-weight-bold mb-0" id="courseCount" runat="server">350,897</span>
                    </div>
                  </div>
                  <p class="mt-3 mb-0 text-muted text-sm">
                    <span class="text-nowrap view-details"> <a href="../course/course-inspect.aspx">  View details <i class="fa fa-arrow-right" aria-hidden="true"></i> </a> </span>
                  </p>
                </div>
              </div>
            </div>
              <div class="col-xl-3 col-lg-6">
              <div class="card card-stats mb-4 mb-xl-0">
                <div class="card-body">
                  <div class="row">
                    <div class="col">
                      <h5 class="card-title text-uppercase text-muted mb-0">Instructor</h5>
                      <span class="h2 font-weight-bold mb-0" runat="server" id="instructorCount">350,897</span>
                    </div>
                  </div>
                  <p class="mt-3 mb-0 text-muted text-sm">
                    <span class="text-nowrap view-details"> <a href="../instructor/instructor-inspect.aspx"> View details <i class="fa fa-arrow-right" aria-hidden="true"></i> </a> </span>
                  </p>
                </div>
              </div>
            </div>
              <div class="col-xl-3 col-lg-6">
              <div class="card card-stats mb-4 mb-xl-0">
                <div class="card-body">
                  <div class="row">
                    <div class="col">
                      <h5 class="card-title text-uppercase text-muted mb-0">Lesson</h5>
                      <span class="h2 font-weight-bold mb-0" runat="server" id="lessonCount">350,897</span>
                    </div>
                  </div>
                  <p class="mt-3 mb-0 text-muted text-sm">
                    <span class="text-nowrap view-details"> <a href="../lesson/lesson-inspect.aspx"> View details <i class="fa fa-arrow-right" aria-hidden="true"></i> </a></span>
                  </p>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
        <div style="display:flex; text-align: center; margin-top: 20px;justify-content: center">
            <div>
            <h1>Student Enrollment data of <span runat="server" id="year"></span></h1>
        <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" Width="1116px" Height="488px"  >
            <series>
                <asp:Series Name="Series1" XValueMember="MonthName" YValueMembers="EnrollmentCount">
                </asp:Series>
            </series>
            <chartareas>
    <asp:ChartArea Name="ChartArea1" >
        <AxisX Interval="1" Title="Months"  TitleFont="Arial,12pt">
            <LabelStyle />
        </AxisX>
        <AxisY Title="No. of Enrollments"  TitleFont="Arial,12pt">

        </AxisY>

        </asp:ChartArea>
            </chartareas>
        </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="SELECT 
    MONTHS.MonthName,
    COALESCE(Enrollments.EnrollmentCount, 0) AS EnrollmentCount
FROM
    (SELECT 'January' AS MonthName, 1 AS MonthNumber FROM DUAL
     UNION ALL SELECT 'February', 2 FROM DUAL
     UNION ALL SELECT 'March', 3 FROM DUAL
     UNION ALL SELECT 'April', 4 FROM DUAL
     UNION ALL SELECT 'May', 5 FROM DUAL
     UNION ALL SELECT 'June', 6 FROM DUAL
     UNION ALL SELECT 'July', 7 FROM DUAL
     UNION ALL SELECT 'August', 8 FROM DUAL
     UNION ALL SELECT 'September', 9 FROM DUAL
     UNION ALL SELECT 'October', 10 FROM DUAL
     UNION ALL SELECT 'November', 11 FROM DUAL
     UNION ALL SELECT 'December', 12 FROM DUAL) MONTHS
LEFT JOIN
    (SELECT 
         CASE WHEN EXTRACT(MONTH FROM enroll_date) = 1 THEN 'January'
              WHEN EXTRACT(MONTH FROM enroll_date) = 2 THEN 'February'
              WHEN EXTRACT(MONTH FROM enroll_date) = 3 THEN 'March'
              WHEN EXTRACT(MONTH FROM enroll_date) = 4 THEN 'April'
              WHEN EXTRACT(MONTH FROM enroll_date) = 5 THEN 'May'
              WHEN EXTRACT(MONTH FROM enroll_date) = 6 THEN 'June'
              WHEN EXTRACT(MONTH FROM enroll_date) = 7 THEN 'July'
              WHEN EXTRACT(MONTH FROM enroll_date) = 8 THEN 'August'
              WHEN EXTRACT(MONTH FROM enroll_date) = 9 THEN 'September'
              WHEN EXTRACT(MONTH FROM enroll_date) = 10 THEN 'October'
              WHEN EXTRACT(MONTH FROM enroll_date) = 11 THEN 'November'
              WHEN EXTRACT(MONTH FROM enroll_date) = 12 THEN 'December'
         END AS MonthName,
         COUNT(*) AS EnrollmentCount
     FROM STUDENT_ENROLLMENT
     WHERE EXTRACT(YEAR FROM enroll_date) = EXTRACT(YEAR FROM SYSDATE)
     GROUP BY EXTRACT(MONTH FROM enroll_date)) Enrollments
ON MONTHS.MonthName = Enrollments.MonthName
ORDER BY MONTHS.MonthNumber"></asp:SqlDataSource>
</div>
        </div>
    </form>
    </asp:Content>


<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">

        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        .auto-width-cell{
            width: 30px !important;
            text-align: left
        }
        table
        {
            border: 1px solid #ccc;
            border-collapse: collapse;
            background-color: #fff;
            width: fit-content;
        }
        table th
        {
            background-color: #B8DBFD;
            color: #333;
            font-weight: bold;
            text-align: center;
        }
        table th, table td
        {
            padding: 5px;
            border: 1px solid #ccc;
            text-align: center;
        }
        table, table table td
        {
            border: 0px solid #ccc;
        }

        .view-details:hover{
            cursor: pointer;
            color: blue;
        }
    </style>
    <link href="css/instructor-inspect.css" rel="stylesheet" />
</asp:Content>

