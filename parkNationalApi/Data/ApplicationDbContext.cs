using Microsoft.EntityFrameworkCore;
using parkNationalApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parkNationalApi.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<NationalPark> NationalPark { get; set; }
        public DbSet<Trails> Trails { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
