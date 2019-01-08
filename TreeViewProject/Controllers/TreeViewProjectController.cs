using Microsoft.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace TreeViewProject.Controllers
{
    //Layer Supertype
    public abstract class TreeViewProjectController : Controller
    {
        protected ActionResult RedirectToAction<TController>(
            Expression<Action<TController>> action)
            where TController : Controller
        {
            return ControllerExtensions.RedirectToAction(this, action);
        }
    }
}