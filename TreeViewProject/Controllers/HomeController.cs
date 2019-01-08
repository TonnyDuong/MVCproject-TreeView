using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreeViewProject.Models;
using Microsoft.Web.Mvc;
using TreeViewProject.Infrastructure.Alerts;

namespace TreeViewProject.Controllers
{
    public class HomeController : Controller
    {
        public List<MenuSite> Tree;
        public ActionResult Index()
        {
            Tree = new List<MenuSite>();
            using (CityInfoDBEntities dc = new CityInfoDBEntities() )
            {
                Tree = dc.MenuSites.OrderBy(T => T.MenuId).ToList();
            }

            return View(Tree);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Create()
        {
            var model = new MenuSiteModel();
            var myList = new List<string>();
            using (CityInfoDBEntities dc = new CityInfoDBEntities())
            {
               // foreach (var entry in dc.MenuSites.OrderBy(T => T.ParentId).ToList())
                //{ myList.Add(entry.ToString()); }

                var ListQuery = from q in dc.MenuSites
                                orderby q.MenuId
                                select q.MenuName;
                myList.AddRange(ListQuery.Distinct());
                ViewBag.myList = new SelectList(myList);

            }

            //model.ParentList = (IEnumerable<SelectListItem>) myList;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(MenuSiteModel Model, string myList)
        {
            if (String.IsNullOrEmpty(Model.Name))
            {
                return(Create().WithError("Please provide a valid name!"));
            }

            MenuSite newEntry = new MenuSite();
            newEntry.MenuName = Model.Name;

            using (CityInfoDBEntities dc = new CityInfoDBEntities())
            {
                var MenuSiteModelId = dc.MenuSites.FirstOrDefault(i => i.MenuName == myList);
                if (MenuSiteModelId != null)
                {
                    newEntry.ParentId = MenuSiteModelId.MenuId;
                }
                else
                {
                    newEntry.ParentId = 0;
                }
                

                dc.MenuSites.Add(newEntry);
                dc.SaveChanges();
            }

            return this.RedirectToAction<HomeController>(c => c.Index()).WithSuccess("Item Created!");
        }

        
        public ActionResult Delete()
        {
            var myList = new List<string>();
            using (CityInfoDBEntities dc = new CityInfoDBEntities())
            {
                var ListQuery = from q in dc.MenuSites
                                orderby q.MenuId
                                select q.MenuName;
                myList.AddRange(ListQuery.Distinct());
                ViewBag.myList = new SelectList(myList);

            }
            return View();
        }


        [HttpPost]
        public ActionResult Delete(string myList)
        {
            using (CityInfoDBEntities dc = new CityInfoDBEntities())
            {
                var MenuSiteEntry = dc.MenuSites.FirstOrDefault(i => i.MenuName == myList);

                if (MenuSiteEntry != null)
                {
                    DeleteBranch(dc, MenuSiteEntry);
                    dc.SaveChanges();
                }
                else
                {
                    return this.RedirectToAction<HomeController>(c => c.Index())
                        .WithError("Please select a valid item to delete!");
                }
                
            }
            return this.RedirectToAction<HomeController>(c => c.Index())
                .WithSuccess("Branch Item successfully deleted.");
        }

        public void DeleteBranch(CityInfoDBEntities dc, MenuSite branch)
        {
            var childList = dc.MenuSites.Where(a => a.ParentId == branch.MenuId).ToList();
            if (childList.Count != 0)
            {
                foreach (var child in childList)
                {
                    DeleteBranch(dc, child);
                }
            }
            dc.MenuSites.Remove(branch);
        }
    }
}