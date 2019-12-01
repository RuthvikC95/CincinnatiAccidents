
namespace Fire
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class FireAccident
    {
        [JsonProperty("address_x")]
        public string AddressX { get; set; }

        [JsonProperty("latitude_x")]
        public string LatitudeX { get; set; }

        [JsonProperty("longitude_x")]
        public string LongitudeX { get; set; }

        [JsonProperty("agency")]
        public Agency Agency { get; set; }

        [DataType(DataType.Date)]
        [JsonProperty("create_time_incident")]
        public DateTimeOffset CreateTimeIncident { get; set; }

        [JsonProperty("disposition_text", NullValueHandling = NullValueHandling.Ignore)]
        public DispositionText? DispositionText { get; set; }

        [JsonProperty("event_number")]
        public string EventNumber { get; set; }

        [JsonProperty("incident_type_id")]
        public IncidentTypeId IncidentTypeId { get; set; }

        [JsonProperty("incident_type_desc")]
        public IncidentTypeDesc IncidentTypeDesc { get; set; }

        [JsonProperty("neighborhood")]
        public string Neighborhood { get; set; }

        [JsonProperty("arrival_time_primary_unit", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? ArrivalTimePrimaryUnit { get; set; }

        [JsonProperty("beat")]
        public Beat Beat { get; set; }

        [JsonProperty("closed_time_incident", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? ClosedTimeIncident { get; set; }

        [JsonProperty("dispatch_time_primary_unit", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DispatchTimePrimaryUnit { get; set; }

        [JsonProperty("cfd_incident_type")]
        public CfdIncidentType CfdIncidentType { get; set; }

        [JsonProperty("cfd_incident_type_group")]
        public CfdIncidentTypeGroup CfdIncidentTypeGroup { get; set; }

        [JsonProperty("community_council_neighborhood")]
        public string CommunityCouncilNeighborhood { get; set; }
    }

    public enum Agency { Cfd };

    public enum Beat { St02, St03, St05, St07, St08, St09, St12, St14, St17, St18, St19, St20, St21, St23, St24, St29, St31, St32, St34, St35, St37, St38, St46, St49, St50, St51 };

    public enum CfdIncidentType { Als, Bls };

    public enum CfdIncidentTypeGroup { AbdominalPainProblems, PregnancyChildbirthMiscarriage, TrafficTransportationIncidents };

    public enum DispositionText { AvAdvised, CnCancel, DefDefaultEmsNoTransport, DupfDuplicate, EmsNoTransport, EmsdDisregard, EmsfFalse, FdFireDisregard, GiGoodIntent, InInvestigation, MalSystemMalfunction, MedMtResponseNoTransport, MeddMtDisregarded, MedfMtResponseFalse, MedtMedicTransport, PtPrivateTransport, UsedClearButton };

    public enum IncidentTypeDesc { AbdominalPain, The1StPartyCallerWithInjuryToNotDangerousBodyArea, The1StTrimesterHemorrhageOrMiscarriage, The1StTrimesterSeriousHemorrhage, The2NdTrimesterHemorrhageOrMiscarriage, The3RdTrimesterHemorrhage };

    public enum IncidentTypeId { The1A1, The24A1, The24C1, The24C2, The24D4, The29A1 };

    public partial class FireAccident
    {
        public static FireAccident[] FromJson(string json) => JsonConvert.DeserializeObject<FireAccident[]>(json, Fire.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this FireAccident[] self) => JsonConvert.SerializeObject(self, Fire.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                AgencyConverter.Singleton,
                BeatConverter.Singleton,
                CfdIncidentTypeConverter.Singleton,
                CfdIncidentTypeGroupConverter.Singleton,
                DispositionTextConverter.Singleton,
                IncidentTypeDescConverter.Singleton,
                IncidentTypeIdConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class AgencyConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Agency) || t == typeof(Agency?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "CFD")
            {
                return Agency.Cfd;
            }
            throw new Exception("Cannot unmarshal type Agency");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Agency)untypedValue;
            if (value == Agency.Cfd)
            {
                serializer.Serialize(writer, "CFD");
                return;
            }
            throw new Exception("Cannot marshal type Agency");
        }

        public static readonly AgencyConverter Singleton = new AgencyConverter();
    }

    internal class BeatConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Beat) || t == typeof(Beat?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "ST02":
                    return Beat.St02;
                case "ST03":
                    return Beat.St03;
                case "ST05":
                    return Beat.St05;
                case "ST07":
                    return Beat.St07;
                case "ST08":
                    return Beat.St08;
                case "ST09":
                    return Beat.St09;
                case "ST12":
                    return Beat.St12;
                case "ST14":
                    return Beat.St14;
                case "ST17":
                    return Beat.St17;
                case "ST18":
                    return Beat.St18;
                case "ST19":
                    return Beat.St19;
                case "ST20":
                    return Beat.St20;
                case "ST21":
                    return Beat.St21;
                case "ST23":
                    return Beat.St23;
                case "ST24":
                    return Beat.St24;
                case "ST29":
                    return Beat.St29;
                case "ST31":
                    return Beat.St31;
                case "ST32":
                    return Beat.St32;
                case "ST34":
                    return Beat.St34;
                case "ST35":
                    return Beat.St35;
                case "ST37":
                    return Beat.St37;
                case "ST38":
                    return Beat.St38;
                case "ST46":
                    return Beat.St46;
                case "ST49":
                    return Beat.St49;
                case "ST50":
                    return Beat.St50;
                case "ST51":
                    return Beat.St51;
            }
            throw new Exception("Cannot unmarshal type Beat");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Beat)untypedValue;
            switch (value)
            {
                case Beat.St02:
                    serializer.Serialize(writer, "ST02");
                    return;
                case Beat.St03:
                    serializer.Serialize(writer, "ST03");
                    return;
                case Beat.St05:
                    serializer.Serialize(writer, "ST05");
                    return;
                case Beat.St07:
                    serializer.Serialize(writer, "ST07");
                    return;
                case Beat.St08:
                    serializer.Serialize(writer, "ST08");
                    return;
                case Beat.St09:
                    serializer.Serialize(writer, "ST09");
                    return;
                case Beat.St12:
                    serializer.Serialize(writer, "ST12");
                    return;
                case Beat.St14:
                    serializer.Serialize(writer, "ST14");
                    return;
                case Beat.St17:
                    serializer.Serialize(writer, "ST17");
                    return;
                case Beat.St18:
                    serializer.Serialize(writer, "ST18");
                    return;
                case Beat.St19:
                    serializer.Serialize(writer, "ST19");
                    return;
                case Beat.St20:
                    serializer.Serialize(writer, "ST20");
                    return;
                case Beat.St21:
                    serializer.Serialize(writer, "ST21");
                    return;
                case Beat.St23:
                    serializer.Serialize(writer, "ST23");
                    return;
                case Beat.St24:
                    serializer.Serialize(writer, "ST24");
                    return;
                case Beat.St29:
                    serializer.Serialize(writer, "ST29");
                    return;
                case Beat.St31:
                    serializer.Serialize(writer, "ST31");
                    return;
                case Beat.St32:
                    serializer.Serialize(writer, "ST32");
                    return;
                case Beat.St34:
                    serializer.Serialize(writer, "ST34");
                    return;
                case Beat.St35:
                    serializer.Serialize(writer, "ST35");
                    return;
                case Beat.St37:
                    serializer.Serialize(writer, "ST37");
                    return;
                case Beat.St38:
                    serializer.Serialize(writer, "ST38");
                    return;
                case Beat.St46:
                    serializer.Serialize(writer, "ST46");
                    return;
                case Beat.St49:
                    serializer.Serialize(writer, "ST49");
                    return;
                case Beat.St50:
                    serializer.Serialize(writer, "ST50");
                    return;
                case Beat.St51:
                    serializer.Serialize(writer, "ST51");
                    return;
            }
            throw new Exception("Cannot marshal type Beat");
        }

        public static readonly BeatConverter Singleton = new BeatConverter();
    }

    internal class CfdIncidentTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CfdIncidentType) || t == typeof(CfdIncidentType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "ALS":
                    return CfdIncidentType.Als;
                case "BLS":
                    return CfdIncidentType.Bls;
            }
            throw new Exception("Cannot unmarshal type CfdIncidentType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CfdIncidentType)untypedValue;
            switch (value)
            {
                case CfdIncidentType.Als:
                    serializer.Serialize(writer, "ALS");
                    return;
                case CfdIncidentType.Bls:
                    serializer.Serialize(writer, "BLS");
                    return;
            }
            throw new Exception("Cannot marshal type CfdIncidentType");
        }

        public static readonly CfdIncidentTypeConverter Singleton = new CfdIncidentTypeConverter();
    }

    internal class CfdIncidentTypeGroupConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CfdIncidentTypeGroup) || t == typeof(CfdIncidentTypeGroup?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "ABDOMINAL PAIN / PROBLEMS":
                    return CfdIncidentTypeGroup.AbdominalPainProblems;
                case "PREGNANCY / CHILDBIRTH / MISCARRIAGE":
                    return CfdIncidentTypeGroup.PregnancyChildbirthMiscarriage;
                case "TRAFFIC / TRANSPORTATION INCIDENTS":
                    return CfdIncidentTypeGroup.TrafficTransportationIncidents;
            }
            throw new Exception("Cannot unmarshal type CfdIncidentTypeGroup");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CfdIncidentTypeGroup)untypedValue;
            switch (value)
            {
                case CfdIncidentTypeGroup.AbdominalPainProblems:
                    serializer.Serialize(writer, "ABDOMINAL PAIN / PROBLEMS");
                    return;
                case CfdIncidentTypeGroup.PregnancyChildbirthMiscarriage:
                    serializer.Serialize(writer, "PREGNANCY / CHILDBIRTH / MISCARRIAGE");
                    return;
                case CfdIncidentTypeGroup.TrafficTransportationIncidents:
                    serializer.Serialize(writer, "TRAFFIC / TRANSPORTATION INCIDENTS");
                    return;
            }
            throw new Exception("Cannot marshal type CfdIncidentTypeGroup");
        }

        public static readonly CfdIncidentTypeGroupConverter Singleton = new CfdIncidentTypeGroupConverter();
    }

    internal class DispositionTextConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DispositionText) || t == typeof(DispositionText?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "AV: ADVISED":
                    return DispositionText.AvAdvised;
                case "CN: CANCEL":
                    return DispositionText.CnCancel;
                case "DEF: DEFAULT,EMS: NO TRANSPORT":
                    return DispositionText.DefDefaultEmsNoTransport;
                case "DUPF: DUPLICATE":
                    return DispositionText.DupfDuplicate;
                case "EMS: NO TRANSPORT":
                    return DispositionText.EmsNoTransport;
                case "EMSD: DISREGARD":
                    return DispositionText.EmsdDisregard;
                case "EMSF: FALSE":
                    return DispositionText.EmsfFalse;
                case "FD: FIRE DISREGARD":
                    return DispositionText.FdFireDisregard;
                case "GI: GOOD INTENT":
                    return DispositionText.GiGoodIntent;
                case "IN: INVESTIGATION":
                    return DispositionText.InInvestigation;
                case "MAL: SYSTEM MALFUNCTION":
                    return DispositionText.MalSystemMalfunction;
                case "MED: MT RESPONSE NO TRANSPORT":
                    return DispositionText.MedMtResponseNoTransport;
                case "MEDD: MT DISREGARDED":
                    return DispositionText.MeddMtDisregarded;
                case "MEDF: MT RESPONSE - FALSE":
                    return DispositionText.MedfMtResponseFalse;
                case "MEDT: MEDIC TRANSPORT":
                    return DispositionText.MedtMedicTransport;
                case "PT: PRIVATE TRANSPORT":
                    return DispositionText.PtPrivateTransport;
                case "USED CLEAR BUTTON":
                    return DispositionText.UsedClearButton;
            }
            throw new Exception("Cannot unmarshal type DispositionText");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (DispositionText)untypedValue;
            switch (value)
            {
                case DispositionText.AvAdvised:
                    serializer.Serialize(writer, "AV: ADVISED");
                    return;
                case DispositionText.CnCancel:
                    serializer.Serialize(writer, "CN: CANCEL");
                    return;
                case DispositionText.DefDefaultEmsNoTransport:
                    serializer.Serialize(writer, "DEF: DEFAULT,EMS: NO TRANSPORT");
                    return;
                case DispositionText.DupfDuplicate:
                    serializer.Serialize(writer, "DUPF: DUPLICATE");
                    return;
                case DispositionText.EmsNoTransport:
                    serializer.Serialize(writer, "EMS: NO TRANSPORT");
                    return;
                case DispositionText.EmsdDisregard:
                    serializer.Serialize(writer, "EMSD: DISREGARD");
                    return;
                case DispositionText.EmsfFalse:
                    serializer.Serialize(writer, "EMSF: FALSE");
                    return;
                case DispositionText.FdFireDisregard:
                    serializer.Serialize(writer, "FD: FIRE DISREGARD");
                    return;
                case DispositionText.GiGoodIntent:
                    serializer.Serialize(writer, "GI: GOOD INTENT");
                    return;
                case DispositionText.InInvestigation:
                    serializer.Serialize(writer, "IN: INVESTIGATION");
                    return;
                case DispositionText.MalSystemMalfunction:
                    serializer.Serialize(writer, "MAL: SYSTEM MALFUNCTION");
                    return;
                case DispositionText.MedMtResponseNoTransport:
                    serializer.Serialize(writer, "MED: MT RESPONSE NO TRANSPORT");
                    return;
                case DispositionText.MeddMtDisregarded:
                    serializer.Serialize(writer, "MEDD: MT DISREGARDED");
                    return;
                case DispositionText.MedfMtResponseFalse:
                    serializer.Serialize(writer, "MEDF: MT RESPONSE - FALSE");
                    return;
                case DispositionText.MedtMedicTransport:
                    serializer.Serialize(writer, "MEDT: MEDIC TRANSPORT");
                    return;
                case DispositionText.PtPrivateTransport:
                    serializer.Serialize(writer, "PT: PRIVATE TRANSPORT");
                    return;
                case DispositionText.UsedClearButton:
                    serializer.Serialize(writer, "USED CLEAR BUTTON");
                    return;
            }
            throw new Exception("Cannot marshal type DispositionText");
        }

        public static readonly DispositionTextConverter Singleton = new DispositionTextConverter();
    }

    internal class IncidentTypeDescConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(IncidentTypeDesc) || t == typeof(IncidentTypeDesc?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "1ST PARTY CALLER WITH INJURY TO NOT DANGEROUS BODY AREA":
                    return IncidentTypeDesc.The1StPartyCallerWithInjuryToNotDangerousBodyArea;
                case "1ST TRIMESTER HEMORRHAGE OR MISCARRIAGE":
                    return IncidentTypeDesc.The1StTrimesterHemorrhageOrMiscarriage;
                case "1ST TRIMESTER SERIOUS HEMORRHAGE":
                    return IncidentTypeDesc.The1StTrimesterSeriousHemorrhage;
                case "2ND TRIMESTER HEMORRHAGE OR MISCARRIAGE":
                    return IncidentTypeDesc.The2NdTrimesterHemorrhageOrMiscarriage;
                case "3RD TRIMESTER HEMORRHAGE":
                    return IncidentTypeDesc.The3RdTrimesterHemorrhage;
                case "ABDOMINAL PAIN":
                    return IncidentTypeDesc.AbdominalPain;
            }
            throw new Exception("Cannot unmarshal type IncidentTypeDesc");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (IncidentTypeDesc)untypedValue;
            switch (value)
            {
                case IncidentTypeDesc.The1StPartyCallerWithInjuryToNotDangerousBodyArea:
                    serializer.Serialize(writer, "1ST PARTY CALLER WITH INJURY TO NOT DANGEROUS BODY AREA");
                    return;
                case IncidentTypeDesc.The1StTrimesterHemorrhageOrMiscarriage:
                    serializer.Serialize(writer, "1ST TRIMESTER HEMORRHAGE OR MISCARRIAGE");
                    return;
                case IncidentTypeDesc.The1StTrimesterSeriousHemorrhage:
                    serializer.Serialize(writer, "1ST TRIMESTER SERIOUS HEMORRHAGE");
                    return;
                case IncidentTypeDesc.The2NdTrimesterHemorrhageOrMiscarriage:
                    serializer.Serialize(writer, "2ND TRIMESTER HEMORRHAGE OR MISCARRIAGE");
                    return;
                case IncidentTypeDesc.The3RdTrimesterHemorrhage:
                    serializer.Serialize(writer, "3RD TRIMESTER HEMORRHAGE");
                    return;
                case IncidentTypeDesc.AbdominalPain:
                    serializer.Serialize(writer, "ABDOMINAL PAIN");
                    return;
            }
            throw new Exception("Cannot marshal type IncidentTypeDesc");
        }

        public static readonly IncidentTypeDescConverter Singleton = new IncidentTypeDescConverter();
    }

    internal class IncidentTypeIdConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(IncidentTypeId) || t == typeof(IncidentTypeId?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "1A1":
                    return IncidentTypeId.The1A1;
                case "24A1":
                    return IncidentTypeId.The24A1;
                case "24C1":
                    return IncidentTypeId.The24C1;
                case "24C2":
                    return IncidentTypeId.The24C2;
                case "24D4":
                    return IncidentTypeId.The24D4;
                case "29A1":
                    return IncidentTypeId.The29A1;
            }
            throw new Exception("Cannot unmarshal type IncidentTypeId");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (IncidentTypeId)untypedValue;
            switch (value)
            {
                case IncidentTypeId.The1A1:
                    serializer.Serialize(writer, "1A1");
                    return;
                case IncidentTypeId.The24A1:
                    serializer.Serialize(writer, "24A1");
                    return;
                case IncidentTypeId.The24C1:
                    serializer.Serialize(writer, "24C1");
                    return;
                case IncidentTypeId.The24C2:
                    serializer.Serialize(writer, "24C2");
                    return;
                case IncidentTypeId.The24D4:
                    serializer.Serialize(writer, "24D4");
                    return;
                case IncidentTypeId.The29A1:
                    serializer.Serialize(writer, "29A1");
                    return;
            }
            throw new Exception("Cannot marshal type IncidentTypeId");
        }

        public static readonly IncidentTypeIdConverter Singleton = new IncidentTypeIdConverter();
    }
}
