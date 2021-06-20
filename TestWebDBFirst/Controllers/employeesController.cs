using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TestWebDBFirst.Models;
using TestWebDBFirst.Repository;

namespace TestWebDBFirst.Controllers
{
    public class employeesController : ApiController
    {
        private IGenericRepository<employee> repository = null;
        public employeesController()
        {
            repository = new GenericRepository<employee>();
        }

        // GET: api/employees
        public IQueryable<employee> Getemployees()
        {
            return repository.GetAll();
        }

        // GET: api/employees/5
        [ResponseType(typeof(employee))]
        public IHttpActionResult Getemployee(int id)
        {
            employee employee = repository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putemployee(employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            repository.Update(employee);

            try
            {
                repository.save();
            }
            catch (DbUpdateConcurrencyException)
            {
                
                    throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/employees
        [ResponseType(typeof(employee))]
        public IHttpActionResult Postemployee(employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.Insert(employee);

            try
            {
                repository.save();
            }
            catch (DbUpdateException)
            {
                if (employeeExists(employee.empId)!=null)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = employee.empId }, employee);
        }

        // DELETE: api/employees/5
        [ResponseType(typeof(employee))]
        public IHttpActionResult Deleteemployee(int id)
        {
            employee employee = employeeExists(id);
            if (employee == null)
            {
                return NotFound();
            }

            repository.Delete(employee);
            repository.save();

            return Ok(employee);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private employee employeeExists(int id)
        {
            return repository.GetById(id);
        }
    }
}