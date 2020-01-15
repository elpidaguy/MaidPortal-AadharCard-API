using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using BOL;

namespace AadharAuthentication.Controllers
{
    public class SendOTPController : ApiController
    {
        public static int otp, contactNo;
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public int Get(int id)
        {
            contactNo = id;
            if (AadharManager.GetByContactNo(id))
            {
                Random r = new Random();
                otp = r.Next(1000, 9999);
                //This otp is sent to contact number also but how I didn't get that
            }
            return otp;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}