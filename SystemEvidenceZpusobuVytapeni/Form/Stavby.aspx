<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Stavby.aspx.cs" Inherits="SystemEvidenceZpusobuVytapeni.Form.Stavby" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"> 
    <table style="width:100%; table-layout: fixed;">        
        <tr>
            <td align="right" class="auto-style1">Id:</td>
            <td class="auto-style1">
                <asp:TextBox ID="Id" runat="server" OnTextChanged="Id_TextChanged"></asp:TextBox>
            </td>
            <td align="right" class="auto-style1">Číslo stavby na KU:</td>
            <td class="auto-style1"><asp:TextBox ID="Cislo_stavby_na_KU" runat="server" OnTextChanged="Cislo_stavby_na_KU_TextChanged"></asp:TextBox>
                <br />
            </td>
        </tr>

        <tr>
            <td align="right">&nbsp;</td>
            <td align="left">
                <asp:CompareValidator ID="CompareId" runat="server" ErrorMessage="Není číslo!" ControlToValidate="Id" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
            </td>
            <td align="right">&nbsp;</td>
            <td align="left">
                <asp:CompareValidator ID="CompareCisloStavby" runat="server" ErrorMessage="Není číslo!" ControlToValidate="Cislo_stavby_na_KU" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
            </td>
        </tr>

        <tr>
            <td align="right">Typ:</td>
            <td>
                <asp:ListBox ID="Typ" runat="server" EnableViewState="False" OnSelectedIndexChanged="Typ_SelectedIndexChanged" Rows="1" Width="165px">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>RD</asp:ListItem>
                    <asp:ListItem>byt</asp:ListItem>
                    <asp:ListItem>hospodářská budova</asp:ListItem>
                    <asp:ListItem>obecní budova</asp:ListItem>
                    <asp:ListItem>chata</asp:ListItem>
                </asp:ListBox>
                <br />
            </td>
            <td align="right">Název KU:</td>
            <td>
    <asp:TextBox ID="Nazev_KU" runat="server" OnTextChanged="Nazev_KU_TextChanged"></asp:TextBox>
                <br />
            </td>
        </tr>

        <tr>
            <td align="right">&nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="right">&nbsp;</td>
            <td align="left">
                <asp:CompareValidator ID="CompareNazevKU" runat="server" ErrorMessage="Není řetězec!" ControlToValidate="Nazev_KU" Operator="DataTypeCheck"></asp:CompareValidator>
                </td>
        </tr>

        <tr>
            <td align="right" class="auto-style2">Ulice:</td>
            <td class="auto-style2">
    <asp:TextBox ID="Ulice" runat="server" OnTextChanged="Ulice_TextChanged"></asp:TextBox>
        
                <br />
        
            </td>
            <td align="right" class="auto-style2">Datum kolaudace:</td>
            <td class="auto-style2"><asp:TextBox ID="Datum_kolaudace" runat="server" OnTextChanged="Datum_kolaudace_TextChanged"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td> &nbsp;</td>
            <td> 
                <asp:CompareValidator ID="CompareUlice" runat="server" ErrorMessage="Není řetězec!" ControlToValidate="Ulice" Operator="DataTypeCheck"></asp:CompareValidator>
        
                </td>
            <td> &nbsp;</td>
            <td> 
                <asp:CompareValidator ID="CompareDatum" runat="server" ControlToValidate="Datum_kolaudace" ErrorMessage="Není správné datum!" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
            </td>
        </tr>

        <tr>
            <td align="right" class="auto-style2">Číslo popisné:</td>
            <td class="auto-style13"><asp:TextBox ID="Cislo_popisne" runat="server" OnTextChanged="Cislo_popisne_TextChanged"></asp:TextBox>
                <br />
            </td>
            <td align="right" class="auto-style13"></td>
            <td class="auto-style13">
                &nbsp;</td>
        </tr>

        <tr>
            <td> 
                <asp:Label ID="Uspesnost" runat="server"></asp:Label>
            </td>
            <td> 
                <asp:CompareValidator ID="CompareCisloPopisne" runat="server" ErrorMessage="Není číslo!" ControlToValidate="Cislo_popisne" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
            <td>&nbsp;</td>
            <td> &nbsp;</td>
        </tr>
    </table>
     
    <table style="width:100%;">
        <tr>
            <td align="center">
        
    <asp:Button ID="Vložení" runat="server" OnClick="Vložení_Click" Text="Vložit stavbu" Height="30px" Width="108px" style="margin-bottom: 0px" /> 
            </td>
            <td align="center">
    <asp:Button ID="Změna" runat="server" OnClick="Změna_Click" Text="Změnit stavbu" Height="30px" Width="108px" />
        
            </td>
                        <td align="center">
    <asp:Button ID="Uložit" runat="server" Text="Uložit stavbu" Height="30px" Width="115px" OnClick="Ulozit_Click" Visible="False" />
        
            </td>
            <td align="center">
    <asp:Button ID="Stavby_vlastnici" runat="server" OnClick="Stavby_vlastnici_Click" Text="Seznam staveb a vlastníků" Height="30px" Width="200px" />
            </td>
            <td align="center"> 
    <asp:Button ID="Seznam_staveb" runat="server" OnClick="Seznam_staveb_Click" Text="Seznam staveb" Height="30px" Width="130px" />
            </td>
            <td align="center">
    <asp:Button ID="Seznam_vlastniku" runat="server" OnClick="Seznam_vlastniku_Click" Text="Seznam vlastníků" Height="30px" Width="140px" />
        
            </td>
        </tr>
    </table>

    <br />

    <table style="width:100%; table-layout: fixed;">
        <tr>
            <td>
    
    <table style="border-style: solid; " class="auto-style17">
        <tr>
            <td class="auto-style8">Vložení vlastníka stavby</td>
            <td class="auto-style18"></td>
        </tr>
        <tr>
            <td class="auto-style8" align="right">Stavba:</td>
            <td class="auto-style18">
                <asp:DropDownList ID="ListStavbaV" runat="server">
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td class="auto-style10"></td>
            <td class="auto-style19">
            </td>
        </tr>

        <tr>
            <td align="right" class="auto-style8">Vlastník:</td>
            <td class="auto-style18">
                <asp:DropDownList ID="ListVlastnikV" runat="server">
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style20">
                &nbsp;</td>
        </tr>
                
        <tr>
            <td class="auto-style8">
                <asp:Label ID="Uspesne_vlozeni_vlastnika" runat="server"></asp:Label>
            </td>
            <td class="auto-style18" align="center">
    <asp:Button ID="Potvrzeni_vlozeni" runat="server" Text="Vložit" OnClick="Potvrzeni_vlozeni_Click" Height="30px" Width="115px" />
            </td>
        </tr>
    </table>
            </td>
            <td>
    
    <table style="border-style: solid; " class="auto-style17">
        <tr>
            <td class="auto-style29">Změna vlastníka stavby</td>
            <td class="auto-style30"></td>
        </tr>
        <tr>
            <td class="auto-style8" align="right">Stavba:</td>
            <td class="auto-style14">
                <asp:DropDownList ID="ListStavbaZ" runat="server">
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td class="auto-style10"></td>
            <td class="auto-style15">
                </td>
        </tr>

        <tr>
            <td align="right" class="auto-style8">Vlastník:</td>
            <td class="auto-style14">
                <asp:DropDownList ID="ListVlastnikZ" runat="server">
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style16">
                &nbsp;</td>
        </tr>
                
        <tr>
            <td class="auto-style8">
                <asp:Label ID="Uspesna_zmena_vlastnika" runat="server"></asp:Label>
            </td>
            <td class="auto-style14" align="center">
    <asp:Button ID="Potvrzeni_zmeny" runat="server" Text="Změnit" OnClick="Potvrzeni_zmeny_Click" Height="30px" Width="115px" />
            </td>
        </tr>
    </table>
    
            </td>
        </tr>
    </table>

    <br />

    <table style="width:100%; table-layout: fixed;">        
        <tr>
            <td class="auto-style1" align="right">
                Vložení způsobu vytápění</td>
            <td class="auto-style1">
            </td>
        </tr>

        <tr>
            <td class="auto-style1" align="right">
                Stavba:</td>
            <td class="auto-style1">
                <asp:DropDownList ID="Stavba_zpusob" runat="server">
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td class="auto-style1">
                &nbsp;</td>
            <td class="auto-style1">
            </td>
        </tr>

        <tr>
            <td class="auto-style1" align="right">
                Způsob vytápění:</td>
            <td class="auto-style1">
                <asp:ListBox ID="Zpusob_vytapeni_vlozeni" runat="server" EnableViewState="False" Rows="1" Width="171px" OnSelectedIndexChanged="Zpusob_vytapeni_vlozeni_SelectedIndexChanged">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>elektrika</asp:ListItem>
                    <asp:ListItem>plyn</asp:ListItem>
                    <asp:ListItem>tuhá paliva</asp:ListItem>
                    <asp:ListItem>tepelné čerpadlo</asp:ListItem>
                </asp:ListBox>
            </td>
        </tr>

        <tr>
            <td class="auto-style1">
                &nbsp;</td>
            <td class="auto-style1">
            </td>
        </tr>

        <tr>
            <td class="auto-style1" align="right">
                Platnost od:</td>
            <td class="auto-style1">
                <asp:TextBox ID="Platnost_od_v" runat="server" OnTextChanged="Platnost_od_v_TextChanged" ></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="auto-style1">
                <asp:Label ID="Uspesne_vlozeni_zpusobu" runat="server"></asp:Label>
                    </td>
            <td class="auto-style1">
                <asp:CompareValidator ID="ComparePlatnostOd" runat="server" ControlToValidate="Platnost_od_v" ErrorMessage="Není správné datum!" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
            </td>
        </tr>

        <tr>
            <td align="center">
    <asp:Button ID="Potvrzeni_vlozeni_zpusobu" runat="server" Text="Vložit způsob" OnClick="Potvrzeni_vlozeni_zpusobu_Click" Height="30px" Width="115px" />
                </td>
            <td align="center">
                <asp:Button ID="Zmena_zpusobu" runat="server" Height="30px" OnClick="Zmena_zpusobu_Click" Text="Změnit způsob" Width="115px" />
            </td>
        </tr>

        <tr>
            <td>
    
                &nbsp;</td>
            <td>
    
                &nbsp;</td>
        </tr>
    </table>
    
    <br />

    <table style="width:100%;">
        <tr>
            <td>
                <asp:Button ID="Stavby_kontroly" runat="server" OnClick="Stavby_kontroly_Click" Text="Stavby neprošly kontrolami" Width="241px" />
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="Stavby_topi" runat="server" OnClick="Stavby_topi_Click" Text="Stavby topí tuhými palivy" Width="241px" />
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="seznam_zpusobu" runat="server" OnClick="seznam_zpusobu_Click" Text="Seznam způsobů vytápění" Width="241px" />
            </td>
        </tr>
    </table>
    <br />

    </asp:Content>



<asp:Content ID="Content3" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            height: 33px;
        }
        .auto-style2 {
            height: 25px;
        }
        .auto-style8 {
            height: 33px;
            width: 185px;
        }
        .auto-style9 {
            width: 185px;
        }
        .auto-style10 {
            height: 25px;
            width: 185px;
        }
        .auto-style13 {
            width: 186px;
        }
        .auto-style14 {
            height: 33px;
            width: 257px;
        }
        .auto-style15 {
            height: 25px;
            width: 257px;
        }
        .auto-style16 {
            width: 257px;
        }
        .auto-style17 {
            height: 196px;
            width: 100%;
        }
        .auto-style18 {
            height: 33px;
            width: 275px;
        }
        .auto-style19 {
            height: 25px;
            width: 275px;
        }
        .auto-style20 {
            width: 275px;
        }
        .auto-style29 {
            height: 32px;
            width: 185px;
        }
        .auto-style30 {
            height: 32px;
            width: 257px;
        }
        .auto-style31 {
            margin-top: 0px;
        }
    </style>
</asp:Content>




