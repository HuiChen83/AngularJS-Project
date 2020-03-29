using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebAppAngularJS.Models
{
    public class CrudContext: DbContext
    {
        public DbSet<WebAppAngularJS.Models.Trip> Trips { get; set; }
    }
}