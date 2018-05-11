using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnMvc2.Models;
using LearnMvc2.Models.Filter;

namespace LearnMvc2.Controllers.Pubs
{
    // HomeとViewsFolder内のHomeフォルダがマッピングされる. (Methods adopted from MVC2.)
    [HandleError]
    [LogFilter]         // LogFilterを適用するテスト
    public class PubsController : Controller
    {
        // GET ~/Pubs/MultiList
        public ActionResult MultiList()
        {
            pubsEntities pubs = new pubsEntities();
            // 型はvarを指定することもできる。
            IEnumerable<publishers> publish = from p in pubs.publishers select p;   // SELECT * FROM [pubs].publishers; と同義

            // Debug
            foreach (publishers r in publish)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}", r.pub_id, r.country, r.city, r.employee);
            }
            Console.ReadLine();


            // Jobsも取得して複数Modelを返すしてみる。
            IEnumerable<jobs> job = from j in pubs.jobs where j.job_id >= 1 select j;   // SELECT * FROM [pubs].jobs where job_id >= 1; と同義

            // 取り出し方不明
            ViewData.Model = new { publishers = publish, jobs = job };

            // この方法はあまりスマートではない。
            ViewData["Mdl1"] = publish;
            ViewData["Mdl2"] = job;

            // 表示Pageを指定する
            return View("List");
        }


        // *****************************
        // GET: /Pubs/Create
        // *****************************
        public ActionResult Create()
        {
            return View();
        }

        // *****************************
        // POST: /Pubs/Create
        // @param pubs  ViewPage作成時に型付けした Modelとして値を受け取る
        // @param collection Formに入力した全てのパラメータを格納
        // *****************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(publishers pubs, FormCollection collection)
        {
            try
            {
                // Execute Validate
                bool isValid = this.ValidatePubs(pubs);
                if (isValid == false)
                    return View();      // When an error occurs. 

                // Pageを返却する。URLがCreateになっているのでRedirectをかけて/Pubs/Mulitlitstに変更する。
                return RedirectToAction("Mulitlitst");
            }
            catch
            {
                return View();
            }
        }



        // *****************************
        // GET: /Pubs/Edit
        // *****************************
        public ActionResult Edit(String id)
        {
            try
            {
                // Check Parameter 
                bool isFailed = ValidateEdit(id);

                if (isFailed == false)
                {
                    // ErrorなのでListPageを返却する。
                    return RedirectToAction("Multilist");
                }

                // Read Data
                publishers pubs = GetData(id);

                // Pageを返却する。
                return View(pubs);
            }
            catch
            {
                return View();
            }

        }



        // Post: /Pubs/Edit *****************************
        /**
         * 指定されたデータを更新する。
         * 
         **/
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(String id, FormCollection collection)
        {

            pubsEntities pubsEntity = new pubsEntities();    // Class メンバ変数に代入しておくことも可能

            try
            {
                // Check Parameter 
                bool isFailed = ValidateEdit(id);

                if (isFailed == false)
                {
                    // ErrorなのでListPageを返却する。
                    return RedirectToAction("Multilist");
                }

                // 対象データを取得する本来であればSessionから取得する。
                // publishers pubs = GetData(id); pubsEntitiesが別インスタンスのため、レコードが更新できなくなるので別途取得した。
                publishers pubs = (from p in pubsEntity.publishers where p.pub_id == id select p).First();

                // 更新部分を変更する。(更新対象はpub_nameのみとする。)
                bool isSucless = this.TryUpdateModel(pubs, new[] {"pub_name"});

                if (isSucless == false || ModelState.IsValid == false)
                {
                    // ErrorなのでEditを返却する。
                    return View();
                }


                // Update Model
                pubsEntity.SaveChanges();       // 更新を反映する。

                // Pageを返却する。URLがEditになっているのでRedirectをかけて/Pubs/Mulitlitstに変更する。
                return RedirectToAction("Multilist");
            }
            catch
            {
                return View();
            }

        }

        #region Validation Methods
        // Validation処理を記載する。
        private bool ValidatePubs(publishers pubs)
        {
            if (String.IsNullOrEmpty(pubs.pub_id))
            {
                ModelState.AddModelError("pub_id", "pub_idは必須項目です。");
            }
            else if (pubs.pub_id.Trim().Length == 0)
            {
                ModelState.AddModelError("pub_id", "pub_idは必須項目です。");
            }

            if (String.IsNullOrEmpty(pubs.pub_name))
            {
                ModelState.AddModelError("pub_name", "pub_nameは必須項目です。");
            }
            else if (pubs.pub_name.Trim().Length == 0)
            {
                ModelState.AddModelError("pub_name", "pub_nameは必須項目です。");
            }

            return ModelState.IsValid;
        }

        // Validation処理を記載する。
        private bool ValidateEdit(String id)
        {
            if (String.IsNullOrEmpty(id))
            {
                ModelState.AddModelError("id", "対象のIDを指定してください。"); // AddModelErrorを追加することで IsValidがFalseを返すようになる。
            }

            return ModelState.IsValid;
        }

        #endregion


        #region DBアクセス処理

        /**
         * DBから指定されたデータを取得する。
         * @param id
         * @return 検索結果
         **/
        private static publishers GetData(String id)
        {
            pubsEntities pubs = new pubsEntities();
            // 型はvarを指定することもできる。
            publishers publish = (from p in pubs.publishers where p.pub_id == id select p).First();   // SELECT * FROM [pubs].publishers; と同義

            return publish;
        }

        #endregion
    }
}
