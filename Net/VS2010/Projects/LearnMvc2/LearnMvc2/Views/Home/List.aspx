<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<LearnMvc2.Models.publishers>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	List:どこですか？
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>List　置き換わるか？</h2>
<!-- Part Header:取得したデータを表示する -->
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
<!-- Part Body:取得したデータを表示する -->
    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.pub_id }) %> |
                <%= Html.ActionLink("Details", "Details", new { id=item.pub_id })%>
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



</asp:Content>
