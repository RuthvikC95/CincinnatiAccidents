using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CincinnatiAccidents.Models;

namespace CincinnatiAccidents.Models
{
    public class CincinnatiAccidentsContext : DbContext
    {
        public CincinnatiAccidentsContext (DbContextOptions<CincinnatiAccidentsContext> options)
            : base(options)
        {
        }

        public DbSet<CincinnatiAccidents.Models.Neighbourhood> Neighbourhood { get; set; }

        public DbSet<CincinnatiAccidents.Models.FireStation> FireStation { get; set; }
    }
}
