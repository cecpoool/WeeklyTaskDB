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
using WebApi2;

namespace WebApi2.Controllers
{
    public class LoansController : ApiController
    {
        private WeeklyTaskEntities db = new WeeklyTaskEntities();

        // GET: api/Loans
        public IQueryable<Loan> GetLoans()
        {
            return db.Loans;
        }

        // GET: api/Loans/5
        [ResponseType(typeof(Loan))]
        public IHttpActionResult GetLoan(string id)
        {
            Loan loan = db.Loans.Find(id);
            if (loan == null)
            {
                return NotFound();
            }

            return Ok(loan);
        }

        // PUT: api/Loans/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLoan(string id, Loan loan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loan.STUDENT_ID)
            {
                return BadRequest();
            }

            db.Entry(loan).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Loans
        [ResponseType(typeof(Loan))]
        public IHttpActionResult PostLoan(Loan loan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Loans.Add(loan);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LoanExists(loan.STUDENT_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = loan.STUDENT_ID }, loan);
        }

        // DELETE: api/Loans/5
        [ResponseType(typeof(Loan))]
        public IHttpActionResult DeleteLoan(string id)
        {
            Loan loan = db.Loans.Find(id);
            if (loan == null)
            {
                return NotFound();
            }

            db.Loans.Remove(loan);
            db.SaveChanges();

            return Ok(loan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LoanExists(string id)
        {
            return db.Loans.Count(e => e.STUDENT_ID == id) > 0;
        }
    }
}