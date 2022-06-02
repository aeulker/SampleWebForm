<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/Main.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="OdevUI.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainBody" runat="server">
    <div style="display: flex; justify-content: center; height: 300px;">
        <asp:AdRotator ID="adBanner" AdvertisementFile="~/Content/adv.xml" runat="server" Height="300px" Width="750px" />
    </div>
    <div>

        <asp:Repeater ID="rptCategoryProducts" runat="server" OnItemDataBound="rptCategoryProducts_ItemDataBound">
            <HeaderTemplate>
                <table style="width: 60%; margin-left: 20%;">
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td>
                        <h2 style="text-align: center; color: rgb(37, 150, 190)"><%# Eval("CategoryName") %> <b>Kategoriesindeki Ürünler </b></h2>
                        <asp:HiddenField ID="hdnCategoryId" runat="server" Value='<%# Eval("Id") %>' />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:ListView ID="lvCategoryProduts" runat="server" ItemPlaceholderID="placeHolderProduct">
                            <LayoutTemplate>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width: 25%;"></td>
                                        <td style="width: 35%;"></td>
                                        <td style="width: 40%;"></td>

                                    </tr>
                                    <tr runat="server" id="placeHolderProduct"></tr>
                                </table>

                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr style="height: 150px;">
                                    <td >
                                        <asp:Image ID="imgProduct" runat="server" Width="100" Height="100" ImageUrl='<%# "~"+Eval("ImageUrl") %>' /></td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>Ürün Kategoriesi</td>
                                                <td>:</td>
                                                <td><%#Eval("CategoryName") %></td>
                                            </tr>
                                            <tr>
                                                <td>Yaş Aralığı</td>
                                                <td>:</td>
                                                <td><%#Eval("AgeRange") %></td>
                                            </tr>
                                            <tr>
                                                <td>Ürün Detayı
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:HyperLink ID="lnkProductDetail" NavigateUrl='<%# "~/Product/ProductDetail.aspx?productId="+Eval("Id") %>' runat="server">
                                                Ürün Detayları
                                                    </asp:HyperLink>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style=" float: right; padding: 20px; ">
                                        <table style="font-size:20px; width:100%;">
                                            <tr style="background-color: yellow; text-decoration: line-through;">
                                                <td style="float:right;">
                                                    <%#Eval("OldUnitPrice") %> ₺ 
                                                </td>
                                            </tr>
                                            <tr style="background-color: red; color: white;">

                                                <td ><%#Eval("Discount") %>% İndirim</td>
                                            </tr>
                                            <tr>
                                                <td style="float:right;font-size:25px;"><%#Eval("UnitPrice") %> ₺ </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr />
                                    </td>
                                </tr>

                            </ItemTemplate>
                        </asp:ListView>
                    </td>
                </tr>


            </ItemTemplate>

            <FooterTemplate>
                </table> 
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

