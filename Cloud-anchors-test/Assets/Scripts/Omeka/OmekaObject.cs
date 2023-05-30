namespace OmekaS {
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;

    public class CidocP108iWasProducedBy {
        [JsonProperty("@id")]
        public string id { get; set; }

        [JsonProperty("o:title")]
        public string otitle { get; set; }
        public string type { get; set; }
        public int property_id { get; set; }
        public string property_label { get; set; }
        public bool is_public { get; set; }
        public int value_resource_id { get; set; }
        public string value_resource_name { get; set; }
        public object url { get; set; }
        public string display_title { get; set; }
    }

    public class CidocP10FallsWithin {
        [JsonProperty("@id")]
        public string id { get; set; }

        [JsonProperty("o:title")]
        public string otitle { get; set; }
        public string type { get; set; }
        public int property_id { get; set; }
        public string property_label { get; set; }
        public bool is_public { get; set; }
        public int value_resource_id { get; set; }
        public string value_resource_name { get; set; }
        public object url { get; set; }
        public string display_title { get; set; }
    }

    public class CidocP10iContain {
        [JsonProperty("@id")]
        public string id { get; set; }

        [JsonProperty("o:title")]
        public string otitle { get; set; }
        public string type { get; set; }
        public int property_id { get; set; }
        public string property_label { get; set; }
        public bool is_public { get; set; }
        public int value_resource_id { get; set; }
        public string value_resource_name { get; set; }
        public object url { get; set; }
        public string display_title { get; set; }
    }

    public class CidocP126Employed {
        [JsonProperty("@id")]
        public string id { get; set; }

        [JsonProperty("o:title")]
        public string otitle { get; set; }
        public string type { get; set; }
        public int property_id { get; set; }
        public string property_label { get; set; }
        public bool is_public { get; set; }
        public int value_resource_id { get; set; }
        public string value_resource_name { get; set; }
        public object url { get; set; }
        public string display_title { get; set; }
    }

    public class CidocP14CarriedOutBy {
        [JsonProperty("@id")]
        public string id { get; set; }

        [JsonProperty("o:title")]
        public string otitle { get; set; }
        public string type { get; set; }
        public int property_id { get; set; }
        public string property_label { get; set; }
        public bool is_public { get; set; }
        public int value_resource_id { get; set; }
        public string value_resource_name { get; set; }
        public object url { get; set; }
        public string display_title { get; set; }
    }

    public class CidocP14iPerformed {
        [JsonProperty("@id")]
        public string id { get; set; }

        [JsonProperty("o:title")]
        public string otitle { get; set; }
        public string type { get; set; }
        public int property_id { get; set; }
        public string property_label { get; set; }
        public bool is_public { get; set; }
        public int value_resource_id { get; set; }
        public string value_resource_name { get; set; }
        public object url { get; set; }
        public string display_title { get; set; }
    }

    public class CidocP156iIsOccupiedBy {
        [JsonProperty("@id")]
        public string id { get; set; }

        [JsonProperty("o:title")]
        public string otitle { get; set; }
        public string type { get; set; }
        public int property_id { get; set; }
        public string property_label { get; set; }
        public bool is_public { get; set; }
        public int value_resource_id { get; set; }
        public string value_resource_name { get; set; }
        public object url { get; set; }
        public string display_title { get; set; }
    }

    public class CidocP156Occupy {
        [JsonProperty("@id")]
        public string id { get; set; }

        [JsonProperty("o:title")]
        public string otitle { get; set; }
        public string type { get; set; }
        public int property_id { get; set; }
        public string property_label { get; set; }
        public bool is_public { get; set; }
        public int value_resource_id { get; set; }
        public string value_resource_name { get; set; }
        public object url { get; set; }
        public string display_title { get; set; }
    }

    public class CidocP168PlaceIsDefinedBy {
        public string type { get; set; }
        public int property_id { get; set; }
        public string property_label { get; set; }
        public bool is_public { get; set; }

        [JsonProperty("@value")]
        public string value { get; set; }
    }

    public class CidocP184EndsBeforeOrWithTheEndOf {
        [JsonProperty("@id")]
        public string id { get; set; }

        [JsonProperty("o:title")]
        public string otitle { get; set; }
        public string type { get; set; }
        public int property_id { get; set; }
        public string property_label { get; set; }
        public bool is_public { get; set; }
        public int value_resource_id { get; set; }
        public string value_resource_name { get; set; }
        public object url { get; set; }
        public string display_title { get; set; }
    }

    public class CidocP184iEndsWithOrAfterTheEndOf {
        [JsonProperty("@id")]
        public string id { get; set; }

        [JsonProperty("o:title")]
        public string otitle { get; set; }
        public string type { get; set; }
        public int property_id { get; set; }
        public string property_label { get; set; }
        public bool is_public { get; set; }
        public int value_resource_id { get; set; }
        public string value_resource_name { get; set; }
        public object url { get; set; }
        public string display_title { get; set; }
    }

    public class CidocP54HasCurrentPermanentLocation {
        public string type { get; set; }
        public int property_id { get; set; }
        public string property_label { get; set; }
        public bool is_public { get; set; }

        [JsonProperty("@id")]
        public string id { get; set; }
        public int value_resource_id { get; set; }
        public string value_resource_name { get; set; }
        public object url { get; set; }
        public string display_title { get; set; }

        [JsonProperty("o:title")]
        public string otitle { get; set; }
    }

    public class CidocP62Depict {
        [JsonProperty("@id")]
        public string id { get; set; }

        [JsonProperty("o:title")]
        public string otitle { get; set; }
        public string type { get; set; }
        public int property_id { get; set; }
        public string property_label { get; set; }
        public bool is_public { get; set; }
        public int value_resource_id { get; set; }
        public string value_resource_name { get; set; }
        public object url { get; set; }
        public string display_title { get; set; }
    }

    public class CidocP62iIsDepictedBy {
        [JsonProperty("@id")]
        public string id { get; set; }

        [JsonProperty("o:title")]
        public string otitle { get; set; }
        public string type { get; set; }
        public int property_id { get; set; }
        public string property_label { get; set; }
        public bool is_public { get; set; }
        public int value_resource_id { get; set; }
        public string value_resource_name { get; set; }
        public object url { get; set; }
        public string display_title { get; set; }
        public string thumbnail_url { get; set; }
        public string thumbnail_title { get; set; }
        public string thumbnail_type { get; set; }
    }

    public class CidocP8iWitnessed {
        [JsonProperty("@id")]
        public string id { get; set; }

        [JsonProperty("o:title")]
        public string otitle { get; set; }
        public string type { get; set; }
        public int property_id { get; set; }
        public string property_label { get; set; }
        public bool is_public { get; set; }
        public int value_resource_id { get; set; }
        public string value_resource_name { get; set; }
        public object url { get; set; }
        public string display_title { get; set; }
    }

    public class CidocP8TookPlaceOnOrWithin {
        [JsonProperty("@id")]
        public string id { get; set; }

        [JsonProperty("o:title")]
        public string otitle { get; set; }
        public string type { get; set; }
        public int property_id { get; set; }
        public string property_label { get; set; }
        public bool is_public { get; set; }
        public int value_resource_id { get; set; }
        public string value_resource_name { get; set; }
        public object url { get; set; }
        public string display_title { get; set; }
    }

    public class CidocP92BroughtIntoExistence {
        [JsonProperty("@id")]
        public string id { get; set; }

        [JsonProperty("o:title")]
        public string otitle { get; set; }
        public string type { get; set; }
        public int property_id { get; set; }
        public string property_label { get; set; }
        public bool is_public { get; set; }
        public int value_resource_id { get; set; }
        public string value_resource_name { get; set; }
        public object url { get; set; }
        public string display_title { get; set; }
    }

    public class DctermsDescription {
        public string type { get; set; }
        public int property_id { get; set; }
        public string property_label { get; set; }
        public bool is_public { get; set; }

        [JsonProperty("@value")]
        public string value { get; set; }
    }

    public class DctermsTitle {
        public string type { get; set; }
        public int property_id { get; set; }
        public string property_label { get; set; }
        public bool is_public { get; set; }

        [JsonProperty("@value")]
        public string value { get; set; }
    }

    public class OCreated {
        [JsonProperty("@value")]
        public DateTime value { get; set; }

        [JsonProperty("@type")]
        public string type { get; set; }
    }

    public class OItemSet {
        [JsonProperty("@id")]
        public string id { get; set; }

        [JsonProperty("o:id")]
        public int oid { get; set; }
    }

    public class OMedium {
        [JsonProperty("@id")]
        public string id { get; set; }

        [JsonProperty("o:id")]
        public int oid { get; set; }
    }

    public class OModified {
        [JsonProperty("@value")]
        public DateTime value { get; set; }

        [JsonProperty("@type")]
        public string type { get; set; }
    }

    public class OOwner {
        [JsonProperty("@id")]
        public string id { get; set; }

        [JsonProperty("o:id")]
        public int oid { get; set; }
    }

    public class OPrimaryMedia {
        [JsonProperty("@id")]
        public string id { get; set; }

        [JsonProperty("o:id")]
        public int oid { get; set; }
    }

    public class OResourceClass {
        [JsonProperty("@id")]
        public string id { get; set; }

        [JsonProperty("o:id")]
        public int oid { get; set; }
    }

    public class Reverse {
        [JsonProperty("cidoc:P54_has_current_permanent_location")]
        public List<CidocP54HasCurrentPermanentLocation> cidocP54_has_current_permanent_location { get; set; }

        [JsonProperty("cidoc:P92_brought_into_existence")]
        public List<CidocP92BroughtIntoExistence> cidocP92_brought_into_existence { get; set; }

        [JsonProperty("cidoc:P8_took_place_on_or_within")]
        public List<CidocP8TookPlaceOnOrWithin> cidocP8_took_place_on_or_within { get; set; }

        [JsonProperty("cidoc:P156i_is_occupied_by")]
        public List<CidocP156iIsOccupiedBy> cidocP156i_is_occupied_by { get; set; }

        [JsonProperty("cidoc:P62_depicts")]
        public List<CidocP62Depict> cidocP62_depicts { get; set; }

        [JsonProperty("cidoc:P108i_was_produced_by")]
        public List<CidocP108iWasProducedBy> cidocP108i_was_produced_by { get; set; }

        [JsonProperty("cidoc:P14i_performed")]
        public List<CidocP14iPerformed> cidocP14i_performed { get; set; }

        [JsonProperty("cidoc:P184i_ends_with_or_after_the_end_of")]
        public List<CidocP184iEndsWithOrAfterTheEndOf> cidocP184i_ends_with_or_after_the_end_of { get; set; }

        [JsonProperty("cidoc:P184_ends_before_or_with_the_end_of")]
        public List<CidocP184EndsBeforeOrWithTheEndOf> cidocP184_ends_before_or_with_the_end_of { get; set; }

        [JsonProperty("cidoc:P14_carried_out_by")]
        public List<CidocP14CarriedOutBy> cidocP14_carried_out_by { get; set; }

        [JsonProperty("cidoc:P126_employed")]
        public List<CidocP126Employed> cidocP126_employed { get; set; }

        [JsonProperty("cidoc:P8i_witnessed")]
        public List<CidocP8iWitnessed> cidocP8i_witnessed { get; set; }

        [JsonProperty("cidoc:P10i_contains")]
        public List<CidocP10iContain> cidocP10i_contains { get; set; }

        [JsonProperty("cidoc:P156_occupies")]
        public List<CidocP156Occupy> cidocP156_occupies { get; set; }

        [JsonProperty("cidoc:P10_falls_within")]
        public List<CidocP10FallsWithin> cidocP10_falls_within { get; set; }

        [JsonProperty("cidoc:P62i_is_depicted_by")]
        public List<CidocP62iIsDepictedBy> cidocP62i_is_depicted_by { get; set; }
    }

    public class OmekaObject {
        [JsonProperty("o:alt_text")]
        public object oalt_text { get; set; }

        [JsonProperty("o:original_url")]
        public System.Uri ooriginal_url { get; set; }

        [JsonProperty("@context")]
        public string context { get; set; }

        [JsonProperty("@id")]
        public string id { get; set; }

        [JsonProperty("@type")]
        public List<string> type { get; set; }

        [JsonProperty("o:id")]
        public int oid { get; set; }

        [JsonProperty("o:is_public")]
        public bool ois_public { get; set; }

        [JsonProperty("o:owner")]
        public OOwner oowner { get; set; }

        [JsonProperty("o:resource_class")]
        public OResourceClass oresource_class { get; set; }

        [JsonProperty("o:resource_template")]
        public object oresource_template { get; set; }

        [JsonProperty("o:thumbnail")]
        public object othumbnail { get; set; }

        [JsonProperty("o:title")]
        public string otitle { get; set; }
        public ThumbnailDisplayUrls thumbnail_display_urls { get; set; }

        [JsonProperty("o:created")]
        public OCreated ocreated { get; set; }

        [JsonProperty("o:modified")]
        public OModified omodified { get; set; }

        [JsonProperty("o:primary_media")]
        public OPrimaryMedia oprimary_media { get; set; }

        [JsonProperty("o:media")]
        public List<OMedium> omedia { get; set; }

        [JsonProperty("o:item_set")]
        public List<OItemSet> oitem_set { get; set; }

        [JsonProperty("o:site")]
        public List<object> osite { get; set; }

        [JsonProperty("dcterms:title")]
        public List<DctermsTitle> dctermstitle { get; set; }

        [JsonProperty("cidoc:P54_has_current_permanent_location")]
        public List<CidocP54HasCurrentPermanentLocation> cidocP54_has_current_permanent_location { get; set; }

        [JsonProperty("cidoc:P168_place_is_defined_by")]
        public List<CidocP168PlaceIsDefinedBy> cidocP168_place_is_defined_by { get; set; }

        [JsonProperty("@reverse")]
        public Reverse reverse { get; set; }

        [JsonProperty("dcterms:description")]
        public List<DctermsDescription> dctermsdescription { get; set; }

        [JsonProperty("cidoc:P108i_was_produced_by")]
        public List<CidocP108iWasProducedBy> cidocP108i_was_produced_by { get; set; }

        [JsonProperty("cidoc:P156_occupies")]
        public List<CidocP156Occupy> cidocP156_occupies { get; set; }

        [JsonProperty("cidoc:P8i_witnessed")]
        public List<CidocP8iWitnessed> cidocP8i_witnessed { get; set; }

        [JsonProperty("cidoc:P62i_is_depicted_by")]
        public List<CidocP62iIsDepictedBy> cidocP62i_is_depicted_by { get; set; }

        [JsonProperty("cidoc:P14_carried_out_by")]
        public List<CidocP14CarriedOutBy> cidocP14_carried_out_by { get; set; }

        [JsonProperty("cidoc:P92_brought_into_existence")]
        public List<CidocP92BroughtIntoExistence> cidocP92_brought_into_existence { get; set; }

        [JsonProperty("cidoc:P184_ends_before_or_with_the_end_of")]
        public List<CidocP184EndsBeforeOrWithTheEndOf> cidocP184_ends_before_or_with_the_end_of { get; set; }

        [JsonProperty("cidoc:P184i_ends_with_or_after_the_end_of")]
        public List<CidocP184iEndsWithOrAfterTheEndOf> cidocP184i_ends_with_or_after_the_end_of { get; set; }

        [JsonProperty("cidoc:P14i_performed")]
        public List<CidocP14iPerformed> cidocP14i_performed { get; set; }

        [JsonProperty("cidoc:P126_employed")]
        public List<CidocP126Employed> cidocP126_employed { get; set; }

        [JsonProperty("cidoc:P8_took_place_on_or_within")]
        public List<CidocP8TookPlaceOnOrWithin> cidocP8_took_place_on_or_within { get; set; }

        [JsonProperty("cidoc:P10_falls_within")]
        public List<CidocP10FallsWithin> cidocP10_falls_within { get; set; }

        [JsonProperty("cidoc:P156i_is_occupied_by")]
        public List<CidocP156iIsOccupiedBy> cidocP156i_is_occupied_by { get; set; }

        [JsonProperty("cidoc:P10i_contains")]
        public List<CidocP10iContain> cidocP10i_contains { get; set; }

        [JsonProperty("cidoc:P62_depicts")]
        public List<CidocP62Depict> cidocP62_depicts { get; set; }
    }

    public class ThumbnailDisplayUrls {
        public string large { get; set; }
        public string medium { get; set; }
        public string square { get; set; }
    }

}