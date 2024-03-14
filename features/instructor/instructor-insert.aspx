<%@ Page Language="C#" AutoEventWireup="true" CodeFile="instructor-insert.aspx.cs" Inherits="features_instructor_instructor_insert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
                <table class="auto-style1">
            <tr>
                <td class="auto-style2">Instructor Name</td>
                <td class="auto-style3">
                    <asp:TextBox ID="nameBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="nameBox" ErrorMessage="Instructor name is must" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            
        </table>
        <div>

            <asp:Button ID="SubmitButton" runat="server" Text="Button" OnClick="Button1_Click"  />

        </div>
    </form>

    <a href="instructor-inspect.aspx">Go To</a>
</body>
</html>
