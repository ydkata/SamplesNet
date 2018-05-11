using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnMvc2.Models;
using LearnMvc2.Models.Filter;

// *******************************************
// TODO: Sample Using Ajax
// TODO: Sample LINQ
// *******************************************
namespace LearnMvc2.Controllers.Pubs
{
    // Ajax用Controler
    [HandleError]
    [LogFilter]         // LogFilterを適用するテスト
    public class PubsAjxController : Controller
    {
        /** 定義 */
        private pubsEntities mPubsEntity = new pubsEntities();



        // GET:/PubsAjx/Index()
        /**
         * 検索Action
         * */
        public ActionResult Index()
        {
            // 検索画面を返却する。
            return View("Search");
        }

        // POST:/PubsAjx/Search
        /**
         * 検索Action (ajax)
         * 
         * @pgeIdx 頁
         * @condition   条件
         * */
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Search(string pageIdx, employee condition)
        {
            // リクエストがAjax通信（非同期通信）である場合のみ検索を実行
            if (Request.IsAjaxRequest()) {

                // ValidationはSkip 無条件検索を可能にする。

                // 検索する。

                IEnumerable<employee> empQuery = (from e in mPubsEntity.employee select e);

                // AND条件で結合される。
                if (String.IsNullOrEmpty(condition.emp_id) == false) {
                    empQuery = empQuery.Where(p => p.emp_id.Equals(condition.emp_id)); // 完全一致
                }
                if (String.IsNullOrEmpty(condition.fname) == false) {
                    empQuery = empQuery.Where(p => p.fname.Contains(condition.fname)); // 部分一致
                }
                if (String.IsNullOrEmpty(condition.lname) == false) {
                    empQuery = empQuery.Where(p => p.lname.Contains(condition.lname));  // 部分一致
                }
                if (condition.job_id > 0) {
                    empQuery = empQuery.Where(p => p.job_id.Equals(condition.job_id)); // 完全一致
                }
                if (condition.hire_date != null) {
                    empQuery = empQuery.Where(p => p.hire_date >= condition.hire_date);
                }

                // 検索結果を格納する
                // employeeを返却させてもよかったが、循環エラーになったためAjax用のModelを作成
                List<EmployeViewMdl> res = new List<EmployeViewMdl>();
                foreach (employee m in empQuery)
                {
                    EmployeViewMdl resMdl = new EmployeViewMdl(m.emp_id,
                                                                m.fname,
                                                                m.lname,
                                                                m.job_id,
                                                                m.pub_id,
                                                                m.hire_date.ToString("gyyyy年MM月dd日(dddd)")
                                                                );
                    res.Add(resMdl);
                }

                // ★JSON形式で返却する。
                return Json(res);

            } else {
                // リクエストがAjax通信以外の場合、何もしない
                return new EmptyResult();
            }
        }



    }
}
