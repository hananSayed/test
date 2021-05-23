using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace softZoneRestTask.Models
{
    public class RestaurantsRes:DbContext
    {
        public RestaurantsRes()
           : base("restDB")
        {
        }
        public DbSet<user> Users { get; set; }
        public DbSet<order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<RestInfo> RestInfos { get; set; }
        public DbSet<City> Cities { get; set; }

    }
}