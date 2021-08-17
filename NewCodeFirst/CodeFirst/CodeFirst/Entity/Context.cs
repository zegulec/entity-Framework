using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CodeFirst.Entity;
namespace CodeFirst.Entity
{
    class Context:DbContext
    {
        public DbSet<Musteri> Musteri { get; set; }
        public DbSet<Ev> Ev { get; set; }
        public DbSet<Satislar> Satislar { get; set; }
    }
}
