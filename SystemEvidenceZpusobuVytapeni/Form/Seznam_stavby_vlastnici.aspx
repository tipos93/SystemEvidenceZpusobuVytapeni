<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Seznam_stavby_vlastnici.aspx.cs" Inherits="SystemEvidenceZpusobuVytapeni.Form.Seznam_stavby_vlastnici" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridViewStavbyVlastnici" runat="server" AllowPaging="True" OnPageIndexChanging="OnPaging" PageSize="10" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField SortExpression="Name" HeaderText="Typ stavby" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal runat="server" ID="ltrTypStavby" Text='<%# Bind("Typ_stavby") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="Name" HeaderText="Ulice" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal runat="server" ID="ltrUliceStavby" Text='<%# Bind("Ulice") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="Name" HeaderText="Číslo popisné" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal runat="server" ID="ltrCisloPopisneStavby" Text='<%# Bind("Cislo_popisne") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="Name" HeaderText="Jméno vlastníka" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal runat="server" ID="ltrJmenoVlastnika" Text='<%# Bind("Jmeno") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField SortExpression="Name" HeaderText="Příjmení vlastníka" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal runat="server" ID="ltrPrijmeniVlastnika" Text='<%# Bind("Prijmeni") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField SortExpression="Name" HeaderText="Datum narození vlastníka" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal runat="server" ID="ltrNarozeniVlastnika" Text='<%# Bind("Datum_narozeni", "{0:dd.MM.yyyy}") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
