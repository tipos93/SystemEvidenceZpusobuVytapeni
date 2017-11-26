<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Seznam_stavby_vlastnici.aspx.cs" Inherits="SystemEvidenceZpusobuVytapeni.Form.Seznam_stavby_vlastnici" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:BoundField DataField="Id_stavby" HeaderText="Id_stavby" SortExpression="Id_stavby" />
            <asp:BoundField DataField="Id_vlastnika" HeaderText="Id_vlastnika" SortExpression="Id_vlastnika" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="Select" TypeName="SystemEvidenceZpusobuVytapeni.Db.DAO.StavbaVlastnikTable">
        <SelectParameters>
            <asp:Parameter Name="Db" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
