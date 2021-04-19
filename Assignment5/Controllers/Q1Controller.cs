using Assignment5.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Assignment5.Controllers
{
    public class Q1Controller : ApiController {
        DbStudentEntities db = new DbStudentEntities();
        
        public IHttpActionResult PostStdData(student std) {
            try {
                if (std != null) {
                    db.students.Add(std);
                    db.SaveChanges();
                    
                    String data = "Post Student Data on" + DateTime.Now.ToString();
                    File.AppendAllText(HttpContext.Current.Server.MapPath("~/Log.txt"), data + "\n");                    
                    return Ok("Data Inserted successfully");
                } else {
                    return BadRequest("Something went wrong");
                }
            } catch (Exception) {
                return Content(HttpStatusCode.InternalServerError, "Primary key Violation");
            }            
        }    
        
        public IHttpActionResult GetStdData() {
            try {
                List<student> data = db.students.ToList();
                if (data.Count > 0) {
                    return Content(HttpStatusCode.OK, data);
                } else {
                    return Content(HttpStatusCode.NoContent, "No Record Found.");
                }
            } catch(Exception) {
                return Content(HttpStatusCode.InternalServerError, "Something went wrong.");
            }
        }

        public IHttpActionResult GetStdData(int sid) {
            try {
                student s = db.students.Find(sid);
                if (s != null) {
                    return Content(HttpStatusCode.OK, s);
                } else {
                    return Content(HttpStatusCode.NoContent, "No data found with Student Id " + sid);
                }
            } catch(Exception) {
                return Content(HttpStatusCode.InternalServerError, "Something went wrong.");
            }
        }

        public IHttpActionResult UpdateData(int sid, student s) {
            try {
                student st = db.students.Find(sid);
                if (st != null) {
                    st.sname = s.sname;
                    st.degree = s.degree;
                    st.city = s.city;
                    st.gender = s.gender;
                    db.SaveChanges();
                    return Content(HttpStatusCode.OK, "Data Updated Successfully");
                } else {
                    return Content(HttpStatusCode.NoContent, "No data found with Student Id " + sid);
                }
            } catch (Exception) {
                return Content(HttpStatusCode.InternalServerError, "Something went wrong.");
            }
        }

        public IHttpActionResult DeleteStdData(int sid) {
            try {                
                student s = db.students.Find(sid);
                if (s != null) {
                    db.students.Remove(s);
                    return Content(HttpStatusCode.OK, "Data Deleted Successfully");
                } else {
                    return Content(HttpStatusCode.NoContent, "No data found with Student Id " + sid);
                }            
            } catch (Exception) {
                return Content(HttpStatusCode.InternalServerError, "Something went wrong.");
            }
        }
    }
}
