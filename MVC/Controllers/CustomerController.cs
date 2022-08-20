using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            IEnumerable<Customer> custList;
            HttpResponseMessage response = GlobalVariables.WebAPIClient.GetAsync("Customer").Result;
            custList = response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
            return View(custList);
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Customer());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebAPIClient.GetAsync("Customer/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Customer>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(Customer cust)
        {


            HttpResponseMessage response = GlobalVariables.WebAPIClient.PostAsJsonAsync("Customer", cust).Result;



            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebAPIClient.DeleteAsync("Customer/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
        //return View();
    }

}

