<%@ Page Language="C#" AutoEventWireup="true" CodeFile="progress-insert.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="features_course_course_insert" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="display: flex; align-items: center; color: #A62A22">
        <i class="fa fa-arrow-left"></i>
        <a style="margin-left: 3px" href="progress.aspx">Go Back</a>
    </div>
    <div class="registration-form">
        <form id="form1" runat="server">
            <div class="form-icon">
                <span id="registerSpan" runat="server">Update Student Enrollment Details</span>
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="form-group">
                        <label>Lesson Status</label>
                        <asp:TextBox ID="statusBox" runat="server" CssClass="form-control item" Placeholder="Lesson Title"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="statusBox" ErrorMessage="Enrolled date is required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Lesson Accessed Date</label>
                        <asp:TextBox ID="accessBox" runat="server" CssClass="form-control item" Placeholder="Lesson Title" type="date"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="accessBox" ErrorMessage="Enrolled date is required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group" style="margin-top: 20px">
                        <label>Select Student</label>
                        <asp:DropDownList ID="studentOptions" runat="server" AutoPostBack="true" Width="100%" CssClass="select">
                            <asp:ListItem Text="Select a student" Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="studentOptions" Display="Dynamic" ErrorMessage="Please select a student" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Select Course</label>
                        <asp:DropDownList ID="ddlOptions" runat="server" AutoPostBack="true" Width="100%" CssClass="select" OnSelectedIndexChanged="ddlOptions_SelectedIndexChanged">
                            <asp:ListItem Text="Select a course" Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlOptions" Display="Dynamic" ErrorMessage="Please select a course" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>


                    <div class="form-group" style="margin-top: 20px">
                        <label>Select Lesson</label>
                        <asp:DropDownList ID="insOptions" runat="server" AutoPostBack="true" Width="100%" CssClass="select">
                            <asp:ListItem Text="Select a Lesson" Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="insOptions" Display="Dynamic" ErrorMessage="Please select a course" ForeColor="Red"></asp:RequiredFieldValidator>

                    </div>
                    <asp:Button ID="Button1" runat="server" Text="Create" CssClass="btn btn-block create-account" OnClick="Button1_Click" OnClientClick=" myFunction();" />


                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>


        </form>
    </div>

    <div id="snackbar">
        <span id="snackbarSpan" runat="server"></span>
    </div>


</asp:Content>

<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
    <script>

        function myFunction() {
            // Get the snackbar DIV

            var name = document.getElementById('<%= insOptions.ClientID %>').value;
            console.log(name)
            if (name.trim() !== '') {
                var x = document.getElementById("snackbar");

                // Add the "show" class to DIV
                x.className = "show";

                setTimeout(function () {
                    x.className = x.className.replace("show", "");
                }, 3000);
            }
        }
    </script>

    <style>
        . /*auto-style1 {
            padding: 3px;
            margin: 0;
            -webkit-border-radius: 4px;
            -moz-border-radius: 4px;
            border-radius: 4px;
            border: 2px solid silver;
            outline: none;
            display: inline-block;
            -webkit-appearance: none;
            -moz-appearance: none;
            cursor: pointer;
        }*/
    </style>

</asp:Content>
