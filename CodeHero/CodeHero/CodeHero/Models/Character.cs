using Newtonsoft.Json;

namespace CodeHero.Models
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class Character
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("thumbnail")]
        public ImageUrl ImageUrl { get; set; }
    }
}
