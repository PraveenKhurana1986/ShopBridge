using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopBridge.Models
{
    public class SqlDbContext :DbContext
    {
        public SqlDbContext() : base("name=ShopBridgeEntities")
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}