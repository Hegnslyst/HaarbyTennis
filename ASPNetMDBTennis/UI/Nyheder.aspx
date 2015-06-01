<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/SiteOrange.Master" AutoEventWireup="true" CodeBehind="Nyheder.aspx.cs" Inherits="ASPNetMDBTennis.UI.Nyheder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
 
      
        <h1>Seneste nyheder</h1>

        <asp:Label ID="pop_up_label" runat="server" Visible="false" ></asp:Label >
        <br />
    <br />
    



        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"

            DataKeyNames="Id" ForeColor="#333333" GridLines="None" 
            OnRowCancelingEdit="GridView1_RowCancelingEdit"
            OnRowDeleting="GridView1_RowDeleting"  
            OnRowEditing="GridView1_RowEditing" 
            OnRowUpdating="GridView1_RowUpdating"
            OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            

            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />

            <Columns>

            <asp:CommandField HeaderText="Edit-Update"  Visible="false" ShowEditButton="False" />

            <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True"  Visible="True" />

            <asp:BoundField DataField="Dato" HeaderText="Dato" />
            <asp:BoundField DataField="overskrift" HeaderText="Overskrift" />
            
            <asp:CommandField HeaderText="Delete" Visible="false" ShowDeleteButton="False"  />

            <asp:CommandField HeaderText="Vis" ShowSelectButton="True"  />

            </Columns>

            <RowStyle BackColor="#E3EAEB" />

            <EditRowStyle BackColor="#7C6F57" />

            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />

            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />

            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />

            <AlternatingRowStyle BackColor="White" />

        </asp:GridView>
         
       
</asp:Content>

