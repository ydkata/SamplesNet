using System.Web.Mvc;

namespace LearnMvc2.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        
        // Area名の上書き
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        // Adminエリア内のルーティングルールの設定
        // アプリケーションと、エリア内のアプリケーションで同一のコントローラー名が使用できません。
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
