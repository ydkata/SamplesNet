<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    This is "/Views/Home/Index.aspx"<br />
    <h2><%: ViewData["Message"] %></h2>
    <p>
        To learn more about ASP.NET MVC visit <a href="http://asp.net/mvc" title="ASP.NET MVC Website">http://asp.net/mvc</a>.
    </p>
    <p><%: Html.ActionLink("Sample(List/Create/Update/))...","Multilist","Pubs")%></p>
    <p><%: Html.ActionLink("Sample(Ajax))...", "", "PubsAjx")%></p>
    <p><%: Html.ActionLink("Sample(Ajax Using PartialForm))...", "", "PubsPartial")%></p>
</asp:Content>
