

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<LearnMvc2.Models.employee>" %>

<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
<script type="text/javascript" src="<%: Url.Content("~/Scripts/MicrosoftAjax.js") %>"></script>
<script type="text/javascript" src="<%: Url.Content("~/Scripts/MicrosoftMvcAjax.js") %>"></script>
<script type="text/javascript" src="<%: Url.Content("~/Scripts/jquery-1.4.1.min.js") %>"></script>
<script type="text/javascript">
    // 非同期通信の成功時に呼び出されるEvent Handler. User Sys.MVC.Ajax
    function dispSearchRes(context) {
        alert("OK");
        if (context == "") return;
        var jsonData = eval(context.get_data());
        if (jsonData == "") {
            alert("nothing data");
        } else {
            // 検索結果Gridの表示
            $('#SearchResGrid').show();
            // 検索結果がある場合削除する
            if ($("#SearchRes #SearchResGrid tbody tr").length > 0) {
                $("#SearchRes #SearchResGrid tbody tr").remove();
            }
            for (var i = 0; i < jsonData.length; i++) {
                // >を指定すると直下になる孫は抽出しない
                var txtSelecter = "#SearchRes #SearchResGrid tbody > tr:last";
                if ($(txtSelecter).length == 0) {
                    // 1件も存在しない場合は行の新規追加
                    // 指定要素の子要素で追加
                    $("#SearchRes #SearchResGrid tbody").append("<tr>"
                                        + "<td>" + (i + 1) + "</td>"
                                        + "<td>" + jsonData[i].emp_id + "</td>"
                                        + "<td>" + jsonData[i].fname + "</td>"
                                        + "<td>" + jsonData[i].lname + "</td>"
                                        + "<td>" + jsonData[i].job_id + "</td>"
                                        + "<td>" + jsonData[i].hire_date + "</td>"
                                        + "</tr>");
                } else {
                    // 指定要素の最後に追加
                    $(txtSelecter).after("<tr>"
                                    + "<td>" + (i + 1) + "</td>"
                                    + "<td>" + jsonData[i].emp_id + "</td>"
                                    + "<td>" + jsonData[i].fname + "</td>"
                                    + "<td>" + jsonData[i].lname + "</td>"
                                    + "<td>" + jsonData[i].job_id + "</td>"
                                    + "<td>" + jsonData[i].hire_date + "</td>"
                                    + "</tr>");
                }

            }
        }
    }
</script>
<!-- 手動で送信する場合のSample -->
<script type="text/javascript">
    $(function () {
        $("#ajax-button").click(function () {
            var p1 = $("#emp_id").val();
            var p2 = $("#fname").val();
            var p3 = $("#lname").val();
            var p4 = $("#job_id").val();
            var p5 = $("#hire_date").val();


            $.ajax({
                type: 'POST',
                url: '<%: Url.Content("~/PubsAjx/Search/") %>',
                dataType: 'json',
                data: {
                    "emp_id": p1,
                    "fname": p2,
                    "lname": p3,
                    "job_id": p4,
                    "hire_date": p5
                },
                success: function (data) {
                    dispSearchRes2(data)
                }
            });
            return false;  //submitイベントハンドラにfalseを返し，action処理をキャンセル
        });
    });

    // 非同期通信の成功時に呼び出されるEvent Handler
    function dispSearchRes2(jsonData) {
        if (jsonData == "") return;
        if (jsonData == "") {
            alert("nothing data");
        } else {
            $('#SearchResGrid').show();
            for (var i = 0; i < jsonData.length; i++) {
                // >を指定すると直下になる孫は抽出しない
                var txtSelecter = "#SearchRes #SearchResGrid tbody > tr:last";
                if ($(txtSelecter).length == 0) {
                    // 1件も存在しない場合は行の新規追加
                    // 指定要素の子要素で追加
                    $("#SearchRes #SearchResGrid tbody").append("<tr>"
                                        + "<td>" + (i + 1) + "</td>"
                                        + "<td>" + jsonData[i].emp_id + "</td>"
                                        + "<td>" + jsonData[i].fname + "</td>"
                                        + "<td>" + jsonData[i].lname + "</td>"
                                        + "<td>" + jsonData[i].job_id + "</td>"
                                        + "<td>" + jsonData[i].hire_date + "</td>"
                                        + "</tr>");
                } else {
                    // 指定要素の最後に追加
                    $(txtSelecter).after("<tr>"
                                    + "<td>" + (i + 1) + "</td>"
                                    + "<td>" + jsonData[i].emp_id + "</td>"
                                    + "<td>" + jsonData[i].fname + "</td>"
                                    + "<td>" + jsonData[i].lname + "</td>"
                                    + "<td>" + jsonData[i].job_id + "</td>"
                                    + "<td>" + jsonData[i].hire_date + "</td>"
                                    + "</tr>");
                }
            }
        }
    }
</script>
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Search
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Search Condition(Not use partial)</h2>

<!-- Part Header:検索条件Form -->
    <% Html.EnableClientValidation(); %>
    <%= Html.ValidationSummary("エラーがあります。エラーメッセージに沿って修正してください。")%>
    <% using (Ajax.BeginForm("Search", "PubsAjx", new AjaxOptions { OnSuccess = "dispSearchRes" }))
       { %>
    <table>
        <tr>
            <th></th>
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
<!-- 検索結果出力部分 JQueryで書き換えをしている。 -->
    <div id="SearchRes">
    <table id="SearchResGrid" style="display: none;">
        <thead>
            <tr>
                <th>#</th>
                <th>Emp_ID</th>
                <th>FName</th>
                <th>LName</th>
                <th>JobID</th>
                <th>Hire Date</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
    </div>

</asp:Content>
