using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TreeViewProject.Models
{
    public class MenuSiteModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string SelectedParent { get; set; }

    }
}