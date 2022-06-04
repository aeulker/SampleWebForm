<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/Account.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="OdevUI.Product.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainTitle" runat="server">
    <h3>Ürün İşlemleri</h3>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainBody" runat="server">
    <asp:HiddenField ID="hdnActiveProductId" runat="server" />
    <div style="padding: 0px 20px; width: 100%;">

        <hr />
        <div>
            <table style="width: 100%;">

                <tr>
                    <td style="width: 30%;"></td>
                    <td style="width: 3%;"></td>
                    <td style="width: 67%;"></td>
                </tr>

                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>Ürün Adı</td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Ürün Kategorisi</td>
                    <td>:</td>
                    <td>
                        <asp:DropDownList ID="ddlProductCategory" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Ürün Fiyatı</td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtUnitPrice" TextMode="Number" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>İndirim Tutarı</td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtDiscount" TextMode="Number" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Yaş Aralığı</td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtAgeRange" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Ürün Açıklaması</td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtDescription" TextMode="MultiLine" Rows="5" Width="300" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Kampanya</td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtCampaign" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div style="display: inline-flex; width: 100%;">
            <div style="width: 30%; padding-left: 3px;">
                Ürün Resinleri
            </div>
            <div style="width: 3%">
                :
            </div>
            <div style="width: 67%">
                <asp:Table ID="tblImages" runat="server" Width="500" Visible="false">

                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblImagesMessage" runat="server" Text=""></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:GridView ID="gvProductImageList" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                                AllowPaging="True" ShowFooter="True"
                                OnRowDeleting="gvProductImageList_RowDeleting"
                                OnRowEditing="gvProductImageList_RowEditing"
                                OnPageIndexChanging="gvProductImageList_PageIndexChanging"
                                OnRowCancelingEdit="gvProductImageList_RowCancelingEdit"
                                OnRowCommand="gvProductImageList_RowCommand"
                                OnRowUpdating="gvProductImageList_RowUpdating"
                                Width="250px" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" EmptyDataText="Kayıtlı Resim Bulunmamaktadır" ShowHeaderWhenEmpty="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="Id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProductImageId" runat="server" Text='<%# Eval("Id") %>' Width="50"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Resim">
                                        <EditItemTemplate>
                                            <asp:FileUpload ID="fuProductImageUrl" runat="server" Width="200" />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:FileUpload ID="fuNProductImageUrl" runat="server" Width="200" />
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Image ID="imgImageUrl" runat="server" Width="100" Height="100" ImageUrl='<%# Eval("ImageUrl") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
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
                        </asp:TableCell>
                    </asp:TableRow>

                </asp:Table>
                <asp:Label ID="lblImagesInfo" runat="server" Text="Resim yüklemek için önce ürün kayıt edilmelidir"></asp:Label>
            </div>


        </div>
        <div style="display: flex; justify-content: center; align-items: center; margin-top: 10px;">
            <asp:Button ID="btnSaveProduct" runat="server" Text="Kaydet" Style="width: 100px;" OnClick="btnSaveProduct_Click" />
            <asp:Button ID="btnUpdateProduct" runat="server" Text="Güncelle" Style="width: 100px; margin-left: 20px;" OnClick="btnUpdateProduct_Click" Visible="false" />
            <asp:Button ID="btnClearForm" runat="server" Text="Formu Temizle" Style="width: 100px; margin-left: 20px;" OnClick="btnClearForm_Click" />
        </div>

    </div>

    <div style="padding: 0px 20px; min-width: 1000px; width: 100%;">
        <hr />
        <h3 style="text-align: center;">Ürün Listesi</h3>
        <asp:GridView ID="gvProductList" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
            AllowPaging="True" ShowFooter="True"
            OnRowDeleting="gvProductList_RowDeleting"
            OnPageIndexChanging="gvProductList_PageIndexChanging"
            OnSelectedIndexChanged="gvProductList_SelectedIndexChanged"
            Width="1000px" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Ürün Id">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="ProductName" HeaderText="Ürün Adı" />
                <asp:BoundField DataField="CategoryName" HeaderText="Kategori Name" />
                <asp:BoundField DataField="UnitPrice" HeaderText="Fiyat">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="Discount" HeaderText="İndirim">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="AgeRange" HeaderText="Yaş Aralığı" />
                <asp:BoundField DataField="Campaign" HeaderText="Kampanya" />
                <asp:BoundField DataField="Description" HeaderText="Açıklama" />
                <asp:CommandField ButtonType="Button" DeleteText="Sil" SelectText="Seç" ShowDeleteButton="True" ShowSelectButton="True">
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
