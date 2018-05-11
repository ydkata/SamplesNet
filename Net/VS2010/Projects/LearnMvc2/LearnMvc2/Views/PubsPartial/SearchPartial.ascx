<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<LearnMvc2.Models.EmployeViewMdl>>" %>

<!-- Part Header:取得したデータを表示する -->
    <table>
        <theader>
            <tr>
                <th></th>
                <th>emp_id</th>
                <th>FName</th>
                <th>LName</th>
                <th>JobID</th>
                <th>Hire Date</th>
            </tr>
        </theader>
<!-- Part Body:取得したデータを表示する -->
    <%  int cnt = 0;
        foreach (var item in Model) {
            cnt++;
    %>
        <tbody>
            <tr>
                <td>
                    <%: cnt %>
                </td>
                <td>
                    <%= Html.Encode(item.emp_id) %>
                </td>
                <td>
                    <%= Html.Encode(item.fname) %>
                </td>
                <td>
                    <%= Html.Encode(item.lname) %>
                </td>
                <td>
                    <%= Html.Encode(item.job_id) %>
                </td>
                <td>
                    <%= Html.Encode(item.hire_date) %>
                </td>
            </tr>
        </tbody>
    <% } %>
    </table>
<!-- Part Header:取得したデータを表示する End -->