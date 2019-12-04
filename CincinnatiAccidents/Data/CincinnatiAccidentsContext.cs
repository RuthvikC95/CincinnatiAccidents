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

        public DbSet<CincinnatiAccidents.Models.Accident> Accident { get; set; }
        public DbSet<CincinnatiAccidents.Models.CitizenSurvey> CitizenSurvey { get; set; }
    }
}
