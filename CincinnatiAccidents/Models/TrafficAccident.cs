namespace Traffic
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class TrafficAccident
    {
        [JsonProperty("address_x", NullValueHandling = NullValueHandling.Ignore)]
        public string AddressX { get; set; }

        [JsonProperty("age")]
        public string Age { get; set; }

        [JsonProperty("community_council_neighborhood")]
        public string CommunityCouncilNeighborhood { get; set; }

        [JsonProperty("cpd_neighborhood")]
        public string CpdNeighborhood { get; set; }

        [DataType(DataType.Date)]
        [JsonProperty("crashdate")]
        public string Crashdate { get; set; }

        [JsonProperty("crashlocation")]
        public string Crashlocation { get; set; }

        [JsonProperty("crashseverity", NullValueHandling = NullValueHandling.Ignore)]
        public string Crashseverity { get; set; }

        [JsonProperty("crashseverityid", NullValueHandling = NullValueHandling.Ignore)]
        public long? Crashseverityid { get; set; }

        [JsonProperty("datecrashreported", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? Datecrashreported { get; set; }

        [JsonProperty("dayofweek", NullValueHandling = NullValueHandling.Ignore)]
        public string Dayofweek { get; set; }

        [JsonProperty("injuries", NullValueHandling = NullValueHandling.Ignore)]
        public string Injuries { get; set; }

        [JsonProperty("instanceid")]
        public string Instanceid { get; set; }

        [JsonProperty("lightconditionsprimary", NullValueHandling = NullValueHandling.Ignore)]
        public string Lightconditionsprimary { get; set; }

        [JsonProperty("localreportno", NullValueHandling = NullValueHandling.Ignore)]
        public string Localreportno { get; set; }

        [JsonProperty("mannerofcrash", NullValueHandling = NullValueHandling.Ignore)]
        public string Mannerofcrash { get; set; }

        [JsonProperty("roadconditionsprimary", NullValueHandling = NullValueHandling.Ignore)]
        public string Roadconditionsprimary { get; set; }

        [JsonProperty("roadcontour", NullValueHandling = NullValueHandling.Ignore)]
        public string Roadcontour { get; set; }

        [JsonProperty("roadsurface", NullValueHandling = NullValueHandling.Ignore)]
        public string Roadsurface { get; set; }

        [JsonProperty("sna_neighborhood")]
        public string SnaNeighborhood { get; set; }

        [JsonProperty("typeofperson", NullValueHandling = NullValueHandling.Ignore)]
        public string Typeofperson { get; set; }

        [JsonProperty("weather", NullValueHandling = NullValueHandling.Ignore)]
        public string Weather { get; set; }

        [JsonProperty("zip", NullValueHandling = NullValueHandling.Ignore)]
        public string Zip { get; set; }

        [JsonProperty("unittype", NullValueHandling = NullValueHandling.Ignore)]
        public string Unittype { get; set; }

        [JsonProperty("latitude_x", NullValueHandling = NullValueHandling.Ignore)]
        public string LatitudeX { get; set; }

        [JsonProperty("gender", NullValueHandling = NullValueHandling.Ignore)]
        public string Gender { get; set; }

        [JsonProperty("longitude_x", NullValueHandling = NullValueHandling.Ignore)]
        public string LongitudeX { get; set; }
    }

    public partial class TrafficAccident
    {
        public static TrafficAccident[] FromJson(string json) => JsonConvert.DeserializeObject<TrafficAccident[]>(json);
    }

    public static class Serialize
    {
        public static string ToJson(this TrafficAccident[] self) => JsonConvert.SerializeObject(self);
    }
}

