<%@ Page Title="Todo List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoList.aspx.cs" Inherits="comp2007_s2016_midterm_200240927.TodoList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="page-header">
            <h1>Your Todo List</h1>
        </div>
        <asp:GridView ID="TodoGridView" runat="server" AutoGenerateColumns="false" DataKeyNames="TodoID"
            CssClass="table table-bordered table-hover table-striped"
            OnRowDataBound="TodoGridView_RowDataBound">
            <Columns>
                <asp:BoundField ID="TodoID" DataField="TodoID" HeaderText="ID" />
                <asp:BoundField DataField="TodoName" HeaderText="Name" />
                <asp:BoundField DataField="TodoNotes" HeaderText="Notes" />

                <asp:TemplateField HeaderText="Completed">
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="Completed" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
