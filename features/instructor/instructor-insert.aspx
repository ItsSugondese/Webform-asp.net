<%@ Page Language="C#" AutoEventWireup="true" CodeFile="instructor-insert.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="features_instructor_instructor_insert" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="display: flex; align-items: center; color: #A62A22">
        <i class="fa fa-arrow-left"></i>
        <a style="margin-left: 3px" href="instructor-inspect.aspx">Go Back</a>
    </div>
    <div class="registration-form">
        <form id="form2" runat="server">
            <div class="form-icon">
                <span id="registerSpan" runat="server">Register Instructor</span>
            </div>


           
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="form-group">
                            <asp:TextBox ID="nameBox" runat="server" CssClass="form-control item" Placeholder="Instructor Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="nameBox" ErrorMessage="Instructor name is required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <asp:Button ID="Button1" runat="server" Text="Create" CssClass="btn btn-block create-account" OnClick="Button1_Click" OnClientClick=" myFunction();" />
                        
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            
        </form>


    </div>



    <!-- The actual snackbar -->
    <div id="snackbar">
        <span id="snackbarSpan" runat="server"></span>
    </div>






</asp:Content>


<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
    <script>
        function myFunction() {
            // Get the snackbar DIV

            var name = document.getElementById('<%= nameBox.ClientID %>').value;
            if (name.trim() !== '') {
                var x = document.getElementById("snackbar");

                // Add the "show" class to DIV
                x.className = "show";

                setTimeout(function () {
                    x.className = x.className.replace("show", "");
                }, 3000);
            }

            // After 3 seconds, remove the show class from DIV

            //return false;
        }

    </script>
    <style>
        body {
            background-color: #dee9ff;
        }

        
    </style>
</asp:Content>
