using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pedre.Models;

    public class MvcSodaContext : DbContext
    {
        public MvcSodaContext (DbContextOptions<MvcSodaContext> options)
            : base(options)
        {
        }

        public DbSet<Pedre.Models.Soda> Soda { get; set; } = default!;
    }
