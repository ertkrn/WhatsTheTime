using SaatKac.Classes;
using SaatKac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SaatKac.Controllers
{
    public class HomeController : Controller
    {
        private SayidanYaziya sy = new SayidanYaziya();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Guncel()
        {
            DateTime simdi = new DateTime();
            simdi = DateTime.Now;
            string hr = simdi.Hour.ToString();
            string mn = simdi.Minute.ToString();
            StringBuilder yazi = new StringBuilder();
            string saat = sy.cevir(simdi.Hour);
            string dakika = sy.cevir(simdi.Minute);
            if (mn == "0")
            {
                yazi.Append("Saat ");
                yazi.Append(saat);
            }
            else if (Int16.Parse(mn) * 4 == 60)
            {
                yazi.Append(saat);
                yazi.Append("'i çeyrek geçiyor.");
            }
            else if (Int16.Parse(mn) + 15 == 60)
            {
                yazi.Append(saat);
                yazi.Append("'e çeyrek var.");
            }
            else if (Int16.Parse(mn) == 30)
            {
                yazi.Append("Saat ");
                yazi.Append(saat);
                yazi.Append(" buçuk.");
            }
            else
            {
                if (Int16.Parse(mn) > 30)
                {
                    int var = 60 - Int16.Parse(mn);
                    saat = sy.cevir(Int16.Parse(hr) + 1);
                    dakika = sy.cevir(var);
                    yazi.Append("Saat ");
                    yazi.Append(saat);
                    string ek = sy.esonikiharf(saat);
                    //yazi.Append("'e ");
                    yazi.Append("'");
                    yazi.Append(ek);
                    yazi.Append(" ");
                    yazi.Append(dakika);
                    yazi.Append(" var.");
                }
                else
                {
                    yazi.Append("Saat ");
                    yazi.Append(saat);
                    string ek = sy.isonikiharf(saat);
                    //yazi.Append("'i ");
                    yazi.Append("'");
                    yazi.Append(ek);
                    yazi.Append(" ");
                    yazi.Append(dakika);
                    yazi.Append(" geçiyor.");
                }
            }
            return Json(yazi.ToString());
        }

        [HttpPost]
        public JsonResult Saat(SaatViewModel model)
        {
            StringBuilder yazi = new StringBuilder();
            string saat = sy.cevir(Int16.Parse(model.saat));
            string dakika = sy.cevir(Int16.Parse(model.dakika));
            if (model.dakika == "0")
            {
                yazi.Append("Saat ");
                yazi.Append(saat);
            }
            else if (Int16.Parse(model.dakika) * 4 == 60)
            {
                yazi.Append(saat);
                yazi.Append("'i çeyrek geçiyor.");
            }
            else if (Int16.Parse(model.dakika) + 15 == 60)
            {
                yazi.Append(saat);
                yazi.Append("'e çeyrek var.");
            }
            else if (Int16.Parse(model.dakika)==30)
            {
                yazi.Append("Saat ");
                yazi.Append(saat);
                yazi.Append(" buçuk.");
            }
            else
            {
                if (Int16.Parse(model.dakika) > 30)
                {
                    int var = 60 - Int16.Parse(model.dakika);
                    saat = sy.cevir(Int16.Parse(model.saat) + 1);
                    dakika = sy.cevir(var);
                    yazi.Append("Saat ");
                    yazi.Append(saat);
                    string ek = sy.esonikiharf(saat);
                    //yazi.Append("'e ");
                    yazi.Append("'");
                    yazi.Append(ek);
                    yazi.Append(" ");
                    yazi.Append(dakika);
                    yazi.Append(" var.");
                }
                else
                {
                    yazi.Append("Saat ");
                    yazi.Append(saat);
                    string ek = sy.isonikiharf(saat);
                    //yazi.Append("'i ");
                    yazi.Append("'");
                    yazi.Append(ek);
                    yazi.Append(" ");
                    yazi.Append(dakika);
                    yazi.Append(" geçiyor.");
                }
            }
            return Json(yazi.ToString());
        }
    }
}