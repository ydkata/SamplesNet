using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnMvc2.Models;

namespace LearnMvc2.Controllers
{
    // HomeとViewsFolder内のHomeフォルダがマッピングされる. (Methods adopted from MVC2.)
    [HandleError]
    public class HomeController : Controller
    {
        //ActionResultメソッドで返るActionResultオブジェクトはそのままViewPageにルーティングされる
        // GET /Home/Index
        public ActionResult Index()
        {
            // ViewDataにキーと値を格納
            ViewData["Title"] = "Test-Home Page";
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            //ControllerクラスのViewメソッドで、ルーティング先のViewPage名を設定する
            // パラメタが指定されない場合はメソッド名と同名のViewPageに値を返す
            return View();
        }

        // GET /Home/List
        public ActionResult List()
        {
            // publishersテーブルすべてを取得するLINQ
            pubsEntities pubs = new pubsEntities();
            // 型はvarを指定することもできる。
            IEnumerable<publishers> publish = from p in pubs.publishers select p;   // SELECT * FROM [pubs].publishers; と同義

            // Debug
            foreach (publishers r in publish)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}",r.pub_id, r.country, r.city, r.employee);
            }
            Console.ReadLine();


            return View(publish);
        }





        // GET /Home//About
        public ActionResult About()
        {
            return View();
        }
    }
}
