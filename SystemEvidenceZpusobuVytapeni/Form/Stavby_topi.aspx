<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Stavby_topi.aspx.cs" Inherits="SystemEvidenceZpusobuVytapeni.Form.Stavby_topi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width:100%;overflow:auto">
        <asp:GridView ID="GridViewStavbyTopi" runat="server" AllowPaging="True" DataSourceID="ObjectDataSource1">
        </asp:GridView>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SelectPaliv" TypeName="SystemEvidenceZpusobuVytapeni.Db.DAO.FunkceTable">
        <SelectParameters>
            <asp:Parameter Name="Db" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
