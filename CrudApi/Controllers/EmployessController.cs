using CrudApi.Data;
using CrudApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrudApi.Controllers
{
    public class EmployessController : ApiController
    {
        public HttpResponseMessage Get()
        {
            using (ApplicationDBContext dBContext = new ApplicationDBContext())
            {
                return Request.CreateResponse(HttpStatusCode.OK, dBContext.employesses.ToList());
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (ApplicationDBContext dBContext = new ApplicationDBContext())
            {
                var emp = dBContext.employesses.FirstOrDefault(e => e.Id == id);
                if (emp != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Empoyees with id " + id + "not found in database");
                }
            }
        }

        public HttpResponseMessage Post(Employess e)
        {
            using (ApplicationDBContext dBContext = new ApplicationDBContext())
            {
                if (e != null)
                {
                     dBContext.employesses.Add(e);
                    dBContext.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK,e);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Please provide proper input data to create data employess");
                }
            }

        }

        public HttpResponseMessage Put(int id, Employess ee)
        {
            using (ApplicationDBContext dBContext = new ApplicationDBContext())
            {
                var emp = dBContext.employesses.FirstOrDefault(e => e.Id == id);
                if (emp != null)
                {
                    emp.FirstName = ee.FirstName;
                    emp.LastName = ee.LastName;
                    emp.Gender = ee.Gender;
                    emp.City = ee.City;
                    emp.IsActive= ee.IsActive;
                    dBContext.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
;                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employess with Id " + id + "not found in database update fail  ");
                }
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            using (ApplicationDBContext dBContext = new ApplicationDBContext())
            {
                 
                var emp = dBContext.employesses.FirstOrDefault(e => e.Id == id);
                if(emp != null)
                {
                    dBContext.employesses.Remove(emp);
                    dBContext.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employees with Id " + id + "not found in database. Delete fail");
                }
            }
        }

    }
}
