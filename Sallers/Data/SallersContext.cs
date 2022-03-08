using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sallers.Models;

namespace Sallers.Data
{
    public class SallersContext : DbContext
    {
        public SallersContext (DbContextOptions<SallersContext> options)
            : base(options)
        {
        }

        public DbSet<Sallers.Models.Departmeent> Departmeent { get; set; }
    }
}
