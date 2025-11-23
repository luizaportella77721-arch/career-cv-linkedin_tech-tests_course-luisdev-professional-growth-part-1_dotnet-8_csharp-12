using JobsAPI.Entities;
using JobsAPI.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobsAPI.Controllers
{
    [ApiController]
    [Route("api/jobs")]
    public class JobsController : ControllerBase
    {
        private readonly JobsDbContext _context;
        public JobsController(JobsDbContext context)
        {
            _context = context;
        }

        // GET api/jobs
        [HttpGet]
        public IActionResult GetAll()
        {
            var jobs = _context.Jobs.ToList();

            return Ok(jobs);
        }

        // GET api/jobs/123
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var job = _context.Jobs.SingleOrDefault(j => j.Id == id);

            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        // POST api/jobs
        [HttpPost]
        public IActionResult Post(Job job)
        {
            _context.Jobs.Add(job);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = job.Id }, job);
        }

        // PUT api/jobs/123
        [HttpPut("{id}")]
        public IActionResult Put(int id, Job input)
        {
            var job = _context.Jobs
                .SingleOrDefault(j => j.Id == id);

            if (job == null)
            {
                return NotFound();
            }

            job.Update(input.Title, input.Description, input.Company, input.Location, input.Salary);

            _context.Jobs.Update(job);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE api/jobs/123
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var job = _context.Jobs
                .SingleOrDefault(j => j.Id == id);

            if (job == null)
            {
                return NotFound();
            }

            _context.Jobs.Remove(job);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
