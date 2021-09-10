using customerCompanyAPI.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace customerCompanyAPI.Data
{
    public class DataContext : DbContext
    {


        public DataContext(DbContextOptions<DataContext> option) : base(option)
        {

        }
        public DbSet<Country> Countries { set; get; }
        public DbSet<City> Cities { set; get; }
        public DbSet<Status> Status { set; get; }
        public DbSet<Role> Roles { set; get; }
        public DbSet<Customer> VW_customers { set; get; }
        public DbSet<Company> VW_companies_branches {set; get;}
        public DbSet<Address> VW_customer_addresses { set; get; }
        public DbSet<Phone> VW_customers_phones { set; get; }
        public DbSet<Customer> VW_Customer_Companies { set; get; }
        public DbSet<User> VW_User_Company { set; get; }
        
        public IConfiguration Configurarion { get; }
        
    }
}
