<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminOrange.Master" AutoEventWireup="true" CodeBehind="Nyhedsbreve.aspx.cs" Inherits="ASPNetMDBTennis.Admin.Nyhedsbreve" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

     <div id="divError" runat="server" class="error" visible="false" style="color:red;  background-color: #FFBABA;border-radius: 5px 5px 5px 5px; border: 1px solid;">
        Eventuel fejlmeddelelse.
    </div>
    
       <h1>Nyhedsbreve</h1>

    <div id="divSearchBox" class="content-main">
        <table  width="100%">
          
            <tr>
                <td style="width: 150px"  valign="top">
                    Mail Emne:
                </td>
                 <td>
                    <asp:TextBox Width="100%" ID="txtEmne" runat="server" ></asp:TextBox>
                    
                </td>
                
            </tr>
             <tr>
                <td style="width: 150px"  valign="top">
                    Mail tekst:
                </td>
                 <td>
                    <asp:TextBox TextMode="MultiLine" Height="300"  Width="100%" ID="txtHenvendelse" runat="server" ></asp:TextBox>
                    
                </td>
                
              </tr>
              
        </table>
    </div>
    <br />
      
                   
    <div class="content-main">
        <div id="divCaptionDokument" class="Caption">
                Dokumenter</div>
        <div id="divListe">
            <asp:ListView ID="lvMain" runat="server" OnItemCommand="lvMain_ItemCommand">
                <LayoutTemplate>
                    <table class="dataList" id="dataList" width="100%">
                        <thead>
                            <tr>
                                <th colspan="2">
                                    Dokument
                                </th>
                                <th>
                                    Størrelse
                                </th>
                                <th>
                                    &nbsp;
                                </th>
                                <th>
                                    &nbsp;
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr runat="server" id="itemPlaceholder">
                            </tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td style="width: 20px">
                            <asp:Image ID="imgDoc" runat="server" ImageUrl="../../Content/images/Dokument16.png" BorderStyle="None" />
                        </td>
                        <td style="width: 300px">
                            
                            <%# Eval("DocNavn") %>
                        </td>
                        <td style="width: 100px">
                            <%# (((int)Eval("DocSize")) / 1024).ToString("#,##0.0") %>
                            KB
                        </td>
                        <td>
                             &nbsp;
                        </td>
                        <td style="width: 35px">
                            <asp:LinkButton ID="lbtnSletDokument" runat="server" CommandName="lbListItemDelete"
                                CommandArgument='<%# Eval("DocNavn") %>' CssClass="sletStatus">Slet</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>Du har ikke overført nogen dokumenter.</EmptyDataTemplate>
            </asp:ListView>
        </div>
        <div class="BtnPanel">
            <table width="100%">
                <tr>
                    <td>
                        Vælgfil:
                    </td>
                    <td>
                        <asp:FileUpload runat="server" ID="fileUpload" Width="350px"></asp:FileUpload>
                    </td>
                    <td>
                        <asp:Button ID="btnUploadFile" runat="server" Text="Vedhæft" OnClick="btnUploadFile_Click"
                            Width="100px" ClientIDMode="Static" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="textbox">
            <strong>Upload af filer</strong><br />
            
            Du kan uploade word samt samt pdf dokumenter.<br />
            Vær opmærksom på, at filerne maksimalt må fylde 6 mb.
        </div>
    </div>
    <table>
        <tr>
            <td style="width: 125px; text-align: right" align="right">
                <asp:Button ID="btnSend" runat="server" Text="Send" Width="120px" OnClick="btnSend_Click" />
            </td>
            <td style="width: 125px; text-align: right" align="right">
                <asp:Button ID="btnFortryd" runat="server" Text="Fortryd" Width="120px" OnClick="btnFortryd_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
