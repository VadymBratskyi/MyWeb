<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="CarShopEntity.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <% @Register tagName="myControl" tagPrefix="test" src="Controls/WebUserControl1.ascx"%>
    <%@ Register Src="~/Controls/WebUserControl1.ascx" TagPrefix="test" TagName="WebUserControl1" %>
    <%@ Register Src="~/Controls/ControlObj.ascx" TagPrefix="test" TagName="ControlObj" %>
    <%@ Reference Control="Controls/TabsUserControl3.ascx" %>
     
    <%@ OutputCache Duration="10" VaryByParam="Id" VaryByCustom="device" %>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h3>Страница за кеширована: <asp:Label ID="cachePageLable" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label></h3>
        <asp:Substitution runat="server" ID="sub" MethodName="GetDate" />
    </div>
    <div class="container">
        <div class="row">
            <asp:Button ID="Btn" runat="server" Text="setCahce" OnClick="Btn_Click"/>
            <asp:Button ID="Button2" runat="server" Text="removeCahce" OnClick="Button2_Click"/>
            <asp:Button ID="Button1" runat="server" Text="getCahce" OnClick="Button1_Click"/>
            <asp:Label ID="Lable" runat="server"></asp:Label>
            <asp:Button runat="server" ID="dileBtn" Text="LoadFile" OnClick="dileBtn_Click" />
            <ul>
                <li><a href="HomePage.aspx?Id=1">hom_1</a></li>
                <li><a href="HomePage.aspx?Id=2">hom_2</a></li>
                <li><a href="HomePage.aspx?Id=3">hom_3</a></li>
            </ul>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <asp:Button ID="Button3" runat="server" Text="getCahce" OnClick="Button3_Click"/>
        </div>
    </div>
    
    <div class="row" style="padding:10px;">
        <test:myControl ID="heloControl" runat="server"></test:myControl>
        <test:WebUserControl1 runat="server" ID="WebUserControl1" />
        <test2:Contol2 runat="server" ID="user2" Width="500" Height="300" ></test2:Contol2>
        <test:ControlObj runat="server" id="ControlObj" />
    </div>

    
    
    <div class="container">
        <div class="row">
            <div class="col-md-12">
               <tab:TabControl runat="server" ID="tabControl" OnSelectionChanged="tabControl_OnSelectionChanged" SelectTabColor="Orange"></tab:TabControl>
                <asp:Label runat="server" ID="labelTab"></asp:Label>
                <asp:PlaceHolder runat="server" ID="plHolder"></asp:PlaceHolder>
            </div>
        </div>        
    </div> 
    

</asp:Content>
