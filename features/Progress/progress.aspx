<%@ Page Language="C#" AutoEventWireup="true" CodeFile="progress.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="features_instructor_instructor_inspect" %>

<%--<!DOCTYPE html>--%>

<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>--%>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="add-new" style="display:flex; justify-content: end; margin-bottom: 10px;">
     <a href="progress-insert.aspx">Add Progress</a>
 </div>
    <form id="form1" runat="server">
        <div class="table-grid auto-style1">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="sid,lid,cid" DataSourceID="SqlDataSource1" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"  Width="100%" AllowSorting="True">
    <Columns>
        <%--<asp:BoundField DataField="sno" HeaderText="S.No." ReadOnly="True" SortExpression="ID"  ItemStyle-CssClass="auto-width-cell" />--%>
  
        <asp:BoundField DataField="name" HeaderText="Student Name" SortExpression="email" />
        <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
        <asp:BoundField DataField="course" HeaderText="Course" SortExpression="course" />
        <asp:BoundField DataField="title" HeaderText="Lesson Title" SortExpression="title" />
        <asp:BoundField DataField="status" HeaderText="Lesson Status" SortExpression="stats" />
        <asp:BoundField DataField="accDate" HeaderText="Last Accessed Date" SortExpression="accDate" />
        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-primary" OnClick="btnEdit_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" CommandName="Delete" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
    SelectCommand="SELECT  s.STUDENT_NAME AS name, s.EMAIL, l.LESSON_TITLE AS title, 
sp.LESSON_STATUS AS status , to_char(sp.LAST_ACCESSED_DATE, 'YYYY-MM-DD') AS accDate,
l.ID AS lid, l.COURSE_ID AS cid, s.S_NO AS sid,
c.COURSE_NAME as course 
FROM STUDENT_PROGRESS sp 
JOIN STUDENT s ON s.S_NO = sp.S_NO 
JOIN LESSON l ON l.ID = sp.LESSON_ID 
JOIN COURSE c ON c.COURSE_ID  = l.COURSE_ID "
    DeleteCommand="DELETE FROM STUDENT_PROGRESS 
WHERE S_NO = :sid 
  AND LESSON_ID = :lid 
  AND LESSON_ID IN (SELECT ID FROM LESSON WHERE COURSE_ID = :cid) ">
    <DeleteParameters>
        <asp:Parameter Name="ID" Type="Int32" />
    </DeleteParameters>
</asp:SqlDataSource>

        </div>

    </form>
    </asp:Content>

<%--</body>
</html>--%>
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

