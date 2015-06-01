<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/SiteOrange.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="ASPNetMDBTennis.UI.ErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <div id="divCaption" class="Caption"><asp:Label ID="lblErrorCaption" runat="server" Text="lblErrorCaption"></asp:Label></div>
    <div id="divErrorContext">
        <p><asp:Label ID="lblErrorContent" runat="server" Text="lblErrorContent"></asp:Label></p>
    </div>
    <div><a href="Default.aspx">Retur til forsiden</a></div>
</asp:Content>
