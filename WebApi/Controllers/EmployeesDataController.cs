using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class EmployeesDataController : ApiController
    {
        public string[] myEmpoyees = { "Gaurav", "Raju", "Ramesh" };
        [HttpGet]
        public string[] GetEmployees()
        {
            return myEmpoyees;
        }

        [HttpGet]
        public string GetEmplyeesByIndex(int id)
        {
            return myEmpoyees[id];
        }
    }
}
