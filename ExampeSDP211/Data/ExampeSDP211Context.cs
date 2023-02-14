using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExampeSDP211;

namespace ExampeSDP211.Data
{
    public class ExampeSDP211Context : DbContext
    {
        public ExampeSDP211Context (DbContextOptions<ExampeSDP211Context> options)
            : base(options)
        {
        }

        public DbSet<ExampeSDP211.WeatherForecast> WeatherForecast { get; set; }
    }
}
