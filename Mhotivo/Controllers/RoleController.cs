﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mhotivo.App_Data;
using Mhotivo.App_Data.Repositories;
using Mhotivo.Models;

namespace Mhotivo.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleRepository repository = new RoleRepository(new MhotivoContext());
                //
        // GET: /Role/

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(repository.Query( x => x));
        }

        //
        // GET: /Role/

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var role = repository.GetById(id);
            return View("_Edit", role);
        }

        [HttpPost]
        public ActionResult Edit(Role modelRole)
        {
            repository.Update(modelRole);
            return View("Index", repository.Query(x => x));
        }
    }
}
