<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/Main.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="OdevUI.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainBody" runat="server">
    <div style="height: 600px; margin: auto; width: 50%;">
        <asp:HiddenField ID="hdnUserId" runat="server" Value="0" />

        <div style="text-align: center;">
            <br />

            <h2>İletişim Formu</h2>
            <br />
            <asp:Label ID="lblInfo" runat="server" Text=" Bizinle aşağıdaki form üzerinden irtibata geçebilirsiniz"></asp:Label>

            <hr />
            <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
            <br />
 
        </div>
        <asp:Table ID="tblContact" runat="server" style="height: 150px; width: 100%;">

            <asp:TableRow>
                <asp:TableCell>
                İsim
                </asp:TableCell>
                <asp:TableCell>
                :
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                Email
                </asp:TableCell>
                <asp:TableCell>
                :
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                Konu
                </asp:TableCell>
                <asp:TableCell>
                :
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                Mesaj
                </asp:TableCell>
                <asp:TableCell>
                :
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="3">
                    <asp:Button ID="btnSend" runat="server" Text="Gönder" Style="margin-left: 35%; width: 100px;" OnClick="btnSend_Click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
</asp:Content>

