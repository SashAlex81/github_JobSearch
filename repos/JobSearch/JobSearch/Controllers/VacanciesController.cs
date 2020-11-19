using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobSearch.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobSearch.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacanciesController : ControllerBase
    {
        VacanciesContext db;
        public VacanciesController(VacanciesContext context)
        {
            db = context;
            if (!db.Vacancies.Any())
            {
                db.Vacancies.Add(new Vacancy
                {
                    Header = "Programmer",
                    Salary = 50000,
                    Organization = "SoftTech",
                    ContactPerson = "John Alekseev",
                    Phone = "+73563478347",
                    TypeOfEmployment = "Software development",
                    Description = "Development of Web Api applications"
                });
                db.Vacancies.Add(new Vacancy
                {
                    Header = "Programmer1",
                    Salary = 60000,
                    Organization = "SoftTech1",
                    ContactPerson = "John Alekseev1",
                    Phone = "+735634783471",
                    TypeOfEmployment = "Software development1",
                    Description = "Development of Web Api applications1"
                });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vacancy>>> Get(string header, int? salaryFrom, int? salaryTo)
        {
            var vacancies = db.Vacancies.AsQueryable();

            if (!string.IsNullOrEmpty(header))
            {
                vacancies = vacancies.Where(i => i.Header.Contains(header));
            }

            if (salaryFrom.HasValue)
            {
                vacancies = vacancies.Where(i => i.Salary >= salaryFrom);
            }

            if (salaryTo.HasValue)
            {
                vacancies = vacancies.Where(i => i.Salary <= salaryTo);
            }

            //List<Vacancy> listVacancy = await vacancies.ToListAsync();
            //return listVacancy;
            return await vacancies.ToListAsync();
        }

        // GET api/vacancies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vacancy>> Get(int id)
        {
            Vacancy vacancy = await db.Vacancies.FirstOrDefaultAsync(x => x.Id == id);
            if (vacancy == null)
                return NotFound();

            return new ObjectResult(vacancy);
        }

        // POST api/vacancies
        [HttpPost]
        public async Task<ActionResult<Vacancy>> Post(Vacancy vacancy)
        {
            if (vacancy == null)
                return BadRequest();

            db.Vacancies.Add(vacancy);
            await db.SaveChangesAsync();
            return Ok(vacancy);
        }

        // PUT api/vacancies/
        [HttpPut]
        public async Task<ActionResult<Vacancy>> Put(Vacancy vacancy)
        {
            if (vacancy == null)
                return BadRequest();

            if (!db.Vacancies.Any(x => x.Id == vacancy.Id))
                return NotFound();

            db.Update(vacancy);
            await db.SaveChangesAsync();
            return Ok(vacancy);
        }

        // DELETE api/vacancies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vacancy>> Delete(int id)
        {
            Vacancy vacancy = db.Vacancies.FirstOrDefault(x => x.Id == id);
            if (vacancy == null)
                return NotFound();

            db.Vacancies.Remove(vacancy);
            await db.SaveChangesAsync();
            return Ok(vacancy);
        }
    }
}
