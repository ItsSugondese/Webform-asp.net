﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="course-insert.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="features_course_course_insert" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <div style="display: flex; align-items: center; color: #A62A22">
     <i class="fa fa-arrow-left"></i>
     <a style="margin-left: 3px" href="course-inspect.aspx">Go Back</a>
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
            <div class="form-group">
                <asp:TextBox ID="courseNameBox" runat="server" CssClass="form-control item" Placeholder="Course Title"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="courseNameBox" ErrorMessage="Course title is required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            
            <asp:Button ID="Button1" runat="server" Text="Create" CssClass="btn btn-block create-account" OnClick="Button1_Click" OnClientClick=" myFunction();" />
   
</div>
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

            var name = document.getElementById('<%= courseNameBox.ClientID %>').value;
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