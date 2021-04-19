using Assignment5.Controllers;
using Assignment5.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment5.Controllers
{
    public class Q4Controller : ApiController {
        public int GetSimpleInterest(int principal, int rate, int num) {
            if(principal < 0) {
                throw new IllegalArgumentException();
            }
            int simpleInterest = (principal * rate * num) / 100;
            return simpleInterest;
        }
    }
}
