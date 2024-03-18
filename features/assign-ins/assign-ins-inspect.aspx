<%@ Page Language="C#" AutoEventWireup="true" CodeFile="assign-ins-inspect.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="features_instructor_instructor_inspect" %>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="add-new" style="display:flex; justify-content: end; margin-bottom: 10px;">
    <a href="lesson-insert.aspx">Add New Lesson</a>
</div>
    <form id="form1" class="grid-form" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="sno" DataSourceID="SqlDataSource1" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="100%">
    <Columns>
        <asp:BoundField DataField="sno" HeaderText="S.No." ReadOnly="True" SortExpression="ID"  ItemStyle-CssClass="auto-width-cell" />
        <asp:BoundField DataField="stdName" HeaderText="Student Name" ReadOnly="True" SortExpression="ID"  />
<asp:BoundField DataField="email" HeaderText="Student email" SortExpression="" />
<asp:BoundField DataField="ins" HeaderText="Instructor Name" SortExpression="" />
<asp:BoundField DataField="course" HeaderText="Course Title" SortExpression="" />
        
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
    SelectCommand="SELECT s.STUDENT_NAME AS stdName, s.EMAIL AS email, 
ci.INSTRUCTOR_NAME AS ins, c.COURSE_NAME AS course, ROW_NUMBER() OVER (ORDER BY ics.INSTRUCTOR_ID) AS sno
FROM INSTRUCTOR_COURSE_STUDENT ics JOIN STUDENTS s ON s.S_NO = ics.STUDENT_NO 
JOIN COURSE c ON c.COURSE_ID = ics.COURSE_ID JOIN COURSE_INSTRUCTOR ci ON ci.INSTRUCTOR_ID = ics.INSTRUCTOR_ID "
    DeleteCommand="DELETE FROM LESSON WHERE id = :ID">
    <DeleteParameters>
        <asp:Parameter Name="ID" Type="Int32" />
    </DeleteParameters>
</asp:SqlDataSource>

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
    </style>
    <link href="css/instructor-inspect.css" rel="stylesheet" />
</asp:Content>

