using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreeViewProject.Infrastructure.Alerts;

namespace TreeViewProject.Infrastructure.Alerts
{
    public class Alert
    {
        public string AlertClass { get; set; }
        public string Message { get; set; }

        public Alert(string alertClass, string message)
        {
            AlertClass = alertClass;
            Message = message;
        }
    }
}
