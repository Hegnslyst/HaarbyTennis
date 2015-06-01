<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Admin/AdminOrange.Master" CodeBehind="Kalender.aspx.cs" Inherits="ASPNetMDBTennis.Admin.Kalender" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Administration af kalender</h1>

    

    Log på www.google.dk
    <br />

    <asp:HyperLink runat="server"   Text="Klik på linket" Target="_blank"  NavigateUrl="http://www.google.dk">www.google.dk</asp:HyperLink>
    <br />
     <ul>
                <li> Klik på linket herover

                </li>
                <li>
                    Klik på den blå knap "Log Ind" i øverste højre hjørne"
                </li>
                <li> Log på med 
                    Brugernavn: Haarbytennis@gmail.com <br />
                    Adgangskode: Haarbytennis5683

                </li>
                <li> 
                    Klik på symbolet med de 9 kvadrater (Apps) i øverste højre hjørne
                </li>
                <li> Vælg kalender</li>
                <li> Klik på den dato som som arrangementet skal foregår</li>           
           

            </ul>
    

    <br />
    <br />

      <iframe src="https://www.google.com/calendar/embed?title=HaarbyTennis%20kalender&amp;height=600&amp;wkst=1&amp;bgcolor=%23FFFFFF&amp;src=haarbytennis%40gmail.com&amp;color=%232952A3&amp;ctz=Europe%2FCopenhagen" style=" border-width:0 " width="800" height="600" frameborder="0" scrolling="no"></iframe>

       
       
         
       
</asp:Content>