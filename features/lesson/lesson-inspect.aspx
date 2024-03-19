<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lesson-inspect.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="features_instructor_instructor_inspect" %>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="add-new" style="display:flex; justify-content: end; margin-bottom: 10px;">
    <a href="lesson-insert.aspx">Add New Lesson</a>
</div>
    <form id="form1" class="grid-form" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="100%" AllowSorting="True">
    <Columns>
        <asp:BoundField DataField="sno" HeaderText="S.No." ReadOnly="True" SortExpression="sno"  ItemStyle-CssClass="auto-width-cell" />
        <asp:BoundField DataField="lessonNo" HeaderText="Lesson No." ReadOnly="True" SortExpression="ID"  />
<asp:BoundField DataField="NAME" HeaderText="Lesson Title" SortExpression="" />
<asp:BoundField DataField="course" HeaderText="Course Title" SortExpression="" />
        <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="set-all-width">
            <ItemTemplate>
                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-primary" OnClick="btnEdit_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" CommandName="Delete" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
    SelectCommand="SELECT l.id AS id, l.LESSON_NO AS lessonNo, ROW_NUMBER() OVER (ORDER BY id) AS sno, l.LESSON_TITLE AS name, c.COURSE_NAME AS course FROM LESSON l JOIN COURSE c ON c.COURSE_ID = l.COURSE_ID"
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

