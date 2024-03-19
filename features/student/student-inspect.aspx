<%@ Page Language="C#" AutoEventWireup="true" CodeFile="student-inspect.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="features_instructor_instructor_inspect" %>

<%--<!DOCTYPE html>--%>

<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>--%>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="add-new" style="display:flex; justify-content: end; margin-bottom: 10px;">
     <a href="student-insert.aspx">Add New Student</a>
 </div>
    <form id="form1" runat="server">
        <div class="table-grid auto-style1">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" 
                OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"  Width="100%" AllowSorting="True">
    <Columns>
        <asp:BoundField DataField="sno" HeaderText="S.No." ReadOnly="True" SortExpression="sno"  ItemStyle-CssClass="auto-width-cell" />
        <asp:BoundField DataField="NAME" HeaderText="Student Name" SortExpression="NAME" />
        <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
        <asp:BoundField DataField="contact" HeaderText="Contact" SortExpression="contact" />
        <asp:BoundField DataField="dob" HeaderText="Date of Birth" SortExpression="dob" />
        <asp:BoundField DataField="country" HeaderText="Country" SortExpression="country" />
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
    SelectCommand="SELECT s.S_NO AS id, s.STUDENT_NAME AS name, s.CONTACT, TO_CHAR(s.DOB, 'YYYY-MM-DD') AS dob, 
    s.EMAIL, s.COUNTRY, ROW_NUMBER() OVER (ORDER BY S_NO) AS sno 
FROM STUDENT s"
    DeleteCommand="DELETE FROM STUDENT WHERE S_NO = :ID">
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

