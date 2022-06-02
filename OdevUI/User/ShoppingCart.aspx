<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/Main.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="OdevUI.User.ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainBody" runat="server">
    <div style="width:80%;margin-left:10%;">
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

        <asp:GridView ID="gvShoppingCartList" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
            AllowPaging="True" ShowFooter="True"
            OnRowDeleting="gvShoppingCartList_RowDeleting"
            OnRowEditing="gvShoppingCartList_RowEditing"
            OnPageIndexChanging="gvShoppingCartList_PageIndexChanging"
            OnRowCancelingEdit="gvShoppingCartList_RowCancelingEdit"
            OnRowUpdating="gvShoppingCartList_RowUpdating"
            Width="900px" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
            EmptyDataText="Sepette ürün bulunmamaktadır" 
            ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:TemplateField HeaderText="Id" Visible="False">
                    <EditItemTemplate>
                        <asp:Label ID="lblEShoppingCart" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblShoppingCartId" runat="server" Text='<%# Eval("Id") %>' Width="50px"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ürün Adı">
                    <EditItemTemplate>
                        <asp:Label ID="lblEProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                    </EditItemTemplate>
                     <ItemTemplate>
                        <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Resim">
                    <EditItemTemplate>
                        <asp:Image ID="imgEProductImageUrl" runat="server" Width="100px" Height="100px" ImageUrl='<%# Eval("ProductImageUrl") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="imgProductImageUrl" runat="server" Width="100px" Height="100px" ImageUrl='<%# Eval("ProductImageUrl") %>' />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Miktar">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblQuantity" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Kargo">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtShippingInfo" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblShippingInfo" runat="server" Text="Kargo Bilgisi Girilmedi"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button" ShowEditButton="True" EditText="Satın Al" UpdateText="Kaydet" CancelText="İptal">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:CommandField>
                <asp:CommandField ButtonType="Button" DeleteText="Sepetten Çıkar" ShowDeleteButton="True">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
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
