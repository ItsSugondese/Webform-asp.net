<%@ Page Language="C#" AutoEventWireup="true" CodeFile="instructor-inspect.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="features_instructor_instructor_inspect" %>





<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="add-new" style="display:flex; justify-content: end; margin-bottom: 10px;">
        <a href="instructor-insert.aspx">Add New Instructor</a>
    </div>
    <form id="form1" class="grid-form" runat="server">
                                    <asp:TextBox ID="idBox" runat="server" CssClass="" Visible="False" 
                                        ClientIDMode="Static"></asp:TextBox>
        <div class="table-grid auto-style1">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="100%" AllowSorting="True">
                <Columns>
                    <asp:BoundField DataField="sno" HeaderText="S.No." ReadOnly="True" SortExpression="sno" ItemStyle-CssClass="auto-width-cell" />
                    <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>

                            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" CssClass="btn btn-primary" />
                            <%--<button type="button" class="btn btn-danger" onclick="openPopUp(<%# Eval("ID") %>);">Delete</button>--%>

                            
                    <asp:Button ID="btnDelete" runat="server" Text="Delete"  CssClass="btn btn-danger" OnClick="btnDelete_Click" />

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT ROW_NUMBER() OVER (ORDER BY INSTRUCTOR_ID) AS sno, INSTRUCTOR_ID AS ID, ci.INSTRUCTOR_NAME AS NAME FROM COURSE_INSTRUCTOR ci" DeleteCommand="DELETE FROM COURSE_INSTRUCTOR WHERE INSTRUCTOR_ID = :ID">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
    </asp:SqlDataSource>
            <div id="modal">
                <p class="message">Are you sure you want to delete this item?</p>
                <div class="options">
                    <%--<asp:Button ID="btnDelete" runat="server" Text="Yes"  CssClass="btn2" OnClick="btnDelete_Click" />--%>
                    <button type="button" class="btn2" onclick="closePopUp()">No</button>
                </div>
            </div>
</asp:Content>




<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <script>
        function openPopUp(id) {
            var x = document.getElementById("modal");
            x.className = "show";
            console.log(id);
            console.log("idBox.ClientID:", '<%= idBox.ClientID %>');
            document.getElementById('myInput').value = id;
       }

        function closePopUp() {
            var x = document.getElementById("modal");
            x.className = "hide";
        }

        
    </script>
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

