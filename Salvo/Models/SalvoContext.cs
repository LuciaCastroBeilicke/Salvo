using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salvo.Models
{
    public class SalvoContext : DbContext
    {
        public SalvoContext(DbContextOptions<SalvoContext> options)
            : base(options)
        {

        }
        //ir agregando nuestro DbSet a medida que los vayamos agregando
        public DbSet<Player> Players { get; set; }
        //hacer con las demas entidades que creemos en nuestro modelo
        public DbSet<Game> Games { get; set; }
    }
}
