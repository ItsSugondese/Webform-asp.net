<%@ Page Language="C#" AutoEventWireup="true" CodeFile="student-course-mapping-insert.aspx.cs" Inherits="features_student_course_mapping_student_course_mapping_insert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 138px;
        }
        .auto-style3 {
            width: 166px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Student Name</td>
                <td class="auto-style3">
                    <asp:DropDownList ID="stdDown" runat="server" Width="162px">
                        <asp:ListItem Text="Select a Student" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Selecting student is must" ControlToValidate="stdDown" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Course Name</td>
                <td class="auto-style3">
                    <asp:DropDownList ID="courseDown" runat="server" Width="164px">
                        <asp:ListItem Text="Select a course" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Selecting course is must" ControlToValidate="courseDown" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Enroll Date</td>
               
                <td class="auto-style3">
                    <asp:TextBox ID="dateBox" runat="server" type="date"></asp:TextBox>
                </td>
                <td>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="dateBox" ErrorMessage="Enroll date is must" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
            </tr>
        </table>
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
    </form>
</body>


</html>
