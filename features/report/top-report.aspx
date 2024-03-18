<%@ Page Language="C#" AutoEventWireup="true" CodeFile="top-report.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="features_instructor_instructor_inspect" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <form id="form1" class="grid-form" runat="server">
        <asp:DropDownList ID="countryDropdown" runat="server" AutoPostBack="true" Width="100%" CssClass="select" OnSelectedIndexChanged="countryDropdown_SelectedIndexChanged">
            <asp:ListItem>Student Enrollment</asp:ListItem>
            <asp:ListItem>Course Instructor</asp:ListItem>
            <asp:ListItem>Best Course</asp:ListItem>
        </asp:DropDownList>

        <div class="add-new" style="display: flex; justify-content: end; margin: 20px 0px;">
            
            <asp:TextBox ID="dateBox" runat="server" AutoPostBack="true" type="date" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>

        </div>
        <div>
            <div style="text-align: center">
                <span id="stdName" runat="server"></span>
            </div>

            <div id="detail_card" style="width: 100%;  display: none; justify-content: end; align-items: center" runat="server">
                <div class="col">
                    <h5 id="country" class="card-title text-uppercase text-muted mb-0" runat="server">Traffic</h5>
                    <span id="naming" runat="server" class="h2 font-weight-bold mb-0">350,897  </span><span id="dob"  runat="server">(2024-01-1)</span>
                </div>
                <div>
                    <span class="h4" id="contact" runat="server">0423432</span>
                </div>
        </div>
        <asp:Repeater ID="repeater" runat="server">
            <HeaderTemplate>
                <table border="1" style="width: 100%">
                    <tr>
                        <%--<th>SNo</th>--%>
                        <th>Course Id</th>
                        <th>Course Name</th>
                        <th>Total Enrolled</th>
                        <th>Enroll on selected day</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <%--<td><%# Eval("sno") %></td>--%>
                    <td><%# Eval("cid") %></td>
                    <td><%# Eval("course") %></td>
                    <td><%# Eval("total") %></td>
                    <td><%# Eval("byday") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>

        </div>

    </form>
</asp:Content>


<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
    <script>
$(function() {
  $("#datepicker").datepicker({
    changeMonth: true,
    changeYear: true,
    showButtonPanel: true,
    dateFormat: 'yy-mm' // Format for year and month
  });
});
    </script>
    <style type="text/css">
        body {
            font-family: Arial;
            font-size: 10pt;
        }

        .auto-width-cell {
            width: 30px !important;
            text-align: left
        }

        table {
            border: 1px solid #ccc;
            border-collapse: collapse;
            background-color: #fff;
            width: fit-content;
        }

            table th {
                background-color: #B8DBFD;
                color: #333;
                font-weight: bold;
                text-align: center;
            }

            table th, table td {
                padding: 5px;
                border: 1px solid #ccc;
                text-align: center;
            }

            table, table table td {
                border: 0px solid #ccc;
            }
    </style>
    <link href="css/instructor-inspect.css" rel="stylesheet" />
</asp:Content>

