using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BOL;
using BLL;


namespace AadharAuthentication.Controllers
{
    public class AadharVerificationController : ApiController
    {
        //[Route("/GetAdhaarList")]
        // GET: api/AadharVerification
        public IEnumerable<Aadhar> Get()
        {
            return AadharManager.GetAadhars();
        }

        // GET: api/AadharVerification/5
       // [Route("/GetAdhaarList/{parameter}")]
        public Aadhar Get(int Id)
        {
            return AadharManager.GetAadhar(Id);
        }

        // POST: api/AadharVerification
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AadharVerification/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AadharVerification/5
        public void Delete(int id)
        {
        }
    }
}
