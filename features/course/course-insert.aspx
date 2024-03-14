<%@ Page Language="C#" AutoEventWireup="true" CodeFile="course-insert.aspx.cs" Inherits="features_course_course_insert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 122px;
        }


        .auto-style3 {
            width: 152px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Course Name</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="courseNameBox" runat="server" Width="158px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="courseNameBox" Display="Dynamic" ErrorMessage="Providing course name is must" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Instructor</td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="ddlOptions" runat="server" AutoPostBack="true" Width="160px">
                            <asp:ListItem Text="Select an Instructor" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlOptions" ErrorMessage="Please select an instructor" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>

        </div>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </p>
    </form>
</body>
</html>
