using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Umbraco.Web.WebApi;

namespace test.Controllers
{
    public class AdminController : UmbracoAuthorizedApiController
    {

        private DemoDbEntities db = new DemoDbEntities();

        // GET: Products
        [HttpGet]
        public string Test()
        {
            return "Test";
        }

        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage GetIndex()
        {
            using (var db = new DemoDbEntities())
            {
                //var p = db.Products.Find();

                var products = db.Products.Select(x => new
                {
                    ProductID = x.ProductID,
                    Name = x.Name,
                    Price = x.Price

                }).ToList();


                return Request.CreateResponse(HttpStatusCode.OK, products);
            };

        }
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage PostProduct([FromBody] Product product)
        {
            using(var db = new DemoDbEntities())
            {
              
                    db.Products.Add(product);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                // return Request.CreateResponse(HttpStatusCode.Created);

            }
        }

        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Put(Guid? id, [FromBody] Product product)
        {
            var p = db.Products.Find(id);

            try
            {
                if (p != null)
                {
                    p.Name = product.Name;
                    p.Price = product.Price;
                    db.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Id = " + id.ToString() + " was not found..");
                }
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }

        }
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(Guid? id)
        {
            try
            {
                var p = db.Products.Find(id);

                if (p != null)
                {
                    db.Products.Remove(p);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "id = " + id.ToString() + " was not found to be deleted.");
                }
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }
    }
}
