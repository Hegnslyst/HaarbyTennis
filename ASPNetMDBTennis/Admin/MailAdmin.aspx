<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminOrange.Master" AutoEventWireup="true" CodeBehind="MailAdmin.aspx.cs" Inherits="ASPNetMDBTennis.Admin.MailAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

     <h1>Administration af Azero mail</h1>

    

    Log på Azero mail server via mail-web klient. <br />
    Bemærk at det er bedst at logge på via browseren Crome. Det giver det bedste resultat.
    <br />

    <asp:HyperLink runat="server"   Text="Klik på linket" Target="_blank"   NavigateUrl="http://mail.haarbytennis.dk">mail.haarbytennis.dk</asp:HyperLink>
    <br />
     <ul>
                <li> Klik på linket herover

                </li>
                
                <li> Log på med 
                    Brugernavn: admin@haarbytennis.dk <br />
                    Adgangskode: (bestyrelse modtager koden via mail).

                </li>
                <li> 
                    Herefter er du i web-mail administrationen. Du kan nu sende/slette og læse emails. 
                </li>
                       
           

            </ul>
    

    <br />
</asp:Content>
