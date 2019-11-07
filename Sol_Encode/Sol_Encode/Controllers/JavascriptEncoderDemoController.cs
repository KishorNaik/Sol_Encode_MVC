using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sol_Encode.Models;

namespace Sol_Encode.Controllers
{
    public class JavascriptEncoderDemoController : Controller
    {
        private readonly JavaScriptEncoder javaScriptEncoder = null;

        public JavascriptEncoderDemoController(JavaScriptEncoder javaScriptEncoder)
        {
            this.javaScriptEncoder = javaScriptEncoder;
        }

        [BindProperty]
        public UserModel Users { get; set; }


        #region Private Method
        private void EncodeUserModel()
        {
            Users.FullName = javaScriptEncoder.Encode(Users.FullName);
        }
        #endregion 

        #region Actions
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
        #endregion 
    }
}