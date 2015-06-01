<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminOrange.Master" AutoEventWireup="true" CodeBehind="AdminMedlemmer.aspx.cs" Inherits="ASPNetMDBTennis.Admin.AdminMedlemmer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


    
    <asp:UpdatePanel ID="updatePanelPage" runat="server">
        <ContentTemplate>
            <div id="divError" runat="server" class="error" visible="false">
                Eventuel fejlmeddelelse.
            </div>
             <div id="divInfo" runat="server" class="info" visible="false">
                Eventuel infomeddelelse.
            </div>
          
            <asp:MultiView ID="mvMain" runat="server" ActiveViewIndex="0">
                <asp:View ID="viewList" runat="server">
                    <div id="divFilter" class="SelectionBox">
                        <table width="100%">
                            <tr>
                                <td style="width: 20%">
                                    Sorter medlemmer efter type:
                                </td>
                                
                                <td>
                                    <asp:DropDownList ID="ddlSearchEfterMedlemstype" runat="server" Width="255px"  AutoPostBack="true" OnSelectedIndexChanged="ddlSearchEfterMedlemstype_SelectedIndexChanged">
                                    </asp:DropDownList>                                  
                                 </td>
                             
                              
                             
                              
                            </tr>
                           
                        </table>
                    </div>
                    <div id="divListe">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div style="margin-bottom: 5px; text-align: right">
                                    <div id="divSeachCounterInfo" runat="server">
                                        <asp:Label runat="server" ID="lblAntalUdsoegte"></asp:Label>
                                    </div>
                                    <asp:DataPager ID="dpMain" runat="server" PagedControlID="lvMain" PageSize="10">
                                        <Fields>
                                            <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False"
                                                FirstPageText="<<" PreviousPageText="<" />
                                            <asp:NumericPagerField />
                                            <asp:NextPreviousPagerField ShowLastPageButton="True" ShowPreviousPageButton="False"
                                                NextPageText=">" LastPageText=">>" />
                                        </Fields>
                                    </asp:DataPager>
                                </div>
                                <asp:ListView ID="lvMain" runat="server" OnItemCommand="lvMain_ItemCommand" OnPreRender="lvMain_PreRender">
                                    <LayoutTemplate>
                                        <table width="100%" class="dataList" id="MedlemmerDataList" runat="server">
                                            <thead>
                                                <tr>
                                                    
                                                    <th>
                                                        Id
                                                    </th>
                                                    <th>
                                                        Fornavn
                                                    </th>
                                                    <th >
                                                        Efternavn
                                                    </th>
                                                    <th>
                                                        Adresse
                                                    </th>
                                                    <th>
                                                        Postnummer
                                                    </th>
                                                     <th>
                                                        By
                                                    </th>                                                    
                                                    <th >
                                                        Telefon
                                                    </th>                   
                                                    <th>
                                                        Email
                                                    </th>
                                                    
                                                    <th>
                                                        Udendørs
                                                    </th>
                                                    <th>
                                                        Indendørs
                                                    </th>
                                                     <th>
                                                        Minitennis
                                                    </th>
                                                   
                                                    <th>
                                                        Rabat
                                                    </th>
                                                     <th>
                                                        Nyhedsbrev
                                                    </th>
                                                     <th style="width: 50px">
                                                        Rediger
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
                                            <td>
                                                <%# Eval("Id")%>
                                            </td>
                                            <td>
                                                <%# Eval("Fornavn") %>
                                            </td>
                                            <td>
                                                <%# Eval("Efternavn") %>
                                            </td>
                                            <td>
                                                <%# Eval("Adresse")%>
                                            </td>
                                            
                                            <td>
                                                <%# Eval("Postnummer")%>
                                            </td>
                                            <td>
                                                <%# Eval("bynavn")%>
                                            </td>
                                            <td>
                                                <%# Eval("Tlf_1")%>
                                            </td>
                                            <td>
                                                <%# Eval("Email")%>
                                            </td>
                                            <td>
                                                <%# Eval("Kontingent")%>
                                            </td>
                                            <td>
                                                <%# Eval("Indendoers")%>
                                            </td>
                                              <td>
                                                <%# Eval("Minitennis")%>
                                            </td>
                                            <td>
                                                <%# Eval("Rabat")%>
                                            </td>
                                            <td>
                                                <%# Eval("JaTilNyheder")%>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lbListItemEdit" runat="server" CommandName="lbListItemEdit" CommandArgument='<%# Eval("Id") %>'>Rediger</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <EmptyDataTemplate>
                                        <div class="info">
                                            Der blev ikke fundet nogen medlemmer.</div>
                                    </EmptyDataTemplate>
                                </asp:ListView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div style="margin-top: 5px">
                        <asp:Button ID="btnNew" runat="server" Text="Opret ny" Width="100px" OnClick="btnNew_Click" />
                      
                    </div>
                      
                       
                       
                    
                </asp:View>
                <asp:View ID="viewEdit" runat="server">
                    <div id="divNewUserFetch" runat="server" class="SelectionBox">
                        <table width="100%">
                            
                            <tr>        
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblCreateFornavn">Fornavn:</asp:Label><asp:label runat="server" ForeColor="Red"  Font-Bold="true" Font-Size="Large">*</asp:label>                    
                                </td>                           
                                <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtCreateFornavn" Width="255px"></asp:Textbox>
                                </td>                                
                            </tr>
                            <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblCreateEfternavn">Efternavn:</asp:Label><asp:label runat="server" ForeColor="Red"  Font-Bold="true" Font-Size="Large">*</asp:label>
                                </td>                            
                                <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtCreateEfternavn" Width="255px"></asp:Textbox>                    
                                </td>
                            </tr>
                            <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblCreateAdresse">Adresse:</asp:Label><asp:label runat="server" ForeColor="Red"  Font-Bold="true" Font-Size="Large">*</asp:label>                    
                                </td>                               
                                  <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtCreateAdresse" Width="255px"></asp:Textbox>                    
                                </td>                                                              
                           
                            </tr>
                            <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblCreatePostnummer">Postnummer:</asp:Label><asp:label runat="server" ForeColor="Red"  Font-Bold="true" Font-Size="Large">*</asp:label>                    
                                </td>
                                <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtCreatePostnummer" Width="50px"></asp:Textbox>                    
                                </td> 
                            </tr>
                            <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblBynavn">Bynavn:</asp:Label><asp:label runat="server" ForeColor="Red"  Font-Bold="true" Font-Size="Large">*</asp:label>                                        
                                </td>
                                <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtCreateBynavn" Width="100px"></asp:Textbox>                    
                                </td> 
                            </tr>
                             <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblCreateTlf_1">Telefon:</asp:Label>
                                </td>
                                <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtCreateTlf_1" Width="100px"></asp:Textbox>                    
                                </td> 
                            </tr>
                             <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblCreateEmail">Email:</asp:Label>
                                </td>
                                <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtCreateEmail" Width="150px"></asp:Textbox>
                                </td> 
                            </tr>
                             <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblCreateFoedselsdato">Fødselsdato:</asp:Label>
                                </td>
                                <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtCreateFoedselsdato" Width="100px"></asp:Textbox>                    
                                </td> 
                            </tr>
                             <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblKontingent">Udendørs:</asp:Label>
                                </td>
                                <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtCreateKontingent" Width="100px"></asp:Textbox>                    
                                </td> 
                            </tr>
                              <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblCreateMinitennis">Minitennis:</asp:Label>
                                </td>
                                <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtCreateMinitennis" Width="100px"></asp:Textbox>                    
                                </td> 
                            </tr>
                              <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblCreateIndendoers">Indendørs:</asp:Label>
                                </td>
                                <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtCreateIndendoers" Width="100px"></asp:Textbox>                    
                                </td> 
                            </tr>
                              <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblCreateRabat">Rabat:</asp:Label>
                                </td>
                                <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtCreateRabat" Width="200px"></asp:Textbox>                    
                                </td> 
                            </tr>
                              <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblCreateBoldkanon">Boldkanon:</asp:Label>
                                </td>
                                <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtCreateBoldkanon" Width="100px"></asp:Textbox>                    
                                </td> 
                            </tr>
                              <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblCreateNoegle">Nøgle:</asp:Label>
                                </td>
                                <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtCreateNoegle" Width="100px"></asp:Textbox>                    
                                </td> 
                            </tr>
                            <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblCreateNewsMail">Nyhedsbrev:</asp:Label>
                                </td>
                                <td class="dataColBred">
                                 <asp:CheckBox runat="server" ID="chkCreateNewsMail"   OnCheckedChanged="chkCreateNewsMail_CheckedChanged"   Width="255px"></asp:CheckBox> 
                                                       
                                </td> 
                            </tr>

                           
                        </table>
                    </div>
                   
                    <div id="divUser" runat="server" class="SelectionBox">
                        <table width="100%">
                            
                              <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblEditId">Id:</asp:Label>
                                </td>                           
                                <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtEditId" Width="255px"  Enabled="false"></asp:Textbox>                    
                                </td>
                            </tr>
                            <tr>        
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblEditFornavn">Fornavn:</asp:Label><asp:label runat="server" ForeColor="Red"  Font-Bold="true" Font-Size="Large">*</asp:label>                    
                                </td>                           
                                <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtEditFornavn" Width="255px"></asp:Textbox>
                                </td>                                
                            </tr>
                            <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblEditEfternavn">Efternavn:</asp:Label><asp:label runat="server" ForeColor="Red"  Font-Bold="true" Font-Size="Large">*</asp:label>                    
                                </td>                            
                                <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtEditEfternavn" Width="255px"></asp:Textbox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblEditAdresse">Adresse:</asp:Label><asp:label runat="server" ForeColor="Red"  Font-Bold="true" Font-Size="Large">*</asp:label>                    
                                </td>                               
                                  <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtEditAdresse" Width="255px"></asp:Textbox>                    
                                </td>                                                              
                           
                            </tr>
                            <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblEditPostnummer">Postnummer:</asp:Label><asp:label runat="server" ForeColor="Red"  Font-Bold="true" Font-Size="Large">*</asp:label>                    
                                </td>
                                <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtEditPostnummer" Width="255px"></asp:Textbox>                    
                                </td> 
                            </tr>
                            <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="Label2">Bynavn: </asp:Label><asp:label runat="server" ForeColor="Red"  Font-Bold="true" Font-Size="Large">*</asp:label>                    
                                </td>
                                <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtEditBynavn" Width="255px"></asp:Textbox>                    
                                </td> 
                            </tr>
                             <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblEditTlf_1">Telefon:</asp:Label>
                                </td>
                                <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtEditTlf_1" Width="255px"></asp:Textbox>                    
                                </td> 
                            </tr>
                             <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblEditEmail">Email:</asp:Label><asp:label runat="server" ForeColor="Red"  Font-Bold="true" Font-Size="Large">*</asp:label>                    
                                </td>
                                <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtEditEmail" Width="255px"></asp:Textbox>                    
                                </td> 
                            </tr>
                             <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblEditFoedselsdato">Fødselsdato:</asp:Label>
                                </td>
                                <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtEditFoedselsdato" Width="255px"></asp:Textbox>                    
                                </td> 
                            </tr>
                             <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="Label3">Udendørs:</asp:Label>
                                </td>
                                <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtEditKontingent" Width="255px"></asp:Textbox>                    
                                </td> 
                            </tr>
                              <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblEditMinitennis">Minitennis:</asp:Label>
                                </td>
                                <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtEditMinitennis" Width="255px"></asp:Textbox>                    
                                </td> 
                            </tr>
                              <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblEditIndendoers">Indendørs:</asp:Label>
                                </td>
                                <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtEditIndendoers" Width="255px"></asp:Textbox>                    
                                </td> 
                            </tr>
                              <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblEditRabat">Rabat:</asp:Label>
                                </td>
                                <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtEditRabat" Width="255px"></asp:Textbox>                    
                                </td> 
                            </tr>
                              <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblEditBoldkanon">Boldkanon:</asp:Label>
                                </td>
                                <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtEditBoldkanon" Width="255px"></asp:Textbox>                    
                                </td> 
                            </tr>
                              <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblEditNoegle">Nøgle:</asp:Label>
                                </td>
                                <td class="dataColBred">
                                    <asp:Textbox runat="server" ID="txtEditNoegle" Width="255px"></asp:Textbox>                    
                                </td> 
                            </tr>
                              <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblEditNewsMail">Nyhedsbrev:</asp:Label>
                                </td>
                                <td class="dataColBred">
                                 <asp:CheckBox runat="server" ID="chkEditNewsMail" Checked="true" Width="255px"></asp:CheckBox> 
                                                       
                                </td> 
                            </tr>
                            
                             <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblEditUdmeldt">Udmeldt:</asp:Label>
                                </td>
                                <td class="dataColBred">
                                 <asp:CheckBox runat="server" ID="chkEditUdmeldt"  Width="255px"></asp:CheckBox> 
                                                       
                                </td> 
                            </tr>

                              <tr>
                                <td class="tekstCol">
                                    <asp:Label runat="server" ID="lblEditMasterPeriode">MasterPeriode:</asp:Label>
                                </td>
                                <td class="dataColBred">
                                 <asp:Textbox runat="server" ID="txtEditMasterPeriode"  Width="255px"></asp:Textbox> 
                                                       
                                </td> 
                            </tr>

                                              
                         
                        </table>
                    </div>
                    <div>
                        <asp:Button ID="btnEditBack" runat="server" Text="Fortryd" Width="100px" OnClick="btnEditBack_Click" />&nbsp;&nbsp;
                        <asp:Button ID="btnEditSave" runat="server" Text="Gem" Width="100px" OnClick="btnEditSave_Click" />
                    </div>

                

                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>

    <br />
      <asp:Button ID="btnExcel" runat="server" Text="Vagns Excel"  Width="100px" OnClick="btnExcel_Click"/>



</asp:Content>
