<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	List:複数Modelを返却する例1
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>[/View/Pubs/List.aspx]</h1>
    <h2>List表示テスト</h2>

<!-- Part Header:取得したデータを表示する -->
[publishersを出力する]<br />
    <table>
        <tr>
            <th></th>
            <th>
                city
            </th>
            <th>
                country
            </th>
            <th>
                pub_id
            </th>
            <th>
                pub_name
            </th>
            <th>
                state
            </th>
        </tr>

<% IEnumerable<LearnMvc2.Models.publishers> mdl1 = ViewData["Mdl1"] as IEnumerable<LearnMvc2.Models.publishers>; %>
<!-- Part Body:取得したデータを表示する -->
    <% foreach (var item in mdl1){ %>
        <tr>
            <td>
                <%= Html.ActionLink("LinkText_Edit", "Edit", new { id = item.pub_id })%> |
                <%= Html.ActionLink("LinkText_Details", "Details", new { id = item.pub_id })%>
            </td>
            <td>
                <%= Html.Encode(item.city) %>
            </td>
            <td>
                <%= Html.Encode(item.country) %>
            </td>
            <td>
                <%= Html.Encode(item.pub_id) %>
            </td>
            <td>
                <%= Html.Encode(item.pub_name) %>
            </td>
            <td>
                <%= Html.Encode(item.state) %>
            </td>
        </tr>
    
    <% } %>
    </table>
    <fieldset>
        <%= Html.ActionLink("Create new record.", "create", "Pubs")%>
    </fieldset>
<hr>
<% IEnumerable<LearnMvc2.Models.jobs> mdl2 = ViewData["Mdl2"] as IEnumerable<LearnMvc2.Models.jobs>; %>
[Jobsを出力する]<br />
    <table>
    <% foreach (var item2 in mdl2){ %>
        <tr>
            <td>
                <%= Html.Encode(item2.job_id)%>
            </td>
            <td>
                <%= Html.Encode(item2.job_desc)%> || 
                <%= Html.TextArea("job_desc", item2.job_desc)%> || 
                <%= Html.TextAreaFor(m => item2.job_desc)%>
            </td>
        </tr>
    <% } %>
    </table>

</asp:Content>
