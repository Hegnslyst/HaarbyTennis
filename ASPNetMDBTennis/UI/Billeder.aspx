﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Shared/SiteOrange.Master" CodeBehind="Billeder.aspx.cs" Inherits="ASPNetMDBTennis.UI.Billeder" %>
<%@ MasterType  virtualPath="~/Shared/SiteOrange.Master"%> 



<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

   
    
  <h1 class="first">Billeder fra klargøringen </h1>
        <div class="container">
        <br>
        <div id="myCarousel" class="carousel slide" data-ride="carousel">
            <!-- Indicators -->
            <ol class="carousel-indicators">
                <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                <li data-target="#myCarousel" data-slide-to="1"></li>
                <li data-target="#myCarousel" data-slide-to="2"></li>
                <li data-target="#myCarousel" data-slide-to="3"></li>
            </ol>

            <!-- Wrapper for slides -->
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    
                    <img src="../Content/Images/2013/MichaelGrube/Billede_1.jpg" alt="Chania" width="460" height="345"/>
                </div>

                <div class="item">
                    <img src="../Content/Images/2013/MichaelGrube/Billede_2.jpg" alt="Chania" width="460" height="345"/>
                </div>

                <div class="item">
                    <img src="../Content/Images/2013/MichaelGrube/Billede_3.jpg" alt="Flower" width="460" height="345"/>
                </div>

                <div class="item">
                    <img src="../Content/Images/2013/MichaelGrube/Billede_4.jpg" alt="Flower" width="460" height="345"/>
                </div>

                <div class="item">
                    <img src="../Content/Images/2013/MichaelGrube/Billede_5.jpg" alt="Flower" width="460" height="345"/>
                </div>
                <div class="item">
                    <img src="../Content/Images/2013/MichaelGrube/Billede_6.jpg" alt="Flower" width="460" height="345"/>
                </div>
                <div class="item">
                    <img src="../Content/Images/2013/MichaelGrube/Billede_7.jpg" alt="Flower" width="460" height="345"/>
                </div>
                <div class="item">
                    <img src="../Content/Images/2013/MichaelGrube/Billede_8.jpg" alt="Flower" width="460" height="345"/>
                </div>
                <div class="item">
                    <img src="../Content/Images/2013/MichaelGrube/Billede_9.jpg" alt="Flower" width="460" height="345"/>
                </div>
                <div class="item">
                    <img src="../Content/Images/2013/MichaelGrube/Billede_10.jpg" alt="Flower" width="460" height="345"/>
                </div>
                <div class="item">
                    <img src="../Content/Images/2013/MichaelGrube/Billede_11.jpg" alt="Flower" width="460" height="345"/>
                </div>
                <div class="item">
                    <img src="../Content/Images/2013/MichaelGrube/Billede_12.jpg" alt="Flower" width="460" height="345"/>
                </div>
                
            </div>

            <!-- Left and right controls -->
            <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>
    </div>


</asp:Content>