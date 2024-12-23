using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using System.Data.Entity;

namespace Zayavki
{
    public partial class ZayavkaContext : DbContext
    {
        public ZayavkaContext() : base("name=ZayavkaConnectionString") { }

        public DbSet<Zayavka> Zayavka { get; set; }
    }
}
