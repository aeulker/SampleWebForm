<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountMenu.ascx.cs" Inherits="OdevUI.UserControls.AccountMenu" %>
<div>


    <asp:Menu ID="menuAccount" runat="server" BackColor="#2596BE" DynamicHorizontalOffset="2"
        Font-Names="Verdana" Font-Size="0.8em" ForeColor="White" Orientation="Vertical"
        StaticSubMenuIndent="10px">
        <DynamicHoverStyle BackColor="#27809e" ForeColor="White" />
        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <DynamicMenuStyle BackColor="#F7F6F3" />
        <DynamicSelectedStyle BackColor="#5D7B9D" />
        <Items>
        </Items>
        <StaticHoverStyle BackColor="#27809e" ForeColor="White" />
        <StaticMenuItemStyle HorizontalPadding="15px" VerticalPadding="5px" Width="150" />
        <StaticSelectedStyle BackColor="#5D7B9D" />
    </asp:Menu>
</div>
