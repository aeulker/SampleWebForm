<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/Account.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="OdevUI.User.UserInfo" %>

<%@ Register Src="~/UserControls/AccountMenu.ascx" TagPrefix="uc1" TagName="AccountMenu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="mainHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainTitle" runat="server">
    <h2>Kullanıcı Bilgileri</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainBody" runat="server">

    <div style="display: flex; justify-content: center;">
        <br />
  
        <table style="height: 150px; width: 350px;">
            <tr>
                <td>Kullanıcı Adı</td>
                <td>:</td>
                <td>
                    <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Parola</td>
                <td>:</td>
                <td>
                    <asp:Label ID="lblPassword" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Adı Soyadi</td>
                <td>:</td>
                <td>

                    <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Cinsiyet</td>
                <td>:</td>
                <td>
                    <asp:Label ID="lblGender" runat="server" Text=""></asp:Label>
                </td>
            </tr>

            <tr>
                <td>Email</td>
                <td>:</td>
                <td>
                    <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Telefon</td>
                <td>:</td>
                <td>
                    <asp:Label ID="lblPhoneNumber" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Adress</td>
                <td>:</td>
                <td>
                    <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                </td>
            </tr>

            <tr>
                <td colspan="3">
                    <asp:Button ID="btnEdit" runat="server" Text="Düzenle" Style="margin-left: 35%; width: 100px;" OnClick="btnEdit_Click" />
                </td>
            </tr>

        </table>
    </div>

</asp:Content>
