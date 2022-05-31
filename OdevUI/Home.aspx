<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/Main.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="OdevUI.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainBody" runat="server">
    <div style="display:flex;justify-content:center;height:300px;">
           <asp:AdRotator ID="adBanner" AdvertisementFile="~/Content/adv.xml" runat="server" Height="300px" Width="750px"  />
    </div>
    <div style="height:100px;">

    </div>
</asp:Content>
