<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vlastnici.aspx.cs" Inherits="SystemEvidenceZpusobuVytapeni.Form.Vlastnici" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

        .auto-style1 {
            height: 33px;
        }
    .auto-style2 {
        height: 29px;
    }
        .auto-style3 {
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%; table-layout: fixed;">
        <tr>
            <td align="right" class="auto-style1">
                Id:</td>
            <td class="auto-style1">
                <asp:TextBox ID="Id" runat="server" OnTextChanged="Id_TextChanged"></asp:TextBox>
            </td>
            <td align="right" class="auto-style1">Trvalé bydliště:</td>
            <td class="auto-style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">&nbsp;</td>
            <td align="left">
                <asp:CompareValidator ID="CompareId" runat="server" ErrorMessage="Není číslo!" ControlToValidate="Id" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
            </td>
            <td align="right">&nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">Jméno:</td>
            <td>
                <asp:TextBox ID="Jmeno" runat="server" OnTextChanged="Jmeno_TextChanged" ></asp:TextBox>
            </td>
            <td align="right">Ulice:</td>
            <td>
                <asp:TextBox ID="Ulice" runat="server" OnTextChanged="Ulice_TextChanged" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">&nbsp;</td>
            <td align="left">
                <asp:CompareValidator ID="CompareJmeno" runat="server" ControlToValidate="Jmeno" ErrorMessage="Není řetězec!" Operator="DataTypeCheck"></asp:CompareValidator>
            </td>
            <td align="right">&nbsp;</td>
            <td align="left">
                <asp:CompareValidator ID="CompareUlice" runat="server" ErrorMessage="Není řetězec!" ControlToValidate="Ulice" Operator="DataTypeCheck"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style2">Příjmení:</td>
            <td class="auto-style2">
                <asp:TextBox ID="Prijmeni" runat="server" OnTextChanged="Prijmeni_TextChanged" ></asp:TextBox>
            </td>
            <td align="right" class="auto-style2">Číslo popisné:</td>
            <td class="auto-style2">
                <asp:TextBox ID="Cislo_popisne" runat="server" OnTextChanged="Cislo_popisne_TextChanged" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:CompareValidator ID="ComparePrijmeni" runat="server" ErrorMessage="Není řetězec!" ControlToValidate="Prijmeni" Operator="DataTypeCheck"></asp:CompareValidator>
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:CompareValidator ID="CompareCisloPopisne" runat="server" ControlToValidate="Cislo_popisne" ErrorMessage="Není hodnota!" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style1">Datum narození:</td>
            <td class="auto-style1">
                <asp:TextBox ID="Datum_narozeni" runat="server" OnTextChanged="Datum_narozeni_TextChanged" ></asp:TextBox>
            </td>
            <td align="right" class="auto-style1">Město:</td>
            <td class="auto-style1">
                <asp:TextBox ID="Mesto" runat="server" OnTextChanged="Mesto_TextChanged" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:CompareValidator ID="CompareDatumNarozeni" runat="server" ErrorMessage="Není datum!" ControlToValidate="Datum_narozeni" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:CompareValidator ID="CompareMesto" runat="server" ErrorMessage="Není řetězec!" ControlToValidate="Mesto" Operator="DataTypeCheck"></asp:CompareValidator>
            </td>
        </tr>

        <tr>
            <td align="right">
                Datum úmrtí:</td>
            <td>
                <asp:TextBox ID="Datum_umrti" runat="server" OnTextChanged="Datum_umrti_TextChanged" ></asp:TextBox>
            </td>
            <td align="right">PSČ:</td>
            <td>
                <asp:TextBox ID="PSC" runat="server" OnTextChanged="PSC_TextChanged" ></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td align="right">
                &nbsp;</td>
            <td>
                <asp:CompareValidator ID="CompareDatumUmrti" runat="server" ErrorMessage="Není datum!" ControlToValidate="Datum_umrti" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:CompareValidator ID="ComparePSC" runat="server" ErrorMessage="Není řetězec!" ControlToValidate="PSC" Operator="DataTypeCheck"></asp:CompareValidator>
            </td>
        </tr>

        <tr>
            <td align="right">
                Rodné číslo:</td>
            <td>
                <asp:TextBox ID="Rodne_cislo" runat="server" OnTextChanged="Rodne_cislo_TextChanged" ></asp:TextBox>
            </td>
            <td align="right">Aktuální vlastník:</td>
            <td>
                <asp:ListBox ID="AktualniVlastnik" runat="server" EnableViewState="False"  Rows="1" Width="166px" OnSelectedIndexChanged="AktualniVlastnik_SelectedIndexChanged">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>ne</asp:ListItem>
                    <asp:ListItem>ano</asp:ListItem>
                </asp:ListBox>
            </td>
        </tr>

        <tr>
            <td align="right" class="auto-style3"></td>
            <td class="auto-style3">
                <asp:CompareValidator ID="CompareRodneCislo" runat="server" ErrorMessage="Není řetězec!" ControlToValidate="Rodne_cislo" Operator="DataTypeCheck"></asp:CompareValidator>
            </td>
            <td class="auto-style3"></td>
            <td class="auto-style3"></td>
        </tr>

        <tr>
            <td align="right" class="auto-style1">
                Pohlaví:</td>
            <td class="auto-style1">
                <asp:ListBox ID="Pohlavi" runat="server" EnableViewState="False" Rows="1" Width="164px" OnSelectedIndexChanged="Pohlavi_SelectedIndexChanged">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>muž</asp:ListItem>
                    <asp:ListItem>žena</asp:ListItem>
                </asp:ListBox>
            </td>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
        </tr>

        <tr>
            <td align="left">
                <asp:Label ID="Uspesnost" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
     
    <table style="width:100%;">
        <tr>
            <td align="center">
        
    <asp:Button ID="Vložení" runat="server" OnClick="Vložení_Click" Text="Vložit vlastníka" Height="30px" Width="140px" style="margin-bottom: 0px" /> 
            </td>
            <td align="center">
    <asp:Button ID="Změna" runat="server" OnClick="Změna_Click" Text="Změnit vlastníka" Height="30px" Width="140px" />
        
            </td>
            <td align="center">
    <asp:Button ID="Uložení" runat="server" Text="Uložit vlastníka" Height="30px" Width="140px" OnClick="Uložení_Click" Visible="False" />
        
            </td>
            <td align="center">
    <asp:Button ID="Seznam_vlastniku" runat="server" OnClick="Seznam_vlastniku_Click" Text="Seznam vlastníků" Height="30px" Width="140px" />
        
            </td>
        </tr>
    </table>

    </asp:Content>
