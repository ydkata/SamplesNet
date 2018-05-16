using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Service;

namespace WebApplication2.Controllers
{
    public class BoardController : Controller
    {

        private IBoardService boardSrv = null;

        public BoardController(IBoardService service)
        {
            this.boardSrv = service;
            Debug.WriteLine("Log# BoardController instance was created.");
        }

        public BoardController()
        {
        }

        // GET: Board
        public ActionResult Index()
        {
            return View();
        }

        // GET: Board/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Board/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Board/Create
        /// <summary>
        /// Boradを作成する。
        /// </summary>
        /// <param name="prm"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(BoardCreateInfoMdl mdl)
        {
            try
            {
                // TODO: Add insert logic here
                decimal res = boardSrv.Create(mdl);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Debug.WriteLine("message: " + ex.Message);
                Debug.WriteLine("stack trace: ");
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine("");
                return View();
            }
        }

        // GET: Board/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Board/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Board/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Board/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
