using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sol_Encode.Models;

namespace Sol_Encode.Controllers
{
    public class HtmlEncoderDemoController : Controller
    {
        private readonly HtmlEncoder htmlEncoder = null;

        public HtmlEncoderDemoController(HtmlEncoder htmlEncoder)
        {
            this.htmlEncoder = htmlEncoder;
        }

        [BindProperty]
        public UserModel Users { get; set; }

        private void EncodeUserModel()
        {
            Users.FullName = htmlEncoder.Encode(Users.FullName);
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OnSubmit()
        {
            EncodeUserModel();

            return View("Index",Users);
        }
    }
}