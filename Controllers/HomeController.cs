﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Three.Servies;

namespace Three.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IClock clock)
        {
                
        }
    }
}
