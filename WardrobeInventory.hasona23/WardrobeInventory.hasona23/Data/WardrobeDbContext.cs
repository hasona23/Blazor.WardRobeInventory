using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WardrobeInventory.hasona23.Models;

namespace WardrobeInventory.hasona23.Data
{
    public class WardrobeDbContext : DbContext
    {
        public WardrobeDbContext (DbContextOptions<WardrobeDbContext> options)
            : base(options)
        {
        }

        public DbSet<WardrobeInventory.hasona23.Models.WearItem> WearItem { get; set; } = default!;
    }
}
