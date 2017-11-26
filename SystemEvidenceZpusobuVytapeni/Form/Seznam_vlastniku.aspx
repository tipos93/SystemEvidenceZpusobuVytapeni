<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Seznam_vlastniku.aspx.cs" Inherits="SystemEvidenceZpusobuVytapeni.Form.Seznam_vlastniku" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridViewVlastnici" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Id_vlastnika" DataSourceID="ObjectDataSource1" >
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="Id_vlastnika" HeaderText="Id_vlastnika" SortExpression="Id_vlastnika" />
            <asp:BoundField DataField="Jmeno" HeaderText="Jmeno" SortExpression="Jmeno" />
            <asp:BoundField DataField="Prijmeni" HeaderText="Prijmeni" SortExpression="Prijmeni" />
            <asp:BoundField DataField="Datum_narozeni" HeaderText="Datum_narozeni" SortExpression="Datum_narozeni" />
            <asp:BoundField DataField="Datum_umrti" HeaderText="Datum_umrti" SortExpression="Datum_umrti" />
            <asp:BoundField DataField="Pohlavi" HeaderText="Pohlavi" SortExpression="Pohlavi" />
            <asp:BoundField DataField="Aktualni_vlastnik" HeaderText="Aktualni_vlastnik" SortExpression="Aktualni_vlastnik" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:DetailsView ID="DetailsViewVlastnici" runat="server" AutoGenerateRows="False" DataSourceID="ObjectDataSource2" Height="50px" Width="125px" DataKeyNames="Id_vlastnika" OnItemUpdated="DetailsViewVlastnici_ItemUpdated" >
        <Fields>
            <asp:BoundField DataField="Id_vlastnika" HeaderText="Id_vlastnika" ReadOnly="True" SortExpression="Id_vlastnika" />

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
                    <asp:Label runat="server" Text='<%# Eval("Datum_umrti", "{0:MM/dd/yyyy}") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextDatum_umrti" runat="server" Text='<%# Bind("Datum_umrti", "{0:MM/dd/yyyy}") %>' />
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
            
            <asp:CommandField ShowEditButton="True" />
        </Fields>
    </asp:DetailsView>
    <br />
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="Select_id" TypeName="SystemEvidenceZpusobuVytapeni.Db.DAO.VlastnikTable" UpdateMethod="Update" DataObjectTypeName="SystemEvidenceZpusobuVytapeni.Db.DTO.Vlastnik">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridViewVlastnici" Name="idVlastnik" PropertyName="SelectedValue" Type="Int32" DefaultValue="" />
            <asp:Parameter Name="Db" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="Select" TypeName="SystemEvidenceZpusobuVytapeni.Db.DAO.VlastnikTable">
        <SelectParameters>
            <asp:Parameter Name="Db" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
