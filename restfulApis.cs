using MyFirstWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFirstWebApp.Controllers
{
    public class HelloWorldController : ApiController
    {
        [HttpGet]
        [Route("hello-world")]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [HttpGet]
        [Route("hello-nazir")]
        public string HelloNazir()
        {
            return "Hello Nazir";
        }

        [HttpGet]
        [Route("Hello")]
        public string HelloName(string name)
        {
            return $"Hello, {name}";
        }

        [HttpGet]
        [Route("Hello/{name}")]
        public string HelloName1(string name)
        {
            return $"Hello, {name}";
        }

        [HttpGet]
        [Route("Persons")]
        public HttpResponseMessage Persons()
        {
            List<Person> persons = new List<Person>()
            {
                new Person("Arif","Ahmad",26),
                new Person("Nazir","asdsadsad",22)
            };
            return Request.CreateResponse(HttpStatusCode.NotFound,persons);
        }

        [HttpPost]
        [Route("my-post")]
        public HttpResponseMessage PostMessage(Post post)
        {
            return Request.CreateResponse(HttpStatusCode.OK, post);
        }
    }
}
