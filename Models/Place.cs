using System.Text.Json.Serialization;

namespace APITraining.Models
{
    public class Place
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public string Location { get; set; }
    }
}
