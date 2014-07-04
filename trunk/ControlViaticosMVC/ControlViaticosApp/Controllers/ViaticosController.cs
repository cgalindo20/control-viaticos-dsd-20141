using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControlViaticosApp.Models;

namespace ControlViaticosApp.Controllers
{
    public class ViaticosController : Controller
    {

        private List<Viaticos> CrearViaticos()
    {
        List<Viaticos> viaticos = new List<Viaticos>();
        viaticos.Add(new Viaticos() { Codigo = 1, ApellidosNombres = "Alvaro Castro Roman", Cargo = "Ejecutivo Ventas", Area = "Ventas", CentroCosto = "14345", JustificacionViaje = "Firma de contrato de crédito", LugarPartida = "Lima", LugarDestino = "Piura", FomaPago = "Efectivo", NumeroDias = 5, MontoViaticoDiario = 120, MontoTotal = 600, Estado = "Aprobado" });
        viaticos.Add(new Viaticos() { Codigo = 2, ApellidosNombres = "Moreno Valvede Maria", Cargo = "Ejecutivo Cuenta", Area = "Ventas", CentroCosto = "14345", JustificacionViaje = "Firma de contrato de crédito", LugarPartida = "Lima", LugarDestino = "Cuzco", FomaPago = "Deposito Bancario", NumeroDias = 3, MontoViaticoDiario = 100, MontoTotal = 300, Estado = "Desaprobado" });
        viaticos.Add(new Viaticos() { Codigo = 3, ApellidosNombres = "Salazar Mendieta Hugo", Cargo = "Ejecutivo Negocio", Area = "Comercial", CentroCosto = "89876", JustificacionViaje = "Venta de productos", LugarPartida = "Lima", LugarDestino = "Arequipa", FomaPago = "Efectivo", NumeroDias = 2, MontoViaticoDiario = 85, MontoTotal = 170, Estado = "Aprobado" });
        viaticos.Add(new Viaticos() { Codigo = 4, ApellidosNombres = "Sanchez Velez Andrés", Cargo = "Ejecutivo Ventas", Area = "Ventas", CentroCosto = "14345", JustificacionViaje = "Firma de contrato de crédito", LugarPartida = "Tacna", LugarDestino = "Lima", FomaPago = "Efectivo", NumeroDias = 4, MontoViaticoDiario = 90, MontoTotal = 360, Estado = "Pendiente" });

        return viaticos;
    }
        private Viaticos ObtenerViatico(int codigo) { 
        
            List<Viaticos> viaticos = (List<Viaticos>)Session["viaticos"];
                Viaticos model = viaticos.Single(delegate(Viaticos viatico){
                    if (viatico.Codigo == codigo) return true;
                    else return false;                
                });
                return model;
        }
        //
        // GET: /Viaticos/

        public ActionResult Index()
        {
            if(Session["viaticos"] == null)
                Session["viaticos"] = CrearViaticos();
            List<Viaticos> model = (List<Viaticos>) Session["viaticos"]; 
            return View(model);
        }


        //
        // GET: /Viaticos/Details/5

        public ActionResult Details(int id)
        {
            Viaticos model = ObtenerViatico(id);
            return View(model);
        }

        //
        // GET: /Viaticos/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Viaticos/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                List<Viaticos> viaticos = (List<Viaticos>)Session["viaticos"];

                viaticos.Add(new Viaticos()
                {
                    Codigo = int.Parse(collection["Codigo"]),
                    ApellidosNombres = collection["ApellidosNombres"],
                    Cargo = collection["Cargo"],
                    Area = collection["Area"],
                    CentroCosto = collection["CentroCosto"],
                    JustificacionViaje = collection["JustificacionViaje"],
                    LugarPartida = collection["LugarPartida"],
                    LugarDestino = collection["LugarDestino"],
                    FomaPago = collection["FomaPago"],
                    NumeroDias = int.Parse(collection["NumeroDias"]),
                    MontoViaticoDiario = Double.Parse(collection["MontoViaticoDiario"]),
                    MontoTotal = Double.Parse(collection["MontoTotal"])
                });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Viaticos/Edit/5
 
        public ActionResult Edit(int id)
        {
            Viaticos model = ObtenerViatico(id);
            return View(model);
        }

        //
        // POST: /Viaticos/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Viaticos model = ObtenerViatico(id);
                model.ApellidosNombres = collection["ApellidosNombres"];
                model.Cargo = collection["Cargo"];
                model.Area = collection["Area"];
                model.CentroCosto = collection["CentroCosto"];
                model.JustificacionViaje = collection["JustificacionViaje"];
                model.LugarPartida = collection["LugarPartida"];
                model.LugarDestino = collection["LugarDestino"];
                model.FomaPago = collection["FomaPago"];
                model.NumeroDias = int.Parse(collection["NumeroDias"]);
                model.MontoViaticoDiario = Double.Parse(collection["MontoViaticoDiario"]);
                model.MontoTotal = Double.Parse(collection["MontoTotal"]);
                model.Estado = "Pendiente";
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Viaticos/Delete/5
 
        public ActionResult Delete(int id)
        {
            Viaticos model = ObtenerViatico(id);
            return View(model);
        }

        //
        // POST: /Viaticos/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                List<Viaticos> viaticos = (List<Viaticos>)Session["viaticos"];
                viaticos.Remove(ObtenerViatico(id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
