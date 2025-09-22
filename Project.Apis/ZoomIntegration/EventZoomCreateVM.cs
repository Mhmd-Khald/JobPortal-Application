using System;

namespace Project.Apis.ZoomIntegration
{
    public class EventZoomCreateVM
    {

        public string Id { get; set; }

        public string Topic { get; set; }

        public string Agenda { get; set; }

        public DateTime Date { get; set; }

        public double Time { get; set; }

        public int Duration { get; set; }

        public string TimeZone { get; set; }

    }
}
