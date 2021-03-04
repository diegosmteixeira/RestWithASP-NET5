using System.Text.Json.Serialization;

namespace RestWithASPNET.Data.VO
{
    public class PersonVO
    {
        //when use POST and PUT = persistence will be with customization's name.

        [JsonPropertyName ("code")] //it's just a customization
        public long Id { get; set; }

        [JsonPropertyName("first_name")] //it's just a customization
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")] //it's just a customization
        public string LastName { get; set; }

        [JsonIgnore]
        public string Address { get; set; }

        [JsonPropertyName("sex")] //it's just a customization
        public string Gender { get; set; }
    }
}
