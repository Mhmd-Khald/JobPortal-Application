using System;

namespace Project.Apis.ZoomIntegration
{
    public class EventZoomVM
    {
        public string Id { get; set; }
        public string Topic { get; set; }
        public string Agenda { get; set; }

        public DateTime Start_Time { get; set; }

        /// to use it time zone 
        public string TimeZone { get; set; }

        public int Duration { get; set; }
        public string Join_Url { get; set; }



    }
}
