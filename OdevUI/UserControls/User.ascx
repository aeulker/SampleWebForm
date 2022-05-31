<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="User.ascx.cs" Inherits="OdevUI.UserControls.User" %>

<div>
    <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
    <asp:HyperLink ID="lnkLogin" runat="server" NavigateUrl="~/User/Login.aspx">Giriş</asp:HyperLink>
    <br />
    <asp:HyperLink ID="lnkLogout" runat="server" NavigateUrl="~/User/Logout.aspx">Çıkış</asp:HyperLink>
    <br />
    <asp:HyperLink ID="lnkCart" runat="server" NavigateUrl="~/User/ShoppingCart.aspx">Sepetim</asp:HyperLink>
    <br />
    <asp:HyperLink ID="lnkAccount" runat="server" NavigateUrl="~/User/UserInfo.aspx">Benim Sayfam</asp:HyperLink>
    <br />
</div>
