using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.WebApi;
using UmbracoApi;

namespace GettingStartedWithUmbraco
{
    [Route("api/[controller]")]
    public class TeamController : UmbracoApiController
    {

        [HttpGet]
        public string Test()
        {
            return "Test";
        }

      


        [HttpGet]
        public HttpResponseMessage GetAllProducts()
        {
            
            using (var db = new UmbracoApiEntities1())
            {
                //var p = db.Products.Find();

                var products = db.Products.Select(x => new 
                {
                    ProductID = x.ProductID,
                    Name = x.Name,
                   Price =  x.Price
                    //Name = x.P,
                    //Price = x.Price
                }).ToList();


                return Request.CreateResponse(HttpStatusCode.OK, products);
            };
        }


        [HttpGet]
        public HttpResponseMessage GetAllMembersFromDb()
        {

            using (var db = new UmbracoApiEntities1())
            {
                //var p = db.Products.Find();

                var members = db.Members.Select(x => new
                {
                    Id = x.MemberID,
                    Name = x.MemberName
                    //Name = x.P,
                    //Price = x.Price
                }).ToList();


                return Request.CreateResponse(HttpStatusCode.OK, members);
            };
        }

        //        //return Request.CreateResponse(HttpStatusCode.OK, products);
        //        return Request.CreateResponse(HttpStatusCode.OK, products);

        public HttpResponseMessage GetAllMembers()
        {
            var item = Umbraco.TypedContent(Guid.Parse("14977c30-c9b1-4549-bd45-f73d322dd58d"));
            //item.Children();
            var members = item.Children
                .Where(x => x.IsVisible())
                .Select(x => new
                {
                    //Name = x.Name
                    MemberName = x.GetProperty("memberName").Value,
                    MemberDescription = x.GetProperty("memberDescription").Value,


                });
            return Request.CreateResponse(HttpStatusCode.OK, members);
            //return new[] { "Arif", "Sharif", "Nazir" };
        }
        
    }
}
