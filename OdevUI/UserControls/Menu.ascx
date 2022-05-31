<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="OdevUI.UserControls.Menu" %>

<div>


    <asp:Menu ID="menuHeader" runat="server" BackColor="#2596BE" DynamicHorizontalOffset="2"
        Font-Names="Verdana" Font-Size="0.8em" ForeColor="White" Orientation="Horizontal"
        StaticSubMenuIndent="10px">
        <DynamicHoverStyle BackColor="#27809e" ForeColor="White" />
        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <DynamicMenuStyle BackColor="#F7F6F3" />
        <DynamicSelectedStyle BackColor="#5D7B9D" />
        <Items>
<%--            <asp:MenuItem NavigateUrl="~/anasayfa.aspx" Text="Ana Sayfa" Value="Ana Sayfa"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/kategoriler.aspx" Text="Katagoriler" Value="Katagoriler"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/urunler.aspx" Text="Ürünler" Value="Ürünler"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/hakkimizda.aspx" Text="Hakkımızda" Value="Hakkımızda"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/iletisim.aspx" Text="İletişim" Value="İletişim"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/magazalar.aspx" Text="Mağazalar" Value="Mağazalar">
                <asp:MenuItem NavigateUrl="~/magazalar.aspx?magazaId=34" Text="İstanbul" Value="İstanbul"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/magazalar.aspx?magazaId=6" Text="Ankara" Value="Ankara"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/magazalar.aspx?magazaId=35" Text="İzmir" Value="İzmir"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/subeler.aspx" Text="Şubeler" Value="Şubeler">
                <asp:MenuItem NavigateUrl="~/subeler.aspx?subeId=1" Text="Maramara" Value="Maramara"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/subeler.aspx?subeId=2" Text="Ege" Value="Ege"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/subeler.aspx?subeId=3" Text="Akdeniz" Value="Akdeniz"></asp:MenuItem>
            </asp:MenuItem>--%>
        </Items>
        <StaticHoverStyle BackColor="#27809e" ForeColor="White" />
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <StaticSelectedStyle BackColor="#5D7B9D" />
    </asp:Menu>
</div>
