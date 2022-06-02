<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="User.ascx.cs" Inherits="OdevUI.UserControls.User" %>


<table style="width: 80%; float: right">
    <tr>
        <td style="width: 40%;">
            <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
        </td>
        <td style="width: 20%;">
            <asp:HyperLink ID="lnkLogin" runat="server" NavigateUrl="~/User/Login.aspx">Giriş</asp:HyperLink>

            <asp:HyperLink ID="lnkLogout" runat="server" NavigateUrl="~/User/Logout.aspx">Çıkış</asp:HyperLink>
        </td>
        <td style="width: 40%; display: block;">
            <ul style="list-style:none;padding-left:0px;margin:1px">
                <li style="margin-bottom:3px;">
                    <asp:HyperLink ID="lnkCart" runat="server" NavigateUrl="~/User/ShoppingCart.aspx">Sepetim</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkAccount" Style="white-space: nowrap;" runat="server" NavigateUrl="~/User/UserInfo.aspx">Benim Sayfam</asp:HyperLink></li>
            </ul>

        </td>
    </tr>
</table>
