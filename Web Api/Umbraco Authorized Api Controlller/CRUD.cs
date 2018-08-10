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
        DemoDbEntities db = new DemoDbEntities();
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage GetIndex()
        {
            using (var db = new DemoDbEntities())
            {

                var products = db.Products.Select(x => new
                {
                    Product_ID = x.ProductID,
                    Product_Name = x.Name,
                    Product_Price = x.Price

                }).ToList();

                return Request.CreateResponse(HttpStatusCode.OK, products);
            };

        }

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Post([FromBody] Product product)
        {
            try
            {
                if(product != null)
                {
                    using (var db = new DemoDbEntities())
                    {
                        product.ProductID = Guid.NewGuid();
                        db.Products.Add(product);
                        db.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.Created);
                    }
                }
                else
                {
                    return Request.CreateResponse("Operation can't be done");
                }
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
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
