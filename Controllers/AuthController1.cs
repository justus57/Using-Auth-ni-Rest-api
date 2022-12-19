using ApiUpdate;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace ApiUpdate.Controllers
{
    public class AuthController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

    
}

