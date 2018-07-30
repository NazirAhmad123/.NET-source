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
            
            using (var db = new UmbracoApiEntities())
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

            using (var db = new UmbracoApiEntities())
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


        [HttpGet]
        public HttpResponseMessage GetAllMembersProduct()
        {

            using (var db = new UmbracoApiEntities())
            {
                //var p = db.Products.Find();

                var memberproduct = db.MemberProducts.Select(x => new
                {
                    Id = x.MemberID,
                    Id1 = x.MemberID,
                    Id2 = x.ProductID
                    //Name = x.P,
                    //Price = x.Price
                }).ToList();


                return Request.CreateResponse(HttpStatusCode.OK, memberproduct);
            };
        }

        // Member product output. Product for each member
        [HttpGet]
        public HttpResponseMessage ProductForEachMember()
        {


            using (var db = new UmbracoApiEntities())
            {
                //var p = db.Products.Find();

                //var mp = db.MemberProducts.FirstOrDefault(x => x.MemberID.Equals("EFEF789E-07E3-479D-9F45-A51A48C0923B"));

                Guid id = Guid.Parse("EFEF789E-07E3-479D-9F45-A51A48C0923B");
                var guids = (from i in db.MemberProducts
                             where i.ID.ToString().Contains("EFEF789E-07E3-479D-9F45-A51A48C0923B")
                             select i).ToList();
                //Guid id2 = Guid.Parse("FBCAFA93-F3CE-47A1-838D-8532E88AC712");

                //var MembersIds = db.MemberProducts.Select(x => x.ID).Max(3;
                //var MembersId = db.MemberProducts.Select(x => new
                //{
                //    Id = x.ID

                //}).ToList();

                //List<MemberProduct> MembersIds = new List<MemberProduct>()
                //{
                //    new MemberProduct {ID = MembersIds}
                //};


                //var query = db.MemberProducts.Join(db.Members,
                //                Name => db.Members.Where(x => x.MemberID == id),
                //                product => db.Products.Where(x => x.ProductID == id),
                //                (Name, product) => new { Name = Name, Product = product });
                //var res = db.MemberProducts.FirstOrDefault(x => x.ID == id);
                //var member = db.Members.Where(x => x.MemberID == id).FirstOrDefault();
                //var products = db.MemberProducts
                //    .Where(x => x.MemberID == id)
                //    .Select(x => x.Product.Name).ToList();

                //var listOfProducts = db.MemberProducts.Select(x => new
                //{
                //    product = x.Product.Name
                //}).ToList();
                
                //IQueryable<Guid> guids = db.MemberProducts.Select(r => r.ID);
                //var ids = db.MemberProducts.Select(r => guids.Contains(r.ID));

                var products = db.MemberProducts
                    .Where(x => x.MemberID == id)
                    .Select(y => new
                    {
                        Id = y.MemberID,
                        Name = y.Member.MemberName,
                        NumOfProduct = y.Product.Name.Length,
                        Products = db.MemberProducts.Where(x => x.MemberID == id)
                        .Select(x => new
                        {
                            Name = x.Product.Name
                        }).ToList()

                    }).ToList();


                // Trying a strang way
                //var products = db.MemberProducts
                //    .Where(x => x.MemberID.Equals(ids))
                //    .Select(y => new
                //    {
                //        Id = y.MemberID,
                //        Name = y.Member.MemberName,
                //        NumOfProduct = y.Product.Name.Length,
                //        Products = db.MemberProducts.Where(x => x.MemberID.Equals(ids))
                //        .Select(x => new
                //        {
                //            Name = x.Product.Name
                //        }).ToList()

                //    }).ToList();
                //var response = new
                //{
                //    Member = member,
                //    Products = product,

                //};

                return Request.CreateResponse(HttpStatusCode.OK, products);
            };
        }
        //        //return Request.CreateResponse(HttpStatusCode.OK, products);
        //        return Request.CreateResponse(HttpStatusCode.OK, products);





        [HttpGet]
        public HttpResponseMessage IDs()
        {


            using (var db = new UmbracoApiEntities())
            {
                var MembersIds = db.MemberProducts.Select(x => new
                {
                    Id = x.ID
                    
                }).ToList();

                return Request.CreateResponse(HttpStatusCode.OK, MembersIds);
            };
        }

        

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
                    MemberCode = x.GetProperty("memberCode").Value


                });
            return Request.CreateResponse(HttpStatusCode.OK, members);
            //return new[] { "Arif", "Sharif", "Nazir" };
        }


        
    }
}
