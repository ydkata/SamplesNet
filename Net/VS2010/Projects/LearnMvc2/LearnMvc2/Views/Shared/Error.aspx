<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<System.Web.Mvc.HandleErrorInfo>" %>

<asp:Content ID="errorTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Error
</asp:Content>

<asp:Content ID="errorContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Sorry, an error occurred while processing your request.
    </h2>
    <h2>エラー詳細</h2>
    <p>
      <b>どこのControllerで発生しました？: </b><%=Model.ControllerName %>
    </p>
    <p>
      <b>どこのActionで発生しました？: </b><%=Model.ActionName %>
    </p>
    <p>
      <b>どんなMessageを持っていますか？: </b><%=Model.Exception.Message %>
    </p>
    <p>
      <b>Stack Traceは次の通りです。: </b><%=Model.Exception.StackTrace %>
    </p>
</asp:Content>
