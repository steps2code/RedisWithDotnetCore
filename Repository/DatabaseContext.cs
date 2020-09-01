using Microsoft.EntityFrameworkCore;
using RedisWebAPIDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisWebAPIDemo.Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<CountryMaster> CountryMaster { get; set; }
    }
}
