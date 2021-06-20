using MVCWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVCWebApplication.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<EmployeeViewModel> employees;
            HttpResponseMessage response = GlobalHttpConnection.HttpConnection.webAPIClient.GetAsync("employees").Result;
            employees = response.Content.ReadAsAsync<IEnumerable<EmployeeViewModel>>().Result;
            return View(employees);
        }
    }
}