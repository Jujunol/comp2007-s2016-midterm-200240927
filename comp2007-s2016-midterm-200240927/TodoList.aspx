<%@ Page Title="Todo List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoList.aspx.cs" Inherits="comp2007_s2016_midterm_200240927.TodoList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="page-header">
            <h1>Your Todo List</h1>
        </div>
        <div>
            <p><a href="TodoDetails.aspx" class="btn btn-sm btn-success"><i class="fa fa-plus"></i></a></p>
        </div>
        <asp:GridView ID="TodoGridView" runat="server" AutoGenerateColumns="false" DataKeyNames="TodoID"
            CssClass="table table-bordered table-hover table-striped"
            OnRowDataBound="TodoGridView_RowDataBound"
            OnRowDeleting="TodoGridView_RowDeleting">
            <Columns>
                <asp:BoundField DataField="TodoID" HeaderText="ID" />
                <asp:BoundField DataField="TodoName" HeaderText="Name" />
                <asp:BoundField DataField="TodoNotes" HeaderText="Notes" />

                <%--<asp:CheckBoxField DataField="Completed" HeaderText="Completed" />--%>
                <asp:TemplateField HeaderText="Completed">
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="Completed" OnCheckedChanged="Completed_CheckedChanged" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o fa-lg'></i> Edit" NavigateUrl="TodoDetails.aspx"
                    DataNavigateUrlFields="TodoID" DataNavigateUrlFormatString="TodoDetails.aspx?todoID={0}"
                    ControlStyle-CssClass="btn btn-success btn-sm" />
                <asp:CommandField HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete" 
                    ShowDeleteButton="true" ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />

            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
