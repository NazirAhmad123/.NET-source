using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace WebApi.Controllers
{
    public class EmployeesController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            using(var db = new ApiDemoEntities())
            {
                return db.Employees.ToList();
            }
        }

        //public Employee Get(int id)
        //{
        //    using (var db = new ApiDemoEntities())
        //    {
        //        return db.Employees.FirstOrDefault(e => e.ID == id);
        //    }
        //}

        public HttpResponseMessage Get(int id)
        {
            using (var db = new ApiDemoEntities())
            {
                var emps = db.Employees.FirstOrDefault(e => e.ID == id);

                if(emps != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, emps);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id = " + id.ToString() + " was not found");
                       
                }
            }
        }


        //public void Post([FromBody] Employee emp)
        //{
        //    using(var db = new ApiDemoEntities())
        //    {
        //        db.Employees.Add(emp);
        //        db.SaveChanges();
        //    }
        //}

        public HttpResponseMessage Post([FromBody] Employee emp)
        {
            try
            {
                using (var db = new ApiDemoEntities())
                {
                    db.Employees.Add(emp);
                    db.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, emp);
                    message.Headers.Location = new Uri(Request.RequestUri + emp.ID.ToString());
                    return message;
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);

            }
        }

        //public void Delete(int id)
        //{
        //    using(var db = new ApiDemoEntities())
        //    {
        //        db.Employees.Remove(db.Employees.FirstOrDefault(e => e.ID == id));
        //        db.SaveChanges();
        //    }
        //}

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (var db = new ApiDemoEntities())
                {
                    var emp = db.Employees.FirstOrDefault(e => e.ID == id);

                    if (emp == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id " + id.ToString() + " was not found to delete.");
                    }
                    else
                    {
                        db.Employees.Remove(emp);
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }
        public HttpResponseMessage Put(int id, [FromBody]Employee employee)
        {
            try
            {
                using (var db = new ApiDemoEntities())
                {
                    var emp = db.Employees.FirstOrDefault(e => e.ID == id);

                    if (emp == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, " Employee with id = " + id.ToString() + " was not found to be updated.");
                    }
                    else
                    {
                        emp.FirstName = employee.FirstName;
                        emp.LastName = employee.LastName;
                        emp.Gender = employee.Gender;
                        emp.Salary = employee.Salary;

                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }

                }
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }
    }
}
