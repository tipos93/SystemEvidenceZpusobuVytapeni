﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Seznam_staveb.aspx.cs" Inherits="SystemEvidenceZpusobuVytapeni.Form.Seznam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridViewStavby" runat="server" AllowPaging="True" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Výběr" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Button ID="btnVybrat" runat="server" Text="Vybrat" OnClick="btnVybrat_Click" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="Name" HeaderText="Typ stavby" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal runat="server" ID="ltrId" Text='<%# Bind("Id_stavby") %>' Visible="false"></asp:Literal>
                    <asp:Literal runat="server" ID="ltrTyp" Text='<%# Bind("Typ_stavby") %>'></asp:Literal>
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
        </Columns>
    </asp:GridView>
    <br />
    
    <asp:DetailsView ID="DetailsViewStavby" runat="server" AutoGenerateRows="False" Height="50px" Width="125px" DataKeyNames="Id_stavby" OnItemUpdated="DetailsViewStavby_ItemUpdated">
        <Fields>
            
            <asp:BoundField DataField="Id_stavby" HeaderText="Id_stavby" ReadOnly="True" SortExpression="Id_stavby" />
            
            <asp:TemplateField HeaderText="typ_stavby" SortExpression="typ_stavby">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Typ_stavby") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ListTyp" runat="server" SelectedValue='<%# Bind("typ_stavby") %>'>
                        <asp:ListItem Text="RD" Value="RD"  />
                        <asp:ListItem Text="byt" Value="byt" />
                        <asp:ListItem Text="hospodářská budova" Value="hospodářská budova" />
                        <asp:ListItem Text="obecní budova" Value="obecní budova" />
                        <asp:ListItem Text="chata" Value="chata" />
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="ulice" SortExpression="ulice">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Ulice") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextUlice" runat="server" Text='<%# Bind("ulice") %>' />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextUlice" CssClass="error">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="cislo_popisne" SortExpression="cislo_popisne">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Cislo_popisne") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextCislo_popisne" runat="server" Text='<%# Bind("cislo_popisne") %>' />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextCislo_popisne" CssClass="error">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="cislo_stavby_na_KU" SortExpression="cislo_stavby_na_KU">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Cislo_stavby_na_KU") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextCislo_stavby" runat="server" Text='<%# Bind("cislo_stavby_na_KU") %>' />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextCislo_stavby" CssClass="error">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="nazev_KU" SortExpression="nazev_KU">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Nazev_KU") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextNazev" runat="server" Text='<%# Bind("nazev_KU") %>' />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextNazev" CssClass="error">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="datum_kolaudace" SortExpression="datum_kolaudace">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Datum_kolaudace ", "{0:MM/dd/yyyy}") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextDatum" runat="server" Text='<%# Bind("datum_kolaudace", "{0:MM/dd/yyyy}") %>' />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextDatum" CssClass="error">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
            </asp:TemplateField>
            
            <asp:CommandField ShowEditButton="True" />
        </Fields>
    </asp:DetailsView>
    <br />
    </asp:Content>
