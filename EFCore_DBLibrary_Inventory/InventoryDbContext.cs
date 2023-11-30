using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFCore_DBLibrary_Inventory
{
    public  class InventoryDbContext:DbContext
    {
        public InventoryDbContext()
        {
                
        }
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options): base(options)
        {
                
        }
    }
}
