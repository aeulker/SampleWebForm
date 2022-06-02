<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/Account.Master" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="OdevUI.Category.CategoryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainTitle" runat="server">
    <h2>Kategori İşlemleri</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainBody" runat="server">
     <div style="display:inline-table;">
         <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
         <hr />
        <asp:GridView ID="gvCategoryList" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                        AllowPaging="True" ShowFooter="True"
                        OnRowDeleting="gvCategoryList_RowDeleting"
                        OnRowEditing="gvCategoryList_RowEditing" 
                        OnPageIndexChanging="gvCategoryList_PageIndexChanging" 
                        OnRowCancelingEdit="gvCategoryList_RowCancelingEdit" 
                        OnRowCommand="gvCategoryList_RowCommand" 
                        OnRowUpdating="gvCategoryList_RowUpdating" 
                        Width="900px" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" EmptyDataText="Tanımlı Kategori Bulunmamaktadır" ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:TemplateField HeaderText="Id">
                    <ItemTemplate>
                        <asp:Label ID="lblCategoryId" runat="server" Text='<%# Eval("Id") %>' Width="50"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Kategori Adı">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCategoryName" runat="server" Text='<%# Eval("CategoryName")%>' Width="300"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtNCategoryName" runat="server"  Width="300"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCategoryName" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Resim">
                    <EditItemTemplate>
                        <asp:FileUpload ID="fuCategoryImageUrl" runat="server" Width="300" />
                    </EditItemTemplate>
                    <FooterTemplate>
                         <asp:FileUpload ID="fuNCategoryImageUrl" runat="server" Width="300" />
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Image ID="imgImageUrl" runat="server"  Width="100"  Height="100" ImageUrl='<%# Eval("ImageUrl") %>' />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button" ShowEditButton="True" EditText="Düzenle" HeaderText="Düzenle" UpdateText="Güncelle" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:CommandField>
                <asp:CommandField ButtonType="Button" DeleteText="Sil" HeaderText="Sil" ShowDeleteButton="True">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:CommandField>
                <asp:TemplateField HeaderText="Ekle">
                    <FooterTemplate>
                        <asp:Button ID="btnAdd" runat="server" CommandName="AddNew" Text="Ekle" />
                    </FooterTemplate>
                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
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
