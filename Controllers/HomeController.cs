using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoDachi.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace DojoDachi.Controllers
{
    public class HomeController : Controller
    {
        public DojoPet newDojoPet{get; set;}

        [HttpGet("")]
        public IActionResult Index()
        {
            string dd = HttpContext.Session.GetString("d");
            if( dd == null)
            {
                newDojoPet = new DojoPet();
                HttpContext.Session.SetString("d", JsonConvert.SerializeObject(newDojoPet));
            }
            else
            {
                newDojoPet = JsonConvert.DeserializeObject<DojoPet>(dd);
                newDojoPet.CheckWin();
                newDojoPet.CheckDead();
                // System.Console.WriteLine("sfdsfd");
            }
            // d.UpdateStatus(d.Happiness, d.Fullness, d.Energy, d.Meals, d.Message);
            return View(newDojoPet);
        }

        [HttpGet("feed")]
        public IActionResult Feed()
        {            
            string dd = HttpContext.Session.GetString("d");
            newDojoPet = JsonConvert.DeserializeObject<DojoPet>(dd);
            newDojoPet.Feed();
            HttpContext.Session.SetString("d", JsonConvert.SerializeObject(newDojoPet));
            return RedirectToAction("Index",newDojoPet);
        }

        [HttpGet("play")]
        public IActionResult Play()
        {
            string dd = HttpContext.Session.GetString("d");
            newDojoPet = JsonConvert.DeserializeObject<DojoPet>(dd);
            newDojoPet.Play();
            HttpContext.Session.SetString("d", JsonConvert.SerializeObject(newDojoPet));
            return RedirectToAction("Index", newDojoPet);
        }
        [HttpGet("work")]
        public IActionResult Work()
        {
            string dd = HttpContext.Session.GetString("d");
            newDojoPet = JsonConvert.DeserializeObject<DojoPet>(dd);
            newDojoPet.Work();
            HttpContext.Session.SetString("d", JsonConvert.SerializeObject(newDojoPet));
            return RedirectToAction("Index", newDojoPet);
        }
        [HttpGet("sleep")]
        public IActionResult Sleep()
        {
            string dd = HttpContext.Session.GetString("d");
            newDojoPet = JsonConvert.DeserializeObject<DojoPet>(dd);
            newDojoPet.Sleep();
            HttpContext.Session.SetString("d", JsonConvert.SerializeObject(newDojoPet));
            return RedirectToAction("Index", newDojoPet);
        }

        [HttpGet("reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}
