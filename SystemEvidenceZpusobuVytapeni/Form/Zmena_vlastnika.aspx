<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Zmena_vlastnika.aspx.cs" Inherits="SystemEvidenceZpusobuVytapeni.Form.Zmena_vlastnika" EnableEventValidation = "false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridViewVlastnici" runat="server" AllowPaging="True" OnPageIndexChanging="OnPaging" PageSize="10" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Výběr" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Button ID="btnVybrat" runat="server" Text="Vybrat" OnClick="btnVybrat_Click"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="Name" HeaderText="Jméno" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal runat="server" ID="ltrId" Text='<%# Bind("Id_vlastnika") %>' Visible="false"></asp:Literal>
                    <asp:Literal runat="server" ID="ltrJmeno" Text='<%# Bind("Jmeno") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="Name" HeaderText="Příjmení" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal runat="server" ID="ltrPrijmeni" Text='<%# Bind("Prijmeni") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="Name" HeaderText="Datum narození" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal runat="server" ID="ltrDatumNarozeni" Text='<%# Bind("Datum_narozeni", "{0:MM/dd/yyyy}") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="Name" HeaderText="Datum úmrtí" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal runat="server" ID="ltrDatumUmrti" Text='<%# Bind("Datum_umrti", "{0:MM/dd/yyyy}") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="Name" HeaderText="Pohlaví" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal runat="server" ID="ltrPohlavi" Text='<%# Bind("Pohlavi") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="Name" HeaderText="Aktuální vlastník" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal runat="server" ID="ltrAktualniVlastnik" Text='<%# Bind("Aktualni_vlastnik") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:DetailsView ID="DetailsViewVlastnici" runat="server" AutoGenerateRows="False" Height="50px" Width="125px" OnItemUpdating="DetailsViewVlastnici_ItemUpdating">
        <Fields>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Label runat="server" ID="IdVlastnika" Text='<%# Eval("Id_vlastnika") %>' Visible="false"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="jmeno" SortExpression="jmeno">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Jmeno") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextJmeno" runat="server" Text='<%# Bind("jmeno") %>' />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextJmeno" CssClass="error">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="prijmeni" SortExpression="prijmeni">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Prijmeni") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextPrijmeni" runat="server" Text='<%# Bind("prijmeni") %>' />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextPrijmeni" CssClass="error">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="datum_narozeni" SortExpression="datum_narozeni">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Datum_narozeni", "{0:MM/dd/yyyy}") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextDatum_narozeni" runat="server" Text='<%# Bind("Datum_narozeni", "{0:MM/dd/yyyy}") %>' />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextDatum_narozeni" CssClass="error">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="datum_umrti" SortExpression="datum_umrti">
                <ItemTemplate>
                    <asp:Label runat="server" Id="datum" Text='<%# Eval("Datum_umrti", "{0:MM/dd/yyyy}") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextDatum_umrti" runat="server" Text='<%# Bind("Datum_umrti", "{0:MM/dd/yyyy}") %>' />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextDatum_umrti" CssClass="error">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="rodne_cislo" SortExpression="rodne_cislo">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Rodne_cislo") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextRodne_cislo" runat="server" Text='<%# Bind("rodne_cislo") %>' />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextRodne_cislo" CssClass="error">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="pohlavi" SortExpression="pohlavi">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Pohlavi") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ListPohlavi" runat="server" SelectedValue='<%# Bind("pohlavi") %>'>
                        <asp:ListItem Text="muž" Value="M"  />
                        <asp:ListItem Text="žena" Value="Z" />
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="trvale_bydliste_ulice" SortExpression="trvale_bydliste_ulice">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Trvale_bydliste_ulice") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextUlice" runat="server" Text='<%# Bind("trvale_bydliste_ulice") %>' />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextUlice" CssClass="error">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="trvale_bydliste_cislo_popisne" SortExpression="trvale_bydliste_cislo_popisne">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Trvale_bydliste_cislo_popisne") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextCislo_popisne" runat="server" Text='<%# Bind("trvale_bydliste_cislo_popisne") %>' />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextCislo_popisne" CssClass="error">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="trvale_bydliste_mesto" SortExpression="trvale_bydliste_mesto">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Trvale_bydliste_mesto") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextMesto" runat="server" Text='<%# Bind("trvale_bydliste_mesto") %>' />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextMesto" CssClass="error">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="trvale_bydliste_PSC" SortExpression="trvale_bydliste_PSC">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Trvale_bydliste_PSC") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextPSC" runat="server" Text='<%# Bind("trvale_bydliste_PSC") %>' />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextPSC" CssClass="error">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="aktualni_vlastnik" SortExpression="aktualni_vlastnik">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Aktualni_vlastnik") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ListAktualnost" runat="server" SelectedValue='<%# Bind("aktualni_vlastnik") %>'>
                        <asp:ListItem Text="ano" Value="A"  />
                        <asp:ListItem Text="ne" Value="N" />
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="btnUpravit" runat="server" CausesValidation="False" 
                        CommandName="Upravit" Text="Upravit" OnClick="btnUpravit_Click"></asp:LinkButton>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:LinkButton ID="btnUpravit" runat="server" CausesValidation="True" 
                        CommandName="Aktualizovat" Text="Aktualizovat" OnClick="btnAktualizovat_Click"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="btnStorno" runat="server" CausesValidation="False" 
                        CommandName="Storno" Text="Storno" OnClick="btnStorno_Click"></asp:LinkButton>
                </EditItemTemplate>
            </asp:TemplateField>
        </Fields>
    </asp:DetailsView>
<br />
</asp:Content>
