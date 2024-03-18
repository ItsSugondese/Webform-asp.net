<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lesson-insert.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="features_course_course_insert" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <div style="display: flex; align-items: center; color: #A62A22">
     <i class="fa fa-arrow-left"></i>
     <a style="margin-left: 3px" href="lesson-inspect.aspx">Go Back</a>
 </div>
    <div class="registration-form">
    <form id="form1" runat="server">
        <div class="form-icon">
    <span id="registerSpan" runat="server">Register Course</span>
</div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="form-group">
                <asp:TextBox ID="lessonNoBox" runat="server" CssClass="form-control item" Placeholder="Lesson Number" type="number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="lessonNoBox" ErrorMessage="Lesson No. is required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:TextBox ID="lessonNameBox" runat="server" CssClass="form-control item" Placeholder="Lesson Title"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="lessonNameBox" ErrorMessage="Lesson title is required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            
            <div class="form-group">
                <asp:DropDownList ID="ddlOptions" runat="server" AutoPostBack="true" Width="100%" CssClass="select" >
    <asp:ListItem Text="Select a course" Value=""></asp:ListItem>
</asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlOptions" Display="Dynamic" ErrorMessage="Please select a course" ForeColor="Red"></asp:RequiredFieldValidator>
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

            var name = document.getElementById('<%= lessonNameBox.ClientID %>').value;
            var lesson = document.getElementById('<%= lessonNoBox.ClientID %>').value;
            console.log(lesson)
            if (name.trim() !== '' && lesson.trim() !== '') {
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
        


        ./*auto-style1 {
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