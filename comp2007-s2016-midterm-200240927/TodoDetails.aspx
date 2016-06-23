<%@ Page Title="Todo Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoDetails.aspx.cs" Inherits="comp2007_s2016_midterm_200240927.TodoDetails" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container">
         <div class="page-header">
             <h1>Todo Details</h1>
         </div>
         
         <div class="col-md-8 col-md-offset-2">
             <div class="form-group">
                 <label for="Name" class="control-label">Name:</label>
                 <asp:TextBox runat="server" ID="Name" placeholder="The Name of the Note" CssClass="form-control" required="true" />
             </div>

             <div class="form-group">
                 <label for="Notes" class="control-label">Notes:</label>
                 <asp:TextBox runat="server" ID="Notes" placeholder="Additional Notes" CssClass="form-control" required="true" />
             </div>

             <div class="form-group">
                 <label for="Completed" class="control-label">Completed:</label>
                 <asp:CheckBox runat="server" ID="Completed" />
             </div>

             <div class="text-center">
                <asp:Button runat="server" ID="SubmitBtn" CssClass="btn btn-success" Text="Send" OnClick="SubmitBtn_Click" CausesValidation="true" />
                <asp:Button runat="server" ID="ResetBtn" CssClass="btn btn-warning" Text="Cancel" OnClick="ResetBtn_Click" CausesValidation="false" UseSubmitBehavior="false" />                        
            </div>
        </div>
     </div>
</asp:Content>
