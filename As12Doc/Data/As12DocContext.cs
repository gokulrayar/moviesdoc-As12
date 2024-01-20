using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using As12Doc.Models;

namespace As12Doc.Data
{
    public class As12DocContext : DbContext
    {
        public As12DocContext (DbContextOptions<As12DocContext> options)
            : base(options)
        {
        }

        public DbSet<As12Doc.Models.Movies> Movies { get; set; } = default!;
    }
}
