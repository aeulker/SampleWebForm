<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/Account.Master" AutoEventWireup="true" CodeBehind="UserOrders.aspx.cs" Inherits="OdevUI.User.UserOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainTitle" runat="server">
    <h3>Siparişlerim</h3>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainBody" runat="server">
    <asp:HiddenField ID="hdnActiveOrderId" runat="server" />
    <div style="padding: 0px 20px; width: 100%;">
        <asp:GridView ID="gvOrderDetail" runat="server" AllowPaging="True" DataKeyNames="Id"
            AutoGenerateColumns="False" CellPadding="3" PageSize="20" Width="1000px"
            OnPageIndexChanging="gvOrderDetail_PageIndexChanging"
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Caption="Sipariş Detayı" CaptionAlign="Top" EmptyDataText="Sipariş kaydı bulunmuyor" ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="OrderId" HeaderText="Sipariş No">
                    <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="ProductName" HeaderText="Ürün">
                    <ItemStyle Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="UnitPrice" HeaderText="Birim Fiyat">
                    <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="Quantity" HeaderText="Mikar">
                    <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="Discount" HeaderText="İndirim">
                    <ItemStyle Width="200px" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
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

    </div>
    <hr />
    <div style="padding: 0px 20px; min-width: 1000px; width: 100%;">


        <asp:GridView ID="gvOrders" runat="server" AllowPaging="True" DataKeyNames="OrderId"
            AutoGenerateColumns="False" CellPadding="3" PageSize="20" Width="1000px"
            OnPageIndexChanging="gvOrders_PageIndexChanging"
            OnSelectedIndexChanged="gvOrders_SelectedIndexChanged"
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Caption="Sipariş Listesi" CaptionAlign="Top">
            <Columns>
                <asp:BoundField DataField="OrderId" HeaderText="Sipariş No">
                    <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="OrderDate" HeaderText="Sipariş Tarihi">
                    <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="OrderCount" HeaderText="Sipariş Adedi">
                    <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="OrderTotal" HeaderText="Toplam">
                    <ItemStyle Width="200px" HorizontalAlign="Right" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:CommandField ButtonType="Button" SelectText="Seç" ShowSelectButton="True">
                    <ItemStyle Width="70px" HorizontalAlign="Center" VerticalAlign="Middle" />
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
    </div>
</asp:Content>
