<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Seznam_staveb.aspx.cs" Inherits="SystemEvidenceZpusobuVytapeni.Form.Seznam" EnableEventValidation = "false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridViewStavby" runat="server" AllowPaging="True" OnPageIndexChanging="OnPaging" PageSize="10" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Výběr" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Button ID="btnVybrat" runat="server" Text="Vybrat" OnClick="btnVybrat_Click"/>
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



        <asp:DetailsView ID="DetailsViewStavby" runat="server" DataKeyNames="Id_stavby" AutoGenerateRows="False" Height="50px" Width="125px">
        <Fields>
            <asp:TemplateField HeaderText="Id_stavby" SortExpression="Id_stavby">
                <ItemTemplate>
                    <asp:Literal runat="server" ID="idStavby" Text='<%# Bind("Id_stavby") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Typ_stavby" SortExpression="Typ_stavby">
                <ItemTemplate>
                    <asp:Label ID="labelTypStavby" runat="server" Text='<%# Bind("Typ_stavby") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ListTyp" runat="server" SelectedValue='<%# Bind("Typ_stavby") %>'>
                        <asp:ListItem Text="RD" Value="RD"  />
                        <asp:ListItem Text="byt" Value="byt" />
                        <asp:ListItem Text="hospodářská budova" Value="hospodářská budova" />
                        <asp:ListItem Text="obecní budova" Value="obecní budova" />
                        <asp:ListItem Text="chata" Value="chata" />
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Ulice" SortExpression="Ulice">
                <ItemTemplate>
                    <asp:Label ID="labelUlice" runat="server" Text='<%# Bind("Ulice") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextUlice" runat="server" Text='<%# Bind("Ulice") %>' />
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="TextUlice" CssClass="error">*</asp:RequiredFieldValidator>--%>
                </EditItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Cislo_popisne" SortExpression="Cislo_popisne">
                <ItemTemplate>
                    <asp:Label ID="labelCisloPopisne" runat="server" Text='<%# Bind("Cislo_popisne") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextCislo_popisne" runat="server" Text='<%# Bind("Cislo_popisne") %>' />
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="TextCislo_popisne" CssClass="error">*</asp:RequiredFieldValidator>--%>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Cislo_stavby_na_KU" SortExpression="Cislo_stavby_na_KU">
                <ItemTemplate>
                    <asp:Label ID="labelCisloStavbyNaKU" runat="server" Text='<%# Bind("Cislo_stavby_na_KU") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextCislo_stavby" runat="server" Text='<%# Bind("Cislo_stavby_na_KU") %>' />
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="TextCislo_stavby" CssClass="error">*</asp:RequiredFieldValidator>--%>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Nazev_KU" SortExpression="Nazev_KU">
                <ItemTemplate>
                    <asp:Label ID="labelNazevKU" runat="server" Text='<%# Bind("Nazev_KU") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextNazev" runat="server" Text='<%# Bind("Nazev_KU") %>' />
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="TextNazev" CssClass="error">*</asp:RequiredFieldValidator>--%>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Datum_kolaudace" SortExpression="Datum_kolaudace">
                <ItemTemplate>
                    <asp:Label ID="labelDatumKolaudace" runat="server" Text='<%# Bind("Datum_kolaudace", "{0:MM/dd/yyyy}") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextDatum" runat="server" Text='<%# Bind("Datum_kolaudace", "{0:MM/dd/yyyy}") %>' />
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="TextDatum" CssClass="error">*</asp:RequiredFieldValidator>--%>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Aktualizace" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Button ID="btnAktualizovat" runat="server" Text="Aktualizuj" OnClick="btnAktualizovat_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Fields>
    </asp:DetailsView>
    <br />
    </asp:Content>
