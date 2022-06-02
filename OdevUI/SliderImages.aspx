<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/Account.Master" AutoEventWireup="true" CodeBehind="SliderImages.aspx.cs" Inherits="OdevUI.SliderResimleri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainTitle" runat="server">
    <h2>Slider İşlemleri</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainBody" runat="server">
    <div style="display: inline-table;">
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        <hr />
        <asp:GridView ID="gvSliderImageList" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
            AllowPaging="True" ShowFooter="True"
            OnRowDeleting="gvSliderImageList_RowDeleting"
            OnRowEditing="gvSliderImageList_RowEditing"
            OnPageIndexChanging="gvSliderImageList_PageIndexChanging"
            OnRowCancelingEdit="gvSliderImageList_RowCancelingEdit"
            OnRowCommand="gvSliderImageList_RowCommand"
            OnRowUpdating="gvSliderImageList_RowUpdating"
            Width="900px" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" EmptyDataText="Kayıtlı resim bulunmamaktadır" ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:TemplateField HeaderText="Id" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblSliderImageId" runat="server" Text='<%# Eval("Id") %>' Width="50"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Resim">
                    <EditItemTemplate>
                        <asp:FileUpload ID="fuSliderImageUrl" runat="server" Width="300" />
                        <asp:Label ID="lblSliderImageUrl" runat="server" Text='<%# Eval("ImageUrl") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:FileUpload ID="fuNSliderImageUrl" runat="server" Width="300" />
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Image ID="imgImageUrl" runat="server" Width="100" Height="100" ImageUrl='<%# Eval("ImageUrl") %>' />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Url">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtNavigateUrl" runat="server" Text='<%# Eval("NavigateUrl") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtNNavigateUrl" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblNavigateUrl" runat="server" Text='<%# Eval("NavigateUrl") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Alternatif Yazı">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtAlternateText" runat="server" Text='<%# Eval("AlternateText") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtNAlternateText" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblAlternateText" runat="server" Text='<%# Eval("AlternateText") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button" ShowEditButton="True" EditText="Düzenle" HeaderText="Düzenle" UpdateText="Güncelle">
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
