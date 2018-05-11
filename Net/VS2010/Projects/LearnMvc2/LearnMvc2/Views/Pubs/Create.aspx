<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<LearnMvc2.Models.publishers>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <h2>Create</h2>
    [ModelのSample]<br />
    <% Html.EnableClientValidation(); %>
    <%= Html.ValidationSummary("新規作成に失敗しました。エラーメッセージに沿って修正してください。")%>
    <% using (Html.BeginForm())
       { %>
        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="pub_id">pub_id:</label> 
                <%: Html.TextBoxFor(m => m.pub_id)%> 
                <%: Html.ValidationMessageFor(m => m.pub_id, "*(上書きされます)")%><!-- ValidationMessageForのThe second parameterは、エラーメッセージを上書きして表示する --> 
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
            </p>
            <p>
                <label for="state">state:</label>
                <%= Html.TextBoxFor(m => m.state)%>
                <%= Html.ValidationMessageFor(m => m.state, "*")%>
            </p>
            <p>
                <label for="country">country:</label>
                <%= Html.TextBoxFor(m => m.country)%>
                <%= Html.ValidationMessageFor(m => m.country, "*")%>
            </p>
            <p>
                <input type="submit" value="CreateTest" />
            </p>
        </fieldset>
    <% } %>


</asp:Content>
