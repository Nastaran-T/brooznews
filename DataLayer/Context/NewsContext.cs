using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class NewsContext:DbContext
    {
        public NewsContext()
        {

        }

        public DbSet<Page> Pages { get; set; }
        public DbSet<PageGroup> PageGroups { get; set; }
        public DbSet<PageComment> PageComments { get; set; }
        public DbSet<Login> Logins { get; set; }

    }
}

