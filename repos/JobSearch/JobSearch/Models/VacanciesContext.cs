using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.Models
{
    public class VacanciesContext : DbContext
    {
        public DbSet<Vacancy> Vacancies { get; set; }
        public VacanciesContext(DbContextOptions<VacanciesContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
