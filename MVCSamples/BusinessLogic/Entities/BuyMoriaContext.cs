using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BusinessLogic.Models
{
    public class BuyMoriaContext : DbContext
    {
        public BuyMoriaContext() : base("BuyMoria") { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Expense> Expenses { get; set; }
    }
}