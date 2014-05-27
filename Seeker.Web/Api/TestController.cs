using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Seeker.Web.Api
{
    public class TestController : ApiController
    {
        public IEnumerable<string> GET() {
            List<string> dummyList = new List<string>() { 
                "Moinul", "Touhid", "Shovan", "Shanto"
            };

            return dummyList;
        }
    }
}