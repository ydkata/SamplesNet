using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Web.Routing;

namespace LearnMvc2.Models.Filter
{
    /**
     * Fileterクラスを作るテスト
     * OnActionExecutedメソッド	Action前に適用されるフィルタ
     * OnActionExecutingメソッド	Action後に適用されるフィルタ
     * OnResulteExecutedメソッド	Result前に適用されるフィルタ
     * OnResultExecutingメソッド	Result後に適用されるフィルタ
     * */

    public class LogFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Log出力
            LogFilterAttribute.LogOutput("OnActionExecuting", filterContext.RouteData);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // Log出力
            LogFilterAttribute.LogOutput("OnActionExecuted", filterContext.RouteData);
        }

        /**
         * Log出力処理
         * 
         * */
        private static void LogOutput(string step, RouteData routeData)
        {
            // controller/actionを取得
            string controllername = routeData.Values["controller"] as string;
            string actionname = routeData.Values["action"] as string;
            // メッセージを作成
            string logs = string.Format(
                                       "LogFilterによるログ出力: {0} アクション名：{1} コントローラ名：{2}",
                                       step, actionname, controllername);

            // ログ出力
            Debug.WriteLine(logs);
        }
    }
}