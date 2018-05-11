<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<LearnMvc2.Models.publishers>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>
    <% Html.EnableClientValidation(); %>
    <%= Html.ValidationSummary("エラーがあります。エラーメッセージに沿って修正してください。")%>
    <% using (Html.BeginForm())
       { %>
        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="pub_id">pub_id:</label> 
                <%: Html.DisplayFor(m => m.pub_id)%> 
            </p>
            <p>
                <label for="pub_name">pub_name:</label>
                <%= Html.TextBoxFor(m => m.pub_name)%>
                <%= Html.ValidationMessageFor(m => m.pub_name, "*")%>
            </p>
            <p>
                <label for="city">city:</label>
                <%= Html.TextBoxFor(m => m.city)%>
                <%= Html.ValidationMessageFor(m => m.city, "*")%>
                変更できないようなっています。
            </p>
            <p>
                <label for="state">state:</label>
                <%= Html.TextBoxFor(m => m.state)%>
                <%= Html.ValidationMessageFor(m => m.state, "*")%>
                変更できないようなっています。
            </p>
            <p>
                <label for="country">country:</label>
                <%= Html.TextBoxFor(m => m.country)%>
                <%= Html.ValidationMessageFor(m => m.country, "*")%>
                変更できないようなっています。
            </p>
            <p>
                <input type="submit" value="UpdateTest" />
            </p>
        </fieldset>
    <% } %>


</asp:Content>
