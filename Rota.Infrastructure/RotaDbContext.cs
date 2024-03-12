using Microsoft.EntityFrameworkCore;
using Rota.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rota.Infrastructure;

public class RotaDbContext : DbContext
{
    public RotaDbContext(DbContextOptions<RotaDbContext> options)
        : base(options)
    {
    }

    public DbSet<RotaEntities> Rotas { get; set; }
}
