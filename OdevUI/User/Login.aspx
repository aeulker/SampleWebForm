<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OdevUI.User.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainBody" runat="server">
    <div style="display: flex; justify-content: center;">
        <br />
 
 
        <table style="height: 150px; width: 350px;">
            <tr>
                <td colspan="3">
                         <asp:Label ID="lblError" runat="server" Text="" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center">
                    <p style="text-align: center">Giriş</p>
                </td>
            </tr>
            <tr>
                <td>Kullanıcı Adı</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Parola</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                </td>
            </tr>
<%--            <tr>
     Cookie kullanılamadığı için geliştirilmiyor
                <td>Beni Hatırla</td>
                <td>:</td>
                <td>
                    <asp:CheckBox ID="cbxRememberMe" runat="server" />
                </td>
            </tr>--%>
            <tr>
                <td colspan="3">
                    <asp:Button ID="btnLogin" runat="server" Text="Giriş" Style="margin-left: 35%; width: 100px;" OnClick="btnLogin_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <p>Parolanızı hatırlamıyorsanız sistem yöneticisi ile irtibata geçiniz. Üye olmak için     
                        <asp:HyperLink ID="lnkRegister" runat="server" NavigateUrl="~/User/Register.aspx">tıklayınız</asp:HyperLink></p>


                </td>
            </tr>
        </table>
    </div>
</asp:Content>
