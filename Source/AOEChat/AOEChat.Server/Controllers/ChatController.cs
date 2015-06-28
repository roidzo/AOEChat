using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AOEChat.Server.Data;
using AOEChat.Server.Models.DTO;
using Serilog;
using AOEChat.Server.Core.Data;
using Autofac;
using Autofac.Integration.WebApi;
using System.Web.Script.Serialization;
using AOEChat.Server.Data;


namespace AOEChat.Server.Controllers
{
    public class ChatController : ApiController
    {
        private readonly IDataServiceDto _dataServiceDto;
        private readonly ILogger _logger;

        public ChatController(ILogger logger, IDataServiceDto dataServiceDto)
        {
            _logger = logger;
            _dataServiceDto = dataServiceDto;
        }

        // GET api/chat
        public IHttpActionResult Get()
        {
            //return _dataServiceDto.GetMessages().ToList();

            var jsonSerialiser = new JavaScriptSerializer();
            var jsonResult = jsonSerialiser.Serialize(_dataServiceDto.GetMessages());

            if (jsonResult != null)
            {
                return Ok(jsonResult);
            }
            return NotFound();

            //return DataService.GetMessages().Select(i=>i.MessageText).ToArray<String>();
            //return new string[] { "value1", "value2" };
        }


        //public JToken Get()
        //{
        //    JToken json = JObject.Parse("{ 'firstname' : 'Jason', 'lastname' : 'Voorhees' }");
        //    return json;
        //}

        // GET api/chat/5
        //public string Get(int id)
        //{
            
        //    return _dataServiceMessage.GetMessage(id).MessageText;
        //    //return "value";
        //}


        public IHttpActionResult Get(int id)
        {
            var jsonSerialiser = new JavaScriptSerializer();
            var jsonResult = jsonSerialiser.Serialize(_dataServiceDto.GetMessagesForUser(id));

            if (jsonResult != null)
            {
                return Ok(jsonResult);
            }
            return NotFound();
        }


        //public HttpResponseMessage Get()
        //{
        //    var resp = new HttpResponseMessage()
        //    {
        //        Content = new StringContent("[{\"Name\":\"ABC\"},[{\"A\":\"1\"},{\"B\":\"2\"},{\"C\":\"3\"}]]")
        //    };
        //    resp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        //    return resp;
        //}


        // POST api/chat
        public HttpResponseMessage Post(MessageDto value)
        {
            if (ModelState.IsValid)
            {
                _dataServiceDto.CreateMessage(value);

                //DataService.CreateMessage(value.ChatUserId, value.MessageText, value.GpsXCoord, value.GpsYCoord);
                //notatweetRepository.InsertOrUpdate(value);
                //notatweetRepository.Save();

                //Created!
                var response = Request.CreateResponse(HttpStatusCode.Created, value);
                //var response = new HttpResponseMessage<NotATweet>(value, HttpStatusCode.Created);

                //Let them know where the new NotATweet is
                string uri = Url.Route(null, new { id = value.ChatUserId });
                response.Headers.Location = new Uri(Request.RequestUri, uri);

                return response;

            }
            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }


        // PUT api/chat/5
        public HttpResponseMessage Put(int id, MessageDto value)
        {
            if (ModelState.IsValid)
            {
                //notatweetRepository.InsertOrUpdate(value);
                //notatweetRepository.Save();
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        // DELETE api/chat/5
        public void Delete(int id)
        {
        }
    }
}
