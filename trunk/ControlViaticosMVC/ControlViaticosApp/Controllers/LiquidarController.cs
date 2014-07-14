using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControlViaticosApp.Models;

namespace ControlViaticosApp.Controllers
{
    public class LiquidarController : Controller
    {

        //Instanciar LiquidarServices
        private  LiquidacionesWS.LiquidacionesClient proxy = new LiquidacionesWS.LiquidacionesClient();
        
        //
        // GET: /Liquidar/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Liquidar/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Liquidar/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Liquidar/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Liquidar/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Liquidar/Edit/5

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

        //
        // GET: /Liquidar/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Liquidar/Delete/5

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
