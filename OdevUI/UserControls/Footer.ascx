<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="OdevUI.UserControls.Footer" %>
<div>


    <asp:Menu ID="menuFooter" runat="server" BackColor="#2596BE" DynamicHorizontalOffset="2"
        Font-Names="Verdana" Font-Size="0.8em" ForeColor="White" Orientation="Horizontal"
        StaticSubMenuIndent="10px">
        <DynamicHoverStyle BackColor="#27809e" ForeColor="White" />
        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <DynamicMenuStyle BackColor="#F7F6F3" />
        <DynamicSelectedStyle BackColor="#5D7B9D" />
        <Items>
<%--           <asp:MenuItem NavigateUrl="~/Home.aspx" Text="Anasayfa" Value="Anasayfa"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/About.aspx" Text="Hakkımızda" Value="Hakkımızda"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Contact.aspx" Text="İletişim" Value="İletişim"></asp:MenuItem>--%>
        </Items>
        <StaticHoverStyle BackColor="#27809e" ForeColor="White" />
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <StaticSelectedStyle BackColor="#5D7B9D" />
    </asp:Menu>
</div>
 