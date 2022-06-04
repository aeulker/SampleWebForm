<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/Account.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="OdevUI.Messages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainTitle" runat="server">
    <h2>Mesaj İşlemleri</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainBody" runat="server">
    <hr/>
    <asp:GridView ID="gvMessages" runat="server" AllowPaging="True" DataKeyNames="Id"
        AutoGenerateColumns="False" CellPadding="3" PageSize="20"  Width="1000px"
        OnPageIndexChanging="gvMessages_PageIndexChanging"
           OnRowDeleting="gvMessages_RowDeleting" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="Kullanıcı" >
            <ItemStyle Width="150px" />
            </asp:BoundField>
            <asp:BoundField DataField="SenderName" HeaderText="Gönderici Adı" >
            <ItemStyle Width="150px" />
            </asp:BoundField>
            <asp:BoundField DataField="Email" HeaderText="Email" >
            <ItemStyle Width="150px" />
            </asp:BoundField>
            <asp:BoundField DataField="Subject" HeaderText="Başlık" >
            <ItemStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="Message" HeaderText="Mesaj" >
            <ItemStyle Width="400px" />
            </asp:BoundField>
            <asp:CommandField ButtonType="Button" DeleteText="Sil" ShowDeleteButton="True" >
            <ItemStyle Width="70px" />
            </asp:CommandField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>

</asp:Content>
