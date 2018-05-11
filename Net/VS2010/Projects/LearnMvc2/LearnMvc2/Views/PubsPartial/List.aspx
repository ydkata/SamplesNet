<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<LearnMvc2.Models.EmployeViewMdl>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Emploee Search
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Please enter search condition.</h2>
<!-- Part Header:検索条件Form -->
    <% Html.EnableClientValidation(); %>
    <%: Html.ValidationSummary("エラーがあります。エラーメッセージに沿って修正してください。")%>
    <% using (Ajax.BeginForm("Search", "PubsPartial", new AjaxOptions
       {
                                                                           OnSuccess = "dispSearchRes"
                                                                          ,UpdateTargetId = "SearchResGrid"
                                                                       }))
       { %>
    <table>
        <tr>
            <th>#</th>
            <th>Emp_ID</th>
            <th>FName</th>
            <th>LName</th>
            <th>JobID</th>
            <th>Hire Date</th>
        </tr>
        <tr>
            <td></td>
            <td>
                <p>
                <label for="emp_id">emp_id:</label>
                <%= Html.LabelFor(m => m.emp_id)%>
                <%= Html.TextBoxFor(m => m.emp_id)%>
                <%= Html.ValidationMessageFor(m => m.emp_id, "*")%>
                </p>
            </td>
            <td>
                <label for="fname">fname:</label>
                <%= Html.TextBoxFor(m => m.fname)%>
                <%= Html.ValidationMessageFor(m => m.fname, "*")%>
            </td>
            <td>
                <label for="lname">lname:</label>
                <%= Html.TextBoxFor(m => m.lname)%>
                <%= Html.ValidationMessageFor(m => m.lname, "*")%>
            </td>
            <td>
                <label for="job_id">job_id:</label>
                <%= Html.TextBoxFor(m => m.job_id)%>
                <%= Html.ValidationMessageFor(m => m.job_id, "*")%>
            </td>
            <td>
                <label for="hire_date">hire_date:</label>
                <%= Html.TextBoxFor(m => m.hire_date)%>
                <%= Html.ValidationMessageFor(m => m.hire_date, "*")%>
            </td>
        </tr>
        <tr>
            <td colspan="6" align="right"> <input type="submit" value="Search" />
            <input id="ajax-button" type="button" value="Search(Manu)" />
            </td>
        </tr>
    </table>
    <% } %>
<!-- Part Header:検索条件Form End -->

<!--部分更新の結果を表示するための領域を確保-->
  <div id="SearchResGrid"></div>
<!-- Part Header:検索条件Form End -->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
<script type="text/javascript" src="<%: Url.Content("~/Scripts/MicrosoftAjax.js") %>"></script>
<script type="text/javascript" src="<%: Url.Content("~/Scripts/MicrosoftMvcAjax.js") %>"></script>
<script type="text/javascript">
    // 非同期通信の成功時に呼び出されるEvent Handler. User Sys.MVC.Ajax
    function dispSearchRes(context) {
        alert("success(partial)");
        if (context == "") return;
        var HtmlTagData = context.get_data();
        if (HtmlTagData == "") {
            alert("nothing data");
        } else {
            alert("Partialの場合, HTMLTagが返されます");
            alert(HtmlTagData);
        }
    }
</script>
</asp:Content>


