<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Seznam_vytapeni.aspx.cs" Inherits="SystemEvidenceZpusobuVytapeni.Form.Seznam_vytapeni" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridViewZpusobu" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="Typ_vytapeni,Id_stavby" >
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="Typ_vytapeni" HeaderText="Typ_vytapeni" SortExpression="Typ_vytapeni" />
            <asp:BoundField DataField="Id_stavby" HeaderText="Id_stavby" SortExpression="Id_stavby" />
        </Columns>
    </asp:GridView>
    &nbsp;<br />
    <asp:DetailsView ID="DetailsViewZpusobu" runat="server" AutoGenerateRows="False" DataKeyNames="Typ_vytapeni,Id_stavby" DataSourceID="ObjectDataSource2" Height="50px" Width="125px" OnItemUpdated="DetailsViewZpusobu_ItemUpdated">
        <Fields>
            <asp:BoundField DataField="Typ_vytapeni" HeaderText="Typ_vytapeni" ReadOnly="True" SortExpression="Typ_vytapeni" />
            <asp:BoundField DataField="Id_stavby" HeaderText="Id_stavby" ReadOnly="True" SortExpression="Id_stavby" />
            <asp:TemplateField HeaderText="platnost_od" SortExpression="platnost_od">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Platnost_od", "{0:MM/dd/yyyy}") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextOd" runat="server" Text='<%# Bind("platnost_od", "{0:MM/dd/yyyy}") %>' />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextOd" CssClass="error">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="platnost_do" SortExpression="platnost_do">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Platnost_do", "{0:MM/dd/yyyy}") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextDo" runat="server" Text='<%# Bind("platnost_do", "{0:MM/dd/yyyy}") %>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" />
        </Fields>
    </asp:DetailsView>
    <br />
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DataObjectTypeName="SystemEvidenceZpusobuVytapeni.Db.DTO.Zpusob_vytapeni" SelectMethod="Select_id" TypeName="SystemEvidenceZpusobuVytapeni.Db.DAO.Zpusob_vytapeniTable" UpdateMethod="Update">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridViewZpusobu" DefaultValue="" Name="idStavba" PropertyName="SelectedDataKey.Values[1]" Type="Int32" />
            <asp:ControlParameter ControlID="GridViewZpusobu" DefaultValue="" Name="zpusobVytapeni" PropertyName="SelectedDataKey.Values[0]" Type="String" />
            <asp:Parameter Name="Db" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="Select" TypeName="SystemEvidenceZpusobuVytapeni.Db.DAO.Zpusob_vytapeniTable">
        <SelectParameters>
            <asp:Parameter Name="Db" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </asp:Content>
