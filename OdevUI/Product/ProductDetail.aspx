<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/Main.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="OdevUI.Product.ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainBody" runat="server">
    <asp:HiddenField ID="hdnProductId" runat="server" />

    <h2 style="text-align: center;">
        <asp:Label ID="lblProductName" runat="server" Text="Product Name"></asp:Label></h2>
    <h5 style="text-align: center;">
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></h5>
    <table style="width: 80%; margin-left: 10%;">

        <tr style="height: 300px;">
            <td style="width: 50%">
                <table style="width: 100%; height: 100%">
                    <tr>
                        <td>
                            <asp:Image ID="imgProductShowCasePicture" Width="250" Height="250" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ListView ID="lstProductPictures" GroupItemCount="4" runat="server" DataKeyNames="Id">
                                <LayoutTemplate>
                                    <asp:PlaceHolder ID="groupPlaceholder" runat="server" />
                                </LayoutTemplate>
                                <GroupTemplate>
                                    <div>
                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                    </div>
                                </GroupTemplate>
                                <ItemTemplate>
                                    <asp:Image ID="productPicture" Width="100" Height="100" runat="server" ImageUrl='<%#  Eval("ImageUrl") %>' />
                                </ItemTemplate>
                                <EmptyItemTemplate>
                                </EmptyItemTemplate>
                            </asp:ListView>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 50%;">
                <table style="width: 100%;">

                    <tr style="height: 40px;">
                        <td style="float: right; background-color: yellow; font-size: 20px;">
                            <asp:Label ID="lblOldUnitPrice" runat="server" Text=""></asp:Label>
                            ₺
                        </td>
                    </tr>
                    <tr style="height: 40px;">
                        <td style="float: right; background-color: red; color: white; font-size: 20px;">
                            <asp:Label ID="lblDiscount" runat="server" Text=""></asp:Label>% İndirim
                        </td>
                    </tr>
                    <tr style="height: 40px;">
                        <td style="float: right; font-size: 20px;">
                            <asp:Label ID="lblUnitPrice" runat="server" Text=""></asp:Label>₺
                        </td>
                    </tr>
                    <tr style="height: 40px;">
                        <td style="float: right;">Adet:<asp:TextBox ID="txtProductCount" runat="server" TextMode="Number" Style="text-align: center; margin-left: 10px;" Width="70" Text="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 60px;">
                        <td style="float: right;">
                            <asp:ImageButton ID="btnAddToCart" runat="server" Width="150" Height="40" ImageUrl="~/Content/Images/addtocart.png" OnClick="btnAddToCart_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 100%;">
                                <tr style="height: 40px;">
                                    <td style="border-top: solid; border-top-width: 1px; width: 35%;">Yaş Aralığı</td>
                                    <td style="border-top: solid; border-top-width: 1px; width: 65%;">:
                                        <asp:Label ID="lblAgeRange" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height: 40px;">
                                    <td style="border-top: solid; border-top-width: 1px;">Ürün Kategorisi</td>
                                    <td style="border-top: solid; border-top-width: 1px;">:<asp:Label ID="lblCategoryName" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>

                    </tr>

                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="border-top: solid; border-top-width: 1px;">
                <h4>Ürün Açıklaması</h4>
                <div>
                    <asp:Label ID="lblProductDescription" runat="server" Text=""></asp:Label>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
