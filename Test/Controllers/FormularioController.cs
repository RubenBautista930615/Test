using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class FormularioController : Controller
    {
        // GET: Formulario
        public ActionResult Index()
        {
            List<SelectListItem> listNo = new List<SelectListItem>();
            listNo.Add(new SelectListItem { Text = "1", Value = "1" });
            listNo.Add(new SelectListItem { Text = "2", Value = "2" });
            listNo.Add(new SelectListItem { Text = "3", Value = "3" });

            ViewBag.No = listNo;

            return View();
        }

        [HttpPost]
        public ActionResult Pagar([Bind(Exclude = "FormularioId")] Formulario f)
        {
            if (!ModelState.IsValid)
            {
                TempData["success"] = "false";
                return RedirectToAction("Index");
            }

            TempData["success"] = "true";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ObtenerUsuarios()
        {

            List<User> listObjects = new List<User>();

            string response = "";
            using (var client = new WebClient() { UseDefaultCredentials = true })
            {
                response = client.DownloadString("https://jsonplaceholder.typicode.com/users");
            }

            listObjects = JsonConvert.DeserializeObject<List<User>>(response);

            return Json(new { listObjects = listObjects }, JsonRequestBehavior.AllowGet);
        }
    }
}