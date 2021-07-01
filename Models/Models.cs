using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FacebookDotNet.Models
{
    public partial class FacebookEventResponse
    {
        [JsonProperty("data")]
        public IEnumerable<Event> Data { get; set; }

        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }

    public class FacebookPage
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class Event
    {
        [JsonProperty("updated_time")]
        public DateTime UpdatedTime { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("cover")]
        public Cover Cover { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("end_time")]
        public DateTime EndTime { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("is_canceled")]
        public bool IsCanceled { get; set; }

        [JsonProperty("is_draft")]
        public bool IsDraft { get; set; }

        [JsonProperty("is_page_owned")]
        public bool IsPageOwned { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("place")]
        public Place Place { get; set; }

        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("event_times", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<EventTime> EventTimes { get; set; }
    }

    public partial class Cover
    {
        [JsonProperty("offset_x")]
        public long OffsetX { get; set; }

        [JsonProperty("offset_y")]
        public long OffsetY { get; set; }

        [JsonProperty("source")]
        public Uri Source { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class EventTime
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("start_time")]
        public string StartTime { get; set; }

        [JsonProperty("end_time")]
        public string EndTime { get; set; }
    }

    public partial class Place
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public Location Location { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }

        [JsonProperty("street", NullValueHandling = NullValueHandling.Ignore)]
        public string Street { get; set; }

        [JsonProperty("zip", NullValueHandling = NullValueHandling.Ignore)]
        public string Zip { get; set; }
    }

    public partial class Paging
    {
        [JsonProperty("cursors")]
        public Cursors Cursors { get; set; }

        [JsonProperty("next")]
        public Uri Next { get; set; }
    }

    public partial class Cursors
    {
        [JsonProperty("before")]
        public string Before { get; set; }

        [JsonProperty("after")]
        public string After { get; set; }
    }
}
