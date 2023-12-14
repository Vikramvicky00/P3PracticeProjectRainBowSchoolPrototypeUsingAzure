<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="SchoolWebApplicationUI.Teacher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2>Teachers</h2>

        <div class="mb-3">
            <asp:Button ID="btnAddTeacher" runat="server" CssClass="btn btn-primary" Text="Add Teacher" OnClick="btnAddTeacher_Click" />
        </div>

        <asp:GridView ID="GridViewTeachers" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" OnRowEditing="GridViewTeachers_RowEditing" OnRowCancelingEdit="GridViewTeachers_RowCancelingEdit" OnRowUpdating="GridViewTeachers_RowUpdating" OnRowDeleting="GridViewTeachers_RowDeleting">
            <Columns>
                <asp:BoundField DataField="TeacherID" HeaderText="Teacher ID" ReadOnly="True" ItemStyle-CssClass="text-center" />
                <asp:BoundField DataField="TeacherName" HeaderText="Teacher Name" ItemStyle-CssClass="text-center" />
                <asp:BoundField DataField="Subject" HeaderText="Subject Name" ItemStyle-CssClass="text-center" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-sm btn-danger" ItemStyle-CssClass="text-center" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>


