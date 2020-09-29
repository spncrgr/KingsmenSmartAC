using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingsmenSmartAC.API.Models;

namespace KingsmenSmartAC.API.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        // Tables
        public DbSet<Device> Devices { get; set; }
    }
}