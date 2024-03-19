<%@ Page Language="C#" AutoEventWireup="true" CodeFile="enroll-inspect.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="features_instructor_instructor_inspect" %>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="add-new" style="display:flex; justify-content: end; margin-bottom: 10px;">
    <a href="enroll-insert.aspx">Enroll New Student</a>
</div>
    <form id="form1" class="grid-form" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="sid, cid" DataSourceID="SqlDataSource1" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="100%">
    <Columns>
        <asp:BoundField DataField="sno" HeaderText="S.No." ReadOnly="True" SortExpression="ID"  ItemStyle-CssClass="auto-width-cell" />
        <asp:BoundField DataField="std" HeaderText="Student Name" ReadOnly="True" SortExpression="ID"   />
        <asp:BoundField DataField="email" HeaderText="Student Email" ReadOnly="True" SortExpression="ID"   />
<asp:BoundField DataField="course" HeaderText="Course Title" SortExpression="" />
<asp:BoundField DataField="enrollDate" HeaderText="Enrolled Date" SortExpression="" />
<asp:BoundField DataField="hasInstructor" HeaderText="Is Instructor Assign" SortExpression="" />
        <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="set-all-width">
            <ItemTemplate>
                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-primary" OnClick="btnEdit_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" CommandName="Delete" OnClick="btnDelete_Click" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
    SelectCommand="SELECT ROW_NUMBER() OVER (ORDER BY se.S_NO) AS sno,
s.STUDENT_NAME AS std, s.email as email, s.S_NO as sid, c.course_id as cid, c.COURSE_NAME AS course, to_Char(se.ENROLL_DATE, 'YYYY-MM-DD') AS enrollDate ,
CASE WHEN ics.INSTRUCTOR_ID IS NULL THEN 'False' ELSE 'True' END AS hasInstructor
FROM STUDENT_ENROLLMENT se  JOIN STUDENT s ON s.S_NO  = se.S_NO 
JOIN COURSE c ON c.COURSE_ID = se.COURSE_ID 
LEFT JOIN INSTRUCTOR_COURSE_STUDENT ics ON ics.COURSE_ID = se.COURSE_ID AND ics.s_no = se.S_NO  "
    DeleteCommand="DELETE FROM STUDENT_ENROLLMENT
WHERE S_NO=:sid AND COURSE_ID=:cid">
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

