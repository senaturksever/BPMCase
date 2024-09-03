using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMCase.DataAccess.Context
{
    public class ApplicationDbContext :DbContext
    {
        private const string DefaultConnectionString =
       "";
        public ApplicationDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(DefaultConnectionString);
            }
        }
    }
}
