<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Seznam_vytapeni.aspx.cs" Inherits="SystemEvidenceZpusobuVytapeni.Form.Seznam_vytapeni" EnableEventValidation = "false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridViewZpusobu" runat="server" AllowPaging="True" OnPageIndexChanging="OnPaging" PageSize="10" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Výběr" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Button ID="btnVybrat" runat="server" Text="Vybrat" OnClick="btnVybrat_Click"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="Name" HeaderText="Typ stavby" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal runat="server" ID="ltrIdStavby" Text='<%# Bind("Id_stavby") %>' Visible="false"></asp:Literal>
                    <asp:Literal runat="server" ID="ltrTypStavby" Text='<%# Bind("Typ_stavby") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="Name" HeaderText="Ulice" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal runat="server" ID="ltrUlice" Text='<%# Bind("Ulice") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="Name" HeaderText="Číslo popisné" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal runat="server" ID="ltrCisloPopisne" Text='<%# Bind("Cislo_popisne") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="Name" HeaderText="Typ vytápění" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal runat="server" ID="ltrTypVytapeni" Text='<%# Bind("Typ_vytapeni") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:DetailsView ID="DetailsViewZpusobu" runat="server" AutoGenerateRows="False" Height="50px" Width="125px">
        <Fields>
            <asp:TemplateField HeaderText="Typ stavby" SortExpression="Typ stavby">
                <ItemTemplate>
                    <asp:Label runat="server" ID="typStavby" Text='<%# Eval("Typ_stavby") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Ulice" SortExpression="Ulice">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Ulice") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Číslo popisné" SortExpression="Číslo popisné">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Cislo_popisne") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Typ vytápění" SortExpression="Typ vytápění">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Typ_vytapeni") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Platnost od" SortExpression="Platnost od">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Platnost_od", "{0:dd.MM.yyyy}") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Platnost do" SortExpression="Platnost do">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Platnost_do", "{0:dd.MM.yyyy}") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Fields>
    </asp:DetailsView>
    <br />
    </asp:Content>
