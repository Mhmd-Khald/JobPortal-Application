using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Project.Apis.ZoomIntegration;
using System.Collections.Generic;
using System.IO;
using System;
using RestSharp;

namespace Project.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoomApiController : ControllerBase
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public ZoomApiController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }


        [HttpPost]
        public ActionResult ZoomCreateMeeting(EventZoomCreateVM meeting)
        {
            refreshToken();


            string Zoomtokenfilepath = Path.Combine(hostingEnvironment.WebRootPath, "ZoomCreaditionals/ZoomTokens.json"); ;
            string ZoomUserDetailsPath = Path.Combine(hostingEnvironment.WebRootPath, "ZoomCreaditionals/ZoomUserDetails.json"); ;
            string ZomMeetingResponsePath = Path.Combine(hostingEnvironment.WebRootPath, "ZoomCreaditionals/ZoomMeetingResponse.json"); ;



            var token = JObject.Parse(System.IO.File.ReadAllText(Zoomtokenfilepath));
            var userDetails = JObject.Parse(System.IO.File.ReadAllText(ZoomUserDetailsPath));
            var access_token = token["access_token"];
            var userId = userDetails["id"];

            ////////////////////  pass Agenda to AllMettings
            HttpContext.Items["Agenda"] = meeting.Agenda;
            ////////////////////


            var meetingModel = new JObject();
            meetingModel["topic"] = meeting.Topic;
            meetingModel["agenda"] = meeting.Agenda;
            meetingModel["start_time"] = meeting.Date.ToString("yyyy-MM-dd") + "T" + TimeSpan.FromHours(meeting.Time).ToString("hh':'mm':'ss");
            meetingModel["duration"] = meeting.Duration;

            meeting.TimeZone = "Asia/Riyadh";


            var model = JsonConvert.SerializeObject(meetingModel);

            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest();

            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", string.Format("Bearer {0}", access_token));
            restRequest.AddParameter("application/json", model, ParameterType.RequestBody);

            restClient.BaseUrl = new Uri(string.Format("https://api.zoom.us/v2/users/{0}/meetings", userId));
            var response = restClient.Post(restRequest);


            var error = response.ErrorMessage;
            var ListOfMettings = new List<string>();

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                System.IO.File.WriteAllText(ZomMeetingResponsePath, response.Content);

                ListOfMettings = ZoomAllMeetings(meeting.Topic);
                return Ok(ListOfMettings);
            }
            return NotFound();
        }



        [NonAction]
        public List<string> ZoomAllMeetings(string TopicMetthig)
        {
            var listURL = new List<string>();
            string Zoomtokenfilepath = Path.Combine(hostingEnvironment.WebRootPath, "ZoomCreaditionals/ZoomTokens.json"); ;
            string ZoomUserDetailsPath = Path.Combine(hostingEnvironment.WebRootPath, "ZoomCreaditionals/ZoomUserDetails.json"); ;
            string ZomMeetingResponsePath = Path.Combine(hostingEnvironment.WebRootPath, "ZoomCreaditionals/ZoomMeetingResponse.json"); ;


            var token = JObject.Parse(System.IO.File.ReadAllText(Zoomtokenfilepath));
            var userDetails = JObject.Parse(System.IO.File.ReadAllText(ZoomUserDetailsPath));
            var access_token = token["access_token"];

            /// to get details from UserDetails.json
            var userId = userDetails["id"];
            var first_name = userDetails["first_name"];
            var display_name = userDetails["display_name"];
            var email = userDetails["email"];
            //// end of details


            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest();
            restRequest.AddHeader("Authorization", "Bearer " + access_token);

            //restClient.BaseUrl = new Uri($"https://api.zoom.us/v2/users/{userId}/meetings");


            //// just only upcoming mettings
            restClient.BaseUrl = new Uri($"https://api.zoom.us/v2/users/{userId}/meetings?type=upcoming_meetings&page_size=300");
            var response = restClient.Get(restRequest);


            //var agendaCraete =  HttpContext.Items["Agenda"].ToString();

            var age = HttpContext.Items["Agenda"];

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var zoomMeetings = JObject.Parse(response.Content)["meetings"].ToObject<IEnumerable<EventZoomVM>>();
                foreach (var item in zoomMeetings)
                {
                    ///// to convert time to local time 
                    //item.Start_Time = TimeZoneInfo.ConvertTimeFromUtc(new DateTime(item.Start_Time.Ticks, DateTimeKind.Unspecified),
                    //                                                TimeZoneInfo.FindSystemTimeZoneById("Egypt Standard Time"));

                    item.Start_Time = TimeZoneInfo.ConvertTimeFromUtc(new DateTime(item.Start_Time.Ticks, DateTimeKind.Unspecified),
                                                                   TimeZoneInfo.FindSystemTimeZoneById("Arab Standard Time"));

                    if (item.Topic == TopicMetthig)
                    {
                        /// Just Return the Url 
                        listURL.Add(item.Join_Url);
                    }


                }
            }
            return listURL;
        }












        [NonAction]
        public void refreshToken()
        {
            string Zoomtokenfilepath = Path.Combine(hostingEnvironment.WebRootPath, "ZoomCreaditionals/ZoomTokens.json"); ;
            string ZoomUserDetailsPath = Path.Combine(hostingEnvironment.WebRootPath, "ZoomCreaditionals/ZoomUserDetails.json"); ;
            string ZomMeetingResponsePath = Path.Combine(hostingEnvironment.WebRootPath, "ZoomCreaditionals/ZoomMeetingResponse.json"); ;


            var token = JObject.Parse(System.IO.File.ReadAllText(Zoomtokenfilepath));

            RestClient restClient = new RestClient();
            RestRequest request = new RestRequest();

            request.AddQueryParameter("grant_type", "refresh_token");
            request.AddQueryParameter("refresh_token", token["refresh_token"].ToString());

            request.AddHeader("Authorization", string.Format(AuthorizationHeader));

            restClient.BaseUrl = new Uri("https://zoom.us/oauth/token");
            var response = restClient.Post(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                System.IO.File.WriteAllText(Zoomtokenfilepath, response.Content);

                /// and get the user details
                GetUserDetails(token["access_token"].ToString());
            }
        }

        [NonAction]
        public void GetUserDetails(string accessToken)
        {
            string Zoomtokenfilepath = Path.Combine(hostingEnvironment.WebRootPath, "ZoomCreaditionals/ZoomTokens.json"); ;
            string ZoomUserDetailsPath = Path.Combine(hostingEnvironment.WebRootPath, "ZoomCreaditionals/ZoomUserDetails.json"); ;
            string ZomMeetingResponsePath = Path.Combine(hostingEnvironment.WebRootPath, "ZoomCreaditionals/ZoomMeetingResponse.json"); ;


            RestClient restClient = new RestClient();
            RestRequest request = new RestRequest();

            request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));

            restClient.BaseUrl = new Uri("https://api.zoom.us/v2/users/me");
            var response = restClient.Get(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                System.IO.File.WriteAllText(ZoomUserDetailsPath, response.Content);
            }
        }

        private string AuthorizationHeader
        {
            get
            {

                //////////////////////////////////////////////////  this is project works in 
                // Turboo
                //  E:\BackEnd___Organize it\angular typescript sql\ZoomMetting\Two_Project\ProjectWithOutDB
                /////////////////////////////////////////////////

                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes($"JZPO_9YTpCNbHCrkW11aw:rCHaa3Oh2sXCRMWDRehelQHyA3q1vQDG");
                var encodedString = System.Convert.ToBase64String(plainTextBytes);
                return $"Basic {encodedString}";
            }
        }








    }
}
