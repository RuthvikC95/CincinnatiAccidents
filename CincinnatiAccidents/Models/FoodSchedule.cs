﻿namespace CincinnatiAccidents.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class FoodSchedule
    {
        [JsonProperty("dayofweekstr")]
        public Dayofweekstr Dayofweekstr { get; set; }

        [JsonProperty("starttime")]
        public Time Starttime { get; set; }

        [JsonProperty("endtime")]
        public Time Endtime { get; set; }

        [JsonProperty("applicant")]
        public string Applicant { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }
    }

    public enum Dayofweekstr { Friday, Monday, Saturday, Sunday, Thursday, Tuesday, Wednesday };

    public enum Time { The10Am, The10Pm, The11Am, The11Pm, The12Am, The12Pm, The1Am, The1Pm, The2Pm, The3Am, The3Pm, The4Am, The4Pm, The5Am, The5Pm, The6Am, The6Pm, The7Am, The7Pm, The8Am, The8Pm, The9Am, The9Pm };

    public partial class FoodSchedule
    {
        public static FoodSchedule[] FromJson(string json) => JsonConvert.DeserializeObject<FoodSchedule[]>(json, CincinnatiAccidents.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this FoodSchedule[] self) => JsonConvert.SerializeObject(self, CincinnatiAccidents.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                DayofweekstrConverter.Singleton,
                TimeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class DayofweekstrConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Dayofweekstr) || t == typeof(Dayofweekstr?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Friday":
                    return Dayofweekstr.Friday;
                case "Monday":
                    return Dayofweekstr.Monday;
                case "Saturday":
                    return Dayofweekstr.Saturday;
                case "Sunday":
                    return Dayofweekstr.Sunday;
                case "Thursday":
                    return Dayofweekstr.Thursday;
                case "Tuesday":
                    return Dayofweekstr.Tuesday;
                case "Wednesday":
                    return Dayofweekstr.Wednesday;
            }
            throw new Exception("Cannot unmarshal type Dayofweekstr");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Dayofweekstr)untypedValue;
            switch (value)
            {
                case Dayofweekstr.Friday:
                    serializer.Serialize(writer, "Friday");
                    return;
                case Dayofweekstr.Monday:
                    serializer.Serialize(writer, "Monday");
                    return;
                case Dayofweekstr.Saturday:
                    serializer.Serialize(writer, "Saturday");
                    return;
                case Dayofweekstr.Sunday:
                    serializer.Serialize(writer, "Sunday");
                    return;
                case Dayofweekstr.Thursday:
                    serializer.Serialize(writer, "Thursday");
                    return;
                case Dayofweekstr.Tuesday:
                    serializer.Serialize(writer, "Tuesday");
                    return;
                case Dayofweekstr.Wednesday:
                    serializer.Serialize(writer, "Wednesday");
                    return;
            }
            throw new Exception("Cannot marshal type Dayofweekstr");
        }

        public static readonly DayofweekstrConverter Singleton = new DayofweekstrConverter();
    }

    internal class TimeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Time) || t == typeof(Time?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "The10Am":
                    return Time.The10Am;
                case "The10Pm":
                    return Time.The10Pm;
                case "The11Am":
                    return Time.The11Am;
                case "The11Pm":
                    return Time.The11Pm;
                case "The12Am":
                    return Time.The12Am;
                case "The12Pm":
                    return Time.The12Pm;
                case "The1Am":
                    return Time.The1Am;
                case "The1Pm":
                    return Time.The1Pm;
                case "The2Pm":
                    return Time.The2Pm;
                case "The3Am":
                    return Time.The3Am;
                case "The3Pm":
                    return Time.The3Pm;
                case "The4Am":
                    return Time.The4Am;
                case "The4Pm":
                    return Time.The4Pm;
                case "The5Am":
                    return Time.The5Am;
                case "The5Pm":
                    return Time.The5Pm;
                case "The6Am":
                    return Time.The6Am;
                case "The6Pm":
                    return Time.The6Pm;
                case "The7Am":
                    return Time.The7Am;
                case "The7Pm":
                    return Time.The7Pm;
                case "The8Am":
                    return Time.The8Am;
                case "The8Pm":
                    return Time.The8Pm;
                case "The9Am":
                    return Time.The9Am;
                case "The9Pm":
                    return Time.The9Pm;
            }
            throw new Exception("Cannot unmarshal type Time");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Time)untypedValue;
            switch (value)
            {
                case Time.The10Am:
                    serializer.Serialize(writer, "The10Am");
                    return;
                case Time.The10Pm:
                    serializer.Serialize(writer, "The10Pm");
                    return;
                case Time.The11Am:
                    serializer.Serialize(writer, "The11Am");
                    return;
                case Time.The11Pm:
                    serializer.Serialize(writer, "The11Pm");
                    return;
                case Time.The12Am:
                    serializer.Serialize(writer, "The12Am");
                    return;
                case Time.The12Pm:
                    serializer.Serialize(writer, "The12Pm");
                    return;
                case Time.The1Am:
                    serializer.Serialize(writer, "The1Am");
                    return;
                case Time.The1Pm:
                    serializer.Serialize(writer, "The1Pm");
                    return;
                case Time.The2Pm:
                    serializer.Serialize(writer, "The2Pm");
                    return;
                case Time.The3Am:
                    serializer.Serialize(writer, "The3Am");
                    return;
                case Time.The3Pm:
                    serializer.Serialize(writer, "The3Pm");
                    return;
                case Time.The4Am:
                    serializer.Serialize(writer, "The4Am");
                    return;
                case Time.The4Pm:
                    serializer.Serialize(writer, "The4Pm");
                    return;
                case Time.The5Am:
                    serializer.Serialize(writer, "The5Am");
                    return;
                case Time.The5Pm:
                    serializer.Serialize(writer, "The5Pm");
                    return;
                case Time.The6Am:
                    serializer.Serialize(writer, "The6Am");
                    return;
                case Time.The6Pm:
                    serializer.Serialize(writer, "The6Pm");
                    return;
                case Time.The7Am:
                    serializer.Serialize(writer, "The7Am");
                    return;
                case Time.The7Pm:
                    serializer.Serialize(writer, "The7Pm");
                    return;
                case Time.The8Am:
                    serializer.Serialize(writer, "The8Am");
                    return;
                case Time.The8Pm:
                    serializer.Serialize(writer, "The8Pm");
                    return;
                case Time.The9Am:
                    serializer.Serialize(writer, "The9Am");
                    return;
                case Time.The9Pm:
                    serializer.Serialize(writer, "The9Pm");
                    return;
            }
            throw new Exception("Cannot marshal type Time");
        }

        public static readonly TimeConverter Singleton = new TimeConverter();
    }
}
