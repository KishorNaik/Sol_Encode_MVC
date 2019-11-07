using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sol_Encode.Models;

namespace Sol_Encode.Controllers
{
    public class UrlEncoderDemoController : Controller
    {
        private readonly UrlEncoder urlEncoder = null;

        public UrlEncoderDemoController(UrlEncoder urlEncoder)
        {
            this.urlEncoder = urlEncoder;
        }

        [BindProperty]
        public UserModel Users { get; set; }

        private void EncodeUserModel()
        {
            Users.FullName = urlEncoder.Encode(Users.FullName);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OnSubmit()
        {
            EncodeUserModel();

            return View("Index", Users);
        }

        [HttpGet("onget/{value}",Name ="onget")]
        public IActionResult OnGet(string value)
        {
            base.ViewBag.Value = value;
            return View();
        }
    }
}