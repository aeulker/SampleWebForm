<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/Main.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="OdevUI.User.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainBody" runat="server">

    <div style="display: flex; justify-content: center;">
        <br />


        <table style="height: 150px; width: 350px;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center">
                    <p style="text-align: center">Kayıt</p>
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
            <tr>
                <td>Adı</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Soyadı</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtSirName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Cinsiyet</td>
                <td>:</td>
                <td>
                    <asp:DropDownList ID="ddlGender" runat="server">
                        <asp:ListItem Value="0">Diğer</asp:ListItem>
                        <asp:ListItem Value="1">Erkek</asp:ListItem>
                        <asp:ListItem Value="2">Kadın</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Email</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Telefon</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Adress</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="3" ></asp:TextBox>
                </td>
            </tr>
 
            <tr>
                <td colspan="3">
                    <asp:Button ID="btnRegister" runat="server" Text="Kayıt" Style="margin-left: 35%; width: 100px;" OnClick="btnRegister_Click"  />
                </td>
            </tr>

        </table>
    </div>
</asp:Content>
