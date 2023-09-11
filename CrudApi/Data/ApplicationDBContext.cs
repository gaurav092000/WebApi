using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CrudApi.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("WebApiCrud") { }


    }
}