using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestSharp;
using RestSharp.Deserializers;

namespace JiraRequester.Controllers
{
    public class JiraRequesterController : ApiController
    {
        // GET: api/JiraRequester
        public object Get([FromUri] string jiraQ)
        {
            using (var client = new WebClient())
            {
                
                client.Headers.Set("Authorization", Request.Headers.Authorization.ToString());
                using (var stream = client.OpenRead($"http://jira.mppglobal.com/rest/api/2/search?jql={jiraQ}&startAt=0&maxResults=-1"))
                using (var reader = new StreamReader(stream))
                {
                    var jObject = Newtonsoft.Json.Linq.JObject.Parse(reader.ReadLine());
                    return jObject;
                }
            }
        }

        // GET: api/JiraRequester/5
        public object Get(int id)
        {
//            switch (id)
//            {
//                case 1:
//                    var client = new RestClient("http://jira.mppglobal.com/rest/api/2/search?jql=%27Epic%20Link%27%20in%20%28MIP-2199,%20MIP-2254,%20MIP-2320%29&startAt=0");
//                    var jsonDeserializer = new JsonDeserializer();
//                    client.AddHandler("application/json", jsonDeserializer);
//                    var request = new RestRequest(Method.GET);
//                    request.AddHeader("Authorization", "Basic Z2FscGU6KWpCZW9QTUNGNHp0");
//                    IRestResponse response = client.Execute(request);
//                    return response;
//            }

            using (var client = new WebClient())
            {
                client.Headers.Set("Authorization", "Basic Z2FscGU6KWpCZW9QTUNGNHp0");
                //using (var stream = client.OpenRead("http://jira.mppglobal.com/rest/api/2/search?jql=%27Epic%20Link%27%20in%20%28MIP-2199,%20MIP-2254,%20MIP-2320%29&startAt=0&maxResults=-1"))
                using (var stream = client.OpenRead("http://jira.mppglobal.com/rest/api/2/search?jql=labels%20%3D%20Milestone2%20and%20labels%20%3D%20tetris%20&startAt=0&maxResults=-1"))
                using (var reader = new StreamReader(stream))
                {
                    var jObject = Newtonsoft.Json.Linq.JObject.Parse(reader.ReadLine());
                    return jObject;
                }
            }
                
            return null;
        }

        // POST: api/JiraRequester
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/JiraRequester/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/JiraRequester/5
        public void Delete(int id)
        {
        }
    }
}
