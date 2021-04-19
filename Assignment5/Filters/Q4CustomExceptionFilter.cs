using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace Assignment5.Filters {
    public class Q4CustomExceptionFilter: ExceptionFilterAttribute {
        public override void OnException(HttpActionExecutedContext actionExecutedContext) {
            base.OnException(actionExecutedContext);

            if (actionExecutedContext.Exception is Exception) {
                HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
                response.Content = new StringContent("Provide proper data");
                response.ReasonPhrase = "Unable to modify";
                actionExecutedContext.Response = response;
            } else if (actionExecutedContext.Exception is IllegalArgumentException) {
                HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
                response.Content = new StringContent("Invalid Principle amount");
                response.ReasonPhrase = "Please try again";
                actionExecutedContext.Response = response;
            } else {
                HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
                response.Content = new StringContent("An Unknown Error occured");
                response.ReasonPhrase = "Please try again";
                actionExecutedContext.Response = response;
            }
        }        
    }
}