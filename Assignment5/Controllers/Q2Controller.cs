using Assignment5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment5.Controllers
{
    public class Q2Controller : ApiController
    {
        DbBookEntities bdb = new DbBookEntities();
        public IHttpActionResult PostBookData(tblBook book) {
            try {
                if(book != null) {
                    bdb.tblBooks.Add(book);
                    bdb.SaveChanges();
                    return Ok("Data Inserted Successfully");
                } else {
                    return BadRequest("Something went wrong.");
                }
            } catch (Exception) {
                return Content(HttpStatusCode.InternalServerError, "Primary key Violation");
            }
        }
        public IHttpActionResult GetBookData() {
            try {
                List<tblBook> bdata = bdb.tblBooks.ToList();
                if (bdata.Count > 0) {
                    return Content(HttpStatusCode.OK, bdata);
                } else {
                    return Content(HttpStatusCode.NoContent, "No Record Found.");
                }
            } catch (Exception) {
                return Content(HttpStatusCode.InternalServerError, "Something went wrong.");
            }
        }

        public IHttpActionResult GetBookData(int bid) {
            try {
                tblBook b = bdb.tblBooks.Find(bid);
                if (b != null) {
                    return Content(HttpStatusCode.OK, b);
                } else {
                    return Content(HttpStatusCode.NoContent, "No data found with Book Id " + bid);
                }
            } catch (Exception) {
                return Content(HttpStatusCode.InternalServerError, "Something went wrong.");
            }
        }

        public IHttpActionResult UpdateBookData(int bid, tblBook book) {
            try {
                tblBook bk = bdb.tblBooks.Find(bid);
                if (bk != null) {
                    bk.book_name = book.book_name;
                    bk.author = book.author;
                    bk.publication = book.publication;
                    bk.subject = book.subject;
                    bdb.SaveChanges();
                    return Content(HttpStatusCode.OK, "Data Updated Successfully");
                } else {
                    return Content(HttpStatusCode.NoContent, "No data found with Book Id " + bid);
                }
            } catch (Exception) {
                return Content(HttpStatusCode.InternalServerError, "Something went wrong.");
            }
        }

        public IHttpActionResult DeleteStdData(int bid) {
            try {
                tblBook bk = bdb.tblBooks.Find(bid);
                if (bk != null) {
                    bdb.tblBooks.Remove(bk);
                    return Content(HttpStatusCode.OK, "Data Deleted Successfully");
                } else {
                    return Content(HttpStatusCode.NoContent, "No data found with Book Id " + bid);
                }
            } catch (Exception) {
                return Content(HttpStatusCode.InternalServerError, "Something went wrong.");
            }
        }
    }    
}
